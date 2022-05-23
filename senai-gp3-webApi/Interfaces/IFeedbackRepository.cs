using senai_gp3_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_gp3_webApi.Interfaces
{
    public interface IFeedbackRepository
    {
        /// <summary>
        /// Lista todos os Feedbacks
        /// </summary>
        /// <returns>Uma lista de feedback</returns>
        List<Feedback> ListarFb();

        /// <summary>
        /// Lista um feed pelo seu id
        /// </summary>
        /// <param name="idFeedback">id do feedback</param>
        /// <returns>o feedback achado</returns>
        Feedback ListarFbPorId(int idFeedback);

        /// <summary>
        /// atualiza um determinado feedback
        /// </summary>
        /// <param name="idFeedback">id do feedback</param>
        /// <param name="feedbackAtualizado">feedback alterado</param>
        void AtualizarFb(int idFeedback, Feedback feedbackAtualizado);

        /// <summary>
        /// Cadastra um feedback
        /// </summary>
        /// <param name="novoFeedback">objeto com informações do feedback</param>
        void CadastrarFb(Feedback novoFeedback);

        /// <summary>
        /// Deleta um feedback
        /// </summary>
        /// <param name="idFeedback">id do feedback</param>
        void DeletarFb(int idFeedback);

        /// <summary>
        /// Verifica se um feedback
        /// </summary>
        /// <param name="feedback">feedback que será verificado</param>
        /// <returns></returns>
        Feedback VerificarFeedback(Feedback feedback);

        /// <summary>
        /// avalia uma determinada decisao
        /// </summary>
        /// <param name="idDecisaoAvaliada">id da decisao que será avaliada</param>
        /// <param name="notaDecisao">nota da decisão</param>
        void AvaliarDecisao(int idDecisaoAvaliada, decimal notaDecisao);

        /// <summary>
        /// Calcula a média de todos os feedbacks
        /// </summary>
        /// <param name="todosFeedbacks">lista com todos os feedbacks</param>
        /// <returns> a media dos feedbacks</returns>
        decimal CalcularMediaFb(List<Feedback> todosFeedbacks);

        List<Feedback> ListarFeedBacksPorUsuario(int idUsuario);

    }
}
