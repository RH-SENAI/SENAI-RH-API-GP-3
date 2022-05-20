using senai_gp3_webApi.Contexts;
using senai_gp3_webApi.Domains;
using senai_gp3_webApi.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace senai_gp3_webApi.Repositories
{
    public class LotacaoRepository : ILotacaoRepository
    {
        private readonly senaiRhContext ctx;


        public LotacaoRepository(senaiRhContext appContext)
        {
            ctx = appContext;
        }

        public void AssociarUsuario(int idFuncionario, int idGestor)
        {
            Usuario funcionarioAchado = ctx.Usuarios.FirstOrDefault( f => f.IdUsuario == idFuncionario );
            Usuario gestorAchado = ctx.Usuarios.FirstOrDefault(g => g.IdUsuario == idGestor);

            Lotacao lotacao = new()
            {  
                IdFuncionario = funcionarioAchado.IdUsuario,
                IdGestor = gestorAchado.IdUsuario,
                
            };

            ctx.Lotacaos.Add(lotacao);
        }

        public List<Lotacao> ListarAssociacoes()
        {
            throw new System.NotImplementedException();
        }
    }
}
