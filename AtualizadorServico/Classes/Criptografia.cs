using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace AtualizadorServico.Classes
{
    /// <summary>
    /// Classe responsavel de criptografia
    /// </summary>
    public class Criptografia
    {
        /// <summary>
        /// Criptografar conteudo
        /// </summary>
        /// <param name="senha">Senha para ser criptografar</param>
        /// <param name="chave">Chave publica da criptografia</param>
        /// <returns>Retora o conteudo criptografado</returns>
        public static String Criptografar(string senha, String chave)
        {
            TripleDESCryptoServiceProvider tdspCripty = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider md5csp = new MD5CryptoServiceProvider();

            try
            {
                if (senha.Trim() != "")
                {
                    string sMKey = chave;
                    tdspCripty.Key = md5csp.ComputeHash(ASCIIEncoding.ASCII.GetBytes(sMKey));
                    tdspCripty.Mode = CipherMode.ECB;

                    ICryptoTransform desdencrypt = tdspCripty.CreateEncryptor();
                    ASCIIEncoding myASCIIEnc = new ASCIIEncoding();

                    byte[] buff = Encoding.ASCII.GetBytes(senha);

                    return Convert.ToBase64String(desdencrypt.TransformFinalBlock(buff, 0, buff.Length));
                }
                else
                {
                    return String.Empty;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                tdspCripty = null;
                md5csp = null;
            }
        }

        /// <summary>
        /// Descriptografar conteudo
        /// </summary>
        /// <param name="senha">Senha para ser criptografar</param>
        /// <param name="chave">Chave publica da criptografia</param>
        /// <returns>Retora o conteudo descriptografado</returns>
        public static String Descriptografar(string senha, string chave)
        {
            TripleDESCryptoServiceProvider tdspCripty = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider md5csp = new MD5CryptoServiceProvider();

            try
            {
                if (senha.Trim() != "")
                {
                    String sMKey = chave;
                    tdspCripty.Key = md5csp.ComputeHash(ASCIIEncoding.ASCII.GetBytes(sMKey));
                    tdspCripty.Mode = CipherMode.ECB;

                    ICryptoTransform desdencrypt = tdspCripty.CreateDecryptor();
                    byte[] buff = Convert.FromBase64String(senha);

                    return ASCIIEncoding.ASCII.GetString(desdencrypt.TransformFinalBlock(buff, 0, buff.Length));
                }
                else
                {
                    return String.Empty;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                tdspCripty = null;
                md5csp = null;
            }
        }
    }
}

