using senai_gp3_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_gp3_webApi.Interfaces
{
    public interface IHistoricoRepository
    {
        /// <summary>
        /// Cadastra um novo registro no histórico 
        /// </summary>
        /// <param name="idUsuario">id do usuário que será pego o registro</param>
        void CadastrarRegistro(int idUsuario);

        /// <summary>
        /// Lista o historico d
        /// </summary>
        /// <returns> Uma lista com o histórico </returns>
        List<Historico> ListarRegistros();

        /// <summary>
        /// Lista todos os históricos daquele usuário
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns>Uma lista com todos os históricos daquele usuário</returns>
        List<Historico> ListarRegistrosPorUsuario(int idUsuario);
    }
}
