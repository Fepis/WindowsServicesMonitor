using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AtualizadorServico.Classes;

namespace AtualizadorServico.Controles
{
    /// <summary>
    /// Tela de monitoramento de serviço
    /// </summary>
    public partial class CtrlPainelControle : UserControl
    {
        /// <summary>
        /// Delegete informa o status do serviço
        /// </summary>
        /// <param name="servidor">Servidor</param>
        /// <param name="status">Status do serviço</param>
        /// <param name="mensagem">Mensagem de conexao</param>
        public delegate void InformaStatusServicoHanlder(string servidor, bool conectado, Servico servico, string mensagem);

        /// <summary>
        /// Objeto de monitoramento
        /// </summary>
        Monitoramento objMonitoramento = new Monitoramento();

        /// <summary>
        /// Variavel informando que esta monitorando
        /// </summary>
        private bool _monitorando = false;

        /// <summary>
        /// Sigla sem informacao N/L
        /// </summary>
        private string _siglaSemInformacao = "N/L";

        /// <summary>
        /// Construtor
        /// </summary>
        public CtrlPainelControle()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Inicia a tela
        /// </summary>
        private void IniciarTela()
        {
            CarregarCombo();

            ConfigurarGrids();

            AssinarEvento();

            MostrarServidor(-1);
        }

        /// <summary>
        /// Configura a grid
        /// </summary>
        private void ConfigurarGrids()
        {
            ((DataGridViewImageColumn)GrdMonitoramento.Columns["StatusAtualizacao"]).DefaultCellStyle.NullValue = null;
            ((DataGridViewImageColumn)GrdMonitoramento.Columns["StatusServico"]).DefaultCellStyle.NullValue = null;
        }

        /// <summary>
        /// Carrega os combos da tela
        /// </summary>
        private void CarregarCombo()
        {
            CmbServicos.DataSource = ConfiguracoesXML.RetornarServicos();
        }

        /// <summary>
        /// Assinar enventos
        /// </summary>
        private void AssinarEvento()
        {
            objMonitoramento.OnInformaStatusServico += objMonitoramento_OnInformaStatusServico;

            Form form = this.FindForm();
            if (form != null)
            {
                form.FormClosed += form_FormClosed;
            }
        }

        /// <summary>
        /// Realiza a listagem dos servidores da rede
        /// </summary>
        private void ListarServidores()
        {
            List<string> servidores = RedeSistema.ListarMaquinasRede(TxtFiltroServidor.Text, ChkServidorNota.Checked, ChkServidorWindows.Checked);

            LstServidores.Items.Clear();

            if (servidores != null && servidores.Count > 0)
            {
                foreach (string servidor in servidores.OrderBy(x => x).ToList())
                {
                    ListViewItem item = new ListViewItem(new string[] { null, servidor });
                    LstServidores.Items.Add(item);
                }
            }
        }

        /// <summary>
        /// Marcar servidores
        /// </summary>
        private void MarcarServidores()
        {
            foreach (ListViewItem item in LstServidores.Items)
            {
                item.Checked = ChkMarcarTodos.Checked;
            }
        }

        /// <summary>
        /// Adciona os servidores para atualizacao do servico
        /// </summary>
        private void AdicionarServidores()
        {
            foreach (ListViewItem item in LstServidores.Items)
            {
                if (item.Checked)
                {
                    string servidor = item.SubItems[1].Text;

                    //Adiciona o servidor na lista de servidores
                    AdicionarServidorSelecionado(servidor);
                }
            }

            if (!string.IsNullOrEmpty(TxtServidorManual.Text))
            {
                //Adiciona o servidor na lista de servidores
                AdicionarServidorSelecionado(TxtServidorManual.Text);
            }
        }


        /// <summary>
        /// Adicionar o servidor na lista de servidores
        /// </summary>
        /// <param name="servidor">Servidoe</param>
        private void AdicionarServidorSelecionado(string servidor)
        {
            if (GrdServidoresSelecionados.DataSource == null) { GrdServidoresSelecionados.DataSource = CriarDataTableServidores(); }

            DataTable tabela = (DataTable)GrdServidoresSelecionados.DataSource;

            //Verifica se o servidor ja foi adicionado
            if (tabela.AsEnumerable().Count(x => x.Field<string>("Servidor") == servidor) == 0)
            {
                tabela.Rows.Add(new object[] { servidor, ImgsForm.Images[(int)TipoImagens.Excluir] });

                objMonitoramento.AdicionarServidor(servidor);

                if (objMonitoramento.VerificarExisteMonitoramentoAndamento())
                {
                    AdicionarServidorMonitormanento(servidor);
                }
            }
        }

