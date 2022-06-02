using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_gp3_webApi.Domains;
using senai_gp3_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_gp3_webApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class AvaliacaoUsuariosController : ControllerBase
    {
        private readonly IAvaliacaoUsuarioRepository _avaliacaoUsuarioRepository;

        public AvaliacaoUsuariosController(IAvaliacaoUsuarioRepository repo)
        {
            _avaliacaoUsuarioRepository = repo;
        }


        
        //[Authorize(Roles = "2, 3")]
        [HttpGet("Listar/{idAvaliacaoUsuario}")]
        public IActionResult ListaUsuarioPorId(int idAvaliacaoUsuario)
        {
            try
            {
                if (idAvaliacaoUsuario == 0)
                {
                    return BadRequest("O id da AvaliacaoUsuario não pode ser 0 !");
                }

                return Ok(_avaliacaoUsuarioRepository.ListarAvaliacaoUsuarioPorId(idAvaliacaoUsuario));
            }
            catch (Exception execp)
            {
                return BadRequest(execp);
            }
        }

        [Authorize(Roles = "2, 3")]
        [HttpGet("Listar")]
        public IActionResult ListarAvaliacaoUsuarios()
        {
            try
            {
                return Ok(_avaliacaoUsuarioRepository.ListarAvaliacaoUsuario());

            }
            catch (Exception execp)
            {
                return BadRequest(execp);
            }
        }

        //[Authorize(Roles = "2, 3")]
        [HttpPost("Cadastrar")]
        public IActionResult CadastrarAvaliacaoUsuario(Avaliacaousuario novaAvaliacaoUsuario)
        {
            try
            {
                if (novaAvaliacaoUsuario == null)
                {
                    return BadRequest("Todos os campos da avaliacao devem ser preenchidos !");
                }
                else
                {
                    _avaliacaoUsuarioRepository.CadastrarAvalicaoUsuario(novaAvaliacaoUsuario);
                    return StatusCode(201);
                }
            }
            catch (Exception exp)
            {

                return BadRequest(exp);
            }
        }
    }
}