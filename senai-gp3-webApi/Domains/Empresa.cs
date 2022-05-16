﻿using System;
using System.Collections.Generic;

#nullable disable

namespace senai_gp3_webApi.Domains
{
    public partial class Empresa
    {
        public Empresa()
        {
            Descontos = new HashSet<Desconto>();
        }

        public int IdEmpresa { get; set; }
        public int IdLocalizacao { get; set; }
        public string NomeEmpresa { get; set; }
        public string EmailEmpresa { get; set; }
        public string TelefoneEmpresa { get; set; }
        public string CaminhoImagemEmpresa { get; set; }

        public virtual Localizacao IdLocalizacaoNavigation { get; set; }
        public virtual ICollection<Desconto> Descontos { get; set; }
    }
}
