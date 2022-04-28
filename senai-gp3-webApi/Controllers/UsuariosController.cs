using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_gp3_webApi.Domains;
using senai_gp3_webApi.Utils;
using senai_gp3_webApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace senai_gp3_webApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {

        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuariosController(IUsuarioRepository repo)
        {
            _usuarioRepository = repo;
        }

        [HttpGet("Listar")]
        public IActionResult ListarUsuario()
        {
            try
            {
                return Ok(_usuarioRepository.ListarUsuario());

            }
            catch (Exception execp)
            {

                return BadRequest(execp);
            }
        }


        [HttpGet("Listar/{idUsuario}")]
        public IActionResult ListaUsuarioPorId(int idUsuario)
        {
            try
            {
                if (idUsuario != 0)
                {
                    return BadRequest("O id do Usuário não pode ser 0 !");
                }

                return Ok(_usuarioRepository.ListarUsuarioPorId(idUsuario));
            }
            catch (Exception execp)
            {
                return BadRequest(execp);
            }
        }

        [HttpPost("Cadastrar")]
        public IActionResult CadastrarUsuario([FromForm] UsuarioCadastroViewModel novoUsuario, IFormFile fotoPerfil)
        {
            try
            {
                if (fotoPerfil == null)
                {
                    novoUsuario.CaminhoFotoPerfil = "imagem-padrao.png";
                }
                else
                {
                    #region Upload da Imagem com extensões permitidas apenas
                    string uploadResultado = Upload.EnviarFoto(fotoPerfil).ToString();

                    if (uploadResultado == "")
                    {
                        return BadRequest("Arquivo não encontrado !");
                    }
                    if (uploadResultado == "Extensão não permitida")
                    {
                        return BadRequest("Extensão do arquivo não permitida");
                    }

                    novoUsuario.CaminhoFotoPerfil = uploadResultado;
                    #endregion
                }

                if (novoUsuario == null)
                {
                    return BadRequest("Todos os campos do usuario devem ser preenchidos !");
                }
                else
                {
                    _usuarioRepository.CadastrarUsuario(novoUsuario);
                    return StatusCode(201);
                }
            }
            catch (Exception exp)
            {

                return BadRequest(exp);
            }
        }

        [HttpPut("Atualizar/Gestor/{idUsuario}")]
        public IActionResult AtualizarGestor(int idUsuario, [FromForm] GestorAtualizadoViewModel gestorAtualizado, IFormFile novaFotoPerfil)
        {
            try
            {
                //Procura um usuario com o id passado
                var gestorAchado = _usuarioRepository.ListarUsuarioPorId(idUsuario);

                if (gestorAchado != null)
                {
                    //Verifica se esse usuário é um gestor
                    if (gestorAchado.IdTipoUsuario == 2)
                    {
                        if (novaFotoPerfil != null)
                        {
                            gestorAchado.CaminhoFotoPerfil = Upload.AtualizarFoto(gestorAchado.CaminhoFotoPerfil, novaFotoPerfil);
                        }

                        return Ok(_usuarioRepository.AtualizarGestor(idUsuario, gestorAtualizado));
                    }

                    return BadRequest("O Usuário passado não é um gestor !");
                }
                else
                {
                    return BadRequest("Nenhum campo foi atualizado");
                }
            }
            catch (Exception execp)
            {
                return BadRequest(execp);
            }
        }


        [HttpPut("Atualizar/Funcionario/{idUsuario}")]
        public IActionResult AtualizarFuncionario(int idUsuario, FuncionarioAtualizadoViewModel funcionarioAtualizado, IFormFile novaFotoPerfil)
        {
            try
            {
                var funcionarioAchado = _usuarioRepository.ListarUsuarioPorId(idUsuario);

                if (funcionarioAchado != null)
                {
                    //Verifica se esse usuário é um funcionario
                    if (funcionarioAchado.IdTipoUsuario == 1)
                    {
                        //Verifica se o funcionario quis atualizar sua própria foto
                        if (novaFotoPerfil != null)
                        {
                            //Atualiza a foto lá no blob
                            funcionarioAchado.CaminhoFotoPerfil = Upload.AtualizarFoto(funcionarioAchado.CaminhoFotoPerfil, novaFotoPerfil);
                        }

                        return Ok(_usuarioRepository.AtualizarFuncionario(idUsuario, funcionarioAtualizado));
                    }

                    return BadRequest("O Usuário passado não é um funcionário !");

                }
                else
                {
                    return BadRequest("Nenhum campo foi atualizado");
                }
            }
            catch (Exception execp)
            {
                return BadRequest(execp);
            }
        }

        // DELETE api/<UsuariosController>/5
        [HttpDelete("Deletar/{id}")]
        public IActionResult DeletarUsuario(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest("O id passado não pode ser 0");
                }
                else
                {
                    _usuarioRepository.DeletarUsuario(id);
                    return NoContent();
                }
            }
            catch (Exception execp)
            {
                return BadRequest(execp);
            }
        }


        /*** ESSE METÓDO SERVIU APENAS PARA TESTAR SE O REMOVER FOTO ESTAVA FUNCIONANDO ***/

        //[HttpDelete("Deletar/Foto/{id}")]
        //public IActionResult DeletarFoto(int id)
        //{
        //    try
        //    {


        //        if (id == 0)
        //        {
        //            return BadRequest("O id passado não pode ser 0");
        //        }
        //        else
        //        {
        //            _usuarioRepository.RemoverFotoDePerfil(id);
        //            return NoContent();
        //        }
        //    }
        //    catch (Exception execp)
        //    {
        //        return BadRequest(execp);
        //    }
        //}
    }
}
