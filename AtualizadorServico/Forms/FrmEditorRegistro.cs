using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using AtualizadorServico.Classes;

namespace AtualizadorServico.Forms
{
    public partial class FrmEditorRegistro : Form
    {
        /// <summary>
        /// Servico do windows
        /// </summary>
        string _chaveRegistro;

        /// <summary>
        /// Informa o arquivo de registro
        /// </summary>
        public string ArquivoRegistro { get; set; }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="chaveRegistro">Chave de registro do windows</param>
        public FrmEditorRegistro(string chaveRegistro, string servicoWindows)
        {
            InitializeComponent();

            ConfiguracoesXML.ServicoWindows = servicoWindows;

            _chaveRegistro = chaveRegistro;
        }

        /// <summary>
        /// Iniciar Tela
        /// </summary>
        private void IniciarTela()
        {
            //Carrega o treeview da tela
            CarregarTreeView();
        }

        /// <summary>
        /// Carrega o TreeView da tela
        /// </summary>
        private void CarregarTreeView()
        {
            TrvChaves.Nodes.Clear();

            TreeNode no = TrvChaves.Nodes.Add(_chaveRegistro);

            if (!RegistroWindows.CriaArvoreRegistroWindows(_chaveRegistro, ref no, (int)ImagemPasta.Fechada))
            {
                Utilidades.EnviarMensagem(string.Format("Não foi possivel localizar a chave {0} no registro do windows", _chaveRegistro), Utilidades.TipoMensagem.Informacao);
                this.Close();
            }
        }

        /// <summary>
        /// Tra o no selecionado
        /// </summary>
        /// <param name="no"></param>
        private void TratarNo(TreeNode no)
        {
            InformarImagemNo(no);

            CarregarValoresChave(no);
        }

        /// <summary>
        /// Carrega valores da chave
        /// </summary>
        /// <param name="no">No Selecionado</param>
        private void CarregarValoresChave(TreeNode no)
        {
            DataTable tabela = RegistroWindows.RetornaCadeiaCaracteresChave(no.FullPath);

            if (tabela.Rows.Count > 0)
            {
                GrdValores.DataSource = tabela.AsEnumerable().OrderBy(x => x.Field<string>("Nome")).CopyToDataTable();
            }
            else
            {
                GrdValores.DataSource = tabela;
            }

            MnuChaveRegistro.Text = string.Join(@"\", new string[] {"Computador",
                                                                    "HKEY_LOCAL_MACHINE",
                                                                    "SOFTWARE",
                                                                    no.FullPath});
        }

        /// <summary>
        /// Abre o editor de chave
        /// </summary>
        /// <param name="no">No (podendo ser nulo)</param>
        private void AbrirEditorChave(TreeNode no)
        {
            string chaveCompletaPai = string.Empty;
            string nomeChave = string.Empty;

            if (no != null)//Caso seja um no selecionado, significa que é uma alteração
            {
                nomeChave = no.Text;
                if (no.Parent != null) { chaveCompletaPai = no.Parent.FullPath; }
            }
            else//Senão faz uma inclusão
            {
                if (TrvChaves.SelectedNode == null)
                {
                    Utilidades.EnviarMensagem("Selecione uma chave de registro.", Utilidades.TipoMensagem.Advertencia);
                    return;
                }
                chaveCompletaPai = TrvChaves.SelectedNode.FullPath;
            }

            using (FrmEditorRegistroChave form = new FrmEditorRegistroChave(chaveCompletaPai, nomeChave))
            {
                form.ShowDialog();

                if (!string.IsNullOrEmpty(form.ChaveCompletaAlterada))
                {
                    if (string.IsNullOrEmpty(chaveCompletaPai)) { _chaveRegistro = form.ChaveCompletaAlterada; }
                    CarregarTreeView();
                    TrvChaves.SelectedNode = LocalizarNo(TrvChaves.Nodes, form.ChaveCompletaAlterada);
                }

            }
        }

        /// <summary>
        /// Abre a tela de editor de valores de registro
        /// </summary>
        /// <param name="linha">Linha da grid, caso seja novo informar -1</param>
        private void AbrirEditorValor(int linha)
        {
            string chaveCompleta = string.Empty;
            string nomeValor = string.Empty;

            if (TrvChaves.SelectedNode == null)
            {
                Utilidades.EnviarMensagem("Selecione uma chave de registro.", Utilidades.TipoMensagem.Advertencia);
                return;
            }

            chaveCompleta = TrvChaves.SelectedNode.FullPath;

            if (linha >= 0 && GrdValores.Rows.Count > 0)
            {
                nomeValor = GrdValores.Rows[linha].Cells["Nome"].Value.ToString();
            }

            using (FrmEditorRegistroValor form = new FrmEditorRegistroValor(chaveCompleta, nomeValor))
            {
                form.ShowDialog();

                if (TrvChaves.SelectedNode != null)
                {
                    CarregarValoresChave(TrvChaves.SelectedNode);
                    LocalizarCadeiaCaracteres(form.NomeAlterado);
                }
            }
        }

