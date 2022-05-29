using senai_gp3_webApi.Contexts;
using senai_gp3_webApi.Domains;
using senai_gp3_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace senai_gp3_webApi.Repositories
{
    public class UnidadesenaiRepository : IUnidadesenaiRepository
    {
        private readonly senaiRhContext ctx;


        public UnidadesenaiRepository(senaiRhContext appContext)
        {
            ctx = appContext;
        }

        public Unidadesenai AtualizarUniSenaiPorId(int idUniSenai, Unidadesenai UniSenaiAtualizada)
        {
            throw new System.NotImplementedException();
        }

        public void CadastrarUniSenai(Unidadesenai unidadesenai)
        {
            ctx.Unidadesenais.Add(unidadesenai);
            ctx.SaveChanges();
        }

        public void CalcularFuncionariosAtivos(int idUniSenai)
        {
            Unidadesenai uniSenai = ctx.Unidadesenais.FirstOrDefault(uniSenai => uniSenai.IdUnidadeSenai == idUniSenai);
            int qtdFuncionariosAtivos = 0;

            foreach (var usuario in ctx.Usuarios)
            {
                if (usuario.IdUnidadeSenai == uniSenai.IdUnidadeSenai && usuario.UsuarioAtivo == true)
                {
                    qtdFuncionariosAtivos += 1;

                }
            }

            uniSenai.QtdFuncionariosAtivos = qtdFuncionariosAtivos;
            ctx.Unidadesenais.Update(uniSenai);
            ctx.SaveChanges();
        }

        public void CalcularProdutividade(int idUnidadeSenai)
        {
            var unidadeSenai = ctx.Unidadesenais.FirstOrDefault(u => u.IdUnidadeSenai == idUnidadeSenai);
            List<decimal?> produtividadeUsuarios = new();

            if (unidadeSenai != null)
            {
                // Calcular media
                foreach (var usuarios in ctx.Usuarios)
                {
                    if (usuarios.IdUnidadeSenai == unidadeSenai.IdUnidadeSenai)
                    {
                        produtividadeUsuarios.Add(usuarios.NotaProdutividade);
                    }
                }



                if (produtividadeUsuarios.Count == 0)
                {
                    unidadeSenai.MediaProdutividadeUnidadeSenai = 0;
                }
                else
                {
                    unidadeSenai.MediaProdutividadeUnidadeSenai = (decimal)produtividadeUsuarios.Sum() / produtividadeUsuarios.Count;
                }

                ctx.Unidadesenais.Update(unidadeSenai);
                ctx.SaveChanges();
            }
        }

        public void CalcularQtdFuncionarios(int idUniSenai)
        {
            Unidadesenai uniSenai = ctx.Unidadesenais.FirstOrDefault(uniSenai => uniSenai.IdUnidadeSenai == idUniSenai);
            int qtdFuncionarios = 0;

            foreach (var usuario in ctx.Usuarios)
            {
                if (usuario.IdUnidadeSenai == uniSenai.IdUnidadeSenai)
                {
                    qtdFuncionarios += 1;

                }
            }

            uniSenai.QtdDeFuncionarios = qtdFuncionarios;
            ctx.Unidadesenais.Update(uniSenai);
            ctx.SaveChanges();
        }

        public void CalcularSatisfacao(int idUnidadeSenai)
        {
            var unidadeSenai = ctx.Unidadesenais.FirstOrDefault(u => u.IdUnidadeSenai == idUnidadeSenai);
            List<decimal?> satisfacaousuarios = new();

            if (unidadeSenai != null)
            {
                // Calcular media
                foreach(var usuarios in ctx.Usuarios)
                {
                    if (usuarios.IdUnidadeSenai == unidadeSenai.IdUnidadeSenai)
                    {
                        satisfacaousuarios.Add(usuarios.MedSatisfacaoGeral);
                    }
                }



                if (satisfacaousuarios.Count == 0 )
                {
                    unidadeSenai.MediaSatisfacaoUnidadeSenai = 0;
                }
                else
                {
                    unidadeSenai.MediaSatisfacaoUnidadeSenai = (decimal)satisfacaousuarios.Sum() / satisfacaousuarios.Count;
                }

                ctx.Unidadesenais.Update(unidadeSenai);
                ctx.SaveChanges();
            }
        }



        public void DeletarUniSenai(int idUnidadeSenai)
        {
            throw new System.NotImplementedException();
        }

        public List<Unidadesenai> ListarUniSenai()
        {
            return ctx.Unidadesenais
                .Select( u => new Unidadesenai
                { 
                   IdLocalizacao = u.IdLocalizacao,
                   IdUnidadeSenai = u.IdUnidadeSenai,
                   MediaProdutividadeUnidadeSenai = u.MediaProdutividadeUnidadeSenai,
                   MediaSatisfacaoUnidadeSenai = u.MediaSatisfacaoUnidadeSenai,
                   TelefoneUnidadeSenai = u.TelefoneUnidadeSenai,
                   EmailUnidadeSenai = u.EmailUnidadeSenai,
                   QtdFuncionariosAtivos = u.QtdFuncionariosAtivos,
                   QtdDeFuncionarios = u.QtdDeFuncionarios,
                   NomeUnidadeSenai = u.NomeUnidadeSenai
                
                })
                .ToList();
        }

        public Unidadesenai ListarUniSenaiPorId(int idUniSenai)
        {
            HistoricoUnidadeRepository historicoUnidadeRepository = new(ctx);

            historicoUnidadeRepository.CadastrarRegistro(idUniSenai);

            CalcularProdutividade(idUniSenai);
            CalcularSatisfacao(idUniSenai);
            CalcularQtdFuncionarios(idUniSenai);
            CalcularFuncionariosAtivos(idUniSenai);

            return ctx.Unidadesenais
                .Select(u => new Unidadesenai
                {
                    IdLocalizacao = u.IdLocalizacao,
                    IdUnidadeSenai = u.IdUnidadeSenai,
                    MediaProdutividadeUnidadeSenai = u.MediaProdutividadeUnidadeSenai,
                    MediaSatisfacaoUnidadeSenai = u.MediaSatisfacaoUnidadeSenai,
                    TelefoneUnidadeSenai = u.TelefoneUnidadeSenai,
                    EmailUnidadeSenai = u.EmailUnidadeSenai,
                    QtdFuncionariosAtivos = u.QtdFuncionariosAtivos,
                    QtdDeFuncionarios = u.QtdDeFuncionarios,
                    NomeUnidadeSenai = u.NomeUnidadeSenai

                })
                .FirstOrDefault(u => u.IdUnidadeSenai == idUniSenai);
        }
    }
}
