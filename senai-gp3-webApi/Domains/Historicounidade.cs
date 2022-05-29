using System;
using System.Collections.Generic;

#nullable disable

namespace senai_gp3_webApi.Domains
{
    public partial class Historicounidade
    {
        public int IdHistoricoUnidade { get; set; }
        public int IdUnidade { get; set; }
        public decimal MediaSatisfacao { get; set; }
        public decimal MediaProdutividade { get; set; }
        public int QtdDeFuncionarios { get; set; }
        public int QtdDeFuncionariosAtivos { get; set; }
        public DateTime AtualizadoEm { get; set; }

        public virtual Unidadesenai IdUnidadeNavigation { get; set; }
    }
}
