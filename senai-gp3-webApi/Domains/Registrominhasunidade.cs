using System;
using System.Collections.Generic;

#nullable disable

namespace senai_gp3_webApi.Domains
{
    public partial class Registrominhasunidade
    {
        public int IdMinhasUnidades { get; set; }
        public int IdUsuario { get; set; }
        public int IdUnidadeSenai { get; set; }

        public virtual Unidadesenai IdUnidadeSenaiNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
