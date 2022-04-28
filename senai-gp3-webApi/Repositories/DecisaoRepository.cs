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
            throw new NotImplementedException();
        }

        public List<Decisao> ListarDecisoes()
        {
            return ctx.Decisaos.ToList();
        }

        public Decisao VerificarDecisao(Decisao decisao)
        {
            throw new NotImplementedException();
        }
    }
}
