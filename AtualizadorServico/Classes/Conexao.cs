using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace AtualizadorServico.Classes
{
    //Classe responsavel pela conexao com o banco de dados
    class Conexao
    {

        /// <summary>
        /// String de conexão do banco de produção
        /// </summary>
        public static string StringConexao
        {
            get
            {
                 return string.Format("Server={0}; DATABASE={1}; User Id={2}; Password={3};", new string[] { ParametrosSistema.ServidorSQL, 
                                                                                                             ParametrosSistema.BancoSQL, 
                                                                                                             ParametrosSistema.UsuarioSQL, 
                                                                                                             ParametrosSistema.SenhaSQL, }); 
            }
        }

        /// <summary>
        /// Valida a conexão com o banco producao
        /// </summary>
        /// <param name="mensagem"></param>
        /// <returns>Retorna conexão realizada</returns>
        public static bool ValidarConexaoBanco(out string mensagem)
        {
            return ValidarConexaoBanco(out mensagem, StringConexao);
        }

        /// <summary>
        /// Valida a conexão com o banco
        /// </summary>
        /// <param name="mensagem">mensagem de erro</param>
        /// <param name="stringConexao">string conexão</param>
        /// <returns>Retorna conexão realizada</returns>
        private static bool ValidarConexaoBanco(out string mensagem, string stringConexao)
        {
            mensagem = string.Empty;

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                try
                {
                    con.Open();
                    con.Close();
                }
                catch (Exception ex)
                {
                    mensagem = ex.Message;
                    return false;
                }
            }
            return true;
        }
    }
}