        /// <summary>
        /// Localizar o no na arvore
        /// </summary>
        /// <param name="no">No da arvore</param>
        /// <param name="chaveCompleta">Nome completo da chave</param>
        private TreeNode LocalizarNo(TreeNodeCollection nos, string chaveCompleta)
        {
            foreach (TreeNode no in nos)
            {
                if (no.FullPath == chaveCompleta) { return no; }
                TreeNode noLocalizado = LocalizarNo(no.Nodes, chaveCompleta);
                if (noLocalizado != null) { return noLocalizado; }
            }
            return null;
        }

        /// <summary>
        /// Seleciona a cadeia de caracteres
        /// </summary>
        /// <param name="nome">Nome da cadeia de caracteres</param>
        private void LocalizarCadeiaCaracteres(string nome)
        {
            foreach (DataGridViewRow linha in GrdValores.Rows)
            {
                linha.Selected = false;
                if (linha.Cells["Nome"].Value.ToString() == nome)
                { linha.Selected = true; break; }
            }
        }


        /// <summary>
        /// Desmaca todas as linhas da grid
        /// </summary>
        private void DesmarcarTodasLinhasGrid()
        {
            foreach (DataGridViewRow linhaSelecionada in GrdValores.SelectedRows)
            {
                linhaSelecionada.Selected = false;
            }
        }

        /// <summary>
        /// Abre o menu de opcoes da treeview
        /// </summary>
        /// <param name="local"></param>
        private void AbrirMenuTreeView(TreeNode no, Point local)
        {
            TrvChaves.SelectedNode = no;
            MnuTrvChaves.Show(TrvChaves, local);
        }

        /// <summary>
        /// Abre o menu de opcoes da grid valores
        /// </summary>
        /// <param name="local"></param>
        private void AbrirMenuGridValores(int linha, Point local)
        {
            DesmarcarTodasLinhasGrid();

            if (GrdValores.Rows.Count > 0 && linha >= 0)
            {
                GrdValores.Rows[linha].Selected = true;
            }

            MnuGrdValores.Show(MousePosition);
        }


        /// <summary>
        /// Configura a imagem do no
        /// </summary>
        /// <param name="no">No para alterar a imagem</param>
        private void InformarImagemNo(TreeNode no)
        {
            if (no == null) { return; }
            if (no.IsExpanded)
            {
                no.ImageIndex = (int)ImagemPasta.Aberta;
            }
            else
            {
                no.ImageIndex = (int)ImagemPasta.Fechada;
            }
        }

        /// <summary>
        /// Remove a chave selcionada no nó
        /// </summary>
        /// <param name="no">No selecionado</param>
        private void RemoverChave(TreeNode no)
        {
            if (TrvChaves.SelectedNode == null) { return; }
            if (no == null) { return; }

            string chaveCompletaPai = string.Empty;

            if (no.Parent != null)
            {
                chaveCompletaPai = no.Parent.FullPath;
            }
            else
            {
                Utilidades.EnviarMensagem("A chave raiz não pode ser excluida.", Utilidades.TipoMensagem.Advertencia);
                return;
            }

            if (Utilidades.EnviarMensagem(string.Format("Deseja excluir a chave {0}?", no.Text), Utilidades.TipoMensagem.Pergunta) == System.Windows.Forms.DialogResult.Yes)
            {
                RegistroWindows.ExcluirChave(chaveCompletaPai, no.Text);
                CarregarTreeView();
                TrvChaves.SelectedNode = LocalizarNo(TrvChaves.Nodes, chaveCompletaPai);
            }
        }

        /// <summary>
        /// Remove a cadeia de carecteres selecionada na grid
        /// </summary>
        /// <param name="linha">Remove a linha selecionada</param>
        private void RemoverCadeiaCaracteres(int linha)
        {
            if (TrvChaves.SelectedNode == null) { return; }
            if (GrdValores.Rows.Count == 0 || linha < 0) { return; }

            string nomeValor = GrdValores.Rows[linha].Cells["Nome"].Value.ToString();

            if (Utilidades.EnviarMensagem(string.Format("Deseja excluir a cadeia de carecteres {0}?", nomeValor), Utilidades.TipoMensagem.Pergunta) == System.Windows.Forms.DialogResult.Yes)
            {
                RegistroWindows.ExcluirValor(TrvChaves.SelectedNode.FullPath, nomeValor);
                CarregarValoresChave(TrvChaves.SelectedNode);
            }
        }

