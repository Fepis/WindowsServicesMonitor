using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;

namespace AtualizadorServico.Classes
{
    class ProcessoAtualizacao : IDisposable
    {
        /// <summary>
        /// Delegate de validacao de parametros
        /// </summary>
        /// <param name="rejeicoes">Lista de rejecoes</param>
        public delegate void RejeicaoParametrosAtualizacaoHandler(List<RejeicaoParametrosAtualizacao> rejeicoes);

        /// <summary>
        /// Delegate Informa procedimento de atualizacao
        /// </summary>
        /// <param name="procedimento">Procediento</param>
        /// <param name="servidor">Servidor</param>
        public delegate void ProcedimentoAtualizacaoHanlder(string servidor, ProcedimentoAtualizacao procedimento);

        /// <summary>
        /// Delegete informa o status do serviço
        /// </summary>
        /// <param name="servidor">Servidor</param>
        /// <param name="status">Status do serviço</param>
        public delegate void InformaStatusServicoHanlder(string servidor, RedeSistema.TipoStatusServico status);

        /// <summary>
        /// Delegate de log de atualizacao
        /// </summary>
        /// <param name="servidor">Servidor</param>
        /// <param name="log">Log de informação</param>
        public delegate void LogProcedimentoAtualizacaoHandler(string servidor, string log);

        /// <summary>
        /// Indica que o processo foi finalizado
        /// </summary>
        public delegate void ProcessoFinalizadoHandler();

        /// <summary>
        /// Evento de rejeicao de parametros de atualizacao
        /// </summary>
        public event RejeicaoParametrosAtualizacaoHandler OnRejeicaoParametrosAtualizacao;

        /// <summary>
        /// Evento que informa procedimento de atualizacao
        /// </summary>
        public event ProcedimentoAtualizacaoHanlder OnProcedimentoAtualizacao;

        /// <summary>
        /// Informa o status do serviço
        /// </summary>
        public event InformaStatusServicoHanlder OnInformaStatusServico;

        /// <summary>
        /// Evento de log de atualizacao
        /// </summary>
        public event LogProcedimentoAtualizacaoHandler OnLogProcedimentoAtualizacao;

        /// <summary>
        /// Indica que o processo foi finalizado
        /// </summary>
        public event ProcessoFinalizadoHandler OnProcessoFinalizado;

        /// <summary>
        /// Lista de threads
        /// </summary>
        private List<Thread> _threadsAtualicacao;

        /// <summary>
        /// Servico do Windows
        /// </summary>
        public string Servico { get; private set; }

        /// <summary>
        /// Serviço executavel
        /// </summary>
        private string _servicoExecutavel;

        /// <summary>
        /// Lista de servidores
        /// </summary>
        private List<string> _servidores;

        /// <summary>
        /// Lista  de arquivos
        /// </summary>
        private List<string> _arquivos;

        /// <summary>
        /// diretorio de gravacao
        /// </summary>
        private string _diretorioDestino;

        /// <summary>
        /// Usuario forte da rede
        /// </summary>
        public string Usuario { get; private set; }

        /// <summary>
        /// Senha forte da rede
        /// </summary>
        public string Senha { get; private set; }

        /// <summary>
        /// Realiza o processo de atualizacao dos arquivos
        /// </summary>
        /// <param name="servico">Serviço do Windows</param>
        /// /// <param name="servicoExecutavel">Nome do executave do serviço</param>
        /// <param name="servidores">Lista de servidores</param>
        /// <param name="arquivos">Arquivos a serem copiados</param>
        /// <param name="diretorioDestino">diretori de destino na maquinas</param>
        /// <returns>retorna se o processo foi realizado ou abortado</returns>
        public bool AtualizarServidores(string servico, string servicoExecutavel, List<string> servidores, List<string> arquivos, string diretorioDestino, string usuario, string senha)
        {
            //Valida os parametros da tela
            if (!ValidarParametrosAtualizacoes(servidores, servicoExecutavel, arquivos, diretorioDestino, usuario, senha)) { return false; }

            Servico = servico;
            _servicoExecutavel = servicoExecutavel;
            _servidores = servidores;
            _arquivos = arquivos;
            _diretorioDestino = diretorioDestino;

            Usuario = usuario;
            Senha = senha;

            //Executa a atualizacao
            return RealizarAtualizacao();
        }

