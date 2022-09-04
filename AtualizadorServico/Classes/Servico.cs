using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtualizadorServico.Classes
{
    /// <summary>
    /// Classe que contem os dados do seviço do windows
    /// </summary>
    public class Servico
    {
        /// <summary>
        /// Nome do serviço
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Display
        /// </summary>
        public string Display { get; set; }

        /// <summary>
        /// Detalhe
        /// </summary>
        public string Descricao { get; set; }

        /// <summary>
        /// Endereco do arquivo executavel
        /// </summary>
        public string EnderecoExecutavel { get; set; }

        /// <summary>
        /// Versao
        /// </summary>
        public string Versao { get; set; }

        /// <summary>
        /// Status do serviço
        /// </summary>
        public RedeSistema.TipoStatusServico Status { get; set; }
    }
}
