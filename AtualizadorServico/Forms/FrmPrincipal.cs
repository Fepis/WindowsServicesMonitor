using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using AtualizadorServico.Classes;


namespace AtualizadorServico.Forms
{
    /// <summary>
    /// Form Principal
    /// </summary>
    public partial class FrmPrincipal : Form
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Inicia a tela
        /// </summary>
        private void IniciarTela()
        {
            this.Text = string.Format(this.Text, Utilidades.RetornarVersao());
        }

        /// <summary>
        /// Evento Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPrincipal_Load(object sender, EventArgs e)
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

        private void ctrlInstalacao1_Load(object sender, EventArgs e)
        {

        }

        private void ctrlPainelControle1_Load(object sender, EventArgs e)
        {

        }
    }
}
