using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using AtualizadorServico.Classes;
using AtualizadorServico.Forms;

namespace AtualizadorServico.Controles
{
    public partial class CtrlInstalacao : UserControl
    {
        /// <summary>
        /// Delegate para atualizar o status do servidor em thread
        /// </summary>
        /// <param name="servidor">Servidor</param>
        /// <param name="procedimento">Procedimento</param>
        delegate void AtualizarGrdServidoresThreadHandler(string servidor, ProcessoAtualizacao.ProcedimentoAtualizacao procedimento);

        /// <summary>
        /// Delegate para atualizar o status do serviço
        /// </summary>
        /// <param name="servidor"></param>
        /// <param name="status"></param>
        delegate void VerificarStatusServicosThreadHandler(string servidor, RedeSistema.TipoStatusServico status);

        /// <summary>
        /// Atualizar Log em thread
        /// </summary>
        /// <param name="servidor">Servidor</param>
        /// <param name="log">Log</param>
        delegate void AtualizarLogThreadHandler(string servidor, string log);

        /// <summary>
        /// Objeto do processo de atualizcao
        /// </summary>
        ProcessoAtualizacao ObjAtualizacao = new ProcessoAtualizacao();

        /// <summary>
        /// Variavel que controla se esta ou não processando
        /// </summary>
        private bool _processando = false;

        /// <summary>
        /// Construtor
        /// </summary>
        public CtrlInstalacao()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Inicia os parametros da tela
        /// </summary>
        private void IniciarTela()
        {
            CarregarCombo();

            AssinarEventos();
        }

        /// <summary>
        /// Carrega os combos da tela
        /// </summary>
        private void CarregarCombo()
        {
            CmbServicos.DataSource = ConfiguracoesXML.RetornarServicos();
        }

