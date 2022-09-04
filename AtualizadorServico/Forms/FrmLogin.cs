using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AtualizadorServico.Classes;

namespace AtualizadorServico.Forms
{
    /// <summary>
    /// Tela de login do sistema
    /// </summary>
    public partial class FrmLogin : Form
    {
        /// <summary>
        /// Informa se ouve validacao no usuario
        /// </summary>
        public bool UsuarioValidado { get; private set; }

        /// <summary>
        /// Construtor
        /// </summary>
        public FrmLogin()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Iniciar Tela
        /// </summary>
        private void IniciarTela()
        {
            UsuarioValidado = false;
            this.Text = string.Format(this.Text, Utilidades.RetornarVersao());
        }

        /// <summary>
        /// Valida o usuario
        /// </summary>
        private void ValidarUsuario()
        {
            string mensagem;

            TxtUsuario.Text = "suporte";
            TxtSenha.Text = "afv12mz";

            if (Credenciais.ValidarUsuarioSenha(TxtUsuario.Text, TxtSenha.Text, out mensagem))
            {
                UsuarioValidado = true;
                this.Close();
            }
            else
            {
                UsuarioValidado = false;
                Utilidades.EnviarMensagem(mensagem, Utilidades.TipoMensagem.Advertencia);
            }
        }

        /// <summary>
        /// Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                IniciarTela();
            }
            catch (Exception ex)
            {
                Utilidades.EnviarMensagem(ex.Message, Utilidades.TipoMensagem.Erro);
            }
        }

        /// <summary>
        /// Valida o usuario do sistema
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                ValidarUsuario();
            }
            catch (Exception ex)
            {
                Utilidades.EnviarMensagem(ex.Message, Utilidades.TipoMensagem.Erro);
            }
            Cursor.Current = Cursors.Default;
        }
    }
}