        /// <summary>
        /// Cria a tabela de servidores para alimentar a estrutura da grid
        /// </summary>
        /// <returns>Retorna a tabela com a estrutura criada porem vazia</returns>
        private DataTable CriarDataTableServidores()
        {
            DataTable tabela = new DataTable();

            tabela.Columns.Add("Servidor", typeof(string));
            tabela.Columns.Add("Remover", typeof(Image));

            return tabela;
        }

        /// <summary>
        /// Remove os servidores de atualizacao
        /// </summary>
        private void RemoverServidores(int linha, int coluna)
        {
            if (linha < 0) { return; }

            if (GrdServidoresSelecionados.Columns["RemoverServidor"].Index == coluna)
            {
                string servidor = GrdServidoresSelecionados.Rows[linha].Cells["Servidor"].Value.ToString();

                objMonitoramento.RemoverServidor(servidor);

                if (GrdMonitoramento.DataSource != null)
                {
                    DataRow linhaMonitoramento = ((DataTable)GrdMonitoramento.DataSource).AsEnumerable().FirstOrDefault(x => x.Field<string>("Servidor").Equals(servidor));

                    if (linhaMonitoramento != null)
                    {
                        ((DataTable)GrdMonitoramento.DataSource).Rows.Remove(linhaMonitoramento);
                        GrdMonitoramento.Refresh();

                        if (((DataTable)GrdMonitoramento.DataSource).Rows.Count == 0)
                        {
                            PararMonitoramento();
                        }
                    }
                }

                RemoverItemGrid(GrdServidoresSelecionados, "RemoverServidor", linha, coluna);
            }

        }

        /// <summary>
        /// Remove a linha da grid
        /// </summary>
        /// <param name="grid">Grid que deseja remover a linha</param>
        /// <param name="nomeColunaClick">Nome da coluna parar considerar o evento da remoção</param>
        /// <param name="linha">Linha clicada</param>
        /// <param name="coluna">Coluna clicada</param>
        private void RemoverItemGrid(DataGridView grid, string nomeColunaClick, int linha, int coluna)
        {
            if (linha < 0) { return; }

            if (grid.Rows.Count == 0) { return; }

            if (grid.Columns[nomeColunaClick].Index == coluna)
            {
                grid.Rows.Remove(grid.Rows[linha]);
            }
        }

        /// <summary>
        /// Adiciona o servidor no monitoramento
        /// </summary>
        private void AdicionarServidoresMonitormanento()
        {
            if (GrdServidoresSelecionados.DataSource == null) { return; }

            if (GrdMonitoramento.DataSource != null) { ((DataTable)GrdMonitoramento.DataSource).Rows.Clear(); }

            foreach (DataRow linha in ((DataTable)GrdServidoresSelecionados.DataSource).Rows)
            {
                AdicionarServidorMonitormanento(linha["Servidor"].ToString());
            }

        }

        /// <summary>
        /// Adiciona o servidor no monitoramento
        /// </summary>
        /// <param name="servidor">Adiciona o sevidor no monitogarmento</param>
        /// <returns>Retorna a linha informada</returns>
        private DataRow AdicionarServidorMonitormanento(string servidor)
        {
            if (GrdMonitoramento.DataSource == null) { GrdMonitoramento.DataSource = CriarDataTableMonitormanento(); }

            DataRow linha = ((DataTable)GrdMonitoramento.DataSource).AsEnumerable().FirstOrDefault(x => x.Field<string>("Servidor").Equals(servidor));

            if (linha == null)
            {
                linha = ((DataTable)GrdMonitoramento.DataSource).NewRow();

                linha["StatusAtualizacao"] = ImgsForm.Images[(int)TipoImagens.Desconectado];

                linha["Servidor"] = servidor;
                linha["Filial"] = Consultas.RetornaFilialServidor(servidor);

                StringBuilder sb = new StringBuilder();

                sb.AppendLine(new string('-', 50));
                sb.AppendLine("Processo de atualização");
                sb.AppendLine("Servidor: " + servidor);
                sb.AppendLine("Inicio: " + DateTime.Now.ToString("HH:mm:ss"));
                sb.AppendLine(new string('-', 50));

                linha["Log"] = sb.ToString();

                ((DataTable)GrdMonitoramento.DataSource).Rows.Add(linha);

            }

            return linha;
        }


