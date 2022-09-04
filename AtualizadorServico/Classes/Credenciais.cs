using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtualizadorServico.Classes
{
    class Credenciais
    {
        /// <summary>
        /// Usuario do Sistema
        /// </summary> 
        public static string Usuario { get; private set; }

        /// <summary>
        /// Senha senha do sistema
        /// </summary>
        public static string Senha { get; private set; }

        /// <summary>
        /// Valida usuario e senha do sistema
        /// </summary>
        /// <param name="usuario">Usuario</param>
        /// <param name="senha">Senha</param>
        /// <param name="mensagem">Mensagem de erro caso haja</param>
        /// <returns>Retorna a validacao do logins</returns>
        public static bool ValidarUsuarioSenha(string usuario, string senha, out string mensagem)
        {
            try
            {
                if (string.IsNullOrEmpty(usuario) || usuario.Trim().Equals(string.Empty)) { mensagem = "Usuário inválido."; return false; }
                if (string.IsNullOrEmpty(senha) || senha.Trim().Equals(string.Empty)) { mensagem = "Senha inválida."; return false; }

                if (RedeSistema.VerificarConexaoServidor(ParametrosSistema.ServidorAD, out mensagem))
                {
                    //Obtem o usuario do AD
                    using (System.DirectoryServices.DirectoryEntry usuarioAD = new System.DirectoryServices.DirectoryEntry("LDAP://" + ParametrosSistema.ServidorAD, usuario, senha))
                    {
                        Guid guid = usuarioAD.Guid;
                        usuarioAD.Close();

                        Usuario = usuario;
                        Senha = senha;

                        return true;
                    }
                }
                else
                {
                    mensagem = string.Format("Não foi possível conectar ao servidor, erro: {0}", mensagem);
                    return false;
                }
            }
            catch (System.DirectoryServices.DirectoryServicesCOMException)
            {
                mensagem = "Usuario o senha inválido.";
                return false;
            }
            catch (Exception ex)
            {
                mensagem = ex.Message;
                return false;
            }
        }
    }
}