        /// <summary>
        /// Assina os eventos do objeto
        /// </summary>
        private void AssinarEventos()
        {
            if (ObjAtualizacao == null) { return; }
            ObjAtualizacao.OnRejeicaoParametrosAtualizacao += ObjAtualizacao_OnRejeicaoParametrosAtualizacao;
            ObjAtualizacao.OnProcedimentoAtualizacao += ObjAtualizacao_OnProcedimentoAtualizacao;
            ObjAtualizacao.OnLogProcedimentoAtualizacao += ObjAtualizacao_OnLogProcedimentoAtualizacao;
            ObjAtualizacao.OnProcessoFinalizado += ObjAtualizacao_OnProcessoFinalizado;
            ObjAtualizacao.OnInformaStatusServico += ObjAtualizacao_OnInformaStatusServico;
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
                tabela.Rows.Add(new object[] { servidor, ImgsForm.Images[(int)Imagem.Excluir] });
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
        /// Remove os servidores de atualizacao
        /// </summary>
        private void RemoverServidores(int linha, int coluna)
        {
            RemoverItemGrid(GrdServidoresSelecionados, "RemoverServidor", linha, coluna);
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
        /// Adiciona os arquivos para 
        /// </summary>
        private void AdicionarArquivos()
        {
            string[] arquivos = SelecionarArquivos();

            if (arquivos == null || arquivos.Length == 0) { return; }

            AdicionarArquivosGrid(arquivos);
        }

        /// <summary>
        /// Realiza a selecao dos arquivos
        /// </summary>
        /// <returns></returns>
        private string[] SelecionarArquivos()
        {
            OpenFileDialog janela = new OpenFileDialog();
            janela.Multiselect = false;
            janela.Filter = "Arquivo compactado|*.zip|Arquivo de Registro do Windows|*.reg";

            if (janela.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                return janela.FileNames;
            }

            return null;
        }

        /// <summary>
        /// Adiciona os arquivos na grid
        /// </summary>
        private void AdicionarArquivosGrid(string[] arquivos)
        {
            if (GrdArquivos.DataSource == null) { GrdArquivos.DataSource = CriarDataTableArquivos(); }

            DataTable tabela = (DataTable)GrdArquivos.DataSource;

            foreach (string arquivo in arquivos)
            {
                if (tabela.AsEnumerable().Count(x => x.Field<string>("EnderecoCompleto") == arquivo) == 0)
                {
                    tabela.Rows.Add(new object[] { Path.GetFileName(arquivo), ImgsForm.Images[(int)Imagem.Excluir], arquivo });

                    //Informa o arquivo executavel do serviço
                    InformarExecutavelServico(arquivo);

                }
            }

        }

        /// <summary>
        /// Cria a tabela de arquivos para alimentar a estrutura da grid
        /// </summary>
        /// <returns>Retorna a tabela com a estrutura criada porem vazia</returns>
        private DataTable CriarDataTableArquivos()
        {
            DataTable tabela = new DataTable();

            tabela.Columns.Add("Arquivo", typeof(string));
            tabela.Columns.Add("Remover", typeof(Image));
            tabela.Columns.Add("EnderecoCompleto", typeof(string));

            return tabela;
        }

        /// <summary>
        /// Informa executavel do serviço
        /// </summary>
        /// <param name="arquivoZip">Arquivo zip para exploração</param>
        private void InformarExecutavelServico(string arquivoZip)
        {
            if (Path.GetExtension(arquivoZip) != ".zip") { return; }

            //Verifica o conteudo do zip
            List<string> arquivos = Utilidades.RetornaArquivoDentroZip(new FileInfo(arquivoZip));

            //Sugere executavel
            string arquivo = SugerirExecutavelServico(arquivos);

            if (!string.IsNullOrEmpty(arquivo)) { TxtExecutavelServico.Text = arquivo; }

        }

        /// <summary>
        /// Sugere um arquivo executavel
        /// </summary>
        /// <param name="arquivos"></param>
        /// <returns></returns>
        private string SugerirExecutavelServico(List<string> arquivos)
        {
            foreach (string arquivo in arquivos.Where(x => Path.GetExtension(x).Equals(".exe")))
            {
                string nomeArquivo = Path.GetFileName(arquivo);

                if (nomeArquivo.ToLower().Contains("srv")) { return nomeArquivo; }
                if (nomeArquivo.ToLower().Contains("serv")) { return nomeArquivo; }
                if (nomeArquivo.ToLower().Contains("reg")) { continue; }
                if (nomeArquivo.ToLower().Contains("admin")) { continue; }
                if (nomeArquivo.ToLower().Contains("adm")) { continue; }
            }

            string arquivoCompleto = arquivos.FirstOrDefault(x => Path.GetExtension(x).Equals(".exe"));

            return string.IsNullOrEmpty(arquivoCompleto) ? string.Empty : Path.GetFileName(arquivoCompleto);
        }

        /// <summary>
        /// Informa a pasta de destino
        /// </summary>
        private void SelecionarDiretorioDestino()
        {
            FolderBrowserDialog janela = new FolderBrowserDialog();
            janela.Description = "Selecione a pasta de destino";

            if (janela.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                TxtPastaDestino.Text = janela.SelectedPath;
            }
        }

        /// <summary>
        /// Remove os servidores de atualizacao
        /// </summary>
        private void RemoverArquivos(int linha, int coluna)
        {
            RemoverItemGrid(GrdArquivos, "Remover", linha, coluna);
        }

        /// <summary>
        /// Cria a estrutura da pasta de destino
        /// </summary>
        private void InformarPastaDestinoDescricao()
        {
            try
            {
                TxtPastaDestinoDescricao.Text = TxtPastaDestino.Text.Replace(Path.GetPathRoot(TxtPastaDestino.Text), string.Concat(@"\", @"\[Servidor]\c$\"));
            }
            catch (Exception)
            {
                TxtPastaDestinoDescricao.Text = TxtPastaDestino.Text;
            }
        }

        /// <summary>
        /// Inicia o processo de atualizacao
        /// </summary>
        private void IniciarAtualizacao()
        {
            string servico = CmbServicos.Text;
            List<string> servidores = RetornarServidores();
            List<string> arquivos = RetornarArquivos();
            string servicoExecutavel = TxtExecutavelServico.Text;
            string diretorioDestino = TxtPastaDestino.Text;
            string usuario = string.Empty; // TxtUsuario.Text;
            string senha = string.Empty; // TxtSenha.Text;

            usuario = "suporte";
            senha = "afv12mz";

            //Informa o processo de atualizacao
            InformarServidoresAtualizacao();

            HabilitarAtualizacao(false);

            if (ObjAtualizacao.AtualizarServidores(servico, servicoExecutavel, servidores, arquivos, diretorioDestino, usuario.Trim(), senha.Trim()))
            {
                _processando = true;
                TmrProcesso.Start();
            }
            else
            {
                HabilitarAtualizacao(true);
            }
        }

        /// <summary>
        /// Retorna a lista de servidores
        /// </summary>
        private List<string> RetornarServidores()
        {
            if (GrdServidoresSelecionados.DataSource == null) { return null; }

            DataTable tabela = (DataTable)GrdServidoresSelecionados.DataSource;

            return tabela.AsEnumerable().Select(x => x.Field<string>("Servidor")).ToList<string>();
        }

        /// <summary>
        /// Retorna a lista de arquivos
        /// </summary>
        private List<string> RetornarArquivos()
        {
            if (GrdArquivos.DataSource == null) { return null; }

            DataTable tabela = (DataTable)GrdArquivos.DataSource;

            return tabela.AsEnumerable().Select(x => x.Field<string>("EnderecoCompleto")).ToList<string>();
        }

        /// <summary>
        /// Carrega os servidores
        /// </summary>
        private void InformarServidoresAtualizacao()
        {
            ((DataGridViewImageColumn)GrdServidores.Columns["StatusAtualizacao"]).DefaultCellStyle.NullValue = null;
            ((DataGridViewImageColumn)GrdServidores.Columns["StatusServico"]).DefaultCellStyle.NullValue = null;
            GrdServidores.DataSource = CriaDataTableServidoresAtualizacao();
        }

        /// <summary>
        /// Informa servidores de atualizacao
        /// </summary>
        /// <returns>Retorna a tabela ja populada</returns>
        private DataTable CriaDataTableServidoresAtualizacao()
        {
            List<string> servidores;

            DataTable tabela = new DataTable();

            tabela.Columns.Add("StatusAtualizacao", typeof(Image));
            tabela.Columns.Add("Servidor", typeof(string));
            tabela.Columns.Add("StatusServico", typeof(Image));
            tabela.Columns.Add("Log", typeof(string));

            servidores = RetornarServidores();

            if (servidores != null)
            {
                //Retorna os servidores selecionados
                foreach (string servidor in servidores)
                {
                    StringBuilder sb = new StringBuilder();

                    sb.AppendLine(new string('-', 50));
                    sb.AppendLine("Processo de atualização");
                    sb.AppendLine("Servidor: " + servidor);
                    sb.AppendLine("Inicio: " + DateTime.Now.ToString("HH:mm:ss"));
                    sb.AppendLine(new string('-', 50));

                    tabela.Rows.Add(new object[] { null, servidor, null, sb.ToString() });
                }
            }

            return tabela;
        }

        /// <summary>
        /// Evento que informa o status do serviço
        /// </summary>
        /// <param name="servidor">Servidor</param>
        /// <param name="status">Status</param>
        void ObjAtualizacao_OnInformaStatusServico(string servidor, RedeSistema.TipoStatusServico status)
        {
            try
            {
                VerificarStatusServicosThread(servidor, status);
            }
            catch (Exception ex)
            {
                Utilidades.EnviarMensagem(ex.Message, Utilidades.TipoMensagem.Erro);
            }
        }

        /// <summary>
        /// Informa o status do serviço em thread
        /// </summary>
        /// <param name="servidor">Servidor</param>
        /// <param name="status">Status</param>
        private void VerificarStatusServicosThread(string servidor, RedeSistema.TipoStatusServico status)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new VerificarStatusServicosThreadHandler(VerificarStatusServicosThread), new object[] { servidor, status });
            }
            else
            {
                VerificarStatusServicos(servidor, status);
            }
        }

        /// <summary>
        /// Informa o status do serviço em thread
        /// </summary>
        /// <param name="servidor">Servidor</param>
        /// <param name="status">Status</param>
        private void VerificarStatusServicos(string servidor, RedeSistema.TipoStatusServico status)
        {
            if (GrdServidores.DataSource == null) { return; }

            foreach (DataGridViewRow linha in GrdServidores.Rows)
            {
                if (linha.Cells["ServidorProcessado"].Value.ToString().Equals(servidor))
                {
                    switch (status)
                    {
                        case RedeSistema.TipoStatusServico.Rodando:
                            linha.Cells["StatusServico"].Value = ImgsForm.Images[(int)Imagem.ServicoRodando];
                            break;
                        case RedeSistema.TipoStatusServico.Parado:
                            linha.Cells["StatusServico"].Value = ImgsForm.Images[(int)Imagem.ServicoParado];
                            break;
                        case RedeSistema.TipoStatusServico.NaoInstalado:
                            linha.Cells["StatusServico"].Value = null;
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Rejeicao
        /// </summary>
        /// <param name="rejeicoes"></param>
        void ObjAtualizacao_OnRejeicaoParametrosAtualizacao(List<ProcessoAtualizacao.RejeicaoParametrosAtualizacao> rejeicoes)
        {
            switch (rejeicoes[0])
            {
                case ProcessoAtualizacao.RejeicaoParametrosAtualizacao.ParametroUsuarioInvalido:
                    Utilidades.EnviarMensagem("O campo usuário possui preenchimento obrigatório", Utilidades.TipoMensagem.Advertencia);
                    //TxtUsuario.Focus();
                    break;
                case ProcessoAtualizacao.RejeicaoParametrosAtualizacao.ParametroSenhaInvalido:
                    Utilidades.EnviarMensagem("O campo senha possui preenchimento obrigatório", Utilidades.TipoMensagem.Advertencia);
                    //TxtSenha.Focus();
                    break;
                case ProcessoAtualizacao.RejeicaoParametrosAtualizacao.ListaServidoresInvalida:
                    Utilidades.EnviarMensagem("Favor selecionar um servidor", Utilidades.TipoMensagem.Advertencia);
                    LstServidores.Focus();
                    break;
                case ProcessoAtualizacao.RejeicaoParametrosAtualizacao.ListaArquivosInvalida:
                    Utilidades.EnviarMensagem("Favor selecionar um arquivo", Utilidades.TipoMensagem.Advertencia);
                    BtnAdicionarArquivos.Focus();
                    break;
                case ProcessoAtualizacao.RejeicaoParametrosAtualizacao.DiretorioInvalido:
                    Utilidades.EnviarMensagem("Diretorio de atualização invalido", Utilidades.TipoMensagem.Advertencia);
                    BtnPastaDestino.Focus();
                    break;
                case ProcessoAtualizacao.RejeicaoParametrosAtualizacao.ThreadEmAndamento:
                    Utilidades.EnviarMensagem("O processo de atualizacao já esta em andamento", Utilidades.TipoMensagem.Advertencia);
                    TxtLogAtualizacao.Focus();
                    break;
                case ProcessoAtualizacao.RejeicaoParametrosAtualizacao.ExtensaoServicoInvalida:
                    Utilidades.EnviarMensagem("A extensão do executavel do serviço deve ser exe.", Utilidades.TipoMensagem.Advertencia);
                    TxtExecutavelServico.Focus();
                    break;
            }
        }

        /// <summary>
        /// Informa a atualizacao dos servicos
        /// </summary>
        /// <param name="servidor"></param>
        /// <param name="procedimento"></param>
        void ObjAtualizacao_OnProcedimentoAtualizacao(string servidor, ProcessoAtualizacao.ProcedimentoAtualizacao procedimento)
        {
            try
            {
                AtualizarGrdServidoresThread(servidor, procedimento);
            }
            catch (Exception ex)
            {
                Utilidades.EnviarMensagem(ex.Message, Utilidades.TipoMensagem.Erro);
            }
        }

        /// <summary>
        /// Atualiza o status da atualizacao na grid de servidores em thread
        /// </summary>
        /// <param name="servidor">Servidor</param>
        /// <param name="procedimento">Procedimento</param>
        private void AtualizarGrdServidoresThread(string servidor, ProcessoAtualizacao.ProcedimentoAtualizacao procedimento)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new AtualizarGrdServidoresThreadHandler(AtualizarGrdServidoresThread), new object[] { servidor, procedimento });
            }
            else
            {
                AtualizarGrdServidores(servidor, procedimento);
            }
        }

        /// <summary>
        /// Atualiza o status da atualizacao na grid de servidores
        /// </summary>
        /// <param name="servidor">Servidor</param>
        /// <param name="procedimento">Procedimento</param>
        private void AtualizarGrdServidores(string servidor, ProcessoAtualizacao.ProcedimentoAtualizacao procedimento)
        {
            if (GrdServidores.DataSource == null) { return; }

            DataRow linha = ((DataTable)GrdServidores.DataSource).AsEnumerable().FirstOrDefault(x => x.Field<string>("Servidor") == servidor);

            if (linha == null) { return; }

            switch (procedimento)
            {
                case ProcessoAtualizacao.ProcedimentoAtualizacao.ErroGenerico:
                    linha["StatusAtualizacao"] = ImgsForm.Images[(int)Imagem.Erro];
                    //linha["StatusServico"] = ImgsForm.Images[(int)Imagem.Erro];
                    break;

                case ProcessoAtualizacao.ProcedimentoAtualizacao.TesteConexaoErro:
                    linha["StatusAtualizacao"] = ImgsForm.Images[(int)Imagem.Erro];
                    //linha["StatusServico"] = ImgsForm.Images[(int)Imagem.Erro];
                    break;

                case ProcessoAtualizacao.ProcedimentoAtualizacao.ServicoNaoLocalizado:
                    linha["StatusAtualizacao"] = ImgsForm.Images[(int)Imagem.Erro];
                    //linha["StatusServico"] = ImgsForm.Images[(int)Imagem.Erro];
                    break;

                case ProcessoAtualizacao.ProcedimentoAtualizacao.ServicoIncializado:
                    //linha["StatusServico"] = ImgsForm.Images[(int)Imagem.ServicoRodando];
                    break;

                case ProcessoAtualizacao.ProcedimentoAtualizacao.ServicoNaoInicializado:
                    linha["StatusAtualizacao"] = ImgsForm.Images[(int)Imagem.Erro];
                    //linha["StatusServico"] = ImgsForm.Images[(int)Imagem.Erro];

                    break;
                case ProcessoAtualizacao.ProcedimentoAtualizacao.ServicoParado:
                    //linha["StatusServico"] = ImgsForm.Images[(int)Imagem.ServicoParado];
                    break;

                case ProcessoAtualizacao.ProcedimentoAtualizacao.ServicoNaoParado:
                    linha["StatusAtualizacao"] = ImgsForm.Images[(int)Imagem.Erro];
                    //linha["StatusServico"] = ImgsForm.Images[(int)Imagem.Erro];
                    break;

                case ProcessoAtualizacao.ProcedimentoAtualizacao.ArquivosCopiadoErro:
                    linha["StatusAtualizacao"] = ImgsForm.Images[(int)Imagem.Erro];
                    break;

                case ProcessoAtualizacao.ProcedimentoAtualizacao.ServicoNaoInstalado:
                    linha["StatusAtualizacao"] = ImgsForm.Images[(int)Imagem.Erro];
                    //linha["StatusServico"] = ImgsForm.Images[(int)Imagem.Erro];
                    break;

                case ProcessoAtualizacao.ProcedimentoAtualizacao.AtualizacaoRealizadaSucesso:
                    linha["StatusAtualizacao"] = ImgsForm.Images[(int)Imagem.Processado];
                    break;
            }

            GrdServidores.Update();
            GrdServidores.Refresh();
        }

        /// <summary>
        /// Informa os logs que estao correndo
        /// </summary>
        /// <param name="servidor"></param>
        /// <param name="log"></param>
        void ObjAtualizacao_OnLogProcedimentoAtualizacao(string servidor, string log)
        {
            try
            {
                AtualizarLogThread(servidor, log);
            }
            catch (Exception ex)
            {
                Utilidades.EnviarMensagem(ex.Message, Utilidades.TipoMensagem.Erro);
            }
        }

        /// <summary>
        /// Atualizar log Thread
        /// </summary>
        /// <param name="servidor">Servidor</param>
        /// <param name="log">Log</param>
        private void AtualizarLogThread(string servidor, string log)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new AtualizarLogThreadHandler(AtualizarLogThread), new object[] { servidor, log });
            }
            else
            {
                AtualizarLog(servidor, log);
            }
        }

