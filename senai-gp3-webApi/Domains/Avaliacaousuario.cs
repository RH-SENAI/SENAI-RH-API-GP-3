﻿using System;
using System.Collections.Generic;

#nullable disable

namespace senai_gp3_webApi.Domains
{
    public partial class Avaliacaousuario
    {
        public int IdAvaliacaoUsuario { get; set; }
        public int IdUsuarioAvaliado { get; set; }
        public int IdUsuarioAvaliador { get; set; }
        public string AvaliacaoUsuario1 { get; set; }
        public int ValorMoedas { get; set; }

        public virtual Usuario IdUsuarioAvaliadoNavigation { get; set; }
        public virtual Usuario IdUsuarioAvaliadorNavigation { get; set; }
    }
}
