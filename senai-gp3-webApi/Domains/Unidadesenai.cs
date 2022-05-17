﻿using System;
using System.Collections.Generic;

#nullable disable

namespace senai_gp3_webApi.Domains
{
    public partial class Unidadesenai
    {
        public Unidadesenai()
        {
            Avaliacaounidadesenais = new HashSet<Avaliacaounidadesenai>();
            Usuarios = new HashSet<Usuario>();
        }

        public int IdUnidadeSenai { get; set; }
        public int IdLocalizacao { get; set; }
        public string NomeUnidadeSenai { get; set; }
        public decimal MediaAvaliacaoUnidadeSenai { get; set; }
        public string TelefoneUnidadeSenai { get; set; }
        public string EmailUnidadeSenai { get; set; }
        public decimal? NotaProdutividade { get; set; }
        public decimal Positive { get; set; }
        public decimal Negativo { get; set; }
        public decimal Neutro { get; set; }
        public int? FuncionarioAtivos { get; set; }
        public int? QtdDeFuncionarios { get; set; }

        public virtual Localizacao IdLocalizacaoNavigation { get; set; }
        public virtual ICollection<Avaliacaounidadesenai> Avaliacaounidadesenais { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
