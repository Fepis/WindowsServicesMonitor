namespace AtualizadorServico.Forms
{
    partial class FrmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            this.TabPrincipal = new System.Windows.Forms.TabControl();
            this.TabPainelControle = new System.Windows.Forms.TabPage();
            this.ctrlPainelControle1 = new AtualizadorServico.Controles.CtrlPainelControle();
            this.TabAtualizadorServico = new System.Windows.Forms.TabPage();
            this.ctrlInstalacao1 = new AtualizadorServico.Controles.CtrlInstalacao();
            this.TabPrincipal.SuspendLayout();
            this.TabPainelControle.SuspendLayout();
            this.TabAtualizadorServico.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabPrincipal
            // 
            this.TabPrincipal.Controls.Add(this.TabPainelControle);
            this.TabPrincipal.Controls.Add(this.TabAtualizadorServico);
            this.TabPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabPrincipal.Location = new System.Drawing.Point(0, 0);
            this.TabPrincipal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TabPrincipal.Name = "TabPrincipal";
            this.TabPrincipal.SelectedIndex = 0;
            this.TabPrincipal.Size = new System.Drawing.Size(1512, 1123);
            this.TabPrincipal.TabIndex = 0;
            // 
            // TabPainelControle
            // 
            this.TabPainelControle.Controls.Add(this.ctrlPainelControle1);
            this.TabPainelControle.Location = new System.Drawing.Point(4, 29);
            this.TabPainelControle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TabPainelControle.Name = "TabPainelControle";
            this.TabPainelControle.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TabPainelControle.Size = new System.Drawing.Size(1504, 1090);
            this.TabPainelControle.TabIndex = 0;
            this.TabPainelControle.Text = "Painel de Controle";
            this.TabPainelControle.UseVisualStyleBackColor = true;
            // 
            // ctrlPainelControle1
            // 
            this.ctrlPainelControle1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlPainelControle1.Location = new System.Drawing.Point(4, 5);
            this.ctrlPainelControle1.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.ctrlPainelControle1.Name = "ctrlPainelControle1";
            this.ctrlPainelControle1.Size = new System.Drawing.Size(1496, 1080);
            this.ctrlPainelControle1.TabIndex = 0;
            this.ctrlPainelControle1.Load += new System.EventHandler(this.ctrlPainelControle1_Load);
            // 
            // TabAtualizadorServico
            // 
            this.TabAtualizadorServico.Controls.Add(this.ctrlInstalacao1);
            this.TabAtualizadorServico.Location = new System.Drawing.Point(4, 29);
            this.TabAtualizadorServico.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TabAtualizadorServico.Name = "TabAtualizadorServico";
            this.TabAtualizadorServico.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TabAtualizadorServico.Size = new System.Drawing.Size(1504, 1090);
            this.TabAtualizadorServico.TabIndex = 1;
            this.TabAtualizadorServico.Text = "Atualizador de Serviço";
            this.TabAtualizadorServico.UseVisualStyleBackColor = true;
            // 
            // ctrlInstalacao1
            // 
            this.ctrlInstalacao1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlInstalacao1.Location = new System.Drawing.Point(4, 5);
            this.ctrlInstalacao1.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.ctrlInstalacao1.Name = "ctrlInstalacao1";
            this.ctrlInstalacao1.Size = new System.Drawing.Size(1496, 1080);
            this.ctrlInstalacao1.TabIndex = 0;
            this.ctrlInstalacao1.Load += new System.EventHandler(this.ctrlInstalacao1_Load);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1512, 1123);
            this.Controls.Add(this.TabPrincipal);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(1525, 1151);
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Atualizador de Serviço v{0}";
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.TabPrincipal.ResumeLayout(false);
            this.TabPainelControle.ResumeLayout(false);
            this.TabAtualizadorServico.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabPrincipal;
        private System.Windows.Forms.TabPage TabPainelControle;
        private System.Windows.Forms.TabPage TabAtualizadorServico;
        private AtualizadorServico.Controles.CtrlInstalacao ctrlInstalacao1;
        private Controles.CtrlPainelControle ctrlPainelControle1;
    }
}