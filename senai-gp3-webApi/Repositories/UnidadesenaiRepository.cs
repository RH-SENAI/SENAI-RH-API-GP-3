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

        public void CalcularProdutividade(int idUnidadeSenai)
        {
            var unidadeSenai = ctx.Unidadesenais.FirstOrDefault(u => u.IdUnidadeSenai == idUnidadeSenai);
            List<decimal?> mediaNotas = new();

            // Pega as avaliações dos usuários
            foreach (var usuario in ctx.Usuarios)
            {
                if (usuario.IdUnidadeSenai == unidadeSenai.IdUnidadeSenai)
                {
                    mediaNotas.Add(usuario.NotaProdutividade);
                }
            }

            // Query personalizada para pegar as listas das notas
            var query = from media in mediaNotas
                        select media;
            decimal? elementoCentral;
            var contagem = query.Count();

            if ((contagem % 2) == 0)
            {
                //Pega as duas avaliações do meio
                var elementoCentral1 = mediaNotas.Skip(contagem / 2).First();
                var elementoCentral2 = mediaNotas.Skip((contagem / 2) - 1).First();
                elementoCentral = (elementoCentral1 + elementoCentral2) / 2;
            }
            else
            {
                // Pega o elemento central
                elementoCentral = mediaNotas.Skip(contagem / 2).First();
            }

            // Calcular media
            unidadeSenai.NotaProdutividade = elementoCentral;
            ctx.SaveChanges();
        }

        public void CalcularSatisfacao(int idUnidadeSenai)
        {
            throw new NotImplementedException();
        }

        //public void CalcularSatisfacao(int idUnidadeSenai)
        //{
        //    var unidadeSenai = ctx.Unidadesenais.FirstOrDefault(u => u.IdUnidadeSenai == idUnidadeSenai);
        //    List<decimal> mediaNotas = new();

        //    // Pega as avaliações dos usuários
        //    foreach (var usuario in ctx.Usuarios)
        //    {
        //        if (usuario.IdUnidadeSenai == unidadeSenai.IdUnidadeSenai )
        //        {
        //            mediaNotas.Add(usuario.NivelSatisfacao);
        //        }
        //    }

        //    // Query personalizada para pegar as listas das notas
        //    var query = from media in mediaNotas
        //                select media;
        //    decimal elementoCentral;
        //    var contagem = query.Count();


        //    if ((contagem % 2) == 0)
        //    {
        //        //Pega as duas avaliações do meio
        //        var elementoCentral1 = mediaNotas.Skip(contagem / 2).First();
        //        var elementoCentral2 = mediaNotas.Skip((contagem / 2) - 1).First();
        //        elementoCentral = (elementoCentral1 + elementoCentral2) / 2;
        //    }else
        //    {
        //        // Pega o elemento central
        //        elementoCentral = mediaNotas.Skip(contagem / 2).First();
        //    }

        //    // Calcular media
        //    unidadeSenai.MediaSatisfacaoUnidadeSenai = elementoCentral;
        //    ctx.SaveChanges();
        //}

        public void DeletarUniSenai(int idUnidadeSenai)
        {
            throw new System.NotImplementedException();
        }

        public List<Unidadesenai> ListarUniSenai()
        {
            return ctx.Unidadesenais.ToList();
        }

        public Unidadesenai ListarUniSenaiPorId(int idUniSenai)
        {
            //CalcularProdutividade(idUniSenai);
            //CalcularSatisfacao(idUniSenai);
            return ctx.Unidadesenais.FirstOrDefault(u => u.IdUnidadeSenai == idUniSenai);
        }
    }
}