        /// <summary>
        /// Realiza a validacoes dos parametros de atualizacao
        /// </summary>
        /// <param name="serviores">Lista de servidores</param>
        /// <param name="arquivos">Arquivos a serem copiados</param>
        /// <param name="diretorioDestino">diretori de destino na maquinas</param>
        /// <returns>retorna a validacao dos parametros</returns>
        private bool ValidarParametrosAtualizacoes(List<string> servidores, string servicoExecutavel, List<string> arquivos, string diretorioDestino, string usuario, string senha)
        {
            List<RejeicaoParametrosAtualizacao> rejeicoes = new List<RejeicaoParametrosAtualizacao>();

            //Valida usuario
            if (string.IsNullOrEmpty(usuario)) { rejeicoes.Add(RejeicaoParametrosAtualizacao.ParametroUsuarioInvalido); }

            //Valida Senha
            if (string.IsNullOrEmpty(senha)) { rejeicoes.Add(RejeicaoParametrosAtualizacao.ParametroSenhaInvalido); }

            //Valida os servidores
            if (servidores == null || servidores.Count == 0) { rejeicoes.Add(RejeicaoParametrosAtualizacao.ListaServidoresInvalida); }

            //Verifica se o servço informado é executavel
            if (!string.IsNullOrEmpty(servicoExecutavel) && !servicoExecutavel.Split('.').Last().Equals("exe")) { rejeicoes.Add(RejeicaoParametrosAtualizacao.ExtensaoServicoInvalida); }

            //Valida os arquivos
            if (arquivos == null || arquivos.Count() == 0) { rejeicoes.Add(RejeicaoParametrosAtualizacao.ListaArquivosInvalida); }

            //Verifica se o diretorio é um diretorio valido
            if (!Utilidades.ValidarDiretorio(diretorioDestino)) { rejeicoes.Add(RejeicaoParametrosAtualizacao.ListaArquivosInvalida); }

            //Verifica se os arquivos realment existem
            if (arquivos != null)
            {
                foreach (string arquivo in arquivos)
                {
                    if (!System.IO.File.Exists(arquivo))
                    {
                        if (!rejeicoes.Exists(x => x == RejeicaoParametrosAtualizacao.ListaArquivosInvalida))
                        { rejeicoes.Add(RejeicaoParametrosAtualizacao.ListaArquivosInvalida); }
                        break;
                    }

                    if (!(".zip|.rar|.reg").Split('|').Contains(Path.GetExtension(arquivo)))
                    {
                        if (!rejeicoes.Exists(x => x == RejeicaoParametrosAtualizacao.ListaArquivosInvalida))
                        { rejeicoes.Add(RejeicaoParametrosAtualizacao.ListaArquivosInvalida); }
                        break;
                    }
                }
            }

            //Verifica se ha threads em andamento
            if (VerificarTreadsExecucao()) { rejeicoes.Add(RejeicaoParametrosAtualizacao.ThreadEmAndamento); }

            if (rejeicoes.Count > 0 && OnRejeicaoParametrosAtualizacao != null) { OnRejeicaoParametrosAtualizacao(rejeicoes); }

            return rejeicoes.Count == 0;
        }

        /// <summary>
        /// Realiza a atualizacao do servidor
        /// </summary>
        /// <param name="servidor">Nome do servidor</param>
        private bool RealizarAtualizacao()
        {
            _threadsAtualicacao = new List<Thread>();

            foreach (string servidor in _servidores)
            {
                Thread thread = new Thread(new ParameterizedThreadStart(RealizarAtualizacao));
                thread.Name = servidor;
                thread.IsBackground = true;
                thread.Start(servidor);
                _threadsAtualicacao.Add(thread);
            }

            Thread threadMontiramento = new Thread(MonitoraThreads);
            threadMontiramento.Start();

            Thread threadStatusServico = new Thread(VerificarStatusServico);
            threadStatusServico.IsBackground = true;
            threadStatusServico.Start();

            return true;
        }

        /// <summary>
        /// Fica monitorando as threads
        /// </summary>
        public void MonitoraThreads()
        {
            while (true)
            {
                Thread.Sleep(100);
                if (!VerificarTreadsExecucao())
                {
                    if (OnProcessoFinalizado != null) { OnProcessoFinalizado(); }
                    break;
                }
            }
        }

        /// <summary>
        /// Verifica se existe alguma thread em andamento
        /// </summary>
        /// <returns>Verifica se existe</returns>
        private bool VerificarTreadsExecucao()
        {
            List<string> threadAndamento = new List<string>();

            if (_threadsAtualicacao != null)
            {
                foreach (Thread thread in _threadsAtualicacao)
                {
                    if (thread != null && thread.IsAlive)
                    {
                        threadAndamento.Add(thread.Name);
                    }
                }
            }

            return (threadAndamento.Count > 0);
        }

        /// <summary>
        /// Verifica o status do serviço
        /// </summary>
        private void VerificarStatusServico()
        {
            Credenciais credencial = new Credenciais();

            while (true)
            {
                try
                {
                    System.Threading.Thread.Sleep(1000);

                    foreach (string servidor in _servidores)
                    {
                        string mensagem;
                        RedeSistema.TipoStatusServico status = RedeSistema.VerificarStatusServico(servidor, Servico, out mensagem);
                        if (OnInformaStatusServico != null) { OnInformaStatusServico(servidor, status); }
                    }

                }
                catch (Exception) { }
            }
        }

