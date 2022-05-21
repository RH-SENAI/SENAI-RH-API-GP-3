using senai_gp3_webApi.Contexts;
using senai_gp3_webApi.Domains;
using senai_gp3_webApi.Interfaces;
using senai_gp3_webApi.ViewModels;
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

        public void AssociarUsuario(LotacaoViewModel novaLotacao)
        {
            Usuario funcionarioAchado = ctx.Usuarios.FirstOrDefault( f => f.Cpf == novaLotacao.Cpf );
            Grupo grupoAchado = ctx.Grupos.FirstOrDefault( g => g.IdGrupo == novaLotacao.IdGrupo );

            Lotacao lotacao = new()
            {  
                IdFuncionario = funcionarioAchado.IdUsuario,
                IdGrupo = grupoAchado.IdGrupo
            };

            ctx.Lotacaos.Add(lotacao);
            ctx.SaveChanges();
        }

        public List<Lotacao> ListarAssociacoes()
        {
            return ctx.Lotacaos.ToList();
        }
    }
}
