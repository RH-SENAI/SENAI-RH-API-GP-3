using Microsoft.AspNetCore.Mvc;
using senai_gp3_webApi.Domains;
using senai_gp3_webApi.Interfaces;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace senai_gp3_webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnidadesenaisController : ControllerBase
    {
        private readonly IUnidadesenaiRepository _unidadeSenaiRepository;

        public UnidadesenaisController(IUnidadesenaiRepository repo)
        {
            _unidadeSenaiRepository = repo;   
        }

        // GET: api/<UnidadesenaisController>
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

        // GET api/<UnidadesenaisController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UnidadesenaisController>
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

        // PUT api/<UnidadesenaisController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UnidadesenaisController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
