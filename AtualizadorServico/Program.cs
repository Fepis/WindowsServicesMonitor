using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AtualizadorServico.Classes;

namespace AtualizadorServico
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string mensagem;

            //Realiza as validacoes do sistema
            if (ParametrosSistema.ValidarParametrosSistema(out mensagem))
            {
                //Chama o form de loginfs
                using (Forms.FrmLogin form = new Forms.FrmLogin())
                {
                    form.ShowDialog();

                    //Caso o usuário seja validado então inicia o sistema
                    if (form.UsuarioValidado)
                    {
                        Application.Run(new Forms.FrmPrincipal());
                        return;
                    }
                }
            }
            else
            {
                Utilidades.EnviarMensagem(mensagem, Utilidades.TipoMensagem.Erro);
            }

            Application.Exit();

        }
    }
}
