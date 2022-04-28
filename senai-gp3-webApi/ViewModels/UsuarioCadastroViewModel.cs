using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace senai_gp3_webApi.ViewModels
{
    public class UsuarioCadastroViewModel
    {

        [Required(ErrorMessage = "IdCargo deve ser preenchido!")]
        public byte IdCargo { get; set; }
        
        [Required(ErrorMessage = "IdUnidadeSenai deve ser preenchido!")]
        public int IdUnidadeSenai { get; set; }
        
        [Required(ErrorMessage = "IdTipoUsuario deve ser preenchido!")]
        public byte IdTipoUsuario { get; set; }
        
        [Required(ErrorMessage = "Nome deve ser preenchido!")]
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "O Email deve ser preenchido!")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Senha deve ser preenchido!")]
        public string Senha { get; set; }
        
        [Required(ErrorMessage = "Data deve ser preenchida!")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }
        
        public short Vantagens { get; set; }
        
        public decimal NivelSatisfacao { get; set; }
        
        [Required(ErrorMessage = "CPF deve ser preenchido!")]
        public string Cpf { get; set; }
        
        public int SaldoMoeda { get; set; }
        
        public int Trofeus { get; set; }

        [Required(ErrorMessage = "Localizacao do Usuario não poder ser nula!")]
        public string LocalizacaoUsuario { get; set; }
        
        public string CaminhoFotoPerfil { get; set; }
        
    }
}