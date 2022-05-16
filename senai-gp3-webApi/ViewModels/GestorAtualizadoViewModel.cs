using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai_gp3_webApi.ViewModels
{
    public class GestorAtualizadoViewModel
    {
        public byte IdCargo { get; set; }

        public int IdUnidadeSenai { get; set; }

        public byte IdTipoUsuario { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        public string Cpf { get; set; }

        public string CaminhoFotoPerfil { get; set; }
    }
}
