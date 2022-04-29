using senai_gp3_webApi.Contexts;
using senai_gp3_webApi.Domains;
using senai_gp3_webApi.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace senai_gp3_webApi.Repositories
{
    public class IdTipoUsuarioRepository : Interfaces.IIdTipoUsuarioRepository
    {
        private readonly senaiRhContext ctx;

        public IdTipoUsuarioRepository(senaiRhContext appContex)
        {
            ctx = appContex;
        }

        public void CadastrarTipoUsuario(Tipousuario novoTipoUsurio)
        {
            throw new System.NotImplementedException();
        }

        public List<Tipousuario> ListarTipoUsuario()
        {
            return ctx.Tipousuarios.ToList();
        }
    }
}
