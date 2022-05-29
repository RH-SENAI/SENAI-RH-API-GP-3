using senai_gp3_webApi.Contexts;
using senai_gp3_webApi.Domains;
using senai_gp3_webApi.Interfaces;
using senai_gp3_webApi.SentimentAnalisys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_gp3_webApi.Repositories
{
    public class FeedBackRepository : IFeedbackRepository
    {
        private readonly senaiRhContext ctx;

        public FeedBackRepository(senaiRhContext appContext)
        {
            ctx = appContext;
        }

        public void AtualizarFb(int idFeedback, Feedback feedbackAtualizado)
        {
            throw new NotImplementedException();
        }

        public void AvaliarDecisao(int idDecisaoAvaliada, decimal notaDecisao)
        {
            throw new NotImplementedException();
        }

        public void CadastrarFb(Feedback novoFeedback)
        {
            SentimentAnalysis sentimentAnalisys = new();

            // Pega o score da IA
            var analiseSentimento = sentimentAnalisys.AnalisarTexto(novoFeedback.ComentarioFeedBack);

            // Atribui os scores
            novoFeedback.Positivo = Convert.ToDecimal(analiseSentimento.ConfidenceScores.Positive);
            novoFeedback.Negativo = Convert.ToDecimal(analiseSentimento.ConfidenceScores.Negative);
            novoFeedback.Neutro = Convert.ToDecimal(analiseSentimento.ConfidenceScores.Neutral);

            ctx.Feedbacks.Add(novoFeedback);
            ctx.SaveChanges();
        }

        public decimal CalcularMediaFb(List<Feedback> todosFeedbacks)
        {
            throw new NotImplementedException();
        }

        public void DeletarFb(int idFeedback)
        {
            throw new NotImplementedException();
        }

        public List<Feedback> ListarFb()
        {
            return ctx.Feedbacks
                .Select( f => new Feedback()
                {
                    IdFeedBack = f.IdFeedBack,
                    IdDecisao = f.IdDecisao,
                    IdUsuario = f.IdUsuario,
                    Negativo = f.Negativo,
                    Neutro = f.Neutro,
                    Positivo = f.Positivo,
                    ComentarioFeedBack = f.ComentarioFeedBack,
                    DataPublicacao = f.DataPublicacao,
                    ValorMoedas = f.ValorMoedas,
                    IdDecisaoNavigation = new Decisao() 
                    {  
                        DescricaoDecisao = f.IdDecisaoNavigation.DescricaoDecisao
                    },
                    IdUsuarioNavigation = new Usuario ()
                    {
                        Nome = f.IdUsuarioNavigation.Nome,
                        CaminhoFotoPerfil = f.IdUsuarioNavigation.CaminhoFotoPerfil
                    }
                }
                )
                .ToList();
        }

        public Feedback ListarFbPorId(int idFeedback)
        {
            throw new NotImplementedException();
        }

        public List<Feedback> ListarFeedBacksPorUsuario(int idUsuario)
        {
            return ctx.Feedbacks
                .Select(f => new Feedback()
                {
                    IdFeedBack = f.IdFeedBack,
                    IdDecisao = f.IdDecisao,
                    IdUsuario = f.IdUsuario,
                    Negativo = f.Negativo,
                    Neutro = f.Neutro,
                    Positivo = f.Positivo,
                    ComentarioFeedBack = f.ComentarioFeedBack,
                    DataPublicacao = f.DataPublicacao,
                    ValorMoedas = f.ValorMoedas,
                    IdDecisaoNavigation = new Decisao()
                    {
                        DescricaoDecisao = f.IdDecisaoNavigation.DescricaoDecisao
                    },
                    IdUsuarioNavigation = new Usuario()
                    {
                        Nome = f.IdUsuarioNavigation.Nome,
                        CaminhoFotoPerfil = f.IdUsuarioNavigation.CaminhoFotoPerfil
                    }
                }
                )
                .Where(f => f.IdUsuario == idUsuario)
                .ToList();
        }

        public Feedback VerificarFeedback(Feedback feedback)
        {
            throw new NotImplementedException();
        }
    }
}
