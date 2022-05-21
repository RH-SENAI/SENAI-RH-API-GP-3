using System.ComponentModel.DataAnnotations;

namespace senai_gp3_webApi.ViewModels
{
    public class LotacaoViewModel
    {
        [Required(ErrorMessage = "Cpf é obrigatório")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "id do Grupo é obrigatório")]
        public byte IdGrupo { get; set; }
    }
}
