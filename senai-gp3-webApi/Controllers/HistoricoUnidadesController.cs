using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_gp3_webApi.Interfaces;
using System;

namespace senai_gp3_webApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class HistoricoUnidadesController : ControllerBase
    {
        private IHistoricoUnidadeRepository _historicoUnidadeRepository { get; set; }

        public HistoricoUnidadesController(IHistoricoUnidadeRepository repo)
        {
            _historicoUnidadeRepository = repo;
        }

        [HttpGet("Listar/{idUnidade}")]
        //[Authorize(Roles = "1, 2")]
        public IActionResult ListarHistorioPorUsuario(int idUnidade)
        {
            try
            {
                return Ok(_historicoUnidadeRepository.ListarRegistrosPorUnidade(idUnidade));
            }
            catch (Exception execp)
            {
                return BadRequest(execp);
            };
        }
    }
}
