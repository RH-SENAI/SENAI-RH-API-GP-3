using senai_gp3_webApi.Contexts;
using senai_gp3_webApi.Domains;
using senai_gp3_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace senai_gp3_webApi.Repositories
{
    public class HistoricoUnidadeRepository : IHistoricoUnidadeRepository
    {
        private readonly senaiRhContext ctx;

        public HistoricoUnidadeRepository(senaiRhContext appContex)
        {
            ctx = appContex;
        }


        public void CadastrarRegistro(int idUnindade)
        {
            Unidadesenai unidadeAchada = ctx.Unidadesenais.FirstOrDefault(u => u.IdUnidadeSenai == idUnindade);

            List<Historicounidade> registroUnidade = ListarRegistrosPorUnidade(unidadeAchada.IdUnidadeSenai);

            DateTime dataAtual = DateTime.Now;

            if (registroUnidade != null)
            {
                foreach (var registro in registroUnidade)
                {

                    if (registro.AtualizadoEm.Day == dataAtual.Day && registro.AtualizadoEm.Month == dataAtual.Month && registro.AtualizadoEm.Year == dataAtual.Year)
                    {
                        RefreshRegistro(unidadeAchada.IdUnidadeSenai, registro.IdHistoricoUnidade);

                        return;
                    }

                }

                UnidadesenaiRepository metodos = new(ctx);

                metodos.CalcularProdutividade(unidadeAchada.IdUnidadeSenai);
                metodos.CalcularSatisfacao(unidadeAchada.IdUnidadeSenai);
                metodos.CalcularFuncionariosAtivos(unidadeAchada.IdUnidadeSenai);
                metodos.CalcularQtdFuncionarios(unidadeAchada.IdUnidadeSenai);

                Historicounidade novoRegistro = new()
                {
                    MediaProdutividade = unidadeAchada.MediaProdutividadeUnidadeSenai,
                    MediaSatisfacao = unidadeAchada.MediaSatisfacaoUnidadeSenai,
                    QtdDeFuncionarios = unidadeAchada.QtdDeFuncionarios,
                    QtdDeFuncionariosAtivos = unidadeAchada.QtdFuncionariosAtivos,
                    AtualizadoEm = DateTime.Now,
                    IdUnidade = unidadeAchada.IdUnidadeSenai
                };

                ctx.Historicounidades.Add(novoRegistro);
                ctx.SaveChanges();

            }
        }

        public void AtualizarRegistro(Historicounidade historicoAtualizado, int IdHistorico)
        {
            Historicounidade historicoAchado = ctx.Historicounidades.FirstOrDefault(h => h.IdHistoricoUnidade == IdHistorico);

            if (historicoAtualizado != null)
            {
                historicoAchado.AtualizadoEm = historicoAtualizado.AtualizadoEm;
                historicoAchado.MediaSatisfacao = historicoAtualizado.MediaSatisfacao;
                historicoAchado.MediaProdutividade = historicoAtualizado.MediaProdutividade;
                historicoAchado.QtdDeFuncionarios = historicoAtualizado.QtdDeFuncionarios;
                historicoAchado.QtdDeFuncionariosAtivos = historicoAtualizado.QtdDeFuncionariosAtivos;

                ctx.Historicounidades.Update(historicoAchado);
                ctx.SaveChanges();
            }
        }

        public void RefreshRegistro(int idUnidade, int idRegistro)
        {
            UnidadesenaiRepository metodos = new (ctx);

            Unidadesenai unidadeAchada = ctx.Unidadesenais.FirstOrDefault(u => u.IdUnidadeSenai == idUnidade);

            metodos.CalcularProdutividade(unidadeAchada.IdUnidadeSenai);
            metodos.CalcularSatisfacao(unidadeAchada.IdUnidadeSenai);
            metodos.CalcularFuncionariosAtivos(unidadeAchada.IdUnidadeSenai);
            metodos.CalcularQtdFuncionarios(unidadeAchada.IdUnidadeSenai);

            Historicounidade novoRegistro = new()
            {
                AtualizadoEm = DateTime.Now,
                IdUnidade = unidadeAchada.IdUnidadeSenai,
                MediaProdutividade = unidadeAchada.MediaProdutividadeUnidadeSenai,
                MediaSatisfacao = unidadeAchada.MediaSatisfacaoUnidadeSenai,
                QtdDeFuncionarios = unidadeAchada.QtdDeFuncionarios,
                QtdDeFuncionariosAtivos = unidadeAchada.QtdFuncionariosAtivos
            };

            AtualizarRegistro(novoRegistro, idRegistro);
        }

        public List<Historicounidade> ListarRegistros()
        {
            throw new System.NotImplementedException();
        }

        public List<Historicounidade> ListarRegistrosPorUnidade(int idUnindade)
        {
            return ctx.Historicounidades
                .Select(u => new Historicounidade
                {
                    MediaProdutividade = u.MediaProdutividade,
                    MediaSatisfacao = u.MediaSatisfacao,
                    QtdDeFuncionarios = u.QtdDeFuncionarios,
                    IdHistoricoUnidade = u.IdHistoricoUnidade,
                    QtdDeFuncionariosAtivos = u.QtdDeFuncionariosAtivos,
                    AtualizadoEm = u.AtualizadoEm,
                    IdUnidade = u.IdUnidade
                }
                )
                .Where(u => u.IdUnidade == idUnindade)
                .ToList();
        }
    }
}
