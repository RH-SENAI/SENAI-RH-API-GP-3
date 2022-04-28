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


        // GET: api/<DecisoesController>
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
        [HttpPost("Cadastrar")]
        public IActionResult CadastrarDecisoes(Decisao novaDecisao)
        {
            try
            {
                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                if (novaDecisao == null)
                {
                    return BadRequest("Objeto Vazio!");

                } else
                {
                    novaDecisao.IdUsuario = idUsuario;
                    _decisaoRepository.CadastrarDecisao(novaDecisao);
                    return StatusCode(201);
                }
            }
            catch (Exception execp)
            {
                return BadRequest(execp);
            }
        }
    }
}
