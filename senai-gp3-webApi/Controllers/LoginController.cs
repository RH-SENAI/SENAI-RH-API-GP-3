using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai_gp3_webApi.Domains;
using senai_gp3_webApi.Repositories;
using senai_gp3_webApi.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace senai_gp3_webApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        // instânica do tipo usuárioRepository que contém os métodos
        private IUsuarioRepository _usuarioRepository { get; set; }

        public LoginController(IUsuarioRepository repo)
        {
            _usuarioRepository = repo;
        }

        // POST api/<UsuariosController>
        [HttpPost]
        public IActionResult Logar(LoginViewModel login)
        {
            try
            {
                //buscando um usuário
                Usuario usuarioBuscado = _usuarioRepository.Login(login.Cpf, login.Senha);

                if (usuarioBuscado != null)
                {

                    //declarando as claims
                    var minhasClaims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                        new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                        new Claim(ClaimTypes.Role, usuarioBuscado.IdTipoUsuario.ToString()),

                        //definindo uma nova claim para colocar o token
                        new Claim("role", usuarioBuscado.IdTipoUsuario.ToString())

                    };

                    //key word para descriptografar a informação
                    var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("senairh-autenticacao-token"));

                    //encriptografando os dados
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    //declarando atributos do token
                    var MeuToken = new JwtSecurityToken(

                        issuer: "SenaiRH_G1.WebApi",
                        audience: "SenaiRH_G1.WebApi",

                        //claims/informações
                        claims: minhasClaims,

                        //data de expiração
                        expires: DateTime.Now.AddMinutes(30),
                        signingCredentials: creds
                        );

                    //escrevendo o token e devolvedo
                    return Ok(new
                    {
                        //escrever o token
                        token = new JwtSecurityTokenHandler().WriteToken(MeuToken)
                    }
                        );
                }

                return NotFound(
                    new
                    {
                        mensagem = "Cpf/Senha passados estão incorretos ou o usuário não existe !",
                        erro = true
                    }

                    );
            }
            catch (Exception excep)
            {
                return BadRequest(
                    new
                    {
                        mensagem = "Algo deu errado no servidor !",
                        erro = excep
                    }
                    );
            }
        }
    }
}
