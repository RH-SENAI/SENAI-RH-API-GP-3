using senai_gp3_webApi.Contexts;
using senai_gp3_webApi.Domains;
using senai_gp3_webApi.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace senai_gp3_webApi.Repositories
{
    public class HistoricoSatisfacaoRepository : IHistoricoSatisfacaoRepository
    {

        private readonly senaiRhContext ctx;

        public HistoricoSatisfacaoRepository(senaiRhContext appContext)
        {
            ctx = appContext;
        }

        public void CadastrarHistorico(Historicosatisfacao novoDado)
        {
            ctx.Historicosatisfacaos.Add(novoDado);
            ctx.SaveChanges();
        }

        public List<Historicosatisfacao> ListarHistorico()
        {
           return ctx.Historicosatisfacaos.ToList();
        }
    }
}
