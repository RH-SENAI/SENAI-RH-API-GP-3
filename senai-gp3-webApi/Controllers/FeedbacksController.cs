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
    public class FeedbacksController : ControllerBase
    {
        private readonly IFeedbackRepository _feedBacksRepostory;

        public FeedbacksController(IFeedbackRepository repo)
        {
            _feedBacksRepostory = repo;
        }

        // GET: api/<FeedbacksController>
        [HttpGet("Listar")]
        public IActionResult ListarFeedbacks()
        {
            try
            {
                return Ok(_feedBacksRepostory.ListarFb());
            }
            catch (Exception execp)
            {
                return BadRequest(execp);
            }
            ;
        }

        // POST api/<FeedbacksController>
        [HttpPost("Cadastrar")]
        public IActionResult CadastrarFeedback(Feedback novoFeedback)
        {
            try
            {
                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);
                if (novoFeedback == null)
                {
                    return BadRequest("Objeto não pode estar vazio!");
                } else
                {
                    novoFeedback.IdUsuario = idUsuario;
                    _feedBacksRepostory.CadastrarFb(novoFeedback);
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
