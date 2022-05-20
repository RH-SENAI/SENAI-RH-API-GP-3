﻿using senai_gp3_webApi.Contexts;
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

        public void AssociarUsuario(int idFuncionario, int idGrupo)
        {
            Usuario funcionarioAchado = ctx.Usuarios.FirstOrDefault( f => f.IdUsuario == idFuncionario );
            Grupo grupoAchado = ctx.Grupos.FirstOrDefault(g => g.IdGrupo == idGrupo);

            Lotacao lotacao = new()
            {  
                IdFuncionario = funcionarioAchado.IdUsuario,
                IdGrupo = grupoAchado.IdGrupo
            };

            ctx.Lotacaos.Add(lotacao);
        }

        public List<Lotacao> ListarAssociacoes()
        {
            return ctx.Lotacaos.ToList();
        }
    }
}
