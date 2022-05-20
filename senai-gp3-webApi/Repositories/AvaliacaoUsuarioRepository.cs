using senai_gp3_webApi.Contexts;
using senai_gp3_webApi.Domains;
using senai_gp3_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_gp3_webApi.Repositories
{
    public class AvaliacaoUsuarioRepository : IAvaliacaoUsuarioRepository
    {
        private readonly senaiRhContext ctx;

        public AvaliacaoUsuarioRepository(senaiRhContext appContext)
        {
            ctx = appContext;
        }

        public void CadastrarAvalicaoUsuario(Avaliacaousuario novaAvaliacao)
        {

            novaAvaliacao.AvaliacaoUsuario1 /= 10;

            ctx.Avaliacaousuarios.Add(novaAvaliacao);

            ctx.SaveChanges();
        }

        public List<Avaliacaousuario> ListarAvaliacaoUsuario()
        {
            return ctx.Avaliacaousuarios.ToList();
        }

        public Avaliacaousuario ListarAvaliacaoUsuarioPorId(int idAvaliacaoUsuario)
        {
            return ctx.Avaliacaousuarios.FirstOrDefault(a => a.IdAvaliacaoUsuario == idAvaliacaoUsuario);
        }
    }
}