namespace AtualizadorServico.Controles
{
    partial class CtrlInstalacao
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtrlInstalacao));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.GrdServidores = new System.Windows.Forms.DataGridView();
            this.StatusAtualizacao = new System.Windows.Forms.DataGridViewImageColumn();
            this.ServidorProcessado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusServico = new System.Windows.Forms.DataGridViewImageColumn();
            this.Log = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnAtualizar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtPastaDestinoDescricao = new System.Windows.Forms.TextBox();
            this.TxtPastaDestino = new System.Windows.Forms.TextBox();
            this.BtnPastaDestino = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.TxtExecutavelServico = new System.Windows.Forms.TextBox();
            this.GrdArquivos = new System.Windows.Forms.DataGridView();
            this.Arquivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remover = new System.Windows.Forms.DataGridViewImageColumn();
            this.EnderecoCompleto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnEditarRegistro = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.BtnAdicionarArquivos = new System.Windows.Forms.Button();
            this.CmbServicos = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
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
            this.panel4 = new System.Windows.Forms.Panel();
            this.GrdServidoresSelecionados = new System.Windows.Forms.DataGridView();
            this.Servidor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RemoverServidor = new System.Windows.Forms.DataGridViewImageColumn();
            this.BtnAdicionarServidores = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.TxtLogAtualizacao = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ImgsForm = new System.Windows.Forms.ImageList(this.components);
            this.TmrProcesso = new System.Windows.Forms.Timer(this.components);
            this.ChkMarcarTodos = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdServidores)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdArquivos)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdServidoresSelecionados)).BeginInit();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1024, 768);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.GrdServidores);
            this.panel3.Controls.Add(this.BtnAtualizar);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(514, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(507, 378);
            this.panel3.TabIndex = 2;
            // 
            // GrdServidores
            // 
            this.GrdServidores.AllowUserToAddRows = false;
            this.GrdServidores.AllowUserToDeleteRows = false;
            this.GrdServidores.AllowUserToResizeColumns = false;
            this.GrdServidores.AllowUserToResizeRows = false;
            this.GrdServidores.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GrdServidores.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.GrdServidores.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.GrdServidores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdServidores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StatusAtualizacao,
            this.ServidorProcessado,
            this.StatusServico,
            this.Log});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(216)))), ((int)(((byte)(216)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GrdServidores.DefaultCellStyle = dataGridViewCellStyle10;
            this.GrdServidores.Location = new System.Drawing.Point(3, 57);
            this.GrdServidores.Name = "GrdServidores";
            this.GrdServidores.ReadOnly = true;
            this.GrdServidores.RowHeadersVisible = false;
            this.GrdServidores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrdServidores.Size = new System.Drawing.Size(501, 318);
            this.GrdServidores.TabIndex = 2;
            this.GrdServidores.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdServidores_CellClick);
            // 
            // StatusAtualizacao
            // 
            this.StatusAtualizacao.DataPropertyName = "StatusAtualizacao";
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
            this.ServidorProcessado.HeaderText = "Servidor";
            this.ServidorProcessado.Name = "ServidorProcessado";
            this.ServidorProcessado.ReadOnly = true;
            this.ServidorProcessado.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // StatusServico
            // 
            this.StatusServico.DataPropertyName = "StatusServico";
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
            // BtnAtualizar
            // 
            this.BtnAtualizar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnAtualizar.BackColor = System.Drawing.Color.LightGreen;
            this.BtnAtualizar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnAtualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAtualizar.Location = new System.Drawing.Point(3, 28);
            this.BtnAtualizar.Name = "BtnAtualizar";
            this.BtnAtualizar.Size = new System.Drawing.Size(501, 23);
            this.BtnAtualizar.TabIndex = 1;
            this.BtnAtualizar.Text = "Atualizar Arquivos";
            this.BtnAtualizar.UseVisualStyleBackColor = false;
            this.BtnAtualizar.Click += new System.EventHandler(this.BtnAtualizar_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.SteelBlue;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(507, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "DADOS DA ATUALIZAÇÃO";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(207, 3);
            this.panel2.Name = "panel2";
            this.tableLayoutPanel1.SetRowSpan(this.panel2, 2);
            this.panel2.Size = new System.Drawing.Size(301, 762);
            this.panel2.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.TxtPastaDestinoDescricao);
            this.groupBox2.Controls.Add(this.TxtPastaDestino);
            this.groupBox2.Controls.Add(this.BtnPastaDestino);
            this.groupBox2.Location = new System.Drawing.Point(3, 635);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(295, 124);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Diretório de Destino";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 84);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Diretório de Gravação:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Exemplo:";
            // 
            // TxtPastaDestinoDescricao
            // 
            this.TxtPastaDestinoDescricao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtPastaDestinoDescricao.BackColor = System.Drawing.Color.PapayaWhip;
            this.TxtPastaDestinoDescricao.Location = new System.Drawing.Point(6, 100);
            this.TxtPastaDestinoDescricao.Name = "TxtPastaDestinoDescricao";
            this.TxtPastaDestinoDescricao.ReadOnly = true;
            this.TxtPastaDestinoDescricao.Size = new System.Drawing.Size(283, 20);
            this.TxtPastaDestinoDescricao.TabIndex = 2;
            // 
            // TxtPastaDestino
            // 
            this.TxtPastaDestino.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtPastaDestino.Location = new System.Drawing.Point(6, 61);
            this.TxtPastaDestino.Name = "TxtPastaDestino";
            this.TxtPastaDestino.Size = new System.Drawing.Size(283, 20);
            this.TxtPastaDestino.TabIndex = 1;
            this.TxtPastaDestino.TextChanged += new System.EventHandler(this.TxtPastaDestino_TextChanged);
            // 
            // BtnPastaDestino
            // 
            this.BtnPastaDestino.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnPastaDestino.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnPastaDestino.Location = new System.Drawing.Point(6, 19);
            this.BtnPastaDestino.Name = "BtnPastaDestino";
            this.BtnPastaDestino.Size = new System.Drawing.Size(283, 23);
            this.BtnPastaDestino.TabIndex = 0;
            this.BtnPastaDestino.Text = "Localizar Diretório";
            this.BtnPastaDestino.UseVisualStyleBackColor = true;
            this.BtnPastaDestino.Click += new System.EventHandler(this.BtnPastaDestino_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.TxtExecutavelServico);
            this.groupBox1.Controls.Add(this.GrdArquivos);
            this.groupBox1.Controls.Add(this.BtnEditarRegistro);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.BtnAdicionarArquivos);
            this.groupBox1.Controls.Add(this.CmbServicos);
            this.groupBox1.Location = new System.Drawing.Point(6, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(292, 601);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Arquivos";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 559);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(117, 13);
            this.label12.TabIndex = 5;
            this.label12.Text = "Executavel do Serviço:";
            // 
            // TxtExecutavelServico
            // 
            this.TxtExecutavelServico.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtExecutavelServico.Location = new System.Drawing.Point(3, 575);
            this.TxtExecutavelServico.Name = "TxtExecutavelServico";
            this.TxtExecutavelServico.Size = new System.Drawing.Size(283, 20);
            this.TxtExecutavelServico.TabIndex = 6;
            // 
            // GrdArquivos
            // 
            this.GrdArquivos.AllowUserToAddRows = false;
            this.GrdArquivos.AllowUserToDeleteRows = false;
            this.GrdArquivos.AllowUserToResizeColumns = false;
            this.GrdArquivos.AllowUserToResizeRows = false;
            this.GrdArquivos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GrdArquivos.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.GrdArquivos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.GrdArquivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdArquivos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Arquivo,
            this.Remover,
            this.EnderecoCompleto});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.PowderBlue;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GrdArquivos.DefaultCellStyle = dataGridViewCellStyle11;
            this.GrdArquivos.GridColor = System.Drawing.SystemColors.ControlLightLight;
            this.GrdArquivos.Location = new System.Drawing.Point(6, 104);
            this.GrdArquivos.MultiSelect = false;
            this.GrdArquivos.Name = "GrdArquivos";
            this.GrdArquivos.ReadOnly = true;
            this.GrdArquivos.RowHeadersVisible = false;
            this.GrdArquivos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.GrdArquivos.Size = new System.Drawing.Size(280, 452);
            this.GrdArquivos.TabIndex = 4;
            this.GrdArquivos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdArquivos_CellClick);
            // 
            // Arquivo
            // 
            this.Arquivo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Arquivo.DataPropertyName = "Arquivo";
            this.Arquivo.HeaderText = "Arquivo";
            this.Arquivo.Name = "Arquivo";
            this.Arquivo.ReadOnly = true;
            this.Arquivo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Remover
            // 
            this.Remover.DataPropertyName = "Remover";
            this.Remover.HeaderText = "";
            this.Remover.Name = "Remover";
            this.Remover.ReadOnly = true;
            this.Remover.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Remover.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Remover.Width = 25;
            // 
            // EnderecoCompleto
            // 
            this.EnderecoCompleto.DataPropertyName = "EnderecoCompleto";
            this.EnderecoCompleto.HeaderText = "";
            this.EnderecoCompleto.Name = "EnderecoCompleto";
            this.EnderecoCompleto.ReadOnly = true;
            this.EnderecoCompleto.Visible = false;
            // 
            // BtnEditarRegistro
            // 
            this.BtnEditarRegistro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnEditarRegistro.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnEditarRegistro.Location = new System.Drawing.Point(6, 46);
            this.BtnEditarRegistro.Name = "BtnEditarRegistro";
            this.BtnEditarRegistro.Size = new System.Drawing.Size(280, 23);
            this.BtnEditarRegistro.TabIndex = 2;
            this.BtnEditarRegistro.Text = "Editar Registro do Windows";
            this.BtnEditarRegistro.UseVisualStyleBackColor = true;
            this.BtnEditarRegistro.Click += new System.EventHandler(this.BtnEditarRegistro_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Serviço:";
            // 
            // BtnAdicionarArquivos
            // 
            this.BtnAdicionarArquivos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnAdicionarArquivos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnAdicionarArquivos.Location = new System.Drawing.Point(6, 75);
            this.BtnAdicionarArquivos.Name = "BtnAdicionarArquivos";
            this.BtnAdicionarArquivos.Size = new System.Drawing.Size(280, 23);
            this.BtnAdicionarArquivos.TabIndex = 3;
            this.BtnAdicionarArquivos.Text = "Adicionar Arquivos";
            this.BtnAdicionarArquivos.UseVisualStyleBackColor = true;
            this.BtnAdicionarArquivos.Click += new System.EventHandler(this.BtnAdicionarArquivos_Click);
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
            this.CmbServicos.Location = new System.Drawing.Point(58, 19);
            this.CmbServicos.Name = "CmbServicos";
            this.CmbServicos.Size = new System.Drawing.Size(228, 21);
            this.CmbServicos.TabIndex = 1;
            this.CmbServicos.ValueMember = "ChaveRegistro";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.SteelBlue;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(301, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "SERVIÇO";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.panel1.TabIndex = 0;
            // 
            // ChkServidorWindows
            // 
            this.ChkServidorWindows.AutoSize = true;
            this.ChkServidorWindows.Location = new System.Drawing.Point(3, 77);
            this.ChkServidorWindows.Name = "ChkServidorWindows";
            this.ChkServidorWindows.Size = new System.Drawing.Size(123, 17);
            this.ChkServidorWindows.TabIndex = 9;
            this.ChkServidorWindows.Text = "Servidores Windows";
            this.ChkServidorWindows.UseVisualStyleBackColor = true;
            // 
            // ChkServidorNota
            // 
            this.ChkServidorNota.AutoSize = true;
            this.ChkServidorNota.Location = new System.Drawing.Point(3, 54);
            this.ChkServidorNota.Name = "ChkServidorNota";
            this.ChkServidorNota.Size = new System.Drawing.Size(102, 17);
            this.ChkServidorNota.TabIndex = 8;
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
            this.label11.TabIndex = 4;
            this.label11.Text = "Ou:";
            // 
            // TxtServidorManual
            // 
            this.TxtServidorManual.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtServidorManual.Location = new System.Drawing.Point(3, 355);
            this.TxtServidorManual.Name = "TxtServidorManual";
            this.TxtServidorManual.Size = new System.Drawing.Size(192, 20);
            this.TxtServidorManual.TabIndex = 5;
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
            this.LstServidores.TabIndex = 3;
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
            this.BtnListarServidor.TabIndex = 2;
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
            this.TxtFiltroServidor.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 0;
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
            // panel4
            // 
            this.panel4.Controls.Add(this.GrdServidoresSelecionados);
            this.panel4.Controls.Add(this.BtnAdicionarServidores);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 387);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(198, 378);
            this.panel4.TabIndex = 0;
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
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.PowderBlue;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GrdServidoresSelecionados.DefaultCellStyle = dataGridViewCellStyle12;
            this.GrdServidoresSelecionados.GridColor = System.Drawing.SystemColors.ControlLightLight;
            this.GrdServidoresSelecionados.Location = new System.Drawing.Point(3, 32);
            this.GrdServidoresSelecionados.MultiSelect = false;
            this.GrdServidoresSelecionados.Name = "GrdServidoresSelecionados";
            this.GrdServidoresSelecionados.ReadOnly = true;
            this.GrdServidoresSelecionados.RowHeadersVisible = false;
            this.GrdServidoresSelecionados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.GrdServidoresSelecionados.Size = new System.Drawing.Size(192, 343);
            this.GrdServidoresSelecionados.TabIndex = 3;
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
            // panel5
            // 
            this.panel5.Controls.Add(this.TxtLogAtualizacao);
            this.panel5.Controls.Add(this.label6);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(514, 387);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(507, 378);
            this.panel5.TabIndex = 4;
            // 
            // TxtLogAtualizacao
            // 
            this.TxtLogAtualizacao.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtLogAtualizacao.BackColor = System.Drawing.Color.PapayaWhip;
            this.TxtLogAtualizacao.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtLogAtualizacao.Location = new System.Drawing.Point(3, 19);
            this.TxtLogAtualizacao.Multiline = true;
            this.TxtLogAtualizacao.Name = "TxtLogAtualizacao";
            this.TxtLogAtualizacao.ReadOnly = true;
            this.TxtLogAtualizacao.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtLogAtualizacao.Size = new System.Drawing.Size(501, 356);
            this.TxtLogAtualizacao.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Log de Atualização";
            // 
            // ImgsForm
            // 
            this.ImgsForm.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImgsForm.ImageStream")));
            this.ImgsForm.TransparentColor = System.Drawing.Color.Transparent;
            this.ImgsForm.Images.SetKeyName(0, "Delete-24.png");
            this.ImgsForm.Images.SetKeyName(1, "Checkmark-26 (1).png");
            this.ImgsForm.Images.SetKeyName(2, "Delete-26.png");
            this.ImgsForm.Images.SetKeyName(3, "Play-24.png");
            this.ImgsForm.Images.SetKeyName(4, "Stop-24.png");
            // 
            // TmrProcesso
            // 
            this.TmrProcesso.Interval = 1000;
            this.TmrProcesso.Tick += new System.EventHandler(this.TmrProcesso_Tick);
            // 
            // ChkMarcarTodos
            // 
            this.ChkMarcarTodos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ChkMarcarTodos.AutoSize = true;
            this.ChkMarcarTodos.Location = new System.Drawing.Point(3, 319);
            this.ChkMarcarTodos.Name = "ChkMarcarTodos";
            this.ChkMarcarTodos.Size = new System.Drawing.Size(162, 17);
            this.ChkMarcarTodos.TabIndex = 10;
            this.ChkMarcarTodos.Text = "Selecionar Todos Servidores";
            this.ChkMarcarTodos.UseVisualStyleBackColor = true;
            this.ChkMarcarTodos.CheckedChanged += new System.EventHandler(this.ChkMarcarTodos_CheckedChanged);
            // 
            // CtrlInstalacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "CtrlInstalacao";
            this.Size = new System.Drawing.Size(1024, 768);
            this.Load += new System.EventHandler(this.CtrlInstalacao_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdServidores)).EndInit();
            this.panel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdArquivos)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdServidoresSelecionados)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView GrdServidores;
        private System.Windows.Forms.DataGridViewImageColumn StatusAtualizacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServidorProcessado;
        private System.Windows.Forms.DataGridViewImageColumn StatusServico;
        private System.Windows.Forms.DataGridViewTextBoxColumn Log;
        private System.Windows.Forms.Button BtnAtualizar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TxtPastaDestinoDescricao;
        private System.Windows.Forms.TextBox TxtPastaDestino;
        private System.Windows.Forms.Button BtnPastaDestino;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox TxtExecutavelServico;
        private System.Windows.Forms.DataGridView GrdArquivos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Arquivo;
        private System.Windows.Forms.DataGridViewImageColumn Remover;
        private System.Windows.Forms.DataGridViewTextBoxColumn EnderecoCompleto;
        private System.Windows.Forms.Button BtnEditarRegistro;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BtnAdicionarArquivos;
        private System.Windows.Forms.ComboBox CmbServicos;
        private System.Windows.Forms.Label label2;
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
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox TxtLogAtualizacao;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ImageList ImgsForm;
        private System.Windows.Forms.Timer TmrProcesso;
        private System.Windows.Forms.CheckBox ChkServidorWindows;
        private System.Windows.Forms.CheckBox ChkServidorNota;
        private System.Windows.Forms.CheckBox ChkMarcarTodos;
    }
}
