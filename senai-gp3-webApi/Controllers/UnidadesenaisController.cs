using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using senai_gp3_webApi.Domains;
using senai_gp3_webApi.Interfaces;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace senai_gp3_webApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class UnidadesenaisController : ControllerBase
    {
        private readonly IUnidadesenaiRepository _unidadeSenaiRepository;

        public UnidadesenaisController(IUnidadesenaiRepository repo)
        {
            _unidadeSenaiRepository = repo;   
        }

        // GET: api/<UnidadesenaisController>
        //[Authorize(Roles = "2, 3")]
        [HttpGet("Listar")]
        public IActionResult ListarUnidadesSenai()
        {
            try
            {
                return Ok(_unidadeSenaiRepository.ListarUniSenai());
            }
            catch (Exception execp)
            {
                return BadRequest(execp);
            };
        }

        //[Authorize(Roles = "1, 2, 3")]
        [HttpGet("Listar/{idUnidade}")]
        public IActionResult ListarUniSenaiPorId(int idUnidade)
        {
            try
            {
                if (idUnidade == 0)
                {
                    return BadRequest("O id da Unidade não pode ser 0 !");
                }

                return Ok(_unidadeSenaiRepository.ListarUniSenaiPorId(idUnidade));
            }
            catch (Exception execp)
            {
                return BadRequest(execp);
            };
        }


        // POST api/<UnidadesenaisController>
        //[Authorize(Roles = "3")]
        [HttpPost("Cadastrar")]
        public IActionResult CadastrarUnidade(Unidadesenai novaUnidadesenai)
        {
            try
            {
                if (novaUnidadesenai == null)
                {
                    return BadRequest("Objeto não pode estar vazio!");
                }
                else
                {
                    _unidadeSenaiRepository.CadastrarUniSenai(novaUnidadesenai);
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