        /// <summary>
        /// Cria a tabela de servidores para alimentar a estrutura da grid
        /// </summary>
        /// <returns>Retorna a tabela com a estrutura criada porem vazia</returns>
        private DataTable CriarDataTableMonitormanento()
        {
            DataTable tabela = new DataTable();

            tabela.Columns.Add("StatusAtualizacao", typeof(Image));
            tabela.Columns.Add("Servidor", typeof(string));
            tabela.Columns.Add("Filial", typeof(string));
            tabela.Columns.Add("StatusServico", typeof(Image));
            tabela.Columns.Add("Log", typeof(string));
            tabela.Columns.Add("NomeServico", typeof(string));
            tabela.Columns.Add("DisplayServico", typeof(string));
            tabela.Columns.Add("DescricaoServico", typeof(string));
            tabela.Columns.Add("IndexStatusServidor", typeof(int));
            tabela.Columns.Add("Local", typeof(string));
            tabela.Columns.Add("Versao", typeof(string));

            return tabela;
        }

        /// <summary>
        /// Iniciar monitoramneto
        /// </summary>
        private void Monitorar()
        {
            if (!_monitorando)
            {
                IniciarMonitoramento();
            }
            else
            {
                PararMonitoramento();
            }
        }

        /// <summary>
        /// Inicia o monitoramento
        /// </summary>
        private void IniciarMonitoramento()
        {
            string mensagem = string.Empty;


            if (objMonitoramento.IniciarMonitoramento(CmbServicos.Text, out mensagem))
            {
                _monitorando = true;
                AdicionarServidoresMonitormanento();
            }
            else
            {
                _monitorando = false;
                Utilidades.EnviarMensagem(mensagem, Utilidades.TipoMensagem.Advertencia);
            }

            ConfiguraBotaoMonitoramento();
        }

        /// <summary>
        /// Parar monitoramento
        /// </summary>
        private void PararMonitoramento()
        {
            string mensagem = string.Empty;

            objMonitoramento.PararMonitoramento();

            _monitorando = false;

            MostrarServidor(-1);

            if (GrdMonitoramento.DataSource != null)
            {
                foreach (DataRow linha in ((DataTable)GrdMonitoramento.DataSource).Rows)
                {
                    linha["StatusAtualizacao"] = ImgsForm.Images[(int)TipoImagens.Desconectado];
                    linha["StatusServico"] = null;
                    linha["IndexStatusServidor"] = -1;
                }

            }

            ConfiguraBotaoMonitoramento();
        }

        /// <summary>
        /// Configura botao do monitormaento
        /// </summary>
        private void ConfiguraBotaoMonitoramento()
        {
            if (_monitorando)
            {
                CmbServicos.Enabled = false;
                BtnMonitoramento.Text = "Para Monitoramento";
                BtnMonitoramento.BackColor = Color.LightCoral;
            }
            else
            {
                CmbServicos.Enabled = true;
                BtnMonitoramento.Text = "Iniciar Monitoramento";
                BtnMonitoramento.BackColor = Color.LightGreen;
            }
        }

        /// <summary>
        /// Mostra o servidor
        /// </summary>
        /// <param name="linha">Linha selecionada</param>
        private void MostrarServidor(int linha)
        {

            BtnIniciarServico.Enabled = false;
            BtnPararServico.Enabled = false;

            if (linha >= 0)
            {
                DataRowView linhaGrid = (DataRowView)GrdMonitoramento.Rows[linha].DataBoundItem;
                TxtServidor.Text = linhaGrid["Servidor"].ToString();
                TxtFilial.Text = linhaGrid["Filial"].ToString();
                TxtServico.Text = linhaGrid["NomeServico"].ToString();
                TxtServicoDisplay.Text = linhaGrid["DisplayServico"].ToString();
                TxtDescricaoServico.Text = linhaGrid["DescricaoServico"].ToString();
                TxtLogAtualizacao.Text = linhaGrid["Log"].ToString();
                TxtVersao.Text = linhaGrid["Versao"].ToString();
                TxtLocal.Text = linhaGrid["Local"].ToString();

                int result;

                if (int.TryParse(linhaGrid["IndexStatusServidor"].ToString(), out result))
                {
                    if ((int)linhaGrid["IndexStatusServidor"] == (int)TipoImagens.ServicoIniciado)
                    {
                        BtnPararServico.Enabled = true;
                    }
                    else if ((int)linhaGrid["IndexStatusServidor"] == (int)TipoImagens.ServicoParado)
                    {
                        BtnIniciarServico.Enabled = true;
                    }
                }
            }
            else
            {

                TxtServidor.Text = _siglaSemInformacao;
                TxtFilial.Text = _siglaSemInformacao;
                TxtServico.Text = _siglaSemInformacao;
                TxtServicoDisplay.Text = _siglaSemInformacao;
                TxtVersao.Text = _siglaSemInformacao;
                TxtLocal.Text = _siglaSemInformacao;
                TxtDescricaoServico.Text = string.Empty;
                TxtLogAtualizacao.Text = string.Empty;
            }
        }

