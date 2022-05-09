using senai_gp3_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_gp3_webApi.Interfaces
{
    public interface IAvaliacaoUsuarioRepository
    {
        void CadastrarAvalicaoUsuario(Avaliacaousuario novaAvaliacao);

        List<Avaliacaousuario> ListarAvaliacaoUsuario();

        Avaliacaousuario ListarAvaliacaoUsuarioPorId(int idAvaliacaoUsuario);
    }
}
