namespace AtualizadorServico.Controles
{
    partial class CtrlPainelControle
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtrlPainelControle));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.CmbServicos = new System.Windows.Forms.ComboBox();
            this.GrdMonitoramento = new System.Windows.Forms.DataGridView();
            this.StatusAtualizacao = new System.Windows.Forms.DataGridViewImageColumn();
            this.ServidorProcessado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Filial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Versao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusServico = new System.Windows.Forms.DataGridViewImageColumn();
            this.Log = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NomeServico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DisplayServico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescricaoServico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IndexStatusServidor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Local = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.TxtLogAtualizacao = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TxtDescricaoServico = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnIniciarServico = new System.Windows.Forms.Button();
            this.ImgsForm = new System.Windows.Forms.ImageList(this.components);
            this.BtnPararServico = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.TxtLocal = new System.Windows.Forms.Label();
            this.TxtVersao = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtServico = new System.Windows.Forms.Label();
            this.TxtServicoDisplay = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.TxtFilial = new System.Windows.Forms.Label();
            this.TxtServidor = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnMonitoramento = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.GrdServidoresSelecionados = new System.Windows.Forms.DataGridView();
            this.Servidor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RemoverServidor = new System.Windows.Forms.DataGridViewImageColumn();
            this.BtnAdicionarServidores = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ChkMarcarTodos = new System.Windows.Forms.CheckBox();
            this.ChkServidorWindows = new System.Windows.Forms.CheckBox();
            this.ChkServidorNota = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.TxtServidorManual = new System.Windows.Forms.TextBox();
            this.LstServidores = new System.Windows.Forms.ListView();
            this.clmChk = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmServers = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BtnListarServidor = new System.Windows.Forms.Button();
            this.TxtFiltroServidor = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdMonitoramento)).BeginInit();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdServidoresSelecionados)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1024, 768);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.CmbServicos);
            this.panel3.Controls.Add(this.GrdMonitoramento);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Controls.Add(this.BtnMonitoramento);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(207, 3);
            this.panel3.Name = "panel3";
            this.tableLayoutPanel1.SetRowSpan(this.panel3, 2);
            this.panel3.Size = new System.Drawing.Size(814, 762);
            this.panel3.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Serviço:";
            // 
            // CmbServicos
            // 
            this.CmbServicos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CmbServicos.DisplayMember = "Servico";
            this.CmbServicos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbServicos.FormattingEnabled = true;
            this.CmbServicos.Items.AddRange(new object[] {
            "servAtuImpAD"});
            this.CmbServicos.Location = new System.Drawing.Point(55, 28);
            this.CmbServicos.Name = "CmbServicos";
            this.CmbServicos.Size = new System.Drawing.Size(756, 21);
            this.CmbServicos.TabIndex = 2;
            this.CmbServicos.ValueMember = "ChaveRegistro";
            // 
            // GrdMonitoramento
            // 
            this.GrdMonitoramento.AllowUserToAddRows = false;
            this.GrdMonitoramento.AllowUserToDeleteRows = false;
            this.GrdMonitoramento.AllowUserToResizeColumns = false;
            this.GrdMonitoramento.AllowUserToResizeRows = false;
            this.GrdMonitoramento.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GrdMonitoramento.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.GrdMonitoramento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.GrdMonitoramento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdMonitoramento.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StatusAtualizacao,
            this.ServidorProcessado,
            this.Filial,
            this.Versao,
            this.StatusServico,
            this.Log,
            this.NomeServico,
            this.DisplayServico,
            this.DescricaoServico,
            this.IndexStatusServidor,
            this.Local});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(216)))), ((int)(((byte)(216)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GrdMonitoramento.DefaultCellStyle = dataGridViewCellStyle9;
            this.GrdMonitoramento.Location = new System.Drawing.Point(3, 84);
            this.GrdMonitoramento.Name = "GrdMonitoramento";
            this.GrdMonitoramento.ReadOnly = true;
            this.GrdMonitoramento.RowHeadersVisible = false;
            this.GrdMonitoramento.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrdMonitoramento.Size = new System.Drawing.Size(808, 413);
            this.GrdMonitoramento.TabIndex = 4;
            this.GrdMonitoramento.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdMonitoramento_CellClick);
            this.GrdMonitoramento.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.GrdMonitoramento_RowsRemoved);
            this.GrdMonitoramento.SelectionChanged += new System.EventHandler(this.GrdMonitoramento_SelectionChanged);
            // 
            // StatusAtualizacao
            // 
            this.StatusAtualizacao.DataPropertyName = "StatusAtualizacao";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.NullValue = "System.Drawing.Bitmap";
            this.StatusAtualizacao.DefaultCellStyle = dataGridViewCellStyle6;
            this.StatusAtualizacao.HeaderText = "Status";
            this.StatusAtualizacao.Name = "StatusAtualizacao";
            this.StatusAtualizacao.ReadOnly = true;
            this.StatusAtualizacao.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.StatusAtualizacao.Width = 60;
            // 
            // ServidorProcessado
            // 
            this.ServidorProcessado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ServidorProcessado.DataPropertyName = "Servidor";
            this.ServidorProcessado.FillWeight = 50F;
            this.ServidorProcessado.HeaderText = "Servidor";
            this.ServidorProcessado.Name = "ServidorProcessado";
            this.ServidorProcessado.ReadOnly = true;
            this.ServidorProcessado.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Filial
            // 
            this.Filial.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Filial.DataPropertyName = "Filial";
            this.Filial.FillWeight = 50F;
            this.Filial.HeaderText = "Filial";
            this.Filial.Name = "Filial";
            this.Filial.ReadOnly = true;
            // 
            // Versao
            // 
            this.Versao.DataPropertyName = "Versao";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Versao.DefaultCellStyle = dataGridViewCellStyle7;
            this.Versao.HeaderText = "Versão";
            this.Versao.Name = "Versao";
            this.Versao.ReadOnly = true;
            // 
            // StatusServico
            // 
            this.StatusServico.DataPropertyName = "StatusServico";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.NullValue = "System.Drawing.Bitmap";
            this.StatusServico.DefaultCellStyle = dataGridViewCellStyle8;
            this.StatusServico.HeaderText = "Serviço";
            this.StatusServico.Name = "StatusServico";
            this.StatusServico.ReadOnly = true;
            this.StatusServico.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.StatusServico.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.StatusServico.Width = 60;
            // 
            // Log
            // 
            this.Log.DataPropertyName = "Log";
            this.Log.HeaderText = "Log";
            this.Log.Name = "Log";
            this.Log.ReadOnly = true;
            this.Log.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Log.Visible = false;
            // 
            // NomeServico
            // 
            this.NomeServico.DataPropertyName = "NomeServico";
            this.NomeServico.HeaderText = "NomeServico";
            this.NomeServico.Name = "NomeServico";
            this.NomeServico.ReadOnly = true;
            this.NomeServico.Visible = false;
            // 
            // DisplayServico
            // 
            this.DisplayServico.DataPropertyName = "DisplayServico";
            this.DisplayServico.HeaderText = "DisplayServico";
            this.DisplayServico.Name = "DisplayServico";
            this.DisplayServico.ReadOnly = true;
            this.DisplayServico.Visible = false;
            // 
            // DescricaoServico
            // 
            this.DescricaoServico.DataPropertyName = "DescricaoServico";
            this.DescricaoServico.HeaderText = "DescricaoServico";
            this.DescricaoServico.Name = "DescricaoServico";
            this.DescricaoServico.ReadOnly = true;
            this.DescricaoServico.Visible = false;
            // 
            // IndexStatusServidor
            // 
            this.IndexStatusServidor.DataPropertyName = "IndexStatusServidor";
            this.IndexStatusServidor.HeaderText = "IndexStatusServidor";
            this.IndexStatusServidor.Name = "IndexStatusServidor";
            this.IndexStatusServidor.ReadOnly = true;
            this.IndexStatusServidor.Visible = false;
            // 
            // Local
            // 
            this.Local.DataPropertyName = "Local";
            this.Local.HeaderText = "Local";
            this.Local.Name = "Local";
            this.Local.ReadOnly = true;
            this.Local.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutPanel3);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 503);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(814, 259);
            this.panel2.TabIndex = 4;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.groupBox3, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.groupBox2, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 85);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(808, 171);
            this.tableLayoutPanel3.TabIndex = 6;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.TxtLogAtualizacao);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(407, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(398, 165);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Log";
            // 
            // TxtLogAtualizacao
            // 
            this.TxtLogAtualizacao.BackColor = System.Drawing.Color.PapayaWhip;
            this.TxtLogAtualizacao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtLogAtualizacao.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtLogAtualizacao.Location = new System.Drawing.Point(3, 16);
            this.TxtLogAtualizacao.Multiline = true;
            this.TxtLogAtualizacao.Name = "TxtLogAtualizacao";
            this.TxtLogAtualizacao.ReadOnly = true;
            this.TxtLogAtualizacao.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtLogAtualizacao.Size = new System.Drawing.Size(392, 146);
            this.TxtLogAtualizacao.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TxtDescricaoServico);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(398, 165);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Descrição Serviço";
            // 
            // TxtDescricaoServico
            // 
            this.TxtDescricaoServico.BackColor = System.Drawing.SystemColors.Window;
            this.TxtDescricaoServico.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtDescricaoServico.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.TxtDescricaoServico.Location = new System.Drawing.Point(3, 16);
            this.TxtDescricaoServico.Multiline = true;
            this.TxtDescricaoServico.Name = "TxtDescricaoServico";
            this.TxtDescricaoServico.ReadOnly = true;
            this.TxtDescricaoServico.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtDescricaoServico.Size = new System.Drawing.Size(392, 146);
            this.TxtDescricaoServico.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.BtnIniciarServico);
            this.groupBox1.Controls.Add(this.BtnPararServico);
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Location = new System.Drawing.Point(6, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(802, 79);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Serviço";
            // 
            // BtnIniciarServico
            // 
            this.BtnIniciarServico.Enabled = false;
            this.BtnIniciarServico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnIniciarServico.ForeColor = System.Drawing.Color.DarkGray;
            this.BtnIniciarServico.ImageIndex = 0;
            this.BtnIniciarServico.ImageList = this.ImgsForm;
            this.BtnIniciarServico.Location = new System.Drawing.Point(6, 32);
            this.BtnIniciarServico.Name = "BtnIniciarServico";
            this.BtnIniciarServico.Size = new System.Drawing.Size(34, 23);
            this.BtnIniciarServico.TabIndex = 0;
            this.BtnIniciarServico.UseVisualStyleBackColor = true;
            this.BtnIniciarServico.Click += new System.EventHandler(this.BtnIniciarServico_Click);
            // 
            // ImgsForm
            // 
            this.ImgsForm.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImgsForm.ImageStream")));
            this.ImgsForm.TransparentColor = System.Drawing.Color.Transparent;
            this.ImgsForm.Images.SetKeyName(0, "Play-24.png");
            this.ImgsForm.Images.SetKeyName(1, "Stop-24.png");
            this.ImgsForm.Images.SetKeyName(2, "Connected-24.png");
            this.ImgsForm.Images.SetKeyName(3, "Disconnected-24.png");
            this.ImgsForm.Images.SetKeyName(4, "Delete-24.png");
            // 
            // BtnPararServico
            // 
            this.BtnPararServico.Enabled = false;
            this.BtnPararServico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPararServico.ForeColor = System.Drawing.Color.DarkGray;
            this.BtnPararServico.ImageIndex = 1;
            this.BtnPararServico.ImageList = this.ImgsForm;
            this.BtnPararServico.Location = new System.Drawing.Point(46, 32);
            this.BtnPararServico.Name = "BtnPararServico";
            this.BtnPararServico.Size = new System.Drawing.Size(34, 23);
            this.BtnPararServico.TabIndex = 1;
            this.BtnPararServico.UseVisualStyleBackColor = true;
            this.BtnPararServico.Click += new System.EventHandler(this.BtnPararServico_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 8;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.TxtLocal, 7, 1);
            this.tableLayoutPanel2.Controls.Add(this.TxtVersao, 7, 0);
            this.tableLayoutPanel2.Controls.Add(this.label8, 6, 1);
            this.tableLayoutPanel2.Controls.Add(this.label7, 6, 0);
            this.tableLayoutPanel2.Controls.Add(this.TxtServico, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.TxtServicoDisplay, 4, 1);
            this.tableLayoutPanel2.Controls.Add(this.label10, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.label9, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.TxtFilial, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.TxtServidor, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(102, 19);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(697, 54);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // TxtLocal
            // 
            this.TxtLocal.AutoSize = true;
            this.TxtLocal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtLocal.Location = new System.Drawing.Point(201, 27);
            this.TxtLocal.Name = "TxtLocal";
            this.TxtLocal.Size = new System.Drawing.Size(493, 27);
            this.TxtLocal.TabIndex = 11;
            this.TxtLocal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TxtVersao
            // 
            this.TxtVersao.AutoSize = true;
            this.TxtVersao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtVersao.Location = new System.Drawing.Point(201, 0);
            this.TxtVersao.Name = "TxtVersao";
            this.TxtVersao.Size = new System.Drawing.Size(493, 27);
            this.TxtVersao.TabIndex = 10;
            this.TxtVersao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(152, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 27);
            this.label8.TabIndex = 9;
            this.label8.Text = "Local:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(152, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 27);
            this.label7.TabIndex = 8;
            this.label7.Text = "Versão:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TxtServico
            // 
            this.TxtServico.AutoSize = true;
            this.TxtServico.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtServico.Location = new System.Drawing.Point(131, 0);
            this.TxtServico.Name = "TxtServico";
            this.TxtServico.Size = new System.Drawing.Size(1, 27);
            this.TxtServico.TabIndex = 3;
            this.TxtServico.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TxtServicoDisplay
            // 
            this.TxtServicoDisplay.AutoSize = true;
            this.TxtServicoDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtServicoDisplay.Location = new System.Drawing.Point(131, 27);
            this.TxtServicoDisplay.Name = "TxtServicoDisplay";
            this.TxtServicoDisplay.Size = new System.Drawing.Size(1, 27);
            this.TxtServicoDisplay.TabIndex = 7;
            this.TxtServicoDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Location = new System.Drawing.Point(79, 27);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 27);
            this.label10.TabIndex = 6;
            this.label10.Text = "Display:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(79, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 27);
            this.label9.TabIndex = 2;
            this.label9.Text = "Serviço:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TxtFilial
            // 
            this.TxtFilial.AutoSize = true;
            this.TxtFilial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtFilial.Location = new System.Drawing.Point(58, 27);
            this.TxtFilial.Name = "TxtFilial";
            this.TxtFilial.Size = new System.Drawing.Size(1, 27);
            this.TxtFilial.TabIndex = 5;
            this.TxtFilial.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TxtServidor
            // 
            this.TxtServidor.AutoSize = true;
            this.TxtServidor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtServidor.Location = new System.Drawing.Point(58, 0);
            this.TxtServidor.Name = "TxtServidor";
            this.TxtServidor.Size = new System.Drawing.Size(1, 27);
            this.TxtServidor.TabIndex = 1;
            this.TxtServidor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(3, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 27);
            this.label6.TabIndex = 4;
            this.label6.Text = "Filial:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 27);
            this.label2.TabIndex = 0;
            this.label2.Text = "Servidor:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BtnMonitoramento
            // 
            this.BtnMonitoramento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnMonitoramento.BackColor = System.Drawing.Color.LightGreen;
            this.BtnMonitoramento.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnMonitoramento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnMonitoramento.Location = new System.Drawing.Point(3, 55);
            this.BtnMonitoramento.Name = "BtnMonitoramento";
            this.BtnMonitoramento.Size = new System.Drawing.Size(808, 23);
            this.BtnMonitoramento.TabIndex = 3;
            this.BtnMonitoramento.Text = "Iniciar Monitoramento";
            this.BtnMonitoramento.UseVisualStyleBackColor = false;
            this.BtnMonitoramento.Click += new System.EventHandler(this.BtnIniciarMonitoramento_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.SteelBlue;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(814, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "MONITORAMENTO";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.GrdServidoresSelecionados);
            this.panel4.Controls.Add(this.BtnAdicionarServidores);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 387);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(198, 378);
            this.panel4.TabIndex = 2;
            // 
            // GrdServidoresSelecionados
            // 
            this.GrdServidoresSelecionados.AllowUserToAddRows = false;
            this.GrdServidoresSelecionados.AllowUserToDeleteRows = false;
            this.GrdServidoresSelecionados.AllowUserToResizeColumns = false;
            this.GrdServidoresSelecionados.AllowUserToResizeRows = false;
            this.GrdServidoresSelecionados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GrdServidoresSelecionados.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.GrdServidoresSelecionados.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.GrdServidoresSelecionados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdServidoresSelecionados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Servidor,
            this.RemoverServidor});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.PowderBlue;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GrdServidoresSelecionados.DefaultCellStyle = dataGridViewCellStyle10;
            this.GrdServidoresSelecionados.GridColor = System.Drawing.SystemColors.ControlLightLight;
            this.GrdServidoresSelecionados.Location = new System.Drawing.Point(3, 32);
            this.GrdServidoresSelecionados.MultiSelect = false;
            this.GrdServidoresSelecionados.Name = "GrdServidoresSelecionados";
            this.GrdServidoresSelecionados.ReadOnly = true;
            this.GrdServidoresSelecionados.RowHeadersVisible = false;
            this.GrdServidoresSelecionados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.GrdServidoresSelecionados.Size = new System.Drawing.Size(192, 343);
            this.GrdServidoresSelecionados.TabIndex = 1;
            this.GrdServidoresSelecionados.TabStop = false;
            this.GrdServidoresSelecionados.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdServidoresSelecionados_CellClick);
            // 
            // Servidor
            // 
            this.Servidor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Servidor.DataPropertyName = "Servidor";
            this.Servidor.HeaderText = "Servidor Selecionado";
            this.Servidor.Name = "Servidor";
            this.Servidor.ReadOnly = true;
            this.Servidor.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // RemoverServidor
            // 
            this.RemoverServidor.DataPropertyName = "Remover";
            this.RemoverServidor.HeaderText = "";
            this.RemoverServidor.Name = "RemoverServidor";
            this.RemoverServidor.ReadOnly = true;
            this.RemoverServidor.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.RemoverServidor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.RemoverServidor.Width = 25;
            // 
            // BtnAdicionarServidores
            // 
            this.BtnAdicionarServidores.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnAdicionarServidores.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnAdicionarServidores.Location = new System.Drawing.Point(3, 3);
            this.BtnAdicionarServidores.Name = "BtnAdicionarServidores";
            this.BtnAdicionarServidores.Size = new System.Drawing.Size(192, 23);
            this.BtnAdicionarServidores.TabIndex = 0;
            this.BtnAdicionarServidores.Text = "Adicionar Servidores";
            this.BtnAdicionarServidores.UseVisualStyleBackColor = true;
            this.BtnAdicionarServidores.Click += new System.EventHandler(this.BtnAdicionarServidores_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ChkMarcarTodos);
            this.panel1.Controls.Add(this.ChkServidorWindows);
            this.panel1.Controls.Add(this.ChkServidorNota);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.TxtServidorManual);
            this.panel1.Controls.Add(this.LstServidores);
            this.panel1.Controls.Add(this.BtnListarServidor);
            this.panel1.Controls.Add(this.TxtFiltroServidor);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(198, 378);
            this.panel1.TabIndex = 1;
            // 
            // ChkMarcarTodos
            // 
            this.ChkMarcarTodos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ChkMarcarTodos.AutoSize = true;
            this.ChkMarcarTodos.Location = new System.Drawing.Point(3, 319);
            this.ChkMarcarTodos.Name = "ChkMarcarTodos";
            this.ChkMarcarTodos.Size = new System.Drawing.Size(162, 17);
            this.ChkMarcarTodos.TabIndex = 7;
            this.ChkMarcarTodos.Text = "Selecionar Todos Servidores";
            this.ChkMarcarTodos.UseVisualStyleBackColor = true;
            this.ChkMarcarTodos.CheckedChanged += new System.EventHandler(this.ChkMarcarTodos_CheckedChanged);
            // 
            // ChkServidorWindows
            // 
            this.ChkServidorWindows.AutoSize = true;
            this.ChkServidorWindows.Location = new System.Drawing.Point(3, 77);
            this.ChkServidorWindows.Name = "ChkServidorWindows";
            this.ChkServidorWindows.Size = new System.Drawing.Size(123, 17);
            this.ChkServidorWindows.TabIndex = 4;
            this.ChkServidorWindows.Text = "Servidores Windows";
            this.ChkServidorWindows.UseVisualStyleBackColor = true;
            // 
            // ChkServidorNota
            // 
            this.ChkServidorNota.AutoSize = true;
            this.ChkServidorNota.Location = new System.Drawing.Point(3, 54);
            this.ChkServidorNota.Name = "ChkServidorNota";
            this.ChkServidorNota.Size = new System.Drawing.Size(102, 17);
            this.ChkServidorNota.TabIndex = 3;
            this.ChkServidorNota.Text = "Servidores Nota";
            this.ChkServidorNota.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(0, 339);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(24, 13);
            this.label11.TabIndex = 8;
            this.label11.Text = "Ou:";
            // 
            // TxtServidorManual
            // 
            this.TxtServidorManual.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtServidorManual.Location = new System.Drawing.Point(3, 355);
            this.TxtServidorManual.Name = "TxtServidorManual";
            this.TxtServidorManual.Size = new System.Drawing.Size(192, 20);
            this.TxtServidorManual.TabIndex = 9;
            // 
            // LstServidores
            // 
            this.LstServidores.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LstServidores.CheckBoxes = true;
            this.LstServidores.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmChk,
            this.clmServers});
            this.LstServidores.FullRowSelect = true;
            this.LstServidores.GridLines = true;
            this.LstServidores.Location = new System.Drawing.Point(3, 129);
            this.LstServidores.Name = "LstServidores";
            this.LstServidores.Size = new System.Drawing.Size(192, 184);
            this.LstServidores.TabIndex = 6;
            this.LstServidores.UseCompatibleStateImageBehavior = false;
            this.LstServidores.View = System.Windows.Forms.View.Details;
            // 
            // clmChk
            // 
            this.clmChk.Text = "";
            this.clmChk.Width = 30;
            // 
            // clmServers
            // 
            this.clmServers.Text = "Servidores Encontrados";
            this.clmServers.Width = 155;
            // 
            // BtnListarServidor
            // 
            this.BtnListarServidor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnListarServidor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnListarServidor.Location = new System.Drawing.Point(3, 100);
            this.BtnListarServidor.Name = "BtnListarServidor";
            this.BtnListarServidor.Size = new System.Drawing.Size(192, 23);
            this.BtnListarServidor.TabIndex = 5;
            this.BtnListarServidor.Text = "Listar Servidores";
            this.BtnListarServidor.UseVisualStyleBackColor = true;
            this.BtnListarServidor.Click += new System.EventHandler(this.BtnListarServidor_Click);
            // 
            // TxtFiltroServidor
            // 
            this.TxtFiltroServidor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtFiltroServidor.Location = new System.Drawing.Point(44, 28);
            this.TxtFiltroServidor.Name = "TxtFiltroServidor";
            this.TxtFiltroServidor.Size = new System.Drawing.Size(151, 20);
            this.TxtFiltroServidor.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Filtro:";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "SERVIDORES";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CtrlPainelControle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "CtrlPainelControle";
            this.Size = new System.Drawing.Size(1024, 768);
            this.Load += new System.EventHandler(this.CtrlPainelControle_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdMonitoramento)).EndInit();
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdServidoresSelecionados)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox TxtServidorManual;
        private System.Windows.Forms.ListView LstServidores;
        private System.Windows.Forms.ColumnHeader clmChk;
        private System.Windows.Forms.ColumnHeader clmServers;
        private System.Windows.Forms.Button BtnListarServidor;
        private System.Windows.Forms.TextBox TxtFiltroServidor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView GrdServidoresSelecionados;
        private System.Windows.Forms.DataGridViewTextBoxColumn Servidor;
        private System.Windows.Forms.DataGridViewImageColumn RemoverServidor;
        private System.Windows.Forms.Button BtnAdicionarServidores;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView GrdMonitoramento;
        private System.Windows.Forms.Button BtnMonitoramento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CmbServicos;
        private System.Windows.Forms.ImageList ImgsForm;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BtnIniciarServico;
        private System.Windows.Forms.Button BtnPararServico;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label TxtServico;
        private System.Windows.Forms.Label TxtServicoDisplay;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label TxtFilial;
        private System.Windows.Forms.Label TxtServidor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox TxtLogAtualizacao;
        private System.Windows.Forms.TextBox TxtDescricaoServico;
        private System.Windows.Forms.CheckBox ChkServidorWindows;
        private System.Windows.Forms.CheckBox ChkServidorNota;
        private System.Windows.Forms.CheckBox ChkMarcarTodos;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label TxtLocal;
        private System.Windows.Forms.Label TxtVersao;
        private System.Windows.Forms.DataGridViewImageColumn StatusAtualizacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServidorProcessado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Filial;
        private System.Windows.Forms.DataGridViewTextBoxColumn Versao;
        private System.Windows.Forms.DataGridViewImageColumn StatusServico;
        private System.Windows.Forms.DataGridViewTextBoxColumn Log;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomeServico;
        private System.Windows.Forms.DataGridViewTextBoxColumn DisplayServico;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescricaoServico;
        private System.Windows.Forms.DataGridViewTextBoxColumn IndexStatusServidor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Local;

    }
}
