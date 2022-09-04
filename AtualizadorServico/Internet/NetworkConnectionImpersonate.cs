using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace AtualizadorServico.Internet
{
    public enum LogOnType
    {
        LogOn32LogOnInteractive = 2,
        LogOn32LogOnNetwork = 3,
        LogOn32LogOnBatch = 4,
        LogOn32LogOnService = 5,
        LogOn32LogOnUnlock = 7,
        LogOn32LogOnNetworkCleartext = 8,
        LogOn32LogOnNewCredentials = 9
    }

    public enum LogOnProvider
    {
        LogOn32ProviderDefault = 0,
        LogOn32ProviderWinnt35 = 1,
        LogOn32ProviderWinnt40 = 2,
        LogOn32ProviderWinnt50 = 3
    }

    public enum ImpersonationLevel
    {
        SecurityAnonymous = 0,
        SecurityIdentification = 1,
        SecurityImpersonation = 2,
        SecurityDelegation = 3
    }

    public class NetworkConnectionImpersonate
    {
        private static WindowsImpersonationContext _impersonationContext;
        private static readonly object _locker = new object();

        private static class NativeMethods
        {
            [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
            public static extern int LogonUser(String lpszUserName,
                                               String lpszDomain,
                                               String lpszPassword,
                                               int dwLogonType,
                                               int dwLogonProvider,
                                               ref IntPtr phToken);

            [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Auto)]
            public static extern int DuplicateToken(IntPtr hToken,
                                                    int impersonationLevel,
                                                    ref IntPtr hNewToken);

            [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Auto)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool RevertToSelf();

            [DllImport("kernel32.dll", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool CloseHandle(IntPtr handle);
        }

        public static void Impersonate(Action action, string user, string domain, string password,
                                       LogOnType logOnType, LogOnProvider logOnProvider,
                                       ImpersonationLevel impersonationLevel)
        {
            try
            {
                ImpersonateValidUser(user, domain, password, logOnType, logOnProvider, impersonationLevel);
                action();
            }
            finally
            {
                UndoImpersonation();
            }
        }

        public static void ImpersonateHappily(Action action, string user, string domain, string password)
        {
            Impersonate(action, user, domain, password, LogOnType.LogOn32LogOnNetworkCleartext,
                        LogOnProvider.LogOn32ProviderDefault, ImpersonationLevel.SecurityImpersonation);
        }

        public static TResult Impersonate<TResult>(Func<TResult> action, string user, string domain, string password,
                                                   LogOnType logOnType, LogOnProvider logOnProvider,
                                                   ImpersonationLevel impersonationLevel)
        {
            try
            {
                ImpersonateValidUser(user, domain, password, logOnType, logOnProvider, impersonationLevel);
                return action();
            }
            finally
            {
                UndoImpersonation();
            }
        }

        public static TResult ImpersonateHappily<TResult>(Func<TResult> action, string user, string domain, string password)
        {
            return Impersonate(action, user, domain, password, LogOnType.LogOn32LogOnNetworkCleartext,
                               LogOnProvider.LogOn32ProviderDefault, ImpersonationLevel.SecurityImpersonation);
        }

        private static void ImpersonateValidUser(String userName, String domain, String password, LogOnType logonType, LogOnProvider logonProvider, ImpersonationLevel impersonationLevel)
        {
            lock (_locker)
            {
                var token = IntPtr.Zero;
                var tokenDuplicate = IntPtr.Zero;
                WindowsIdentity tempWindowsIdentity = null;

                try
                {
                    if (!NativeMethods.RevertToSelf())
                        throw new Win32Exception(Marshal.GetLastWin32Error());
                    if (NativeMethods.LogonUser(userName, domain, password, (int)logonType, (int)logonProvider, ref token) == 0)
                        throw new Win32Exception(Marshal.GetLastWin32Error());
                    if (NativeMethods.DuplicateToken(token, (int)impersonationLevel, ref tokenDuplicate) == 0)
                        throw new Win32Exception(Marshal.GetLastWin32Error());

                    tempWindowsIdentity = new WindowsIdentity(tokenDuplicate);
                    _impersonationContext = tempWindowsIdentity.Impersonate();
                }
                finally
                {
                    if (token != IntPtr.Zero)
                        NativeMethods.CloseHandle(token);
                    if (tokenDuplicate != IntPtr.Zero)
                        NativeMethods.CloseHandle(tokenDuplicate);
                    if (tempWindowsIdentity != null)
                        tempWindowsIdentity.Dispose();
                }
            }
        }

        private static void UndoImpersonation()
        {
            lock (_locker)
            {
                if (_impersonationContext != null)
                {
                    _impersonationContext.Undo();
                }
            }
        }
    }
}
