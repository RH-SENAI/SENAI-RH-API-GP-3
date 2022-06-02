using senai_gp3_webApi.Contexts;
using senai_gp3_webApi.Domains;
using senai_gp3_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_gp3_webApi.Repositories
{
    public class GrupoRepository : IGrupoRepository
    {
        private readonly senaiRhContext ctx;


        public GrupoRepository(senaiRhContext appContext)
        {
            ctx = appContext;
        }

        public void CadastrarGrupo(Grupo novoGrupo)
        {
            Usuario gestorAchado = ctx.Usuarios.FirstOrDefault(u => u.IdUsuario == novoGrupo.IdGestor);

            if(gestorAchado.IdTipoUsuario == 2)
            {
                ctx.Grupos.Add(novoGrupo);
            }

            ctx.SaveChanges();
        }

        public List<Grupo> ListarGrupos()
        {
           return ctx.Grupos.ToList();
        }
    }
}