        /// <summary>
        /// Informa o status do serviço
        /// </summary>
        /// <param name="servidor">Servidor</param>
        /// <param name="servico">Serviço</param>
        /// <param name="mensagem">Mensagem</param>
        private void InformarStatusServicoThread(string servidor, bool conectado, Servico servico, string mensagem)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new InformaStatusServicoHanlder(InformarStatusServicoThread), new object[] { servidor, conectado, servico, mensagem });
            }
            else
            {
                InformarStatusServico(servidor, conectado, servico, mensagem);
            }
        }

        /// <summary>
        /// Informa o status do serviço
        /// </summary>
        /// <param name="servidor">Servidor</param>
        /// <param name="servico">Serviço</param>
        /// <param name="mensagem">Mensagem</param>
        private void InformarStatusServico(string servidor, bool conectado, Servico servico, string mensagem)
        {
            if (!_monitorando) { return; }

            if (GrdMonitoramento.DataSource == null) { return; }

            if (!CmbServicos.Text.Equals(objMonitoramento.NomeServico)) { return; }

            DataRow linha = ((DataTable)GrdMonitoramento.DataSource).AsEnumerable().FirstOrDefault(x => x.Field<string>("Servidor").Equals(servidor));

            if (linha != null)
            {
                linha["StatusAtualizacao"] = conectado ? ImgsForm.Images[(int)TipoImagens.Conectado] : ImgsForm.Images[(int)TipoImagens.Desconectado];

                linha["StatusServico"] = null;
                linha["IndexStatusServidor"] = -1;

                if (servico != null)
                {
                    switch (servico.Status)
                    {
                        case RedeSistema.TipoStatusServico.Rodando:
                            linha["StatusServico"] = ImgsForm.Images[(int)TipoImagens.ServicoIniciado];
                            linha["IndexStatusServidor"] = (int)TipoImagens.ServicoIniciado;

                            break;
                        case RedeSistema.TipoStatusServico.Parado:
                            linha["StatusServico"] = ImgsForm.Images[(int)TipoImagens.ServicoParado];
                            linha["IndexStatusServidor"] = (int)TipoImagens.ServicoParado;
                            break;
                    }

                    linha["NomeServico"] = servico.Nome;
                    linha["DisplayServico"] = servico.Display;
                    linha["DescricaoServico"] = servico.Descricao;
                    linha["Versao"] = servico.Versao;
                    linha["Local"] = servico.EnderecoExecutavel;
                }

                if (!string.IsNullOrEmpty(mensagem) && !mensagem.Trim().Equals(string.Empty))
                {
                    linha["log"] += Environment.NewLine;
                    linha["log"] += Environment.NewLine;
                    linha["log"] += string.Format("   [{0}] " + mensagem, DateTime.Now.ToString("HH:mm:ss"));

                }

                //caso seja igual ao servidor selecionado
                if (TxtServidor.Text.Equals(servidor))
                {
                    foreach (DataGridViewRow item in GrdMonitoramento.Rows)
                    {
                        if (item.Cells["ServidorProcessado"].Value.ToString().Equals(servidor))
                        {
                            MostrarServidor(item.Index);
                            break;
                        }
                    }
                }

            }
        }

        /// <summary>
        /// Executa um comando para parar o serviço
        /// </summary>
        /// <param name="comando">Executar comando</param>
        private void ExecutarAcaoServico(RedeSistema.TipoComandoServico comando)
        {
            string servidor = TxtServidor.Text;
            string servico = TxtServico.Text;

            if (string.IsNullOrEmpty(servidor) || servidor.Trim().Equals(string.Empty) || servidor.Trim().Equals(_siglaSemInformacao)) { return; }
            if (string.IsNullOrEmpty(servico) || servico.Trim().Equals(string.Empty) || servico.Trim().Equals(_siglaSemInformacao)) { return; }

            string mensagem;

            BtnIniciarServico.Enabled = false;
            BtnPararServico.Enabled = false;

            if (!RedeSistema.ExecutarComandoServico(servidor, servico, comando, out mensagem))
            {
                Utilidades.EnviarMensagem(mensagem, Utilidades.TipoMensagem.Erro);
            }
        }

        /// <summary>
        /// Informa o status do serviço
        /// </summary>
        /// <param name="servidor">Servidor</param>
        /// <param name="servico">Serviço</param>
        /// <param name="mensagem">Mensagem</param>
        void objMonitoramento_OnInformaStatusServico(string servidor, bool conectado, Servico servico, string mensagem)
        {
            try
            {
                InformarStatusServicoThread(servidor, conectado, servico, mensagem);
            }
            catch (Exception ex)
            {
                Utilidades.EnviarMensagem(ex.Message, Utilidades.TipoMensagem.Erro);
            }
        }

        /// <summary>
        /// Evento Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CtrlPainelControle_Load(object sender, EventArgs e)
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
        /// Form closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void form_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                PararMonitoramento();
            }
            catch (Exception ex)
            {
                Utilidades.EnviarMensagem(ex.Message, Utilidades.TipoMensagem.Erro);
            }
        }

        /// <summary>
        /// Listar Servidor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnListarServidor_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                ListarServidores();
            }
            catch (Exception ex)
            {
                Utilidades.EnviarMensagem(ex.Message, Utilidades.TipoMensagem.Erro);
            }
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// Marcar Todos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChkMarcarTodos_CheckedChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                MarcarServidores();
            }
            catch (Exception ex)
            {
                Utilidades.EnviarMensagem(ex.Message, Utilidades.TipoMensagem.Erro);
            }
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// Adicionar Servidores
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAdicionarServidores_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                AdicionarServidores();
            }
            catch (Exception ex)
            {
                Utilidades.EnviarMensagem(ex.Message, Utilidades.TipoMensagem.Erro);
            }
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// Remover servidor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GrdServidoresSelecionados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                RemoverServidores(e.RowIndex, e.ColumnIndex);
            }
            catch (Exception ex)
            {
                Utilidades.EnviarMensagem(ex.Message, Utilidades.TipoMensagem.Erro);
            }
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// Iniciar Monitoramento
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnIniciarMonitoramento_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                Monitorar();
            }
            catch (Exception ex)
            {
                Utilidades.EnviarMensagem(ex.Message, Utilidades.TipoMensagem.Erro);
            }
            Cursor.Current = Cursors.Default;
        }

        private void GrdMonitoramento_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {

            }
            catch (Exception ex)
            {
                Utilidades.EnviarMensagem(ex.Message, Utilidades.TipoMensagem.Erro);
            }
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// Remove linha
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GrdMonitoramento_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                MostrarServidor(-1);
            }
            catch (Exception ex)
            {
                Utilidades.EnviarMensagem(ex.Message, Utilidades.TipoMensagem.Erro);
            }
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GrdMonitoramento_SelectionChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (GrdMonitoramento.SelectedRows.Count > 0) { MostrarServidor(GrdMonitoramento.SelectedRows[0].Index); }
            }
            catch (Exception ex)
            {
                Utilidades.EnviarMensagem(ex.Message, Utilidades.TipoMensagem.Erro);
            }
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// Iniciar Servico
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnIniciarServico_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                ExecutarAcaoServico(RedeSistema.TipoComandoServico.Iniciar);
            }
            catch (Exception ex)
            {
                Utilidades.EnviarMensagem(ex.Message, Utilidades.TipoMensagem.Erro);
            }
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// Parar  servico
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPararServico_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                ExecutarAcaoServico(RedeSistema.TipoComandoServico.Parar);
            }
            catch (Exception ex)
            {
                Utilidades.EnviarMensagem(ex.Message, Utilidades.TipoMensagem.Erro);
            }
            Cursor.Current = Cursors.Default;
        }


        #region enum

        /// <summary>
        /// Imagenss
        /// </summary>
        private enum TipoImagens
        {
            ServicoIniciado = 0,
            ServicoParado = 1,
            Conectado = 2,
            Desconectado = 3,
            Excluir = 4
        }

        #endregion


    }
}
