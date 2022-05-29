using System;
using System.Collections.Generic;

#nullable disable

namespace senai_gp3_webApi.Domains
{
    public partial class Unidadesenai
    {
        public Unidadesenai()
        {
            Historicounidades = new HashSet<Historicounidade>();
            Registrominhasunidades = new HashSet<Registrominhasunidade>();
            Usuarios = new HashSet<Usuario>();
        }

        public int IdUnidadeSenai { get; set; }
        public int? IdLocalizacao { get; set; }
        public string NomeUnidadeSenai { get; set; }
        public string TelefoneUnidadeSenai { get; set; }
        public string EmailUnidadeSenai { get; set; }
        public decimal MediaSatisfacaoUnidadeSenai { get; set; }
        public decimal MediaProdutividadeUnidadeSenai { get; set; }
        public decimal MediaAvaliacaoUnidadeSenai { get; set; }
        public int QtdDeFuncionarios { get; set; }
        public int QtdFuncionariosAtivos { get; set; }

        public virtual Localizacao IdLocalizacaoNavigation { get; set; }
        public virtual ICollection<Historicounidade> Historicounidades { get; set; }
        public virtual ICollection<Registrominhasunidade> Registrominhasunidades { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
