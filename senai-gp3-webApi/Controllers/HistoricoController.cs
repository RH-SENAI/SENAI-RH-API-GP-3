using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using senai_gp3_webApi.Domains;
using senai_gp3_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace senai_gp3_webApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class HistoricoAController : ControllerBase
    {

        private IHistoricoRepository _historicoRepository { get; set; }

        public HistoricoAController(IHistoricoRepository repo)
        {
            _historicoRepository = repo;
        }

        //[Authorize(Roles = "1, 2, 3")]
        [HttpGet("Listar/{idUsuario}")]
        public IActionResult ListarHistorioPorUsuario(int idUsuario)
        {
            try
            {
                return Ok(_historicoRepository.ListarRegistrosPorUsuario(idUsuario));
            }
            catch (Exception execp)
            {
                return BadRequest(execp);
            };
        }
    }
}
