using senai_gp3_webApi.Domains;
using System.Collections.Generic;

namespace senai_gp3_webApi.Interfaces
{
    public interface IHistoricoSatisfacaoRepository
    {
        /// <summary>
        /// Cadastra um novo registro no histórico de satisfação
        /// </summary>
        /// <param name="novoDado">Registro que será cadastrado</param>
        void CadastrarHistorico(Historicosatisfacao novoDado);

        /// <summary>
        /// Lista o historico de avaliacao
        /// </summary>
        /// <returns> Uma lista com o histórico de avaliação</returns>
        List<Historicosatisfacao> ListarHistorico();
    }
}
