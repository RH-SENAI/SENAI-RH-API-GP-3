using Newtonsoft.Json;
using senai_gp3_webApi.Contexts;
using senai_gp3_webApi.Domains;
using senai_gp3_webApi.Utils;
using senai_gp3_webApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_gp3_webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly senaiRhContext ctx;

        public UsuarioRepository(senaiRhContext appContext)
        {
            ctx = appContext;
        }

        public Usuario AtualizarFuncionario(int idUsuario, FuncionarioAtualizadoViewModel funcionarioAtualizado)
        {
            var funcionarioAchado = ctx.Usuarios.FirstOrDefault(u => u.IdUsuario == idUsuario);

            if (funcionarioAtualizado.Senha != null)
            {
                funcionarioAchado.Senha = Criptografia.CriptografarSenha(funcionarioAtualizado.Senha);
            }

            if (funcionarioAtualizado.CaminhoFotoPerfil != null)
            {
                funcionarioAchado.CaminhoFotoPerfil = funcionarioAtualizado.CaminhoFotoPerfil ;
            }

            ctx.Usuarios.Update(funcionarioAchado);
            ctx.SaveChanges();

            return funcionarioAchado;
        }

        public Usuario AtualizarGestor(int idUsuario, GestorAtualizadoViewModel GestorAtualizado)
        {
            var GestorAchado = ctx.Usuarios.FirstOrDefault(u => u.IdUsuario == idUsuario);

            if (GestorAchado != null)
            {

                if (GestorAtualizado.Nome != null)
                {
                    GestorAchado.Nome = GestorAtualizado.Nome;
                }

                if (GestorAtualizado.Email != null)
                {
                    GestorAchado.Email = GestorAtualizado.Email;
                }

                if (GestorAtualizado.Senha != null)
                {
                    GestorAchado.Senha = GestorAtualizado.Senha;
                }

                if (GestorAtualizado.Cpf != null)
                {
                    GestorAchado.Cpf = GestorAtualizado.Cpf;
                }

                if (GestorAtualizado.CaminhoFotoPerfil != null)
                {
                    GestorAchado.CaminhoFotoPerfil = GestorAtualizado.CaminhoFotoPerfil;
                }

                if (GestorAtualizado.DataNascimento < GestorAtualizado.DataNascimento)
                {
                    GestorAchado.DataNascimento = GestorAtualizado.DataNascimento;
                }

                if (GestorAtualizado.IdTipoUsuario != 0)
                {
                    GestorAchado.IdTipoUsuario = GestorAtualizado.IdTipoUsuario;
                }

                if (GestorAtualizado.IdCargo != 0)
                {
                    GestorAchado.IdCargo = GestorAtualizado.IdCargo;
                }

                if (GestorAtualizado.IdUnidadeSenai != 0)
                {
                    GestorAchado.IdUnidadeSenai = GestorAtualizado.IdUnidadeSenai;
                }

                if (GestorAtualizado.LocalizacaoUsuario != null)
                {
                    GestorAchado.LocalizacaoUsuario = GestorAtualizado.LocalizacaoUsuario;
                }

                ctx.Usuarios.Update(GestorAchado);
                ctx.SaveChanges();

                return GestorAchado;
            }

            return null;
        }

        public void CadastrarUsuario(UsuarioCadastroViewModel novoUsuario)
        {
            Usuario usuario = new Usuario()
            {

                Nome = novoUsuario.Nome,
                Email = novoUsuario.Email,
                Senha = novoUsuario.Senha,
                Cpf = novoUsuario.Cpf,
                CaminhoFotoPerfil = novoUsuario.CaminhoFotoPerfil,
                DataNascimento = novoUsuario.DataNascimento,
                IdTipoUsuario = novoUsuario.IdTipoUsuario,
                Trofeus = novoUsuario.Trofeus,
                IdCargo = novoUsuario.IdCargo,
                IdUnidadeSenai = novoUsuario.IdUnidadeSenai,
                LocalizacaoUsuario = novoUsuario.LocalizacaoUsuario,
                NivelSatisfacao = novoUsuario.NivelSatisfacao,
                SaldoMoeda = novoUsuario.SaldoMoeda,
                Vantagens = novoUsuario.Vantagens
            };

            ctx.Usuarios.Add(usuario);


            ctx.SaveChanges();
        }


        public string CalcularMediaAvaliacao(int idUsuario)
        {
            throw new System.NotImplementedException();
        }

        public string CalcularSatisfacao(int idUsuario)
        {
            throw new System.NotImplementedException();
        }

        public void DeletarUsuario(int idUsuario)
        {
            var usuarioAchado = ctx.Usuarios.FirstOrDefault(u => u.IdUsuario == idUsuario);
            ctx.Usuarios.Remove(usuarioAchado);
            ctx.SaveChanges();
        }

        public List<Usuario> ListarUsuario()
        {
            return ctx.Usuarios
                .Select(u => new Usuario
                {
                    IdUsuario = u.IdUsuario,
                    Nome = u.Nome,
                    Email = u.Email,
                    Senha = u.Senha,
                    Cpf = u.Cpf,
                    CaminhoFotoPerfil = u.CaminhoFotoPerfil,
                    DataNascimento = u.DataNascimento,
                    IdTipoUsuario = u.IdTipoUsuario,
                    Trofeus = u.Trofeus,
                    IdCargo = u.IdCargo,
                    IdUnidadeSenai = u.IdUnidadeSenai,
                    LocalizacaoUsuario = u.LocalizacaoUsuario,
                    NivelSatisfacao = u.NivelSatisfacao,
                    SaldoMoeda = u.SaldoMoeda,
                    Vantagens = u.Vantagens,
                    IdCargoNavigation = new Cargo()
                    {
                        IdCargo = u.IdCargoNavigation.IdCargo,
                        NomeCargo = u.IdCargoNavigation.NomeCargo
                    },
                    IdTipoUsuarioNavigation = new Tipousuario()
                    {
                        IdTipoUsuario = u.IdTipoUsuarioNavigation.IdTipoUsuario,
                        NomeTipoUsuario = u.IdTipoUsuarioNavigation.NomeTipoUsuario
                    },
                    IdUnidadeSenaiNavigation = new Unidadesenai ()
                    {
                        NomeUnidadeSenai = u.IdUnidadeSenaiNavigation.NomeUnidadeSenai
                    }

                }).
                ToList();
        }

        public Usuario ListarUsuarioPorId(int idUsuario)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.IdUsuario == idUsuario);
        }

        public Usuario Login(string cpf, string senha)
        {
            var usuario = ctx.Usuarios.FirstOrDefault(u => u.Cpf == cpf);

            if (usuario != null)
            {
                // verifica se a senha desse Usuário possui caracteristicas de um senha criptografada
                if (usuario.Senha.Length != 60 && usuario.Senha[0].ToString() != "$")
                {
                    // senha criptografada
                    string senhaHash = Criptografia.CriptografarSenha(senha);
                    usuario.Senha = senhaHash;
                    ctx.Usuarios.Update(usuario);
                    ctx.SaveChanges();

                    // retorna o usuário, com senha já atualizada
                    return usuario;

                } else
                {
                    // comparada senha que fornecida pelo usuário com a senha que já está criptografa no banco
                    bool confere = Criptografia.CompararSenha(senha, usuario.Senha);
                    
                    // caso a comparação seja válida retorne o usuário
                    if (confere)
                        return usuario;
                }


            }
            return null;
        }


        public void RemoverFotoDePerfil(int idUsuario)
        {
            var usuario = ctx.Usuarios.FirstOrDefault(u => u.IdUsuario == idUsuario);
            Upload.RemoverFoto(usuario.CaminhoFotoPerfil);
        }
    }
}
