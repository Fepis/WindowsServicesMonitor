using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics;
using System.Xml;

namespace AtualizadorServico.Classes
{
    /// <summary>
    /// Classe responsavel por manipular o registro do windows
    /// </summary>
    class RegistroWindows
    {
        /// <summary>
        /// Suspende a alteração no xml
        /// </summary>
        private static bool _suspenderAltercaoXML = false;

        /// <summary> 
        /// Nome da maquina remota
        /// </summary>
        public static string MaquinaRemota { get; set; }

        /// <summary>
        /// Cria a instancia da chave de registro
        /// </summary>
        /// <param name="chave">Nome da chave sem SOFTWARE</param>
        /// <returns>Retorna a chave de reigstro</returns>
        private static RegistryKey RetornaChave(string chave, bool edicao)
        {
            string chaveCompleta = string.Join("\\", new string[] { "SOFTWARE", chave });

            if (string.IsNullOrEmpty(MaquinaRemota))
            {
                return Registry.LocalMachine.OpenSubKey(chaveCompleta, edicao);
            }
            else
            {
                return RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, MaquinaRemota, RegistryView.Registry64);
            }
        }

        /// <summary>
        /// Cria uma estrutura em arvore da chave do registro do windows
        /// </summary>
        /// <param name="chave">Chave do registro do windows</param>
        /// <param name="no">No do controle da treeview</param>
        /// <param name="imagemIndex">Index da imagem</param>
        /// <returns>Se a arvore foi criada ou não</returns>
        public static bool CriaArvoreRegistroWindows(string chave, ref TreeNode no, int imagemIndex)
        {
            no.Text = chave;
            no.ImageIndex = imagemIndex;

            RegistryKey registroWindows = RetornaChave(no.FullPath, false);

            if (registroWindows == null) { return false; }

            foreach (string chaveRegistroWindowsFilho in registroWindows.GetSubKeyNames())
            {
                TreeNode noFilho = new TreeNode(chaveRegistroWindowsFilho);
                no.Nodes.Add(noFilho);
                CriaArvoreRegistroWindows(chaveRegistroWindowsFilho, ref noFilho, imagemIndex);
            }

            return true;
        }

        /// <summary>
        /// Nome da chave completa
        /// </summary>
        /// <param name="chaveCompleta">Chave sem o SOFTWARE</param>
        /// <returns>Retorna a tabela contendo os valores</returns>
        public static DataTable RetornaCadeiaCaracteresChave(string chaveCompleta)
        {
            DataTable tabela = new DataTable();
            tabela.Columns.Add("Nome", typeof(string));
            tabela.Columns.Add("Dados", typeof(string));

            RegistryKey registroWindows = RetornaChave(chaveCompleta, false);

            if (registroWindows == null) { return tabela; }

            foreach (string chaveRegistroWindowsFilho in registroWindows.GetValueNames())
            {
                tabela.Rows.Add(new string[] { chaveRegistroWindowsFilho, registroWindows.GetValue(chaveRegistroWindowsFilho, String.Empty, RegistryValueOptions.None).ToString() });
            }
            return tabela;
        }

        /// <summary>
        /// Retorna conteudo do valor da chave
        /// </summary>
        /// <param name="chaveCompleta">Nome completo da chave sem o SOFTWARE</param>
        /// <param name="nomeValor">nome do valor</param>
        /// <returns>Retorna o conteudo do valor da chave</returns>
        public static string RetornaConteudoValor(string chaveCompleta, string nomeValor)
        {
            RegistryKey registroWindows = RetornaChave(chaveCompleta, false);
            return registroWindows.GetValue(nomeValor).ToString();
        }

        /// <summary>
        /// Incluir  Cadeia de Caracteres
        /// </summary>
        /// <param name="chaveCompleta">Chave sem o SOFTWARE</param>
        /// <param name="nomeValor">Nome do Valor a ser incluido</param>
        /// <param name="dadosValor">Dados do valor a ser incluido</param>
        public static void IncluirValor(string chaveCompleta, string nomeValor, string dadosValor)
        {
            RegistryKey registroWindows = RetornaChave(chaveCompleta, true);
            registroWindows.SetValue(nomeValor, dadosValor);
            if (!_suspenderAltercaoXML) { ConfiguracoesXML.IncluirNomeValor(chaveCompleta, nomeValor); }
        }

