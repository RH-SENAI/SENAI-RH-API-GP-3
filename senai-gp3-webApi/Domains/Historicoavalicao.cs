using System;
using System.Collections.Generic;

#nullable disable

namespace senai_gp3_webApi.Domains
{
    public partial class Historicoavalicao
    {
        public int IdHistoricoAvaliacao { get; set; }
        public int IdUsuario { get; set; }
        public DateTime AtualizadoEm { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
