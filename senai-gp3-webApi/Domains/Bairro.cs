using System;
using System.Collections.Generic;

#nullable disable

namespace senai_gp3_webApi.Domains
{
    public partial class Bairro
    {
        public Bairro()
        {
            Localizacaos = new HashSet<Localizacao>();
        }

        public int IdBairro { get; set; }
        public string NomeBairro { get; set; }

        public virtual ICollection<Localizacao> Localizacaos { get; set; }
    }
}