        /// <summary>
        /// Altera o nome e o valor da cadeia de caracteres
        /// </summary>
        /// <param name="chaveCompleta">Chave sem o SOFTWARE</param>
        /// <param name="nomeValor">Nome do Valor a ser alterado</param>
        /// <param name="nomeValorNovo">Nome do valor novo a ser incluido</param>
        /// <param name="dadosValor">Dados do valor a ser alterado</param>
        public static bool AlterarValor(string chaveCompleta, string nomeValor, string nomeValorNovo, string dadosValor, out string mensagem)
        {
            if (ConfiguracoesXML.ValidarDadosValor(chaveCompleta, nomeValor, dadosValor, out mensagem))
            {
                _suspenderAltercaoXML = true;
                ExcluirValor(chaveCompleta, nomeValor);
                IncluirValor(chaveCompleta, nomeValorNovo, dadosValor);
                _suspenderAltercaoXML = false;

                ConfiguracoesXML.AlterarNomeValor(chaveCompleta, nomeValor, nomeValorNovo);

                return true;
            }

            return false;
        }

        /// <summary>
        /// Excluir uma cadeia de caracteres
        /// </summary>
        /// <param name="chaveCompleta">Chave sem o SOFTWARE</param>
        /// <param name="nomeValor"></param>
        public static void ExcluirValor(string chaveCompleta, string nomeValor)
        {
            RegistryKey registroWindows = RetornaChave(chaveCompleta, true);
            registroWindows.DeleteValue(nomeValor);
            if (!_suspenderAltercaoXML) { ConfiguracoesXML.ExcluirNomeValor(chaveCompleta, nomeValor); }
        }


        /// <summary>
        /// Grava a chave no registro
        /// </summary>
        /// <param name="chaveCompletaPai">Chave completa pai</param>
        /// <param name="nomeChave">Nome da chave</param>
        public static void IncluirChave(string chaveCompletaPai, string nomeChave)
        {
            RegistryKey registroWindows = RetornaChave(chaveCompletaPai, true);
            registroWindows.CreateSubKey(nomeChave);
            if (!_suspenderAltercaoXML) { ConfiguracoesXML.IncluirChave(chaveCompletaPai, nomeChave); }
        }

        /// <summary>
        /// Altera o nome da chave
        /// </summary>
        /// <param name="chaveCompletaPai">Chave completa</param>
        /// <param name="nomeChave">Nome da chave existente</param>
        /// <param name="nomeChaveNova">Nome da nova chave</param>
        public static void AlterarChave(string chaveCompletaPai, string nomeChave, string nomeChaveNova)
        {
            _suspenderAltercaoXML = true;

            //Copia acha chave
            CopiarChave(chaveCompletaPai, nomeChave, nomeChaveNova);
            ExcluirChave(chaveCompletaPai, nomeChave);

            //Altera no xml a chave de registro
            ConfiguracoesXML.AlterarChave(chaveCompletaPai, nomeChave, nomeChaveNova);

            _suspenderAltercaoXML = false;
        }

        /// <summary>
        /// Exclui a chave de registro
        /// </summary>
        /// <param name="chaveCompletaPai">Chave completa</param>
        /// <param name="nomeChave">Nome da chave a ser exlcuida</param>
        public static void ExcluirChave(string chaveCompletaPai, string nomeChave)
        {
            RegistryKey registroWindows = RetornaChave(chaveCompletaPai, true);
            registroWindows.DeleteSubKeyTree(nomeChave);

            string chaveCompleta = string.Join("\\", chaveCompletaPai, nomeChave);
            if (!_suspenderAltercaoXML) { ConfiguracoesXML.ExlcuirChave(chaveCompleta); }
        }

        /// <summary>
        /// Copiar a chave
        /// </summary>
        /// <param name="chavePai">Chave Pai</param>
        /// <param name="nomeChaveOrigem">Chave de Origem</param>
        /// <param name="nomeChaveOrigemDestino">Chave de Destino</param>
        public static void CopiarChave(string chaveCompletaPai, string nomeChaveOrigem, string nomeChaveOrigemDestino)
        {
            RegistryKey registroWindows = RetornaChave(chaveCompletaPai, true);

            //Cria a nova chave
            RegistryKey chaveDestino = registroWindows.CreateSubKey(nomeChaveOrigemDestino);

            //Instancia a chave de origem
            RegistryKey chaveOrigem = registroWindows.OpenSubKey(nomeChaveOrigem);

            //Copia a chave recursivamente
            CopiarChave(chaveOrigem, chaveDestino);
        }

