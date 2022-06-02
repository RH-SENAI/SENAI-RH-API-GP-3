using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_gp3_webApi.Domains;
using senai_gp3_webApi.Interfaces;
using senai_gp3_webApi.ViewModels;
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

        //[Authorize(Roles = "2, 3")]
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
        
        //[Authorize(Roles = "2, 3")]
        [HttpPost("Cadastrar/{idFuncionario}/{idGrupo}")]
        public IActionResult CadastraLotacao(LotacaoViewModel novaLotacao)
        {
            try
            {

                if (novaLotacao != null)
                {
                    _lotacaoRepository.AssociarUsuario(novaLotacao);
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
