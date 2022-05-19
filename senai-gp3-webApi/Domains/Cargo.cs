using System;
using System.Collections.Generic;

#nullable disable

namespace senai_gp3_webApi.Domains
{
    public partial class Cargo
    {
        public Cargo()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public byte IdCargo { get; set; }
        public string NomeCargo { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
