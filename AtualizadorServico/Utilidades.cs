using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
using System.IO.Compression;
using System.Text.RegularExpressions;
using ICSharpCode.SharpZipLib.Core;

namespace AtualizadorServico
{
    class Utilidades
    {
        /// <summary>
        /// Envia uma caixa de mensagem para o usuário
        /// </summary>
        /// <param name="mensagem">Mensagem que será visualizado pelo usuário </param>
        /// <param name="tipo">Tipo de mensagem que o usuário irá receber no tela</param>
        /// <returns>Retorna o botão pressionado pelo usuário</returns>
        public static DialogResult EnviarMensagem(string mensagem, TipoMensagem tipo)
        {
            MessageBoxButtons botao;
            MessageBoxIcon icone;

            switch (tipo)
            {
                case TipoMensagem.Informacao:
                    botao = MessageBoxButtons.OK;
                    icone = MessageBoxIcon.Information;
                    break;
                case TipoMensagem.Advertencia:
                    botao = MessageBoxButtons.OK;
                    icone = MessageBoxIcon.Exclamation;
                    break;
                case TipoMensagem.Pergunta:
                    botao = MessageBoxButtons.YesNo;
                    icone = MessageBoxIcon.Question;
                    break;
                case TipoMensagem.Erro:
                    botao = MessageBoxButtons.OK;
                    icone = MessageBoxIcon.Error;
                    break;
                default:
                    botao = MessageBoxButtons.OK;
                    icone = MessageBoxIcon.Information;
                    break;
            }

            return MessageBox.Show(mensagem, string.Format("Atualizador de Serviços v{0}", RetornarVersao()), botao, icone);
        }

        /// <summary>
        /// Retorna Versao
        /// </summary>
        /// <returns>Retrona o numero da versão</returns>
        public static string RetornarVersao()
        {
            System.Reflection.Assembly CurrentAssembly = Assembly.GetExecutingAssembly();
            System.Diagnostics.FileVersionInfo fileVersionInfo = System.Diagnostics.FileVersionInfo.GetVersionInfo(CurrentAssembly.Location);
            return fileVersionInfo.FileVersion.ToString();
        }

        /// <summary>
        /// Verifica se é um diretorio valido tentando cria-lo
        /// </summary>
        /// <param name="diretorio">diretorio</param>
        /// <returns>Retorna a validade do diretorio</returns>
        public static bool ValidarDiretorio(string diretorio)
        {
            try
            {
                if (diretorio == null) { return false; }
                if (Directory.Exists(diretorio)) { return true; }
                Directory.CreateDirectory(diretorio);
                Directory.Delete(diretorio);
            }
            catch (Exception) { return false; }
            return true;
        }

        /// <summary>
        /// Descompactar
        /// </summary>
        /// <param name="fi">Arquivo</param>
        /// <returns>Lista de arquivos Descompactoados</returns>
        public static List<string> Descompactar(FileInfo fi)
        {
            List<string> arquivosDescompactados = new List<string>();

            ZipInputStream zipIStream = new ZipInputStream(File.OpenRead(fi.FullName));

            //string pastaDeDestino = fi.DirectoryName + "\\" + fi.Name.Substring(0, fi.Name.Length - 4);
            string pastaDeDestino = fi.DirectoryName;

            try
            {
                ZipEntry entrada = zipIStream.GetNextEntry();

                while ((entrada != null))
                {
                    string destinoDaEntrada = Path.Combine(pastaDeDestino, entrada.Name);

                    arquivosDescompactados.Add(destinoDaEntrada);

                    if (entrada.IsDirectory)
                    { Directory.CreateDirectory(destinoDaEntrada); }
                    else
                    {
                        int tamanhoDoBuffer = 2048;
                        byte[] buffer = new byte[tamanhoDoBuffer + 1];

                        string pastaPai = Path.GetDirectoryName(destinoDaEntrada);
                        if ((!Directory.Exists(pastaPai)))
                            Directory.CreateDirectory(pastaPai);

                        FileStream fs = new FileStream(destinoDaEntrada, FileMode.Create);

                        try
                        {
                            do
                            {
                                tamanhoDoBuffer = zipIStream.Read(buffer, 0, buffer.Length);

                                if (tamanhoDoBuffer > 0)
                                { fs.Write(buffer, 0, tamanhoDoBuffer); }
                                else
                                { break; } //TODO: might not be correct. Was : Exit Do        }

                            } while (true);
                        }
                        finally
                        {
                            if ((fs != null))
                            {
                                fs.Flush();
                                fs.Close();
                            }
                        }

                    }
                    entrada = zipIStream.GetNextEntry();
                }
            }
            finally
            {
                if ((zipIStream != null))
                    zipIStream.Close();
            }

            return arquivosDescompactados;
        }

        /// <summary>
        /// Descompactar
        /// </summary>
        /// <param name="fi">Arquivo</param>
        /// <returns>Lista de arquivos Descompactoados</returns>
        public static List<string> RetornaArquivoDentroZip(FileInfo fi)
        {
            List<string> arquivosDescompactados = new List<string>();

            ZipInputStream zipIStream = new ZipInputStream(File.OpenRead(fi.FullName));

            //string pastaDeDestino = fi.DirectoryName + "\\" + fi.Name.Substring(0, fi.Name.Length - 4);
            string pastaDeDestino = fi.DirectoryName;

            try
            {
                ZipEntry entrada = zipIStream.GetNextEntry();

                while ((entrada != null))
                {
                    string destinoDaEntrada = Path.Combine(pastaDeDestino, entrada.Name);
                    arquivosDescompactados.Add(destinoDaEntrada);
                    entrada = zipIStream.GetNextEntry();
                }
            }
            finally
            {
                if ((zipIStream != null))
                    zipIStream.Close();
            }

            return arquivosDescompactados;
        }

        /// <summary>
        /// Valida o email informado
        /// </summary>
        /// <param name="email">Validar Email</param>
        /// <returns></returns>
        public static bool ValidarEmail(string email)
        {
            return ValidarExpressaoRegular(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z");
        }

        /// <summary>
        /// Validar Expressao Regular
        /// </summary>
        /// <param name="valor">Conteudo a validar</param>
        /// <param name="expressao">Expressao</param>
        /// <returns>Retorna se foi validado ou não</returns>
        public static bool ValidarExpressaoRegular(string valor, string expressao)
        {
            bool result = false;

            Regex regex = new Regex(expressao, RegexOptions.IgnoreCase);

            if (regex.IsMatch(valor))
            {
                result = true;
            }

            return result;
        }

        #region Enums

        /// <summary>
        /// Enum contendo o tipo de mensagem para apresentar para o usuário
        /// </summary>
        public enum TipoMensagem
        {
            Informacao = 1,
            Advertencia = 2,
            Pergunta = 3,
            Erro = 4
        }

        #endregion
    }
}
