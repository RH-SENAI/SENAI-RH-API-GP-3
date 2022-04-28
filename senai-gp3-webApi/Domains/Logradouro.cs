using System;
using System.Collections.Generic;

#nullable disable

namespace senai_gp3_webApi.Domains
{
    public partial class Logradouro
    {
        public Logradouro()
        {
            Localizacaos = new HashSet<Localizacao>();
        }

        public int IdLogradouro { get; set; }
        public string NomeLogradouro { get; set; }

        public virtual ICollection<Localizacao> Localizacaos { get; set; }
    }
}
