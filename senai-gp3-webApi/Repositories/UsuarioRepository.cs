﻿using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using senai_gp3_webApi.Contexts;
using senai_gp3_webApi.Domains;
using senai_gp3_webApi.Utils;
using senai_gp3_webApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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

        private const string SENHA_PADRAO = "Sesisenai@2022";

        public Usuario AtualizarFuncionario(int idUsuario, FuncionarioAtualizadoViewModel funcionarioAtualizado)
        {
            var funcionarioAchado = ctx.Usuarios.FirstOrDefault(u => u.IdUsuario == idUsuario);

            if (funcionarioAtualizado.Senha != null)
            {
                funcionarioAchado.Senha = Criptografia.CriptografarSenha(funcionarioAtualizado.Senha);
            }

            if (funcionarioAtualizado.CaminhoFotoPerfil != null)
            {
                funcionarioAchado.CaminhoFotoPerfil = funcionarioAtualizado.CaminhoFotoPerfil;
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

                ctx.Usuarios.Update(GestorAchado);
                ctx.SaveChanges();

                return GestorAchado;
            }

            return null;
        }

        public void CadastrarUsuario(UsuarioCadastroViewModel novoUsuario)
        {
            Usuario usuario = new()
            {

                Nome = novoUsuario.Nome,
                Email = novoUsuario.Email,
                Senha = SENHA_PADRAO,
                Cpf = novoUsuario.Cpf,
                CaminhoFotoPerfil = novoUsuario.CaminhoFotoPerfil,
                DataNascimento = novoUsuario.DataNascimento,
                IdTipoUsuario = novoUsuario.IdTipoUsuario,
                Trofeus = 0,
                IdCargo = novoUsuario.IdCargo,
                IdUnidadeSenai = novoUsuario.IdUnidadeSenai,
                UsuarioAtivo = true,
                SaldoMoeda = novoUsuario.SaldoMoeda,

            };

            ctx.Usuarios.Add(usuario);


            ctx.SaveChanges();
        }


        public void CalcularProdutividade(int idUsuario)
        {
            Usuario usuario = ctx.Usuarios.FirstOrDefault(u => u.IdUsuario == idUsuario);
            List<Minhasatividade> totalAtividadesUsuario = new();
            int qtdeAtividadesConcluidas = 0;


            foreach (var atividade in ctx.Minhasatividades)
            {
                if (atividade.IdUsuario == usuario.IdUsuario)
                {
                    totalAtividadesUsuario.Add(atividade);
                }
            }


            //Procura todas as atividades daquele usuário
            foreach (var atividade in totalAtividadesUsuario)
            {
                //Verifica se a atividade pertence aquele usuario e se está Finalizada
                if (atividade.IdSituacaoAtividade == 1)
                {
                    qtdeAtividadesConcluidas += 1;
                }
            }

            if (totalAtividadesUsuario.Count == 0)
            {
                usuario.NotaProdutividade = 0;
            }
            else
            {   // Atribui uma nota ao usuário
                usuario.NotaProdutividade = qtdeAtividadesConcluidas / totalAtividadesUsuario.Count;
                ctx.SaveChanges();
            }
        }

        public void CalcularValoresMediosIA_SatisfacaoGeral(int idUsuario)
        {
            Usuario usuarioAtual = ctx.Usuarios.FirstOrDefault(u => u.IdUsuario == idUsuario);

            if (usuarioAtual == null) Console.WriteLine("Usuario não encontrado");

            else
            {
                List<Feedback> listaFeedbacks = ctx.Feedbacks.Where(u => u.IdUsuario == idUsuario).ToList();
                List<Comentariocurso> listaComentariosCursos = ctx.Comentariocursos.Where(u => u.IdUsuario == idUsuario).ToList();
                List<Comentariodesconto> listaComentariosDescontos = ctx.Comentariodescontos.Where(u => u.IdUsuario == idUsuario).ToList();

                //usuarioAtual.MedFeedbackNeg = (listaFeedbacks.Sum(i => i.Negativo)) / listaFeedbacks.Count; // CALCULANDO A MEDIA MANUALMENTE

                usuarioAtual.MedFeedbackNeg = listaFeedbacks.Average(i => i.Negativo);
                usuarioAtual.MedFeedbackNeu = listaFeedbacks.Average(i => i.Neutro);
                usuarioAtual.MedFeedbackPos = listaFeedbacks.Average(i => i.Positivo);
                if (usuarioAtual.MedFeedbackPos == null) usuarioAtual.MedFeedbackPos = (decimal)0.5;
                

                usuarioAtual.MedCursosNeg = listaComentariosCursos.Average(i => i.Negativo);
                usuarioAtual.MedCursosNeu = listaComentariosCursos.Average(i => i.Neutro);
                usuarioAtual.MedCursosPos = listaComentariosCursos.Average(i => i.Positivo);
                if (usuarioAtual.MedCursosPos == null) usuarioAtual.MedCursosPos = (decimal)0.5;

                usuarioAtual.MedDescontosNeg = listaComentariosDescontos.Average(i => i.Negativo);
                usuarioAtual.MedDescontosNeu = listaComentariosDescontos.Average(i => i.Neutro);
                usuarioAtual.MedDescontosPos = listaComentariosDescontos.Average(i => i.Positivo);

                if (usuarioAtual.MedDescontosPos == null) usuarioAtual.MedDescontosPos = (decimal)0.5;

                decimal pesoFeedback = (decimal)1.20;
                decimal pesoCurso = (decimal)1.00;
                decimal pesoDesconto = (decimal)1.00;

                usuarioAtual.MedSatisfacaoGeral = ((usuarioAtual.MedFeedbackPos * pesoFeedback) + (usuarioAtual.MedCursosPos * pesoCurso) + (usuarioAtual.MedDescontosPos * pesoDesconto)) / 
                    (pesoFeedback + pesoCurso + pesoDesconto);

                ctx.Usuarios.Update(usuarioAtual);
                ctx.SaveChanges();

                Console.WriteLine("Valores medios calculados com sucesso.");
            }
                
        }

        public void CalcularMediaAvaliacao(int idUsuario)
        {
            Usuario usuarioAchado = ctx.Usuarios.FirstOrDefault(u => u.IdUsuario == idUsuario);
            List<decimal> avaliacaousuarios = new();

            foreach (var avaliacaoUsuario in ctx.Avaliacaousuarios)
            {
                if (avaliacaoUsuario.IdUsuarioAvaliado == idUsuario)
                {
                    avaliacaousuarios.Add((decimal)avaliacaoUsuario.AvaliacaoUsuario1);
                }
            }

            if (avaliacaousuarios.Count == 0)
            {
                usuarioAchado.MediaAvaliacao = 0;
            }
            else
            {
                usuarioAchado.MediaAvaliacao = (avaliacaousuarios.Sum() / avaliacaousuarios.Count);
            }

            ctx.SaveChanges();
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
                    SaldoMoeda = u.SaldoMoeda,
                    MedFeedbackNeg = u.MedFeedbackNeg,
                    MedFeedbackPos = u.MedFeedbackPos,
                    MedFeedbackNeu = u.MedFeedbackNeu,
                    MedCursosNeg = u.MedCursosNeg,
                    MedCursosPos = u.MedCursosPos,
                    MedCursosNeu = u.MedCursosNeu,
                    MedDescontosNeg = u.MedDescontosNeg,
                    MedDescontosPos = u.MedDescontosPos,
                    MedDescontosNeu = u.MedDescontosNeu,
                    MedSatisfacaoGeral = u.MedSatisfacaoGeral,
                    UsuarioAtivo = u.UsuarioAtivo,
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
                    IdUnidadeSenaiNavigation = new Unidadesenai()
                    {
                        NomeUnidadeSenai = u.IdUnidadeSenaiNavigation.NomeUnidadeSenai
                    }

                }).
                ToList();
        }

        public Usuario ListarUsuarioPorId(int idUsuario)
        {

            HistoricoRepository historicoRepository = new(ctx);


            historicoRepository.CadastrarRegistro(idUsuario);

            CalcularMediaAvaliacao(idUsuario);
            CalcularProdutividade(idUsuario);
            CalcularValoresMediosIA_SatisfacaoGeral(idUsuario);

            return ctx.Usuarios.Select(u => new Usuario
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
                SaldoMoeda = u.SaldoMoeda,
                MedFeedbackNeg = u.MedFeedbackNeg,
                MedFeedbackPos = u.MedFeedbackPos,
                MedFeedbackNeu = u.MedFeedbackNeu,
                MedCursosNeg = u.MedCursosNeg,
                MedCursosPos = u.MedCursosPos,
                MedCursosNeu = u.MedCursosNeu,
                MedDescontosNeg = u.MedDescontosNeg,
                MedDescontosPos = u.MedDescontosPos,
                MedDescontosNeu = u.MedDescontosNeu,
                MedSatisfacaoGeral = u.MedSatisfacaoGeral,
                UsuarioAtivo = u.UsuarioAtivo,
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
                IdUnidadeSenaiNavigation = new Unidadesenai()
                {
                    NomeUnidadeSenai = u.IdUnidadeSenaiNavigation.NomeUnidadeSenai
                }

            }).FirstOrDefault(u => u.IdUsuario == idUsuario);
        }

        public Usuario Login(string cpf, string senha)
        {
            var usuario = ctx.Usuarios.FirstOrDefault(u => u.Cpf == cpf);

            if (usuario != null)
            {
                if (ValidarSenha(senha))
                {
                    // senha criptografada
                    string senhaHash = Criptografia.CriptografarSenha(senha);
                    usuario.Senha = senhaHash;
                    ctx.Usuarios.Update(usuario);
                    ctx.SaveChanges();
                }

                // comparada senha que fornecida pelo usuário com a senha que já está criptografa no banco
                bool confere = Criptografia.CompararSenha(senha, usuario.Senha);

                // caso a comparação seja válida retorne o usuário
                if (confere)
                    return usuario;


            }
            return null;
        }

        /// <summary>
        /// Atualiza a senha 
        /// </summary>
        /// <param name="idUsuario">Id do Usuario que a senha será atualizada</param>
        /// <param name="senhaAtualizada">senha atualizada</param>
        public void AtualizarSenha(int idUsuario, string senhaAtualizada)
        {
            Usuario usuario = ctx.Usuarios.FirstOrDefault(u => u.IdUsuario == idUsuario);

            if (ValidarSenha(senhaAtualizada))
            {
                // senha criptografada
                string senhaHash = Criptografia.CriptografarSenha(senhaAtualizada);
                usuario.Senha = senhaHash;
                ctx.Usuarios.Update(usuario);
                ctx.SaveChanges();
            }

        }

        /// <summary>
        /// Valida senha 
        /// </summary>
        /// <param name="senha">senha que será validada</param>
        /// <returns>se a senha é valida(true) ou não(false)</returns>
        public bool ValidarSenha(string senha)
        {
            const int TAMANHO = 60;

            if (string.IsNullOrEmpty(senha) || senha.Length > TAMANHO)
            {
                return false;
            }
            else if (Regex.IsMatch(senha, @"\$"))
            {
                return false;
            }
            else if (senha == SENHA_PADRAO)
            {
                return true;
            }
            else
            {
                return true;
            }
        }
    }
}
