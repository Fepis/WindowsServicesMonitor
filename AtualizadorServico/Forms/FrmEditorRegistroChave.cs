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
    public partial class FrmEditorRegistroChave : Form
    {
        /// <summary>
        /// Nome do registro pai
        /// </summary>
        string _chaveCompletaPai;

        /// <summary>
        /// Nome da chave
        /// </summary>
        string _nomeChave;

        /// <summary>
        /// Nome completo da chave alterada
        /// </summary>
        public string ChaveCompletaAlterada { get; set; }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="chaveCompletaPai">Endereco da chave pai</param>
        /// <param name="nomeChave">Nome da chave</param>
        public FrmEditorRegistroChave(string chaveCompletaPai, string nomeChave)
        {
            InitializeComponent();

            _chaveCompletaPai = chaveCompletaPai;
            _nomeChave = nomeChave;
        }


        /// <summary>
        /// Inicia a tela
        /// </summary>
        private void IniciarTela()
        {
            TxtChave.Text = _nomeChave;
        }

        /// <summary>
        /// Gravar Registro
        /// </summary>
        private void Gravar()
        {
            if (string.IsNullOrEmpty(TxtChave.Text))
            {
                Utilidades.EnviarMensagem("O campo chave possui preenchimento obrigatório", Utilidades.TipoMensagem.Advertencia);
                TxtChave.Focus();
                return;
            }

            if (string.IsNullOrEmpty(_nomeChave))
            {
                //Inclui a chave no registro do windows
                RegistroWindows.IncluirChave(_chaveCompletaPai, TxtChave.Text);
            }
            else
            {
                //Altera a chave no registro do windows
                RegistroWindows.AlterarChave(_chaveCompletaPai, _nomeChave, TxtChave.Text);
            }

            if (string.IsNullOrEmpty(_chaveCompletaPai))
            {
                ChaveCompletaAlterada = TxtChave.Text;
            }
            else
            {
                ChaveCompletaAlterada = string.Join("\\", new string[] { _chaveCompletaPai, TxtChave.Text });
            }
            
            this.Close();
        }

        /// <summary>
        /// Evento Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmEditorRegistroChave_Load(object sender, EventArgs e)
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
        /// Gravar
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
        /// Cancelar Operacao
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

    }
}