        /// <summary>
        /// Realiza a atualizacao do servidor
        /// </summary>
        /// <param name="servidorParam">Nome do servidor</param>
        private void RealizarAtualizacao(object servidorParam)
        {
            bool servicoInstalado;
            bool sucesso = false;
            string servidor = servidorParam.ToString();

            try
            {
                // Valida a conexao com o servidor
                if (!ValidarConexaoServidor(servidor)) { return; }

                //Verificar se o serviço existe na maquina
                servicoInstalado = ValidarExistenciaServico(servidor);

                //Caso não haja um executavel para instalacao então sai fora
                if (!servicoInstalado && string.IsNullOrEmpty(_servicoExecutavel)) { return; }

                //Parar o serviço
                if (servicoInstalado && !PararServico(servidor)) { return; }

                //Copia os arquivos para o servidcor
                sucesso = CopiarArquivos(servidor);

                //Caso não localize o serviço então realiza a instalação
                if (sucesso && !servicoInstalado) { servicoInstalado = InstalarServico(servidor); }

                //Caso haja falha ao instalar o serviço então sai do metodo
                if (!servicoInstalado) { return; }

                //Iniciar o serviço
                if (!IniciarServico(servidor)) { return; }

                if (sucesso)
                { EnviarProcedimentoAtualizacao(servidor, ProcedimentoAtualizacao.AtualizacaoRealizadaSucesso, "Atualizacao realizada com sucesso."); }
            }
            catch (Exception ex)
            {
                EnviarProcedimentoAtualizacao(servidor, ProcedimentoAtualizacao.ErroGenerico, string.Format("Ocorreu um erro genérico na atualizacao: {0}.", ex.Message));
            }

        }

        /// <summary>
        /// Valida a conexao com o servidor
        /// </summary>
        /// <param name="servidor">Servidor</param>
        /// <returns>Retorna a validacao da conexao</returns>
        private bool ValidarConexaoServidor(string servidor)
        {
            string mensagem = string.Empty;

            if (RedeSistema.VerificarConexaoServidor(servidor, out mensagem))
            {
                EnviarProcedimentoAtualizacao(servidor, ProcedimentoAtualizacao.TesteConexaoOK, "Conexão realizada com sucesso.");
                return true;
            }
            else
            {
                EnviarProcedimentoAtualizacao(servidor, ProcedimentoAtualizacao.TesteConexaoErro, string.Format("Não foi possível realizar a conexão erro: {0}.", mensagem));
                return false;
            }
        }

        /// <summary>
        /// Verifica se o serviço existe
        /// </summary>
        /// <param name="servidor">Servidor</param>
        /// <returns>Retorna a validacao do serviço</returns>
        private bool ValidarExistenciaServico(string servidor)
        {
            string mensagem = string.Empty;

            if (string.IsNullOrEmpty(Servico)) { return true; }

            if (RedeSistema.VerificarExistenciaServico(servidor, Servico, out mensagem))
            {
                EnviarProcedimentoAtualizacao(servidor, ProcedimentoAtualizacao.ServicoLocalizado, "Serviço localizado com sucesso.");
                return true;
            }
            else
            {
                EnviarProcedimentoAtualizacao(servidor, ProcedimentoAtualizacao.ServicoNaoLocalizado, string.Format("Serviço NÃO localizado no servidor: {0}.", mensagem));
                return false;
            }
        }

        /// <summary>
        /// Para o serviço do servidor
        /// </summary>
        /// <param name="servidor">Servidor</param>
        /// <returns>Retorna se foi possivel o não parar</returns>
        private bool PararServico(string servidor)
        {
            string mensagem = string.Empty;

            if (string.IsNullOrEmpty(Servico)) { return true; }

            if (RedeSistema.ExecutarComandoServico(servidor, Servico, RedeSistema.TipoComandoServico.Parar, out mensagem))
            {
                EnviarProcedimentoAtualizacao(servidor, ProcedimentoAtualizacao.ServicoParado, "Serviço parado com sucesso.");
                return true;
            }
            else
            {
                EnviarProcedimentoAtualizacao(servidor, ProcedimentoAtualizacao.ServicoNaoParado, string.Format("Não foi possivel parar o serviço: {0}.", mensagem));
                return false;
            }
        }


