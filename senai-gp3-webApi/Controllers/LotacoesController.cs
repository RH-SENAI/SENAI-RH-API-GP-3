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
    public class LotacoesController : ControllerBase
    {
        private readonly ILotacaoRepository _lotacaoRepository;

        public LotacoesController(ILotacaoRepository repo)
        {
            _lotacaoRepository = repo;
        }

        [HttpGet("Listar")]
        public IActionResult ListarLotacao()
        {
            try
            {
                return Ok(_lotacaoRepository.ListarAssociacoes());
            }
            catch (Exception execp)
            {
                return BadRequest(execp);
            }
        }

        [HttpPost("Cadastrar")]
        public IActionResult CadastraLotacao(int idFuncionario, int idGrupo)
        {
            try
            {

                if (idGrupo != 0 && idFuncionario != 0)
                {
                    _lotacaoRepository.AssociarUsuario(idFuncionario, idGrupo);
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
