using senai_gp3_webApi.Contexts;
using senai_gp3_webApi.Domains;
using senai_gp3_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_gp3_webApi.Repositories
{

    public class HistoricoRepository : IHistoricoRepository
    {
        private readonly senaiRhContext ctx;

        public HistoricoRepository(senaiRhContext appContex)
        {
            ctx = appContex;
        }


        /// <summary>
        /// Cadastra um novo registro no histórico
        /// </summary>
        /// <param name="idUsuario">id do usuario que será adicionado o histórico</param>
        public void CadastrarRegistro(int idUsuario)
        {
            Usuario usuarioAchado = ctx.Usuarios.FirstOrDefault(u => u.IdUsuario == idUsuario);

            List<Historico> registrosUsuario = ListarRegistrosPorUsuario(usuarioAchado.IdUsuario);

            DateTime dataAtual = DateTime.Now;

            if (registrosUsuario != null)
            {
                foreach (var registro in registrosUsuario)
                {

                    if (registro.AtualizadoEm.Day == dataAtual.Day && registro.AtualizadoEm.Month == dataAtual.Month && registro.AtualizadoEm.Year == dataAtual.Year)
                    {
                        RefreshRegistro(usuarioAchado.IdUsuario, registro.IdHistorico);

                        return;
                    }

                }

                Historico novoRegistro = new()
                {
                    IdUsuario = usuarioAchado.IdUsuario,
                    MediaAvaliacao = usuarioAchado.MediaAvaliacao,
                    NivelSatisfacao = usuarioAchado.MedSatisfacaoGeral,
                    SaldoMoeda = usuarioAchado.SaldoMoeda,
                    Trofeus = usuarioAchado.Trofeus,
                    NotaProdutividade = usuarioAchado.NotaProdutividade,
                    AtualizadoEm = DateTime.Now,
                    QtdDeTotalAtividade = CalcularQtdAtividades(usuarioAchado.IdUsuario),
                    QtdDeTotalCursos = CalcularQtdCursos(usuarioAchado.IdUsuario),
                    QtdDeTotalDescontos = CalcularQtdDescontos(usuarioAchado.IdUsuario)

                };

                ctx.Historicos.Add(novoRegistro);
                ctx.SaveChanges();

            } 
        }

        /// <summary>
        /// Calcula a quantidade de atividades total de um histórico
        /// </summary>
        /// <param name="idUsuario">id Usuario que será calculado</param>
        /// <returns></returns>
        public int CalcularQtdAtividades(int idUsuario)
        {
            Usuario usuarioAchado = ctx.Usuarios.FirstOrDefault(u => u.IdUsuario == idUsuario);

            int qtdAtividadesTotal = ctx.Minhasatividades.Where(m => m.IdUsuario == usuarioAchado.IdUsuario).Count();

            return qtdAtividadesTotal;
        }


        /// <summary>
        /// Calcula a quantiddade de cursos total de usuário
        /// </summary>
        /// <param name="idUsuario">id Usuario que será calculado</param>
        /// <returns></returns>
        public int CalcularQtdCursos(int idUsuario)
        {
            Usuario usuarioAchado = ctx.Usuarios.FirstOrDefault(u => u.IdUsuario == idUsuario);

            int qtdCursosObtidosTotal = ctx.Registrocursos.Where(m => m.IdUsuario == usuarioAchado.IdUsuario).Count();

            return qtdCursosObtidosTotal;
        }

        public void AtualizarRegistro(Historico historicoAtualizado, int IdHistorico)
        {
            Historico historicoAchado = ctx.Historicos.FirstOrDefault(h => h.IdHistorico == IdHistorico);

            if (historicoAtualizado != null)
            {
                historicoAchado.AtualizadoEm = historicoAtualizado.AtualizadoEm;
                historicoAchado.MediaAvaliacao = historicoAtualizado.MediaAvaliacao;
                historicoAchado.NotaProdutividade = historicoAtualizado.NotaProdutividade;
                historicoAchado.QtdDeTotalAtividade = historicoAtualizado.QtdDeTotalAtividade;
                historicoAchado.QtdDeTotalCursos = historicoAtualizado.QtdDeTotalCursos;
                historicoAchado.NivelSatisfacao = historicoAtualizado.NivelSatisfacao;
                historicoAchado.IdUsuario = historicoAtualizado.IdUsuario;
                historicoAchado.QtdDeTotalDescontos = historicoAtualizado.QtdDeTotalDescontos;
                historicoAchado.Trofeus = historicoAtualizado.Trofeus;
                historicoAchado.SaldoMoeda = historicoAtualizado.SaldoMoeda;

                ctx.Historicos.Update(historicoAchado);
                ctx.SaveChanges();
            }
        }


        public void RefreshRegistro(int idUsuario, int idRegistro)
        {
            UsuarioRepository metodos = new(ctx);

            Usuario usuarioAchado = ctx.Usuarios.FirstOrDefault(u => u.IdUsuario == idUsuario);

            metodos.CalcularValoresMediosIA_SatisfacaoGeral(idUsuario);
            metodos.CalcularProdutividade(idUsuario);
            metodos.CalcularMediaAvaliacao(idUsuario);

            Historico novoRegistro = new()
            {
                IdUsuario = usuarioAchado.IdUsuario,
                MediaAvaliacao = usuarioAchado.MediaAvaliacao,
                NivelSatisfacao = usuarioAchado.MedSatisfacaoGeral,
                SaldoMoeda = usuarioAchado.SaldoMoeda,
                Trofeus = usuarioAchado.Trofeus,
                NotaProdutividade = usuarioAchado.NotaProdutividade,
                AtualizadoEm = DateTime.Now,
                QtdDeTotalAtividade = CalcularQtdAtividades(usuarioAchado.IdUsuario),
                QtdDeTotalCursos = CalcularQtdCursos(usuarioAchado.IdUsuario),
                QtdDeTotalDescontos = CalcularQtdDescontos(usuarioAchado.IdUsuario)

            };

            AtualizarRegistro(novoRegistro, idRegistro);
        }

        /// <summary>
        /// Calcula a quantidade de cursos total de usuário
        /// </summary>
        /// <param name="idUsuario">id Usuario que será calculado</param>
        /// <returns></returns>
        public int CalcularQtdDescontos(int idUsuario)
        {
            Usuario usuarioAchado = ctx.Usuarios.FirstOrDefault(u => u.IdUsuario == idUsuario);

            int qtdDescontosObtidosTotal = ctx.Registrodescontos.Where(m => m.IdUsuario == usuarioAchado.IdUsuario).Count();

            return qtdDescontosObtidosTotal;
        }

        /// <summary>
        /// Lista todos os históricos
        /// </summary>
        /// <returns>Uma lista com todos os históricos</returns>
        public List<Historico> ListarRegistros()
        {
            return ctx.Historicos.ToList();
        }

        public List<Historico> ListarRegistrosPorUsuario(int idUsuario)
        {


            return ctx.Historicos.Select(u => new Historico()
            {
                IdHistorico = u.IdHistorico,
                IdUsuario = u.IdUsuario,
                MediaAvaliacao = u.MediaAvaliacao,
                NivelSatisfacao = u.NivelSatisfacao,
                SaldoMoeda = u.SaldoMoeda,
                Trofeus = u.Trofeus,
                NotaProdutividade = u.NotaProdutividade,
                AtualizadoEm = u.AtualizadoEm,
                QtdDeTotalAtividade = u.QtdDeTotalAtividade,
                QtdDeTotalCursos = u.QtdDeTotalCursos,
                QtdDeTotalDescontos = u.QtdDeTotalDescontos

            })
            .Where(h => h.IdUsuario == idUsuario)
            .ToList();
        }
    }
}
