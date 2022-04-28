using senai_gp3_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_gp3_webApi.Interfaces
{
    public interface IDecisaoRepository
    {
        /// <summary>
        /// Lista todas as decisões
        /// </summary>
        /// <returns>Retorna uma lista com todas as decisões</returns>
        List<Decisao> ListarDecisoes();

        /// <summary>
        /// Deleta uma decisão
        /// </summary>
        /// <param name="idDecisao"> id da decisão que será deletada</param>
        void DeletarDecisao(int idDecisao);

        /// <summary>
        /// Cadastra uma nova decisao
        /// </summary>
        /// <param name="novaDecisao">decisao que será cadastrada</param>
        void CadastrarDecisao(Decisao novaDecisao);

        /// <summary>
        /// Atualiza um decisão
        /// </summary>
        /// <param name="idDecisao">id da decisão que foi atualizada</param>
        /// <param name="decisaoAtualizada">decisão atualizada</param>
        void AtualizarDecisao(int idDecisao, Decisao decisaoAtualizada);

        /// <summary>
        /// Lista um decisão pelo seu id
        /// </summary>
        /// <param name="idDecisao">id da decisao que será listada</param>
        /// <returns></returns>
        Decisao ListarDecisaoPorId(int idDecisao);


        /// <summary>
        /// Verifica uma decisao
        /// </summary>
        /// <param name="decisao">decisao que sera verificada</param>
        /// <returns>decisao verificada</returns>
        Decisao VerificarDecisao(Decisao decisao);
    }
}
