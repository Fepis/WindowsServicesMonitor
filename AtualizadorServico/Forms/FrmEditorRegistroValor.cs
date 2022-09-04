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
    /// Form para editar os dados do valor do registro
    /// </summary>
    public partial class FrmEditorRegistroValor : Form
    {
        /// <summary>
        /// Nome da chave completa
        /// </summary>
        string _chaveCompleta;

        /// <summary>
        /// Nome do valor 
        /// </summary>
        string _nomeValor;

        /// <summary>
        /// Nome do registro alterado
        /// </summary>
        public string NomeAlterado;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="chaveCompleta">Nome da chave completa</param>
        /// <param name="nomeValor">Nome do valor</param>
        public FrmEditorRegistroValor(string chaveCompleta, string nomeValor)
        {
            InitializeComponent();

            _chaveCompleta = chaveCompleta;
            _nomeValor = nomeValor;
        }


        /// <summary>
        /// Carrega as informacoes da tela
        /// </summary>
        private void IniciarTela()
        {
            CarregarConteudo();

            HabilitarCamposCriptografia();
        }

        /// <summary>
        /// Carrega os campos na tela
        /// </summary>
        private void CarregarConteudo()
        {
            if (!string.IsNullOrEmpty(_nomeValor))
            {
                TxtNome.Text = _nomeValor;
                TxtValor.Text = RegistroWindows.RetornaConteudoValor(_chaveCompleta, _nomeValor);
            }
        }

        /// <summary>
        /// Habilita os campos de criptografia
        /// </summary>
        private void HabilitarCamposCriptografia()
        {
            TxtChave.Enabled = false;
            BtnCriptografar.Enabled = false;
            BtnDescriptografar.Enabled = false;

            if (!string.IsNullOrEmpty(_nomeValor))
            {
                if (ConfiguracoesXML.VerificarNomeValorCriptografado(_chaveCompleta,_nomeValor))
                {
                    TxtChave.Enabled = true;
                    BtnCriptografar.Enabled = true;
                    BtnDescriptografar.Enabled = true;
                }
            }
        }

        /// <summary>
        /// Gravar a cadeia de caracteres
        /// </summary>
        private void Gravar()
        {
            if (!ValidarInformacoes()) { return; }

            if (string.IsNullOrEmpty(_nomeValor))
            {
                RegistroWindows.IncluirValor(_chaveCompleta, TxtNome.Text, TxtValor.Text);
            }
            else
            {
                string mensagem;
                if (!RegistroWindows.AlterarValor(_chaveCompleta, _nomeValor, TxtNome.Text, TxtValor.Text, out mensagem))
                {
                    Utilidades.EnviarMensagem(mensagem, Utilidades.TipoMensagem.Advertencia);
                    return;
                }
            }

            NomeAlterado = TxtNome.Text;
            this.Close();
        }

        /// <summary>
        /// Validar informacoes
        /// </summary>
        private bool ValidarInformacoes()
        {
            if (string.IsNullOrEmpty(TxtNome.Text))
            {
                Utilidades.EnviarMensagem("O campo nome possui preenchimento obrigatorio", Utilidades.TipoMensagem.Advertencia);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Criptografar/Descriptografar
        /// </summary>
        /// <param name="criptografar">Criptografar/Descriptografar</param>
        private void Criptografar(bool criptografar)
        {
            if (criptografar) { TxtValor.Text = Criptografia.Criptografar(TxtValor.Text, TxtChave.Text); }
            else { TxtValor.Text = Criptografia.Descriptografar(TxtValor.Text, TxtChave.Text); }
        }

        /// <summary>
        /// Evento load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmEditorRegistroValor_Load(object sender, EventArgs e)
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
        /// Botao click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOK_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                Gravar();
            }
            catch (Exception ex)
            {
                Utilidades.EnviarMensagem(ex.Message, Utilidades.TipoMensagem.Erro);
            }
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// Botao Cancelar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCancelar_Click(object sender, EventArgs e)
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
        /// Descriptografar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDescriptografar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                Criptografar(false);
            }
            catch (System.Security.Cryptography.CryptographicException)
            {
                Utilidades.EnviarMensagem("A chave de criptografia é inválida.", Utilidades.TipoMensagem.Advertencia);
            }

            catch (FormatException)
            {
                Utilidades.EnviarMensagem("O campo ja está descriptografado.", Utilidades.TipoMensagem.Advertencia);
            }
            catch (Exception ex)
            {
                Utilidades.EnviarMensagem(ex.Message, Utilidades.TipoMensagem.Erro);
            }
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// Criptografar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCriptografar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                Criptografar(true);
            }
            catch (Exception ex)
            {
                Utilidades.EnviarMensagem(ex.Message, Utilidades.TipoMensagem.Erro);
            }
            Cursor.Current = Cursors.Default;
        }
    }
}
