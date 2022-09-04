using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Data;

namespace AtualizadorServico.Classes
{
    /// <summary>
    /// Classe responsavel pelas configuracoes Iniciais
    /// </summary>
    class ConfiguracoesXML
    {
        /// <summary>
        /// arquivo de inicialzacao
        /// </summary>
        private static string _arquivoIniXML = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Servicos.xml");

        /// <summary>
        /// Nome do servico do windows
        /// </summary>
        public static string ServicoWindows { get; set; }

        /// <summary>
        /// Retorna xml de configuracoes
        /// </summary>
        /// <returns>Caso haja configuracao retorna o xml senão retorna nulo</returns>
        public static XmlDocument RetornaConfiguracoesXML()
        {
            if (File.Exists(_arquivoIniXML))
            {
                XmlDocument documento = new XmlDocument();
                documento.Load(_arquivoIniXML);
                return documento;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Retornar serviços
        /// </summary>
        /// <returns>Retorna nome do servico e chave principal de registro</returns>
        public static DataTable RetornarServicos()
        {
            DataTable tabela = CriarTabelaServico();

            XmlDocument documento = RetornaConfiguracoesXML();

            if (documento == null) { return tabela; }

            if (documento["Servicos"] != null)
            {
                foreach (XmlNode no in documento["Servicos"].ChildNodes)
                {
                    string registroWindows = string.Empty;

                    if (no.Attributes["registroWindows"] != null) { registroWindows = no.Attributes["registroWindows"].InnerText; }

                    tabela.Rows.Add(new string[] { no.Name, registroWindows });
                }
            }

            return tabela;
        }

        /// <summary>
        /// Cria a tabela contendo o nome do serico mais a chave de registro
        /// </summary>
        /// <returns>Retorna a tabela</returns>
        private static DataTable CriarTabelaServico()
        {
            DataTable tabela = new DataTable();
            tabela.Columns.Add("Servico");
            tabela.Columns.Add("ChaveRegistro");
            tabela.Rows.Add(new string[] { string.Empty, string.Empty });
            return tabela;
        }

        #region Chave

        /// <summary>
        /// Incluir Chave no XML de configuração
        /// </summary>
        /// <param name="chavePai">Chave pai</param>
        /// <param name="chave">Chave a ser incluida</param>
        public static void IncluirChave(string chavePai, string chave)
        {
            XmlDocument documento = RetornaConfiguracoesXML();
            if (documento == null) { return; }

            XmlElement noPai = RetornaChave(documento, chavePai);
            if (noPai == null) { return; }

            if (noPai[chave] == null)
            {
                noPai.AppendChild(documento.CreateElement(chave));
                SalvarDocumento(documento);
            }
        }

        /// <summary>
        /// Altera o nome da chave
        /// </summary>
        /// <param name="chavePai">Chave pai completa</param>
        /// <param name="chaveOrigem">Nome original da chave</param>
        /// <param name="chaveDestino">Nome destino da chave</param>
        public static void AlterarChave(string chavePai, string chaveOrigem, string chaveDestino)
        {
            XmlDocument documento = RetornaConfiguracoesXML();
            if (documento == null) { return; }

            XmlElement noPai = RetornaChave(documento, chavePai);
            if (noPai == null) { return; }

            XmlElement noOrigem = noPai[chaveOrigem];
            if (noOrigem == null) { return; }

            XmlElement noDestino = documento.CreateElement(chaveDestino);
            noDestino.InnerXml = noOrigem.InnerXml;

            foreach (XmlAttribute atributo in noOrigem.Attributes)
            {
                noDestino.Attributes.Append(atributo);
            }

            noPai.ReplaceChild(noDestino, noOrigem);
            SalvarDocumento(documento);
        }

        /// <summary>
        /// Exclui a chave do registro
        /// </summary>
        /// <param name="chave">Nome da chave do registro</param>
        public static void ExlcuirChave(string chave)
        {
            XmlDocument documento = RetornaConfiguracoesXML();
            if (documento == null) { return; }

            XmlElement no = RetornaChave(documento, chave);
            if (no == null) { return; }

            //Caso seja chave raiz.. então o documento remove o no
            if (no.ParentNode == null)
            {
                documento.RemoveChild(no);
            }
            else // Senão o nó pai pai remove o no
            {
                XmlNode noPai = no.ParentNode;
                noPai.RemoveChild(no);
            }

            SalvarDocumento(documento);
        }

        /// <summary>
        /// Retorna a chave
        /// </summary>
        /// <param name="documento">Documento para procurar a chave</param>
        /// <param name="chave">Chave pai completa</param>
        /// <returns>Retorna o xmlelement da chave</returns>
        private static XmlElement RetornaChave(XmlDocument documento, string chave)
        {
            //Obtem as chaves em ordem
            string[] chaves = chave.Split('\\');
            XmlElement no;

            //Obtem a chave principal (primeiro no)
            no = documento["Servicos"];
            if (no == null) { return null; }

            no = no[ServicoWindows];
            if (no == null) { return null; }

            no = no["RegistroWindows"];
            if (no == null) { return null; }

            if (string.IsNullOrEmpty(chaves[0]))
            {
                return no;
            }

            no = no[chaves[0]];

            //Caso não ache, então informa nulo
            if (no == null) { return null; }

            //Começa a varrer as demais chaves em ordem
            for (int index = 0; index < chaves.Length; index++)
            {
                //Se for a chave raiz ignora, pois a mesma foi tratada no começo do codigo
                if (index == 0) { continue; }

                //Caso a chave filha não exita, então retorna nulo
                if (no[chaves[index]] == null)
                {
                    return null;
                }
                else //Senão a chave corrente passa ser a chave filha
                {
                    no = no[chaves[index]];
                }
            }

            //Retorna a chave selecionada
            return no;
        }

        #endregion

        #region Valor

        /// <summary>
        /// Exclui o valor da chave de registro do windows
        /// </summary>
        /// <param name="chaveCompleta"></param>
        /// <param name="nomeValor"></param>
        public static void IncluirNomeValor(string chaveCompleta, string nomeValor)
        {
            IncluirChave(chaveCompleta, "valores");

            string chave = string.Join("\\", new string[] { chaveCompleta, "valores" });
            IncluirChave(chave, nomeValor);

            chave = string.Join("\\", new string[] { chave, nomeValor });
            IncluirChave(chave, "tipo");

            XmlDocument documento = RetornaConfiguracoesXML();
            if (documento == null) { return; }

            XmlElement no = RetornaChave(documento, string.Join("\\", new string[] { chave, "tipo" }));
            if (no != null && string.IsNullOrEmpty(no.InnerText)) { no.InnerText = "string"; }

            SalvarDocumento(documento);
        }

        /// <summary>
        /// Exclui o valor da chave de registro do windows
        /// </summary>
        /// <param name="chaveCompleta"></param>
        /// <param name="nomeValor"></param>
        public static void AlterarNomeValor(string chaveCompleta, string nomeValorOrigem, string nomeValorDestino)
        {
            string chave = string.Join("\\", new string[] { chaveCompleta, "valores" });
            AlterarChave(chave, nomeValorOrigem, nomeValorDestino);
        }

        /// <summary>
        /// Exclui o valor da chave de registro do windows
        /// </summary>
        /// <param name="chaveCompleta"></param>
        /// <param name="nomeValor"></param>
        public static void ExcluirNomeValor(string chaveCompleta, string nomeValor)
        {
            string chave = string.Join("\\", new string[] { chaveCompleta, "valores", nomeValor });
            ExlcuirChave(chave);
        }

        /// <summary>
        /// Valida as informacoes da chave
        /// </summary>
        /// <param name="chaveCompleta">Nome completo da chave</param>
        /// <param name="nome">Nome da cadeia de Caracteres</param>
        /// <param name="valor">Valor da cadeia de caracteres</param>
        /// <returns>Retorna se foi validado</returns>
        public static bool ValidarDadosValor(string chaveCompleta, string nome, string valor, out string mensagem)
        {
            mensagem = string.Empty;

            XmlDocument documento = RetornaConfiguracoesXML();
            if (documento == null) { return true; }

            XmlElement noPai = RetornaChave(documento, chaveCompleta);
            if (noPai == null) { return true; }

            XmlElement noValores = noPai["valores"];
            if (noValores == null) { return true; }

            XmlElement noNome = noValores[nome];
            if (noNome == null) { return true; }

            //Caso não haja conteudo então não valida
            if (string.IsNullOrEmpty(valor)) { return true; }

            if (noNome["tipo"] != null)
            {
                //Valida os tipos basicos: string, int, bool, decimal, etc...
                if (!ValidarTipo(noNome["tipo"].InnerText, valor, out mensagem)) { return false; };
            }

            if (noNome["especifico"] != null)
            {
                //Valida os tipos especificos: diretorio, enum, regex, etc...
                if (!ValidarEspecifico(noNome, noNome["especifico"].InnerText, valor, out mensagem)) { return false; };
            }

            return true;
        }

        /// <summary>
        /// Valida o tipo de dados
        /// </summary>
        /// <param name="tipo">Tipo de dados</param>
        /// <param name="conteudo">Conteudo da cadeia de caracteres</param>
        /// <returns>Retorna se foi validado</returns>
        private static bool ValidarTipo(string tipo, string conteudo, out string mensagem)
        {
            mensagem = string.Empty;

            if (tipo.ToLower() == "int")
            {
                int result;
                if (!int.TryParse(conteudo, out result))
                {
                    mensagem = "O campo deve ser um numérico inteiro";
                    return false;
                }
                return true;
            }

            if (tipo.ToLower() == "bool")
            {
                bool result;
                if (!bool.TryParse(conteudo, out result))
                {
                    mensagem = "O campo deve ser \"true\" ou \"false\"";
                    return false;
                }

                return true;
            }

            if (tipo.ToLower() == "decimal")
            {
                decimal result;
                if (!decimal.TryParse(conteudo, out result))
                {
                    mensagem = "O campo deve ser um numérico em decimais";
                    return false;
                }
                return true;
            }

            if (tipo.ToLower() == "datetime")
            {
                try
                {
                    //Retira a hora
                    string data = conteudo.Split(' ')[0];

                    //Coloca em data
                    DateTime result = new DateTime(Convert.ToInt32(data.Split('/')[2]),
                                                   Convert.ToInt32(data.Split('/')[1]),
                                                   Convert.ToInt32(data.Split('/')[0]));

                    if (conteudo.Split(' ').Length > 1)
                    {
                        if (conteudo.Split(' ').Length > 2) 
                        {
                            mensagem = "O campo dever ser uma data no formato dd/MM/yyyy ou dd/MM/yyyy HH:mm";
                            return false; 
                        }

                        string hora = conteudo.Split(' ')[1];

                        if (Convert.ToInt32(hora.Split(':')[0]) > 23 )
                        {
                            mensagem = "O campo dever ser uma data no formato dd/MM/yyyy ou dd/MM/yyyy HH:mm";
                            return false; 
                        }

                        if (Convert.ToInt32(hora.Split(':')[1]) > 59)
                        {
                            mensagem = "O campo dever ser uma data no formato dd/MM/yyyy ou dd/MM/yyyy HH:mm";
                            return false;
                        }

                        if (hora.Split(':').Length > 2 )
                        {
                            mensagem = "O campo dever ser uma data no formato dd/MM/yyyy ou dd/MM/yyyy HH:mm";
                            return false;
                        }

                    }
                    return true;

                }
                catch (Exception)
                {
                    mensagem = "O campo dever ser uma data no formato dd/MM/yyyy ou dd/MM/yyyy HH:mm";
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Validacao especifica
        /// </summary>
        /// <param name="no">No da validacao</param>
        /// <param name="especifico">Tipo de dados</param>
        /// <param name="conteudo">Conteudo da cadeia de caracteres</param>
        /// <returns>Retorna se foi validado</returns>
        private static bool ValidarEspecifico(XmlElement no, string especifico, string conteudo, out string mensagem)
        {
            mensagem = string.Empty;

            //Realiza a validacao do diretorio
            if (especifico.ToLower() == "diretorio")
            {
                try
                {
                    //Caso não consiga extrair o diretorio raiz (C:, \\ln010cpdNN, etc..)
                    if (Path.GetPathRoot(conteudo).Length <= 0)
                    {
                        mensagem = "O campo deve ser um diretorio válido";
                        return false;
                    }

                    return true;
                }
                catch (Exception)
                {
                    mensagem = "O campo deve ser um diretorio válido";
                    return false;
                }
            }

            //Verifica se existe um parametro de conteudo a ser validado
            if (no["validacao"] != null)
            {
                //Caso seja do tipo enum separado por pipe ex: SP|RJ|MG
                if (especifico.ToLower() == "enum")
                {
                    if (!no["validacao"].InnerText.Split('|').Contains(conteudo))
                    {
                        //Verifica se existe uma mensagem no xml para enviar ao usuario
                        if (no["mensagem"] != null && !string.IsNullOrEmpty(no["mensagem"].InnerText))
                        {
                            mensagem = no["mensagem"].InnerText;
                        }
                        else //Senão envia uma mensagem padrao
                        {
                            mensagem = string.Format("O campo deve ser um dos conteudos a seguir: {0}",
                                                     no["validacao"].InnerText.Replace("|", ", "));
                        }
                        return false;
                    }
                }

                //Verifica se é uma expressao regular
                if (especifico.ToLower() == "regex")
                {
                    //Valida a expressao regular
                    if (!Utilidades.ValidarExpressaoRegular(conteudo, no["validacao"].InnerText))
                    {
                        //Verifica se existe uma mensagem no xml para enviar ao usuario
                        if (no["mensagem"] != null && !string.IsNullOrEmpty(no["mensagem"].InnerText))
                        {
                            mensagem = no["mensagem"].InnerText;
                        }
                        else //Senão envia uma mensagem padrao
                        {
                            mensagem = "O campo informado não é um campo válido";
                        }

                        return false;
                    }
                    return true;
                }
            }

            return true;
        }

        /// <summary>
        /// Verifica se é um campo criptogragfado
        /// </summary>
        /// <param name="chaveCompleta">Chave de registro completa</param>
        /// <param name="nomeValor">Nome do valor da chave</param>
        /// <returns>Retorna se é criptografado</returns>
        public static bool VerificarNomeValorCriptografado(string chaveCompleta, string nomeValor)
        {
            XmlDocument documento = RetornaConfiguracoesXML();
            if (documento == null) { return false; }

            XmlElement noPai = RetornaChave(documento, chaveCompleta);
            if (noPai == null) { return false; }

            XmlElement noValores = noPai["valores"];
            if (noValores == null) { return false; }

            XmlElement noNome = noValores[nomeValor];
            if (noNome == null) { return false; }

            if (noNome["criptografia"] != null)
            {
                bool result = false;
                bool.TryParse(noNome["criptografia"].InnerText, out result);
                return result;
            }

            return false;
        }

        #endregion

        /// <summary>
        /// Salva o arquivo xml
        /// </summary>
        /// <param name="documento">Documeto a ser salvo</param>
        private static void SalvarDocumento(XmlDocument documento)
        {
            documento.Save(_arquivoIniXML);
        }

    }
}