        /// <summary>
        /// Atualizar log Thread
        /// </summary>
        /// <param name="servidor">Servidor</param>
        /// <param name="log">Log</param>
        private void AtualizarLog(string servidor, string log)
        {
            if (GrdServidores.DataSource == null) { return; }

            DataRow linha = ((DataTable)GrdServidores.DataSource).AsEnumerable().FirstOrDefault(x => x.Field<string>("Servidor") == servidor);

            if (linha == null) { return; }

            linha["log"] += Environment.NewLine;
            linha["log"] += Environment.NewLine;
            linha["log"] += string.Format("   [{0}] " + log, DateTime.Now.ToString("HH:mm:ss"));

            if (GrdServidores.SelectedRows.Count > 0)
            {
                string sevidorSelecionado = ((DataRowView)GrdServidores.SelectedRows[0].DataBoundItem)["Servidor"].ToString();

                if (sevidorSelecionado == servidor) { TxtLogAtualizacao.Text = linha["log"].ToString(); }
            }
        }

        /// <summary>
        /// Informa que o processo de atualizacao foi parado
        /// </summary>
        void ObjAtualizacao_OnProcessoFinalizado()
        {
            _processando = false;
        }

        private void HabilitarRecursos()
        {
            TmrProcesso.Stop();

            if (_processando)
            {
                HabilitarAtualizacao(false);
                switch (BtnAtualizar.Text)
                {
                    case "Atualizando":
                        BtnAtualizar.Text = "Atualizando.";
                        break;

                    case "Atualizando.":
                        BtnAtualizar.Text = "Atualizando..";
                        break;

                    case "Atualizando..":
                        BtnAtualizar.Text = "Atualizando...";
                        break;

                    default:
                        BtnAtualizar.Text = "Atualizando";
                        break;
                }

                TmrProcesso.Start();
            }
            else
            {
                BtnAtualizar.Text = "Atualizar Arquivos";
                HabilitarAtualizacao(true);
                TmrProcesso.Stop();
            }
        }

