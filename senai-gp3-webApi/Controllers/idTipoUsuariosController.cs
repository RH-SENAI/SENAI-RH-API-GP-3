using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using senai_gp3_webApi.Interfaces;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace senai_gp3_webApi.Controllers
{
    

    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class idTipoUsuariosController : ControllerBase
    {
        private readonly IIdTipoUsuarioRepository _idTipoUsuarioRepository;

        public idTipoUsuariosController(IIdTipoUsuarioRepository repo)
        {
            _idTipoUsuarioRepository = repo;
        }

        // GET: api/<idTipoUsuariosController>
        //[Authorize(Roles = "2, 3")]
        [HttpGet("Listar")]
        public IActionResult ListarIdTiposUsuarios()
        {
            try
            {
                return Ok(_idTipoUsuarioRepository.ListarTipoUsuario());
            }
            catch (Exception execp)
            {
                return BadRequest(execp);
            };
        }
    }
}