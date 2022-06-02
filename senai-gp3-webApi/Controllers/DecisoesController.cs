using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using senai_gp3_webApi.Domains;
using senai_gp3_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace senai_gp3_webApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class DecisoesController : ControllerBase
    {
        private readonly IDecisaoRepository _decisaoRepository;

        public DecisoesController(IDecisaoRepository repo)
        {
            _decisaoRepository = repo;
        }



        //[Authorize(Roles = "1, 2, 3")]
        [HttpGet("Listar")]
        public IActionResult ListarDecisoes()
        {
            try
            {
                return Ok(_decisaoRepository.ListarDecisoes());
            }
            catch (Exception execp)
            {
                return BadRequest(execp);
            }
        }

        // POST api/<DecisoesController>
        //[Authorize(Roles = "2")]
        [HttpPost("Cadastrar")]
        public IActionResult CadastrarDecisoes(Decisao novaDecisao)
        {
            try
            {
                //int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                if (novaDecisao == null)
                {
                    return BadRequest("Objeto Vazio!");
                }
                else
                {
                    novaDecisao.IdUsuario = novaDecisao.IdUsuario;
                    _decisaoRepository.CadastrarDecisao(novaDecisao);
                    return StatusCode(201);
                }
            }
            catch (Exception execp)
            {
                return BadRequest(execp);
            }
        }

        //[Authorize(Roles = "1, 2, 3")]
        [HttpGet("Listar/{idDecisao}")]
        public IActionResult ListarDecisaoPorId(int idDecisao)
        {
            try
            {
                if (idDecisao == 0)
                {
                    return BadRequest("O id da Decisao não pode ser 0 !");
                }

                return Ok(_decisaoRepository.ListarDecisaoPorId(idDecisao));
            }
            catch (Exception execp)
            {
                return BadRequest(execp);
            }
        }
    }
}