        /// <summary>
        /// Copia a chave recursivamente
        /// </summary>
        /// <param name="chaveOrigem">Chave de origem</param>
        /// <param name="chaveDestino">Chave de destino</param>
        private static void CopiarChave(RegistryKey chaveOrigem, RegistryKey chaveDestino)
        {
            //Percorre todos os valores
            foreach (string nomeValor in chaveOrigem.GetValueNames())
            {
                object valor = chaveOrigem.GetValue(nomeValor);
                RegistryValueKind dados = chaveOrigem.GetValueKind(nomeValor);
                chaveDestino.SetValue(nomeValor, valor, dados);
            }

            //Percorre todas as subchaves de forma recursiva
            foreach (string nomeSubChave in chaveOrigem.GetSubKeyNames())
            {
                RegistryKey subChaveOrigem = chaveOrigem.OpenSubKey(nomeSubChave);
                RegistryKey subChaveDestino = chaveDestino.CreateSubKey(nomeSubChave);
                CopiarChave(subChaveOrigem, subChaveDestino);
            }
        }

        /// <summary>
        /// Exporta o registro para o arquivo
        /// </summary>
        /// <param name="nomeArquivo"></param>
        /// <param name="nomeChave"></param>
        public static void ExportarRegistro(string nomeArquivo, string nomeChave)
        {
            nomeChave = string.Join("\\", new string[] { "HKEY_LOCAL_MACHINE", "SOFTWARE", nomeChave });
            Process proc = new Process();

            try
            {
                proc.StartInfo.FileName = "regedit.exe";
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.Verb = "runas";

                string a = String.Concat("/e ", nomeArquivo, " ", nomeChave, "");

                proc = Process.Start("regedit.exe", a);
                proc.WaitForExit();
            }
            finally
            {
                proc.Dispose();
            }
        }

        /// <summary>
        /// Exporta a estrutura do xml
        /// </summary>
        /// <param name="nomeArquivo">Nome do arquivo para exportacao</param>
        /// <param name="nomeChave">Nome da chave</param>
        public static XmlDocument ExportarExtruturaRegistroXML(XmlDocument documento, string nomeChave)
        {
            RegistryKey registroWindows = RetornaChave(nomeChave, true);

            if (documento == null) { documento = new XmlDocument(); }

            XmlNode no;

            no = documento["Servicos"] != null ? documento["Servicos"] : documento.AppendChild(documento.CreateElement("Servicos"));
            no = no[ConfiguracoesXML.ServicoWindows] != null ? no[ConfiguracoesXML.ServicoWindows] : no.AppendChild(documento.CreateElement(ConfiguracoesXML.ServicoWindows));
            if (no.Attributes["registroWindows"] == null) { ((XmlElement)no).SetAttribute("registroWindows", nomeChave); }
            no = no["RegistroWindows"] != null ? no["RegistroWindows"] : no.AppendChild(documento.CreateElement("RegistroWindows"));

            no = no[nomeChave] != null ? no[nomeChave] : no.AppendChild(documento.CreateElement(nomeChave));

            MontarExtruturaXML(documento, no, registroWindows);

            return documento;
        }

        /// <summary>
        /// Monta a estrutura do xml
        /// </summary>
        /// <param name="documento">Documento xml</param>
        /// <param name="no">No corrente</param>
        /// <param name="chave">chave corrente</param>
        private static void MontarExtruturaXML(XmlDocument documento, XmlNode no, RegistryKey chave)
        {
            if (chave.ValueCount > 0)
            {
                XmlNode noValores = no["valores"] != null ? no["valores"] : no.AppendChild(documento.CreateElement("valores"));

                foreach (string valor in chave.GetValueNames())
                {
                    if (noValores[valor] == null)
                    {
                        XmlNode noValor = noValores.AppendChild(documento.CreateElement(valor));
                        noValor.AppendChild(documento.CreateElement("tipo")).InnerText = "string";
                    }
                }
            }

            foreach (string item in chave.GetSubKeyNames())
            {
                RegistryKey chaveFilha = chave.OpenSubKey(item);
                XmlNode noFilho = no[item] != null ? no[item] : no.AppendChild(documento.CreateElement(item));
                MontarExtruturaXML(documento, noFilho, chaveFilha);
            }
        }
    }
}