        /// <summary>
        /// Copiar os arquivos para o servidor
        /// </summary>
        /// <param name="servidor">Servidor</param>
        /// <returns>Retorna se a operacao foi executada com sucesso</returns>
        private bool CopiarArquivos(string servidor)
        {
            string mensagem = string.Empty;

            if (RedeSistema.CopiarDescompactarArquivosRede(servidor, _arquivos, _diretorioDestino, out mensagem))
            {
                EnviarProcedimentoAtualizacao(servidor, ProcedimentoAtualizacao.ArquivosCopiadoSucesso, "Arquivos atualizados com sucesso.");
                return true;
            }
            else
            {
                EnviarProcedimentoAtualizacao(servidor, ProcedimentoAtualizacao.ArquivosCopiadoErro, string.Format("Não foi possivel atualizar os arquivos erro: {0}.", mensagem));
                return false;
            }
        }

        /// <summary>
        /// Instalar serviço
        /// </summary>
        /// <param name="servidor">Servidor</param>
        /// <returns>Verifica se foi instalado o serviço</returns>
        private bool InstalarServico(string servidor)
        {
            string mensagem = string.Empty;

            if (RedeSistema.ExecutarInstalacaoSerivcoWindowsMaquinaRemota(servidor, _diretorioDestino, _servicoExecutavel, out mensagem))
            {
                EnviarProcedimentoAtualizacao(servidor, ProcedimentoAtualizacao.ServicoInstalado, "Serviço instalado com sucesso.");
                return true;
            }
            else
            {
                EnviarProcedimentoAtualizacao(servidor, ProcedimentoAtualizacao.ServicoNaoInstalado, string.Format("Não foi possivel instalar o serviço: {0}.", mensagem));
                return false;
            }
        }

        /// <summary>
        /// Iniciar o serviço do servidor
        /// </summary>
        /// <param name="servidor">Servidor</param>
        /// <returns>Retorna se foi possivel o não iniciar</returns>
        private bool IniciarServico(string servidor)
        {
            string mensagem = string.Empty;

            if (string.IsNullOrEmpty(Servico)) { return true; }

            if (RedeSistema.ExecutarComandoServico(servidor, Servico, RedeSistema.TipoComandoServico.Iniciar, out mensagem))
            {
                EnviarProcedimentoAtualizacao(servidor, ProcedimentoAtualizacao.ServicoIncializado, "Serviço iniciado com sucesso.");
                return true;
            }
            else
            {
                EnviarProcedimentoAtualizacao(servidor, ProcedimentoAtualizacao.ServicoNaoInicializado, string.Format("Não foi possivel iniciar o serviço: {0}.", mensagem));
                return false;
            }
        }

        /// <summary>
        /// Envia log de atualizacao
        /// </summary>
        /// <param name="servidor">Servidor</param>
        /// <param name="log">Log</param>
        private void EnviarProcedimentoAtualizacao(string servidor, ProcedimentoAtualizacao procedimeneto, string log)
        {
            if (OnProcedimentoAtualizacao != null) { OnProcedimentoAtualizacao(servidor, procedimeneto); }
            EnviarLog(servidor, log);
        }

        /// <summary>
        /// Envia log de atualizacao
        /// </summary>
        /// <param name="servidor">Servidor</param>
        /// <param name="log">Log</param>
        private void EnviarLog(string servidor, string log)
        {
            if (OnLogProcedimentoAtualizacao != null) { OnLogProcedimentoAtualizacao(servidor, log); }
        }

        #region Enums

        /// <summary>
        /// Tipo de rejeicoes do diretorio
        /// </summary>
        public enum RejeicaoParametrosAtualizacao
        {
            ParametroUsuarioInvalido = 0,
            ParametroSenhaInvalido = 1,
            ListaServidoresInvalida = 2,
            ListaArquivosInvalida = 3,
            DiretorioInvalido = 4,
            ThreadEmAndamento = 5,
            ExtensaoServicoInvalida = 6
        }

        /// <summary>
        /// Enum com os procedimentosw de atualizacao
        /// </summary>
        public enum ProcedimentoAtualizacao
        {
            ErroGenerico = 0,

            TesteConexaoErro = 1,
            TesteConexaoOK = 2,

            ServicoLocalizado = 3,
            ServicoNaoLocalizado = 4,

            ServicoIncializado = 5,
            ServicoNaoInicializado = 6,

            ServicoParado = 7,
            ServicoNaoParado = 8,

            ArquivosCopiadoErro = 9,
            ArquivosCopiadoSucesso = 10,

            AtualizacaoRealizadaSucesso = 11,

            ServicoInstalado = 12,
            ServicoNaoInstalado = 13,
        }
        #endregion

        #region IDisposable

        /// <summary>
        /// Descarta o objeto
        /// </summary>
        public void Dispose()
        {
            foreach (Thread thread in _threadsAtualicacao)
            {
                if (thread.IsAlive) { thread.Abort(); }
            }
        }

        #endregion
    }
}
