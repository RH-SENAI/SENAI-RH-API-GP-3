using senai_gp3_webApi.Domains;
using System.Collections.Generic;

namespace senai_gp3_webApi.Interfaces
{
    public interface IHistoricoUnidadeRepository
    {
        /// <summary>
        /// Cadastra um novo registro no histórico da unidade
        /// </summary>
        /// <param name="idUnindade">id da unidade que será pego o registro</param>
        void CadastrarRegistro(int idUnindade);

        /// <summary>
        /// Lista o historico de registros de uma unidade
        /// </summary>
        /// <returns> Uma lista com o registros de uma unindade </returns>
        List<Historicounidade> ListarRegistros();

        /// <summary>
        /// Lista todos os históricos daquela unidade
        /// </summary>
        /// <param name="idUnindade"></param>
        /// <returns>Uma lista com todos os históricos daquela unidade</returns>
        List<Historicounidade> ListarRegistrosPorUnidade(int idUnindade);
    }
}