        /// <summary>
        /// Habilita ou não o botão de atualizacao
        /// </summary>
        /// <param name="habilitar"></param>
        private void HabilitarAtualizacao(bool habilitar)
        {
            if (habilitar)
            {
                BtnAtualizar.Enabled = true;
                BtnAtualizar.BackColor = Color.LightGreen;
            }
            else
            {
                BtnAtualizar.Enabled = false;
                BtnAtualizar.BackColor = Color.LightGray;
            }
        }

        /// <summary>
        /// Abre a tela para editar o registro do windows
        /// </summary>
        private void AbrirEditorRegistroWindows()
        {
            if (string.IsNullOrEmpty(CmbServicos.Text) || CmbServicos.Text.Trim().Equals(string.Empty))
            {
                Utilidades.EnviarMensagem("Selecione um serviço para editar o registro", Utilidades.TipoMensagem.Advertencia);
                return;
            }

            if (CmbServicos.SelectedValue == null || string.IsNullOrEmpty(CmbServicos.SelectedValue.ToString().Trim()))
            {
                Utilidades.EnviarMensagem("O servico selecionado não possui configuração para editar o registro do windows", Utilidades.TipoMensagem.Advertencia);
                return;
            }

            //Abre o form de editor de registro
            using (FrmEditorRegistro form = new FrmEditorRegistro(CmbServicos.SelectedValue.ToString(), CmbServicos.Text))
            {
                form.ShowDialog();

                if (!string.IsNullOrEmpty(form.ArquivoRegistro))
                {
                    AdicionarArquivosGrid(new string[] { form.ArquivoRegistro });
                }

                CarregarCombo();

                CmbServicos.SelectedValue = form.RetornaChaveRaizRegistroWindows();
            }
        }



