namespace AtualizadorServico.Forms
{
    partial class FrmEditorRegistro
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEditorRegistro));
            this.MnuPrincipal = new System.Windows.Forms.MenuStrip();
            this.MnuNovo = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuNovaChave = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuNovaCadeiaCaracteres = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuEditar = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuEditarChave = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuEditarCadeiaCaracteres = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuExcluir = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuExcluirChave = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuExcluirCadeiaCaracteres = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuExportar = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuExportarArquivoRegistro = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuExportarAtualizadorServico = new System.Windows.Forms.ToolStripMenuItem();
            this.arquivoDeConfiguraçãoXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuSair = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.MnuChaveRegistro = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.TrvChaves = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.GrdValores = new System.Windows.Forms.DataGridView();
            this.Imamge = new System.Windows.Forms.DataGridViewImageColumn();
            this.Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dados = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MnuTrvChaves = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.renomearChaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuTrvChavesNovoChave = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuTrvChavesNovoCadeiaCaracteres = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MnuTrvChavesRenomear = new System.Windows.Forms.ToolStripMenuItem();
            this.removerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuGrdValores = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.adicionarCadeiaDeCaracteresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarCadeiaDeCaracteresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removerCadeiaDeCaracteresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuPrincipal.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdValores)).BeginInit();
            this.MnuTrvChaves.SuspendLayout();
            this.MnuGrdValores.SuspendLayout();
            this.SuspendLayout();
            // 
            // MnuPrincipal
            // 
            this.MnuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuNovo,
            this.MnuEditar,
            this.MnuExcluir,
            this.MnuExportar,
            this.MnuSair});
            this.MnuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.MnuPrincipal.Name = "MnuPrincipal";
            this.MnuPrincipal.Size = new System.Drawing.Size(784, 24);
            this.MnuPrincipal.TabIndex = 0;
            this.MnuPrincipal.Text = "menuStrip1";
            // 
            // MnuNovo
            // 
            this.MnuNovo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuNovaChave,
            this.MnuNovaCadeiaCaracteres});
            this.MnuNovo.Image = ((System.Drawing.Image)(resources.GetObject("MnuNovo.Image")));
            this.MnuNovo.Name = "MnuNovo";
            this.MnuNovo.Size = new System.Drawing.Size(64, 20);
            this.MnuNovo.Text = "Novo";
            // 
            // MnuNovaChave
            // 
            this.MnuNovaChave.Image = ((System.Drawing.Image)(resources.GetObject("MnuNovaChave.Image")));
            this.MnuNovaChave.Name = "MnuNovaChave";
            this.MnuNovaChave.Size = new System.Drawing.Size(230, 22);
            this.MnuNovaChave.Text = "Chave";
            this.MnuNovaChave.Click += new System.EventHandler(this.MnuNovaChave_Click);
            // 
            // MnuNovaCadeiaCaracteres
            // 
            this.MnuNovaCadeiaCaracteres.Image = ((System.Drawing.Image)(resources.GetObject("MnuNovaCadeiaCaracteres.Image")));
            this.MnuNovaCadeiaCaracteres.Name = "MnuNovaCadeiaCaracteres";
            this.MnuNovaCadeiaCaracteres.Size = new System.Drawing.Size(230, 22);
            this.MnuNovaCadeiaCaracteres.Text = "Valor da Cadeia de Caracteres";
            this.MnuNovaCadeiaCaracteres.Click += new System.EventHandler(this.MnuNovaCadeiaCaracteres_Click);
            // 
            // MnuEditar
            // 
            this.MnuEditar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuEditarChave,
            this.MnuEditarCadeiaCaracteres});
            this.MnuEditar.Image = ((System.Drawing.Image)(resources.GetObject("MnuEditar.Image")));
            this.MnuEditar.Name = "MnuEditar";
            this.MnuEditar.Size = new System.Drawing.Size(65, 20);
            this.MnuEditar.Text = "Editar";
            // 
            // MnuEditarChave
            // 
            this.MnuEditarChave.Image = ((System.Drawing.Image)(resources.GetObject("MnuEditarChave.Image")));
            this.MnuEditarChave.Name = "MnuEditarChave";
            this.MnuEditarChave.Size = new System.Drawing.Size(230, 22);
            this.MnuEditarChave.Text = "Chave";
            this.MnuEditarChave.Click += new System.EventHandler(this.MnuEditarChave_Click);
            // 
            // MnuEditarCadeiaCaracteres
            // 
            this.MnuEditarCadeiaCaracteres.Image = ((System.Drawing.Image)(resources.GetObject("MnuEditarCadeiaCaracteres.Image")));
            this.MnuEditarCadeiaCaracteres.Name = "MnuEditarCadeiaCaracteres";
            this.MnuEditarCadeiaCaracteres.Size = new System.Drawing.Size(230, 22);
            this.MnuEditarCadeiaCaracteres.Text = "Valor da Cadeia de Caracteres";
            this.MnuEditarCadeiaCaracteres.Click += new System.EventHandler(this.MnuEditarCadeiaCaracteres_Click);
            // 
            // MnuExcluir
            // 
            this.MnuExcluir.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuExcluirChave,
            this.MnuExcluirCadeiaCaracteres});
            this.MnuExcluir.Image = ((System.Drawing.Image)(resources.GetObject("MnuExcluir.Image")));
            this.MnuExcluir.Name = "MnuExcluir";
            this.MnuExcluir.Size = new System.Drawing.Size(69, 20);
            this.MnuExcluir.Text = "Excluir";
            // 
            // MnuExcluirChave
            // 
            this.MnuExcluirChave.Image = ((System.Drawing.Image)(resources.GetObject("MnuExcluirChave.Image")));
            this.MnuExcluirChave.Name = "MnuExcluirChave";
            this.MnuExcluirChave.Size = new System.Drawing.Size(230, 22);
            this.MnuExcluirChave.Text = "Chave";
            this.MnuExcluirChave.Click += new System.EventHandler(this.MnuExcluirChave_Click);
            // 
            // MnuExcluirCadeiaCaracteres
            // 
            this.MnuExcluirCadeiaCaracteres.Image = ((System.Drawing.Image)(resources.GetObject("MnuExcluirCadeiaCaracteres.Image")));
            this.MnuExcluirCadeiaCaracteres.Name = "MnuExcluirCadeiaCaracteres";
            this.MnuExcluirCadeiaCaracteres.Size = new System.Drawing.Size(230, 22);
            this.MnuExcluirCadeiaCaracteres.Text = "Valor da Cadeia de Caracteres";
            this.MnuExcluirCadeiaCaracteres.Click += new System.EventHandler(this.MnuExcluirCadeiaCaracteres_Click);
            // 
            // MnuExportar
            // 
            this.MnuExportar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuExportarArquivoRegistro,
            this.MnuExportarAtualizadorServico,
            this.arquivoDeConfiguraçãoXMLToolStripMenuItem});
            this.MnuExportar.Image = ((System.Drawing.Image)(resources.GetObject("MnuExportar.Image")));
            this.MnuExportar.Name = "MnuExportar";
            this.MnuExportar.Size = new System.Drawing.Size(78, 20);
            this.MnuExportar.Text = "Exportar";
            // 
            // MnuExportarArquivoRegistro
            // 
            this.MnuExportarArquivoRegistro.Image = ((System.Drawing.Image)(resources.GetObject("MnuExportarArquivoRegistro.Image")));
            this.MnuExportarArquivoRegistro.Name = "MnuExportarArquivoRegistro";
            this.MnuExportarArquivoRegistro.Size = new System.Drawing.Size(234, 22);
            this.MnuExportarArquivoRegistro.Text = "Arquivo de Registro";
            this.MnuExportarArquivoRegistro.Click += new System.EventHandler(this.MnuExportarArquivoRegistro_Click);
            // 
            // MnuExportarAtualizadorServico
            // 
            this.MnuExportarAtualizadorServico.Image = ((System.Drawing.Image)(resources.GetObject("MnuExportarAtualizadorServico.Image")));
            this.MnuExportarAtualizadorServico.Name = "MnuExportarAtualizadorServico";
            this.MnuExportarAtualizadorServico.Size = new System.Drawing.Size(234, 22);
            this.MnuExportarAtualizadorServico.Text = "Atualizador de Servico";
            this.MnuExportarAtualizadorServico.Click += new System.EventHandler(this.MnuExportarAtualizadorServico_Click);
            // 
            // arquivoDeConfiguraçãoXMLToolStripMenuItem
            // 
            this.arquivoDeConfiguraçãoXMLToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("arquivoDeConfiguraçãoXMLToolStripMenuItem.Image")));
            this.arquivoDeConfiguraçãoXMLToolStripMenuItem.Name = "arquivoDeConfiguraçãoXMLToolStripMenuItem";
            this.arquivoDeConfiguraçãoXMLToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.arquivoDeConfiguraçãoXMLToolStripMenuItem.Text = "Arquivo de Configuração XML";
            this.arquivoDeConfiguraçãoXMLToolStripMenuItem.Click += new System.EventHandler(this.arquivoDeConfiguraçãoXMLToolStripMenuItem_Click);
            // 
            // MnuSair
            // 
            this.MnuSair.Image = ((System.Drawing.Image)(resources.GetObject("MnuSair.Image")));
            this.MnuSair.Name = "MnuSair";
            this.MnuSair.Size = new System.Drawing.Size(54, 20);
            this.MnuSair.Text = "Sair";
            this.MnuSair.Click += new System.EventHandler(this.MnuSair_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuChaveRegistro});
            this.statusStrip1.Location = new System.Drawing.Point(0, 540);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(784, 22);
            this.statusStrip1.TabIndex = 1;
            // 
            // MnuChaveRegistro
            // 
            this.MnuChaveRegistro.Name = "MnuChaveRegistro";
            this.MnuChaveRegistro.Size = new System.Drawing.Size(102, 17);
            this.MnuChaveRegistro.Text = "Chave de Registro";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel1.Controls.Add(this.TrvChaves, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.GrdValores, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(784, 516);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // TrvChaves
            // 
            this.TrvChaves.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TrvChaves.ImageIndex = 0;
            this.TrvChaves.ImageList = this.imageList1;
            this.TrvChaves.Location = new System.Drawing.Point(3, 3);
            this.TrvChaves.Name = "TrvChaves";
            this.TrvChaves.SelectedImageIndex = 1;
            this.TrvChaves.Size = new System.Drawing.Size(268, 510);
            this.TrvChaves.TabIndex = 0;
            this.TrvChaves.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.TrvChaves_AfterCollapse);
            this.TrvChaves.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.TrvChaves_AfterExpand);
            this.TrvChaves.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TrvChaves_AfterSelect);
            this.TrvChaves.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TrvChaves_NodeMouseClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Folder-24.png");
            this.imageList1.Images.SetKeyName(1, "Open Folder-24.png");
            // 
            // GrdValores
            // 
            this.GrdValores.AllowUserToAddRows = false;
            this.GrdValores.AllowUserToDeleteRows = false;
            this.GrdValores.AllowUserToResizeColumns = false;
            this.GrdValores.AllowUserToResizeRows = false;
            this.GrdValores.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.GrdValores.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.GrdValores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdValores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Imamge,
            this.Nome,
            this.Dados});
            this.GrdValores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdValores.GridColor = System.Drawing.SystemColors.ControlLightLight;
            this.GrdValores.Location = new System.Drawing.Point(277, 3);
            this.GrdValores.MultiSelect = false;
            this.GrdValores.Name = "GrdValores";
            this.GrdValores.ReadOnly = true;
            this.GrdValores.RowHeadersVisible = false;
            this.GrdValores.Size = new System.Drawing.Size(504, 510);
            this.GrdValores.TabIndex = 1;
            this.GrdValores.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdValores_CellDoubleClick);
            this.GrdValores.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.GrdValores_CellMouseClick);
            // 
            // Imamge
            // 
            this.Imamge.HeaderText = "";
            this.Imamge.Image = ((System.Drawing.Image)(resources.GetObject("Imamge.Image")));
            this.Imamge.Name = "Imamge";
            this.Imamge.ReadOnly = true;
            this.Imamge.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Imamge.Width = 35;
            // 
            // Nome
            // 
            this.Nome.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Nome.DataPropertyName = "Nome";
            this.Nome.FillWeight = 40F;
            this.Nome.HeaderText = "Nome";
            this.Nome.Name = "Nome";
            this.Nome.ReadOnly = true;
            this.Nome.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Dados
            // 
            this.Dados.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Dados.DataPropertyName = "Dados";
            this.Dados.FillWeight = 60F;
            this.Dados.HeaderText = "Dados";
            this.Dados.Name = "Dados";
            this.Dados.ReadOnly = true;
            // 
            // MnuTrvChaves
            // 
            this.MnuTrvChaves.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.renomearChaveToolStripMenuItem,
            this.toolStripSeparator1,
            this.MnuTrvChavesRenomear,
            this.removerToolStripMenuItem});
            this.MnuTrvChaves.Name = "MnuTrvChaves";
            this.MnuTrvChaves.Size = new System.Drawing.Size(153, 98);
            // 
            // renomearChaveToolStripMenuItem
            // 
            this.renomearChaveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuTrvChavesNovoChave,
            this.MnuTrvChavesNovoCadeiaCaracteres});
            this.renomearChaveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("renomearChaveToolStripMenuItem.Image")));
            this.renomearChaveToolStripMenuItem.Name = "renomearChaveToolStripMenuItem";
            this.renomearChaveToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.renomearChaveToolStripMenuItem.Text = "Novo";
            // 
            // MnuTrvChavesNovoChave
            // 
            this.MnuTrvChavesNovoChave.Image = ((System.Drawing.Image)(resources.GetObject("MnuTrvChavesNovoChave.Image")));
            this.MnuTrvChavesNovoChave.Name = "MnuTrvChavesNovoChave";
            this.MnuTrvChavesNovoChave.Size = new System.Drawing.Size(184, 22);
            this.MnuTrvChavesNovoChave.Text = "Chave";
            this.MnuTrvChavesNovoChave.Click += new System.EventHandler(this.MnuTrvChavesNovoChave_Click);
            // 
            // MnuTrvChavesNovoCadeiaCaracteres
            // 
            this.MnuTrvChavesNovoCadeiaCaracteres.Image = ((System.Drawing.Image)(resources.GetObject("MnuTrvChavesNovoCadeiaCaracteres.Image")));
            this.MnuTrvChavesNovoCadeiaCaracteres.Name = "MnuTrvChavesNovoCadeiaCaracteres";
            this.MnuTrvChavesNovoCadeiaCaracteres.Size = new System.Drawing.Size(184, 22);
            this.MnuTrvChavesNovoCadeiaCaracteres.Text = "Cadeia de Caracteres";
            this.MnuTrvChavesNovoCadeiaCaracteres.Click += new System.EventHandler(this.MnuTrvChavesNovoCadeiaCaracteres_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(125, 6);
            // 
            // MnuTrvChavesRenomear
            // 
            this.MnuTrvChavesRenomear.Image = ((System.Drawing.Image)(resources.GetObject("MnuTrvChavesRenomear.Image")));
            this.MnuTrvChavesRenomear.Name = "MnuTrvChavesRenomear";
            this.MnuTrvChavesRenomear.Size = new System.Drawing.Size(128, 22);
            this.MnuTrvChavesRenomear.Text = "Renomear";
            this.MnuTrvChavesRenomear.Click += new System.EventHandler(this.MnuTrvChavesRenomear_Click);
            // 
            // removerToolStripMenuItem
            // 
            this.removerToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("removerToolStripMenuItem.Image")));
            this.removerToolStripMenuItem.Name = "removerToolStripMenuItem";
            this.removerToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.removerToolStripMenuItem.Text = "Remover";
            this.removerToolStripMenuItem.Click += new System.EventHandler(this.removerToolStripMenuItem_Click);
            // 
            // MnuGrdValores
            // 
            this.MnuGrdValores.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adicionarCadeiaDeCaracteresToolStripMenuItem,
            this.editarCadeiaDeCaracteresToolStripMenuItem,
            this.removerCadeiaDeCaracteresToolStripMenuItem});
            this.MnuGrdValores.Name = "MnuGrdValores";
            this.MnuGrdValores.Size = new System.Drawing.Size(239, 70);
            // 
            // adicionarCadeiaDeCaracteresToolStripMenuItem
            // 
            this.adicionarCadeiaDeCaracteresToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("adicionarCadeiaDeCaracteresToolStripMenuItem.Image")));
            this.adicionarCadeiaDeCaracteresToolStripMenuItem.Name = "adicionarCadeiaDeCaracteresToolStripMenuItem";
            this.adicionarCadeiaDeCaracteresToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.adicionarCadeiaDeCaracteresToolStripMenuItem.Text = "Adicionar Cadeia de Caracteres";
            this.adicionarCadeiaDeCaracteresToolStripMenuItem.Click += new System.EventHandler(this.adicionarCadeiaDeCaracteresToolStripMenuItem_Click);
            // 
            // editarCadeiaDeCaracteresToolStripMenuItem
            // 
            this.editarCadeiaDeCaracteresToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("editarCadeiaDeCaracteresToolStripMenuItem.Image")));
            this.editarCadeiaDeCaracteresToolStripMenuItem.Name = "editarCadeiaDeCaracteresToolStripMenuItem";
            this.editarCadeiaDeCaracteresToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.editarCadeiaDeCaracteresToolStripMenuItem.Text = "Editar Cadeia de Caracteres";
            this.editarCadeiaDeCaracteresToolStripMenuItem.Click += new System.EventHandler(this.editarCadeiaDeCaracteresToolStripMenuItem_Click);
            // 
            // removerCadeiaDeCaracteresToolStripMenuItem
            // 
            this.removerCadeiaDeCaracteresToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("removerCadeiaDeCaracteresToolStripMenuItem.Image")));
            this.removerCadeiaDeCaracteresToolStripMenuItem.Name = "removerCadeiaDeCaracteresToolStripMenuItem";
            this.removerCadeiaDeCaracteresToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.removerCadeiaDeCaracteresToolStripMenuItem.Text = "Remover Cadeia de Caracteres";
            this.removerCadeiaDeCaracteresToolStripMenuItem.Click += new System.EventHandler(this.removerCadeiaDeCaracteresToolStripMenuItem_Click);
            // 
            // FrmEditorRegistro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.MnuPrincipal);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MnuPrincipal;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "FrmEditorRegistro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editor de Registros";
            this.Load += new System.EventHandler(this.FrmEditorRegistro_Load);
            this.MnuPrincipal.ResumeLayout(false);
            this.MnuPrincipal.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdValores)).EndInit();
            this.MnuTrvChaves.ResumeLayout(false);
            this.MnuGrdValores.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MnuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem MnuNovo;
        private System.Windows.Forms.ToolStripMenuItem MnuNovaChave;
        private System.Windows.Forms.ToolStripMenuItem MnuNovaCadeiaCaracteres;
        private System.Windows.Forms.ToolStripMenuItem MnuExcluir;
        private System.Windows.Forms.ToolStripMenuItem MnuExcluirChave;
        private System.Windows.Forms.ToolStripMenuItem MnuExcluirCadeiaCaracteres;
        private System.Windows.Forms.ToolStripMenuItem MnuExportar;
        private System.Windows.Forms.ToolStripMenuItem MnuExportarArquivoRegistro;
        private System.Windows.Forms.ToolStripMenuItem MnuExportarAtualizadorServico;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel MnuChaveRegistro;
        private System.Windows.Forms.ToolStripMenuItem MnuSair;
        private System.Windows.Forms.ToolStripMenuItem arquivoDeConfiguraçãoXMLToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TreeView TrvChaves;
        private System.Windows.Forms.DataGridView GrdValores;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.DataGridViewImageColumn Imamge;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dados;
        private System.Windows.Forms.ContextMenuStrip MnuTrvChaves;
        private System.Windows.Forms.ToolStripMenuItem renomearChaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MnuTrvChavesNovoChave;
        private System.Windows.Forms.ToolStripMenuItem MnuTrvChavesNovoCadeiaCaracteres;
        private System.Windows.Forms.ToolStripMenuItem MnuTrvChavesRenomear;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem removerToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip MnuGrdValores;
        private System.Windows.Forms.ToolStripMenuItem adicionarCadeiaDeCaracteresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarCadeiaDeCaracteresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removerCadeiaDeCaracteresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MnuEditar;
        private System.Windows.Forms.ToolStripMenuItem MnuEditarChave;
        private System.Windows.Forms.ToolStripMenuItem MnuEditarCadeiaCaracteres;
    }
}