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
    public class GruposController : ControllerBase
    {
        private readonly IGrupoRepository _grupoRepository;

        public GruposController(IGrupoRepository repo)
        {
            _grupoRepository = repo;
        }

        //[Authorize(Roles = "2, 3")]
        [HttpGet("Listar")]
        public IActionResult ListarGrupos()
        {
            try
            {
                return Ok(_grupoRepository.ListarGrupos());
            }
            catch (Exception execp)
            {
                return BadRequest(execp);
            }
        }

        //[Authorize(Roles = "3")]
        [HttpPost("Cadastrar")]
        public IActionResult CadastraGrupo(Grupo novoGrupo)
        {
            try
            {
                if(novoGrupo != null)
                {
                    _grupoRepository.CadastrarGrupo(novoGrupo);
                    return StatusCode(201);
                }

                return BadRequest("Os id's passados são 0 !");
            }
            catch (Exception exp)
            {

                return BadRequest(exp);
            }
        }
    }
}
