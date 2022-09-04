using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;

namespace AtualizadorServico.Classes
{
    /// <summary>
    /// Classe responsavel pelos parametro do sistema
    /// </summary>
    class ParametrosSistema
    {
        /// <summary>
        /// arquivo de inicialzacao
        /// </summary>
        private static string _arquivoIniXML = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "dbxConnection.xml");

        /// <summary>
        /// Servidor do AD
        /// </summary>
        public static string ServidorAD { get; set; }

        /// <summary>
        /// Servidor do banco de dados
        /// </summary>
        public static string ServidorSQL { get; set; }

        /// <summary>
        /// Servidor do banco de dados
        /// </summary>
        public static string BancoSQL { get; set; }

        /// <summary>
        /// Usuario do banco de dados
        /// </summary>
        public static string UsuarioSQL { get; set; }

        /// <summary>
        /// Senha do banco de dados
        /// </summary>
        public static string SenhaSQL { get; set; }


        /// <summary>
        /// Valida os parametros de configuracao do sistema
        /// </summary>
        /// <returns></returns>
        public static bool ValidarParametrosSistema(out string mensagem)
        {
            mensagem = string.Empty;

            //Validar existencia dbxconection
            if (!ValidarDbxConnection(out mensagem)) { return false; }

            //Validar conexao com o servidor ad
            if (!ValidarConexaoAD(out mensagem)) { return false; }

            //validar conexao com o banco de dados
            if (!ValidarConexaoBancoDados(out mensagem)) { return false; }

            return true;
        }

        /// <summary>
        /// Valida o dbx conection
        /// </summary>
        /// <param name="mensagem">Mensagem de Erro</param>
        /// <returns>Retorna validacao</returns>
        private static bool ValidarDbxConnection(out string mensagem)
        {
            mensagem = string.Empty;
            try
            {
                if (!File.Exists(_arquivoIniXML))
                {
                    mensagem = "dbxConnection.xml não localizado";
                    return false;
                }

                XmlDocument documento = new XmlDocument();
                documento.Load(_arquivoIniXML);

                XmlElement no = documento["AtualizadorServico"];

                if (no == null)
                {
                    mensagem = "Arrquivo de configuração fora do padrão esperado.";
                    return false;
                }

                ServidorAD = no["ServidorAD"].InnerText;
                ServidorSQL = no["ServidorSQL"].InnerText;
                BancoSQL = no["BancoSQL"].InnerText;
                UsuarioSQL = no["UsuarioSQL"].InnerText;
                SenhaSQL = Criptografia.Descriptografar(no["SenhaSQL"].InnerText, "AtualizadorServico");
            }

            catch (Exception ex)
            {
                mensagem = ex.Message;
                return false;
            }

            return true;
        }

        /// <summary>
        /// Valida a conexão com o AD
        /// </summary>
        /// <param name="mensagem">Mensagem de Erro</param>
        /// <returns>Retorna validacao</returns>
        private static bool ValidarConexaoAD(out string mensagem)
        {
            mensagem = string.Empty;

            try
            {
                return RedeSistema.VerificarConexaoServidor(ServidorAD, out mensagem);
            }
            catch (Exception ex)
            {
                mensagem = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Valida a conexão com o BD
        /// </summary>
        /// <param name="mensagem">Mensagem de Erro</param>
        /// <returns>Retorna validacao</returns>
        private static bool ValidarConexaoBancoDados(out string mensagem)
        {
            mensagem = string.Empty;

            try
            {
                return Conexao.ValidarConexaoBanco(out mensagem);
            }
            catch (Exception ex)
            {
                mensagem = ex.Message;
                return false;
            }
        }
    }
}
