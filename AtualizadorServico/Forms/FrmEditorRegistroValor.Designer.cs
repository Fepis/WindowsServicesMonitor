namespace AtualizadorServico.Forms
{
    partial class FrmEditorRegistroValor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEditorRegistroValor));
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnOK = new System.Windows.Forms.Button();
            this.TxtNome = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtValor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtChave = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnCriptografar = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.BtnDescriptografar = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnCancelar.Location = new System.Drawing.Point(297, 90);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(75, 23);
            this.BtnCancelar.TabIndex = 9;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnOK
            // 
            this.BtnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnOK.Location = new System.Drawing.Point(216, 90);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(75, 23);
            this.BtnOK.TabIndex = 8;
            this.BtnOK.Text = "OK";
            this.BtnOK.UseVisualStyleBackColor = true;
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // TxtNome
            // 
            this.TxtNome.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtNome.Location = new System.Drawing.Point(56, 12);
            this.TxtNome.Name = "TxtNome";
            this.TxtNome.Size = new System.Drawing.Size(316, 20);
            this.TxtNome.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome:";
            // 
            // TxtValor
            // 
            this.TxtValor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtValor.Location = new System.Drawing.Point(56, 38);
            this.TxtValor.Name = "TxtValor";
            this.TxtValor.Size = new System.Drawing.Size(316, 20);
            this.TxtValor.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Valor:";
            // 
            // TxtChave
            // 
            this.TxtChave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtChave.Location = new System.Drawing.Point(115, 64);
            this.TxtChave.Name = "TxtChave";
            this.TxtChave.Size = new System.Drawing.Size(257, 20);
            this.TxtChave.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Chave Criptografia:";
            // 
            // BtnCriptografar
            // 
            this.BtnCriptografar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCriptografar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnCriptografar.ImageIndex = 0;
            this.BtnCriptografar.ImageList = this.imageList1;
            this.BtnCriptografar.Location = new System.Drawing.Point(52, 90);
            this.BtnCriptografar.Name = "BtnCriptografar";
            this.BtnCriptografar.Size = new System.Drawing.Size(34, 23);
            this.BtnCriptografar.TabIndex = 7;
            this.toolTip1.SetToolTip(this.BtnCriptografar, "Criptografar valor");
            this.BtnCriptografar.UseVisualStyleBackColor = true;
            this.BtnCriptografar.Click += new System.EventHandler(this.BtnCriptografar_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Lock 2-24.png");
            this.imageList1.Images.SetKeyName(1, "Unlock 2-24.png");
            // 
            // BtnDescriptografar
            // 
            this.BtnDescriptografar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnDescriptografar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnDescriptografar.ImageIndex = 1;
            this.BtnDescriptografar.ImageList = this.imageList1;
            this.BtnDescriptografar.Location = new System.Drawing.Point(12, 90);
            this.BtnDescriptografar.Name = "BtnDescriptografar";
            this.BtnDescriptografar.Size = new System.Drawing.Size(34, 23);
            this.BtnDescriptografar.TabIndex = 6;
            this.toolTip1.SetToolTip(this.BtnDescriptografar, "Descriptografar valor");
            this.BtnDescriptografar.UseVisualStyleBackColor = true;
            this.BtnDescriptografar.Click += new System.EventHandler(this.BtnDescriptografar_Click);
            // 
            // FrmEditorRegistroValor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 127);
            this.Controls.Add(this.BtnDescriptografar);
            this.Controls.Add(this.BtnCriptografar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtChave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtValor);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnOK);
            this.Controls.Add(this.TxtNome);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 131);
            this.Name = "FrmEditorRegistroValor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadeia de Caracteres";
            this.Load += new System.EventHandler(this.FrmEditorRegistroValor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnOK;
        private System.Windows.Forms.TextBox TxtNome;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtValor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtChave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnCriptografar;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button BtnDescriptografar;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}