        /// <summary>
        /// Mostra o log na tela
        /// </summary>
        /// <param name="linha">Linha da grid</param>
        private void MostrarLog(int linha)
        {
            if (GrdServidores.Rows.Count == 0) { return; }
            if (linha == -1) { return; }
            TxtLogAtualizacao.Text = GrdServidores.Rows[linha].Cells["log"].Value.ToString();
        }

        #region Enuns

        enum Imagem
        {
            Excluir = 0,
            Processado = 1,
            Erro = 2,
            ServicoRodando = 3,
            ServicoParado = 4
        }

        #endregion

        #region Eventos

        /// <summary>
        /// Evento Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CtrlInstalacao_Load(object sender, EventArgs e)
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
        /// Botao Listar Servidores
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
        /// Botao Adicionar Servidores
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
        /// Remover o servidores
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
        /// Botao Editar Registros
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEditarRegistro_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                AbrirEditorRegistroWindows();
            }
            catch (Exception ex)
            {
                Utilidades.EnviarMensagem(ex.Message, Utilidades.TipoMensagem.Erro);
            }
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// Botao AdicionarArquivos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAdicionarArquivos_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                AdicionarArquivos();
            }
            catch (Exception ex)
            {
                Utilidades.EnviarMensagem(ex.Message, Utilidades.TipoMensagem.Erro);
            }
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// Click celula
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GrdArquivos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                RemoverArquivos(e.RowIndex, e.ColumnIndex);
            }
            catch (Exception ex)
            {
                Utilidades.EnviarMensagem(ex.Message, Utilidades.TipoMensagem.Erro);
            }
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// Botão Pasta de Destino
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPastaDestino_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                SelecionarDiretorioDestino();
            }
            catch (Exception ex)
            {
                Utilidades.EnviarMensagem(ex.Message, Utilidades.TipoMensagem.Erro);
            }
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// Botão Atualizar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAtualizar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                IniciarAtualizacao();
            }
            catch (Exception ex)
            {
                Utilidades.EnviarMensagem(ex.Message, Utilidades.TipoMensagem.Erro);
            }
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// Pastsa Destino text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtPastaDestino_TextChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                InformarPastaDestinoDescricao();
            }
            catch (Exception ex)
            {
                Utilidades.EnviarMensagem(ex.Message, Utilidades.TipoMensagem.Erro);
            }
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// Selecão da Linha
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GrdServidores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                MostrarLog(e.RowIndex);
            }
            catch (Exception ex)
            {
                Utilidades.EnviarMensagem(ex.Message, Utilidades.TipoMensagem.Erro);
            }
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// Timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TmrProcesso_Tick(object sender, EventArgs e)
        {
            try
            {
                HabilitarRecursos();
            }
            catch (Exception)
            {
            }
        }

        #endregion

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

    }
}
