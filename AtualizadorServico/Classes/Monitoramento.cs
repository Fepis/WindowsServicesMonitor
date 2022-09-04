using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace AtualizadorServico.Classes
{
    /// <summary>
    /// Classe responsavel pelo monitoramento dos servicos
    /// </summary>
    class Monitoramento
    {
        /// <summary>
        /// Delegete informa o status do serviço
        /// </summary>
        /// <param name="servidor">Servidor</param>
        /// <param name="status">Status do serviço</param>
        /// <param name="mensagem">Mensagem de conexao</param>
        public delegate void InformaStatusServicoHanlder(string servidor, bool conectado, Servico servico, string mensagem);


        /// <summary>
        /// Informa o status do serviço
        /// </summary>
        public event InformaStatusServicoHanlder OnInformaStatusServico;

        /// <summary>
        /// Lista de servidores a ser monitorado
        /// </summary>
        public List<string> Servidores { get; private set; }

        /// <summary>
        /// Servico a ser monitorado
        /// </summary>
        public string NomeServico { get; private set; }

        /// <summary>
        /// Threads em andamento
        /// </summary>
        private Dictionary<string, Timer> _timers;

        /// <summary>
        /// Adiciona o servidor na lista
        /// </summary>
        /// <param name="servidor">servidor</param>
        public void AdicionarServidor(string servidor)
        {
            if (Servidores == null) { Servidores = new List<string>(); }
            if (Servidores.FirstOrDefault(x => x.Equals(servidor)) != null) { return; }
            Servidores.Add(servidor);

            if (VerificarExisteMonitoramentoAndamento())
            {
                IniciarMonitoramento(servidor);
            }
        }

        /// <summary>
        /// Remover o servidor na lista
        /// </summary>
        /// <param name="servidor">Remover</param>
        public void RemoverServidor(string servidor)
        {
            if (Servidores == null) { Servidores = new List<string>(); }
            if (Servidores.FirstOrDefault(x => x.Equals(servidor)) == null) { return; }
            Servidores.Remove(servidor);

            if (VerificarExisteMonitoramentoAndamento())
            {
                PararMonitoramento(servidor);
            }
        }

        /// <summary>
        /// Inicia o monitoramento
        /// </summary>
        /// <param name="servico">Lista de servico</param>
        /// <returns>Retorna se o servico foi inciiado</returns>
        public bool IniciarMonitoramento(string servico, out string mensagem)
        {
            mensagem = string.Empty;

            if (string.IsNullOrEmpty(servico) || servico.Trim().Equals(string.Empty))
            {
                mensagem = "Favor selecionar um serviço.";
                return false;
            }

            if (Servidores == null || Servidores.Count == 0)
            {
                mensagem = "Selecione um servidor.";
                return false;
            }

            if (VerificarExisteMonitoramentoAndamento())
            {
                mensagem = "Já existe consultas em andamento.";
                return false;
            }

            NomeServico = servico;

            IniciarMonitoramento();

            return true;
        }

        /// <summary>
        /// Verifica se existe threads em andamento
        /// </summary>
        /// <returns>Retorna se existe threads em andamento</returns>
        public bool VerificarExisteMonitoramentoAndamento()
        {
            if (_timers == null) { return false; }
            return (_timers.Count > 0);
        }

        /// <summary>
        /// Iniciar monitoramento
        /// </summary>
        private void IniciarMonitoramento()
        {
            PararMonitoramento();

            foreach (string servidor in Servidores)
            {
                IniciarMonitoramento(servidor);
            }
        }

        /// <summary>
        /// Inicia monitoramento
        /// </summary>
        /// <param name="servidor">Servidor</param>
        private void IniciarMonitoramento(string servidor)
        {
            if (_timers == null) { _timers = new Dictionary<string, Timer>(); }

            if (_timers.FirstOrDefault(x => x.Key.Equals(servidor)).Value == null)
            {
                Timer timer = new Timer(new TimerCallback(IniciarMonitoramentoThread), servidor, 0, 2000);
                _timers.Add(servidor, timer);
            }
        }

        /// <summary>
        /// Parar de monitorar threads
        /// </summary>
        public void PararMonitoramento()
        {
            if (_timers == null) { return; }

            foreach (KeyValuePair<string, Timer> item in _timers)
            {
                item.Value.Dispose();
            }

            _timers.Clear();
        }

        /// <summary>
        /// Para de verificar um determinado servidor
        /// </summary>
        /// <param name="servidor"></param>
        private void PararMonitoramento(string servidor)
        {
            if (_timers == null) { return; }

            Timer timer = _timers.FirstOrDefault(x => x.Key.Equals(servidor)).Value;
            if (timer == null) { return; }
            timer.Dispose();
            _timers.Remove(servidor);
        }


        /// <summary>
        /// Inicia monitoramento
        /// </summary>
        /// <param name="servidor">Servidor</param>
        private void IniciarMonitoramentoThread(object servidorObjeto)
        {
            string servidor = servidorObjeto.ToString();
            string mensagem;

            try
            {
                if (RedeSistema.VerificarConexaoServidor(servidor, out mensagem))
                {
                    Servico servico = RedeSistema.RetornarServico(servidor, NomeServico, out mensagem);
                    if (OnInformaStatusServico != null) { OnInformaStatusServico(servidor, true, servico, mensagem); }

                    if (servico == null)
                    {
                        //PararMonitoramento(servidor);
                    }
                }
                else
                {
                    if (OnInformaStatusServico != null) { OnInformaStatusServico(servidor, false, null, mensagem); }
                }
            }
            catch (Exception ex)
            {
                mensagem = "Erro genérico no monitormanento: " + ex.Message;
                if (OnInformaStatusServico != null) { OnInformaStatusServico(servidor, false, null, mensagem); }
            }
        }
    }
}