        /// <summary>
        /// Exporta o arquivo de registro
        /// </summary>
        /// <param name="fecharJanela">Fechar a janela do editor de registro</param>
        private string ExportarArquivo(bool fecharJanela)
        {
            string nomeArquivo = string.Empty;
            string nomeChave = TrvChaves.TopNode.Text;

            SaveFileDialog janela = new SaveFileDialog();
            janela.Filter = "Arquivo de Registro do Windows|*.reg";
            janela.RestoreDirectory = true;
            janela.FileName = nomeChave + ".reg";

            if (janela.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //Recupera o nome do arquvi
                nomeArquivo = janela.FileName;

                //Exporta o arquivo
                RegistroWindows.ExportarRegistro(nomeArquivo, nomeChave);

                //Fecha janela
                if (fecharJanela)
                {
                    Utilidades.EnviarMensagem("Arquivo exportado com sucesso.", Utilidades.TipoMensagem.Informacao);
                    this.Close();
                }

            }

            //Retorna o nome do arquivo
            return nomeArquivo;
        }

        /// <summary>
        /// Exporta o arquivo de registro
        /// </summary>
        private void ExportarArquivoAdicionarAtualizador()
        {
            string arquivo = ExportarArquivo(false);

            if (!string.IsNullOrEmpty(arquivo))
            {
                ArquivoRegistro = arquivo;
                this.Close();
            }

        }

        /// <summary>
        /// Exportar arquivo de configuracao XMl
        /// </summary>
        private void ExportarArquivoConfiguracaoXML()
        {
            string nomeChave = TrvChaves.TopNode.Text;

            SaveFileDialog janela = new SaveFileDialog();
            janela.Filter = "Arquivo XML|*.xml";
            janela.RestoreDirectory = true;
            janela.FileName = nomeChave + ".xml";

            if (janela.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //Exporta o arquivo
                XmlDocument documento = RegistroWindows.ExportarExtruturaRegistroXML(ConfiguracoesXML.RetornaConfiguracoesXML(), nomeChave);
                documento.Save(janela.FileName);
            }

        }

        /// <summary>
        /// Retorna a chave raiz do registro do windows
        /// </summary>
        /// <returns>Retorna a chave raiz</returns>
        public string RetornaChaveRaizRegistroWindows()
        {
            if (TrvChaves.Nodes.Count > 0)
            {
                return TrvChaves.Nodes[0].FullPath;
            }
            return string.Empty;
        }

        #region Eventos

