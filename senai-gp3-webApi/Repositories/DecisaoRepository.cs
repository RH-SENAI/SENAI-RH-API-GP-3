using senai_gp3_webApi.Contexts;
using senai_gp3_webApi.Domains;
using senai_gp3_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_gp3_webApi.Repositories
{
    public class DecisaoRepository : IDecisaoRepository
    {
        private readonly senaiRhContext ctx;

        public DecisaoRepository(senaiRhContext appContext)
        {
            ctx = appContext;
        }

        public void AtualizarDecisao(int idDecisao, Decisao decisaoAtualizada)
        {
            throw new NotImplementedException();
        }

        public void CadastrarDecisao(Decisao novaDecisao)
        {
            ctx.Decisaos.Add(novaDecisao);
            ctx.SaveChanges();
        }

        public void DeletarDecisao(int idDecisao)
        {
            throw new NotImplementedException();
        }

        public Decisao ListarDecisaoPorId(int idDecisao)
        {
            return ctx.Decisaos
                .Select(d => new Decisao
                {
                    IdDecisao = d.IdDecisao,
                    IdUsuario = d.IdUsuario,
                    DataDecisao = d.DataDecisao,
                    DescricaoDecisao = d.DescricaoDecisao,
                    PrazoDeAvaliacao = d.PrazoDeAvaliacao,
                    IdUsuarioNavigation = new()
                    {
                        Nome = d.IdUsuarioNavigation.Nome,
                        CaminhoFotoPerfil = d.IdUsuarioNavigation.CaminhoFotoPerfil
                    }
                })
                .FirstOrDefault(d => d.IdDecisao == idDecisao);
        }

        public List<Decisao> ListarDecisoes()
        {
            return ctx.Decisaos.Select(d => new Decisao
            {
                IdDecisao = d.IdDecisao,
                IdUsuario = d.IdUsuario,
                DataDecisao = d.DataDecisao,
                DescricaoDecisao = d.DescricaoDecisao,
                PrazoDeAvaliacao = d.PrazoDeAvaliacao,
                IdUsuarioNavigation = new ()
                { 
                    Nome = d.IdUsuarioNavigation.Nome,
                    CaminhoFotoPerfil = d.IdUsuarioNavigation.CaminhoFotoPerfil
                }
            }).ToList(); 

        }

        public Decisao VerificarDecisao(Decisao decisao)
        {
            throw new NotImplementedException();
        }
    }
}
