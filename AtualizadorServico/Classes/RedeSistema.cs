using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.DirectoryServices;
using System.Net.NetworkInformation;
using System.Management;
using AtualizadorServico.Internet;
using System.IO.Compression;
using System.Diagnostics;


namespace AtualizadorServico.Classes
{
    public class RedeSistema
    {
        /// <summary>
        /// Lista todas as maquinas na rede
        /// </summary>
        /// <param name="filtro">filtro do nome da maquina</param>
        /// <param name="nota">servidor de nf</param>
        /// <param name="windows">servidor windows</param>
        /// <returns>Retorna lista de servidores</returns>
        public static List<string> ListarMaquinasRede(string filtro, bool nota, bool windows)
        {
            if (!nota && !windows)
            {
                return ListarMaquinasRede().Where(x => x.Contains(filtro.ToLower()) || string.IsNullOrEmpty(filtro)).ToList();
            }
            else
            {
                return Consultas.RetornarMaquinasFiliais(filtro, nota, windows);
            }
        }

        /// <summary>
        /// Lista todas as maquinas na rede
        /// </summary>
        /// <returns>Retorna o nome das maquinas</returns>
        private static List<string> ListarMaquinasRede()
        {
            List<String> computersList = new List<String>();
            try
            {
                DirectoryEntry entry = new DirectoryEntry("LDAP://company");
                DirectorySearcher mySearcher = new DirectorySearcher(entry);
                mySearcher.Filter = ("(objectClass=computer)");

                SearchResultCollection coll = mySearcher.FindAll();

                foreach (SearchResult rs in coll)
                {
                    ResultPropertyCollection resultPropColl = rs.Properties;
                    foreach (object computerName in resultPropColl["name"])
                    {
                        computersList.Add(computerName.ToString().ToLower());
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return computersList;
        }


        /// <summary>
        /// Verifica a conexao com o servidor
        /// </summary>
        /// <param name="servidor"></param>
        /// <returns></returns>
        public static bool VerificarConexaoServidor(string servidor, out string mensagem)
        {
            mensagem = string.Empty;

            Ping testeConexao = new Ping();
            PingReply retorno = testeConexao.Send(servidor, 10000);

            if (retorno.Status != IPStatus.Success)
            {
                mensagem = retorno.Status.ToString();
            }

            return retorno.Status == IPStatus.Success;
        }

        /// <summary>
        /// Verifica o status do serviço
        /// </summary>
        /// <param name="servidor">Servidor</param>
        /// <param name="servico">Serviço</param>
        /// <param name="mensagem">Retorna uma mensagem de erro caso exista</param>
        /// <returns>Retorna status do serviço</returns>
        public static TipoStatusServico VerificarStatusServico(string servidor, string servico, out string mensagem)
        {
            string mensagemRecebida = string.Empty;
            TipoStatusServico status = TipoStatusServico.NaoInstalado;

            try
            {
                NetworkConnectionImpersonate.ImpersonateHappily(() =>
                {
                    var sc = new System.ServiceProcess.ServiceController(servico, servidor);

                    if (sc == null) { status = TipoStatusServico.NaoInstalado; }
                    else
                    {
                        switch (sc.Status)
                        {
                            case System.ServiceProcess.ServiceControllerStatus.Running:
                                status = TipoStatusServico.Rodando;
                                break;
                            default:
                                status = TipoStatusServico.Parado;
                                break;
                        }
                    }
                },
               Credenciais.Usuario, "COMPANY", Credenciais.Senha);

                mensagem = mensagemRecebida;
            }
            catch (Exception ex)
            {
                mensagem = ex.Message;
                return TipoStatusServico.NaoInstalado;
            }

            return status;
        }

        /// <summary>
        /// Verifica o status do serviço
        /// </summary>
        /// <param name="servidor">Servidor</param>
        /// <param name="servico">Serviço</param>
        /// <param name="mensagem">Retorna uma mensagem de erro caso exista</param>
        /// <returns>Retorna status do serviço</returns>
        public static Servico RetornarServico(string servidor, string servico, out string mensagem)
        {
            mensagem = string.Empty;

            try
            {
                Servico objServico = null;

                ConnectionOptions co = new ConnectionOptions();
                co.Username = Credenciais.Usuario;
                co.Password = Credenciais.Senha;

                //Point to machine
                System.Management.ManagementScope ms = new System.Management.
                    ManagementScope(@"\\" + servidor + @"\root\cimv2", co);

                ObjectQuery oq = new ObjectQuery(string.Format("SELECT * FROM Win32_Service WHERE Name = '{0}'", servico));
                ManagementObjectSearcher query = new ManagementObjectSearcher(ms, oq);
                ManagementObjectCollection queryCollection = query.Get();

                foreach (ManagementObject mo in queryCollection)
                {
                    objServico = new Servico();

                    objServico.Nome = mo["Name"].ToString();
                    objServico.Descricao = mo["Description"].ToString();
                    objServico.Display = mo["DisplayName"].ToString();
                    objServico.EnderecoExecutavel = mo["PathName"].ToString().Replace("\"", "");

                    if (mo["State"].ToString().Equals("Running") || mo["State"].ToString().Equals("Continue Pending"))
                    {
                        objServico.Status = TipoStatusServico.Rodando;
                    }
                    else
                    {
                        objServico.Status = TipoStatusServico.Parado;
                    }

                    break;
                }

                if (objServico != null)
                {

                    //Monta o raiz do servidor
                    string raiz = string.Concat(@"\", @"\", servidor, @"\c$");

                    //Remove o diretorio raiz (C:\)
                    string arquivoExecutavel = objServico.EnderecoExecutavel.Replace(Directory.GetDirectoryRoot(objServico.EnderecoExecutavel), "");

                    //Adiciona o endereço do servidor
                    arquivoExecutavel = Path.Combine(raiz, arquivoExecutavel);

                    //Conecta-se a maquina remota
                    using (new NetworkConnectionDirectory(raiz, @"COMPANY\" + Credenciais.Usuario, Credenciais.Senha))
                    {
                        if (File.Exists(arquivoExecutavel))
                        {
                            FileVersionInfo arquivo = FileVersionInfo.GetVersionInfo(arquivoExecutavel);
                            objServico.Versao = arquivo.FileVersion;
                        }
                        else
                        {
                            objServico.Versao = "Não localizada";
                        }
                    }
                }
                else
                {
                    mensagem = "Serviço não localizado.";
                }

                return objServico;
            }
            catch (Exception ex)
            {
                mensagem = ex.Message;
                return null;
            }
        }

        /// <summary>
        /// Verifica se o servico existe
        /// </summary>
        /// <param name="servidor">Servidor</param>
        /// <param name="servico">Serviço</param>
        /// <param name="mensagem">Retorna uma mensagem de erro caso exista</param>
        /// <returns>Retorna a verificação</returns>
        public static bool VerificarExistenciaServico(string servidor, string servico, out string mensagem)
        {
            string mensagemRecebida = string.Empty;

            try
            {
                NetworkConnectionImpersonate.ImpersonateHappily(() =>
                {
                    var sc = new System.ServiceProcess.ServiceController(servico, servidor);
                    if (sc == null)
                    { mensagemRecebida = "Não localizado."; }
                    else
                    { mensagemRecebida = sc.DisplayName; }
                },
              Credenciais.Usuario, "COMPANY", Credenciais.Senha);

                mensagem = mensagemRecebida;
            }
            catch (Exception ex)
            {
                mensagem = ex.Message;
                return false;
            }
            return true;
        }

        /// <summary>
        /// Inicia / Para / Pausa o serviço do windows
        /// </summary>
        /// <param name="servidor">Servidor</param>
        /// <param name="servico">Serviço</param>
        /// <param name="comando">Acao do servico</param>
        /// <param name="mensagem">Retorna uma mensagem de erro caso exista</param>
        /// <returns>Informa se foi efetuado com sucesso o procedimento</returns>
        public static bool ExecutarComandoServico(string servidor, string servico, TipoComandoServico comando, out string mensagem)
        {
            mensagem = string.Empty;

            try
            {
                NetworkConnectionImpersonate.ImpersonateHappily(() =>
                {
                    var sc = new System.ServiceProcess.ServiceController(servico, servidor);

                    switch (comando)
                    {
                        case TipoComandoServico.Iniciar:
                            sc.Start();
                            sc.WaitForStatus(System.ServiceProcess.ServiceControllerStatus.Running);
                            break;

                        case TipoComandoServico.Parar:
                            if (sc.Status == System.ServiceProcess.ServiceControllerStatus.Running)
                            {
                                sc.Stop();
                                sc.WaitForStatus(System.ServiceProcess.ServiceControllerStatus.Stopped);
                            }
                            break;

                        case TipoComandoServico.Pausar:
                            if (sc.Status == System.ServiceProcess.ServiceControllerStatus.Running)
                            {
                                sc.Pause();
                                sc.WaitForStatus(System.ServiceProcess.ServiceControllerStatus.Paused);
                            }
                            break;

                    }
                },
               Credenciais.Usuario, "COMPANY", Credenciais.Senha);
            }
            catch (Exception ex)
            {
                mensagem = ex.Message;
                return false;
            }
            return true;
        }


        /// <summary>
        /// Copiar e descompacta o arquivo no servidor
        /// </summary>
        /// <param name="servidor">Servidor</param>
        /// <param name="arquivos">arquivos a serem descompactados</param>
        /// <param name="diretorioDestino">diretorio de destino</param>
        /// <param name="mensagem">mensagem de erro</param>
        /// <returns>Retorna se o processo foi executado com sucesso</returns>
        public static bool CopiarDescompactarArquivosRede(string servidor, List<string> arquivos, string diretorioDestino, out string mensagem)
        {
            List<string> arquivosDescompactados = new List<string>();
            mensagem = string.Empty;

            try
            {
                //Monta o raiz do servidor
                string raiz = string.Concat(@"\", @"\", servidor, @"\c$");

                //Remove o diretorio raiz (C:\)
                diretorioDestino = diretorioDestino.Replace(Directory.GetDirectoryRoot(diretorioDestino), "");

                //Adiciona o endereço do servidor
                diretorioDestino = Path.Combine(raiz, diretorioDestino);

                //Cria um diretorio de backup
                string diretorioDestinoBackup = Path.Combine(diretorioDestino, string.Format("BackupAplic_{0}", DateTime.Today.ToString("yyyyMMdd")));

                //Conecta-se a maquina remota
                using (new NetworkConnectionDirectory(raiz, @"COMPANY\" + Credenciais.Usuario, Credenciais.Senha))
                {
                    //Caso não haja o diretorio então cria 
                    if (!Directory.Exists(diretorioDestino))
                    { Directory.CreateDirectory(diretorioDestino); }
                    else //senão realiza o backup
                    { if (!CriarBackupRede(diretorioDestino, diretorioDestinoBackup, out mensagem)) { return false; }; }

                    try
                    {
                        //Começa a varrer os arquivos
                        foreach (string arquivo in arquivos)
                        {
                            //Cria o nome do arquivo de destino
                            string arquivoDestino = Path.Combine(diretorioDestino, Path.GetFileName(arquivo));

                            //Caso o arquivo de destino ja exista então exclui
                            if (File.Exists(arquivoDestino)) { File.Delete(arquivoDestino); }

                            //Copia o arquivo para o diretorio de destino
                            File.Copy(arquivo, arquivoDestino);

                            try
                            {
                                //Verifica se arquivo é zip
                                if (Path.GetExtension(arquivoDestino) == ".zip")
                                {
                                    //Decompacta o arquivo
                                    arquivosDescompactados.AddRange(Utilidades.Descompactar(new FileInfo(arquivoDestino)));
                                }

                                //Verifica se arquivo é reg
                                if (Path.GetExtension(arquivoDestino) == ".reg")
                                {
                                    //Executa o .reg no servidor
                                    if (!ExecutarRegistroWindowsMaquinaRemota(servidor, arquivoDestino, out mensagem))
                                    {
                                        //Caso de errado cai na rotina de restaurar o backup
                                        throw new Exception(string.Format("erro no registro do windows erro: {0}", mensagem));
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                //Apos descompactar o arquivo tem exclui o zip
                                File.Delete(arquivoDestino);

                                //Caso haja backup então restaura
                                if (Directory.Exists(diretorioDestinoBackup))
                                { CriarBackupRede(diretorioDestinoBackup, diretorioDestino, out mensagem); }

                                if (!string.IsNullOrEmpty(mensagem)) { mensagem += ", "; }
                                mensagem = ex.Message;
                                return false;
                            }

                            if (File.Exists(arquivoDestino))
                            {
                                //Exclui somente os arquivos zip
                                if (Path.GetExtension(arquivoDestino) == ".zip")
                                {
                                    //Apos descompactar o arquivo tem exclui o zip
                                    File.Delete(arquivoDestino);
                                }
                            }

                        }
                    }
                    catch (Exception ex) //Se deu algum erro no processo de copiar volta o backup
                    {
                        //Caso haja backup então restaura
                        if (Directory.Exists(diretorioDestinoBackup))
                        { CriarBackupRede(diretorioDestinoBackup, diretorioDestino, out mensagem); }

                        if (!string.IsNullOrEmpty(mensagem)) { mensagem += ", "; }
                        mensagem = ex.Message;
                        return false;
                    }

                    try // vai executar os arquivos de registro que foram descompactados no zip
                    {
                        //Verifica se tem algum arquivo para rodar no registro do windows
                        foreach (string arquivo in arquivosDescompactados.Where(x => Path.GetExtension(x) == ".reg"))
                        {
                            //Executa o .reg no servidor
                            if (!ExecutarRegistroWindowsMaquinaRemota(servidor, arquivo, out mensagem))
                            {
                                //Caso de errado cai na rotina de restaurar o backup
                                throw new Exception("erro no registro do windows");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        //Caso haja backup então restaura
                        if (Directory.Exists(diretorioDestinoBackup))
                        { CriarBackupRede(diretorioDestinoBackup, diretorioDestino, out mensagem); }

                        if (!string.IsNullOrEmpty(mensagem)) { mensagem += ", "; }
                        mensagem = ex.Message;
                        return false;
                    }

                    //Apos realizar o processo exclui a pasta de backup
                    if (Directory.Exists(diretorioDestinoBackup))
                    {
                        DirectoryInfo diretorioBackup = new DirectoryInfo(diretorioDestinoBackup);
                        diretorioBackup.Delete(true);
                    }
                }
            }
            catch (Exception ex)
            {
                if (!string.IsNullOrEmpty(mensagem)) { mensagem += ", "; }
                mensagem += ex.Message;
                return false;
            }
            return true;
        }

        /// <summary>
        /// Cria o backup do arquivos na rede
        /// </summary>
        /// <param name="diretorio">diretorio</param>
        /// <param name="diretorioBackup">diretorio</param>
        /// <returns>Retorna se foi criado ou não</returns>
        private static bool CriarBackupRede(string diretorioPrincipal, string diretorioPrincipalBackup, out string mensagem)
        {
            mensagem = string.Empty;

            try
            {
                //Percorre os diretorios 
                foreach (string diretorio in Directory.GetDirectories(diretorioPrincipal))
                {
                    if (diretorio == diretorioPrincipalBackup) { continue; }
                    string diretorioBackup = Path.Combine(diretorioPrincipalBackup, Path.GetFileName(diretorio));
                    CriarBackupRede(diretorio, diretorioBackup, out mensagem);
                }

                //Cria a pasta de backup
                if (!Directory.Exists(diretorioPrincipalBackup)) { Directory.CreateDirectory(diretorioPrincipalBackup); }

                //Percorre os arquivos
                foreach (string arquivo in Directory.GetFiles(diretorioPrincipal))
                {
                    string arquivoBackup = Path.Combine(diretorioPrincipalBackup, Path.GetFileName(arquivo));
                    if (File.Exists(arquivoBackup)) { File.Delete(arquivoBackup); }
                    File.Copy(arquivo, arquivoBackup);
                }
            }
            catch (Exception ex)
            {
                mensagem = ex.Message;
                return false;
            }
            return true;
        }

        /// <summary>
        /// Retorna todos os arquivos e do diretorio e sub diretorio com a extensao informada
        /// </summary>
        /// <param name="diretorio">Diretorio</param>
        /// <param name="extensao">Extensao com o ponto (.reg)</param>
        /// <returns>Retorna todos os arquivos</returns>
        private static List<string> RetornarArquivosRede(string diretorio, string extensao)
        {
            List<string> retorno = new List<string>();

            //Percorre os diretorios 
            foreach (string subDiretorio in Directory.GetDirectories(diretorio))
            {
                List<string> retornoSubDiretorio = RetornarArquivosRede(subDiretorio, extensao);
                if (retornoSubDiretorio.Count > 0) { retorno.AddRange(retornoSubDiretorio); }
            }

            //Percorre os arquivos cuja a extensao seja a informada
            foreach (string arquivo in Directory.GetFiles(diretorio).Where(x => Path.GetExtension(x) == extensao))
            {
                retorno.Add(arquivo);
            }

            return retorno;
        }

        /// <summary>
        /// Instala o serviço do windows
        /// </summary>
        /// <param name="servidor">Servidor</param>
        /// <param name="diretorio">Diretorio de gravação</param>
        /// <param name="arquivo">Nome do executavel</param>
        /// <param name="mensagem">Mensagem de erro</param>
        /// <returns>Retorna se foi instalado ou não</returns>
        public static bool ExecutarInstalacaoSerivcoWindowsMaquinaRemota(string servidor, string diretorio, string arquivo, out string mensagem)
        {
            try
            {

                //Monta o raiz do servidor
                string raiz = string.Concat(@"\", @"\", servidor, @"\c$");

                //Remove o diretorio raiz (C:\)
                diretorio = diretorio.Replace(Directory.GetDirectoryRoot(diretorio), "");

                //Adiciona o endereço do servidor
                diretorio = Path.Combine(raiz, diretorio, arquivo);

                string comando = string.Format(@"C:\Windows\Microsoft.NET\Framework64\v4.0.30319\InstallUtil.exe ""{0}""", diretorio);
                return ExecutarComandoMaquinaRemota(servidor, comando, out mensagem);

            }
            catch (Exception ex)
            {
                mensagem = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Executa o registro do windows
        /// </summary>
        /// <param name="servidor">Servidor</param>
        /// <param name="arquivo">arquivo para regstrar</param>
        /// <returns>Retorna se foi registrado ou não</returns>
        private static bool ExecutarRegistroWindowsMaquinaRemota(string servidor, string arquivo, out string mensagem)
        {
            string comando = string.Format("reg import {0}", arquivo);
            return ExecutarComandoMaquinaRemota(servidor, comando, out mensagem);
        }

        /// <summary>
        /// Executa o registro do windows
        /// </summary>
        /// <param name="servidor">Servidor</param>
        /// <param name="comando">Comando para execução</param>
        /// <returns>Retorna se foi registrado ou não</returns>
        private static bool ExecutarComandoMaquinaRemota(string servidor, string comando, out string mensagem)
        {
            mensagem = string.Empty;
            int resultado = 0;

            try
            {
                String ns = @"root\cimv2";

                ConnectionOptions options = new ConnectionOptions();
                options.Impersonation = System.Management.ImpersonationLevel.Impersonate;
                options.EnablePrivileges = true;
                options.Username = Credenciais.Usuario;
                options.Password = Credenciais.Senha;

                ManagementScope scope = new ManagementScope(string.Format(@"\\{0}\{1}", servidor, ns), options);
                scope.Connect();

                ObjectGetOptions objectGetOptions = new ObjectGetOptions();
                ManagementPath managementPath = new ManagementPath("Win32_Process");
                ManagementClass processClass = new ManagementClass(scope, managementPath, objectGetOptions);

                ManagementBaseObject inParams = processClass.GetMethodParameters("Create");
                inParams["CommandLine"] = comando;

                ManagementBaseObject outParams = processClass.InvokeMethod("Create", inParams, null);

                if (!int.TryParse(outParams["returnValue"].ToString(), out resultado))
                {
                    mensagem = "Não foi possivel obter o valor de resposta do servidor";
                    return false;
                }

                if (resultado != 0) { mensagem = string.Format("Não foi possivel executar o comando {0}, erro nº: {1}", comando, resultado.ToString()); return false; }

                return true;
            }
            catch (Exception ex)
            {
                mensagem = ex.Message;
                return false;
            }
        }

        #region Enums

        /// <summary>
        /// Tipo de comando par ao serviço
        /// </summary>
        public enum TipoComandoServico
        {
            Iniciar = 1,
            Parar = 2,
            Pausar = 3
        }

        /// <summary>
        /// Status do serviço
        /// </summary>
        public enum TipoStatusServico
        {
            Rodando = 1,
            Parado = 2,
            NaoInstalado = 3
        }
        #endregion
    }
}