        /// <summary>
        /// Evento load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmEditorRegistro_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                IniciarTela();
            }
            catch (Exception ex)
            {
                Utilidades.EnviarMensagem(ex.Message, Utilidades.TipoMensagem.Erro);
            }
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// Nova Chave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MnuNovaChave_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                AbrirEditorChave(null);
            }
            catch (Exception ex)
            {
                Utilidades.EnviarMensagem(ex.Message, Utilidades.TipoMensagem.Erro);
            }
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// Nova Cadeia de Caracteres
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MnuNovaCadeiaCaracteres_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                AbrirEditorValor(-1);
            }
            catch (Exception ex)
            {
                Utilidades.EnviarMensagem(ex.Message, Utilidades.TipoMensagem.Erro);
            }
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// Excluir Chave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MnuExcluirChave_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (TrvChaves.SelectedNode != null) { RemoverChave(TrvChaves.SelectedNode); }
            }
            catch (Exception ex)
            {
                Utilidades.EnviarMensagem(ex.Message, Utilidades.TipoMensagem.Erro);
            }
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// Excluir Cadeia Caracteres
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MnuExcluirCadeiaCaracteres_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (GrdValores.SelectedCells.Count > 0) { RemoverCadeiaCaracteres(GrdValores.SelectedCells[0].RowIndex); }
            }
            catch (Exception ex)
            {
                Utilidades.EnviarMensagem(ex.Message, Utilidades.TipoMensagem.Erro);
            }
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// Exportar Registro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MnuExportarArquivoRegistro_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                ExportarArquivo(true);
            }
            catch (Exception ex)
            {
                Utilidades.EnviarMensagem(ex.Message, Utilidades.TipoMensagem.Erro);
            }
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// Exportar Registro Aplicacao
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MnuExportarAtualizadorServico_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                ExportarArquivoAdicionarAtualizador();
            }
            catch (Exception ex)
            {
                Utilidades.EnviarMensagem(ex.Message, Utilidades.TipoMensagem.Erro);
            }
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// Exportar Arquivo XML
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void arquivoDeConfiguraçãoXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                ExportarArquivoConfiguracaoXML();
            }
            catch (Exception ex)
            {
                Utilidades.EnviarMensagem(ex.Message, Utilidades.TipoMensagem.Erro);
            }
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// Sair
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MnuSair_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                Utilidades.EnviarMensagem(ex.Message, Utilidades.TipoMensagem.Erro);
            }
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// No Selecionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TrvChaves_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                TratarNo(e.Node);
            }
            catch (Exception ex)
            {
                Utilidades.EnviarMensagem(ex.Message, Utilidades.TipoMensagem.Erro);
            }
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// Click no No
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TrvChaves_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    AbrirMenuTreeView(e.Node, e.Location);
                }
            }
            catch (Exception ex)
            {
                Utilidades.EnviarMensagem(ex.Message, Utilidades.TipoMensagem.Erro);
            }
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// Nova chave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MnuTrvChavesNovoChave_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                AbrirEditorChave(null);
            }
            catch (Exception ex)
            {
                Utilidades.EnviarMensagem(ex.Message, Utilidades.TipoMensagem.Erro);
            }
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// Nova cadeia de caract3eres
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MnuTrvChavesNovoCadeiaCaracteres_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                AbrirEditorValor(-1);
            }
            catch (Exception ex)
            {
                Utilidades.EnviarMensagem(ex.Message, Utilidades.TipoMensagem.Erro);
            }
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// Renomear chave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MnuTrvChavesRenomear_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                AbrirEditorChave(TrvChaves.SelectedNode);
            }
            catch (Exception ex)
            {
                Utilidades.EnviarMensagem(ex.Message, Utilidades.TipoMensagem.Erro);
            }
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// No Fechado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TrvChaves_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                InformarImagemNo(e.Node);
            }
            catch (Exception ex)
            {
                Utilidades.EnviarMensagem(ex.Message, Utilidades.TipoMensagem.Erro);
            }
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// No Aberto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TrvChaves_AfterExpand(object sender, TreeViewEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                InformarImagemNo(e.Node);
            }
            catch (Exception ex)
            {
                Utilidades.EnviarMensagem(ex.Message, Utilidades.TipoMensagem.Erro);
            }
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// Duplo click grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GrdValores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                AbrirEditorValor(e.RowIndex);
            }
            catch (Exception ex)
            {
                Utilidades.EnviarMensagem(ex.Message, Utilidades.TipoMensagem.Erro);
            }
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// Click na celula
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GrdValores_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    AbrirMenuGridValores(e.RowIndex, e.Location);
                }
            }
            catch (Exception ex)
            {
                Utilidades.EnviarMensagem(ex.Message, Utilidades.TipoMensagem.Erro);
            }
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// Botao Editar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MnuEditarChave_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (TrvChaves.SelectedNode != null) { AbrirEditorChave(TrvChaves.SelectedNode); }
            }
            catch (Exception ex)
            {
                Utilidades.EnviarMensagem(ex.Message, Utilidades.TipoMensagem.Erro);
            }
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// Botao Editar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MnuEditarCadeiaCaracteres_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (GrdValores.SelectedCells.Count > 0) { AbrirEditorValor(GrdValores.SelectedCells[0].RowIndex); }
            }
            catch (Exception ex)
            {
                Utilidades.EnviarMensagem(ex.Message, Utilidades.TipoMensagem.Erro);
            }
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// Adicionar Cadeia de caracteres
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void adicionarCadeiaDeCaracteresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                AbrirEditorValor(-1);
            }
            catch (Exception ex)
            {
                Utilidades.EnviarMensagem(ex.Message, Utilidades.TipoMensagem.Erro);
            }
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// Editar cadeia de caracteres
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editarCadeiaDeCaracteresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (GrdValores.SelectedCells.Count > 0) { AbrirEditorValor(GrdValores.SelectedCells[0].RowIndex); }
            }
            catch (Exception ex)
            {
                Utilidades.EnviarMensagem(ex.Message, Utilidades.TipoMensagem.Erro);
            }
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// Remover cadeia de caracteres
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void removerCadeiaDeCaracteresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (GrdValores.SelectedCells.Count > 0) { RemoverCadeiaCaracteres(GrdValores.SelectedCells[0].RowIndex); }
            }
            catch (Exception ex)
            {
                Utilidades.EnviarMensagem(ex.Message, Utilidades.TipoMensagem.Erro);
            }
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// Remover chave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void removerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (TrvChaves.SelectedNode != null) { RemoverChave(TrvChaves.SelectedNode); }
            }
            catch (Exception ex)
            {
                Utilidades.EnviarMensagem(ex.Message, Utilidades.TipoMensagem.Erro);
            }
            Cursor.Current = Cursors.Default;
        }

        #endregion

        #region Enum

        private enum ImagemPasta
        {
            Fechada = 0,
            Aberta = 1
        }

        #endregion


    }
}
