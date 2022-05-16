﻿using System;
using System.Collections.Generic;

#nullable disable

namespace senai_gp3_webApi.Domains
{
    public partial class Curso
    {
        public int IdCurso { get; set; }
        public int IdEmpresa { get; set; }
        public string NomeCurso { get; set; }
        public string DescricaoCurso { get; set; }
        public string SiteCurso { get; set; }
        public bool ModalidadeCurso { get; set; }
        public string CaminhoImagemCurso { get; set; }
        public int CargaHoraria { get; set; }
        public DateTime DataFinalizacao { get; set; }
        public decimal MediaAvaliacaoCurso { get; set; }
        public byte? IdSituacaoInscricao { get; set; }
        public int? ValorCurso { get; set; }
    }
}
