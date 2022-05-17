using System.Collections.Generic;
using senai_gp3_webApi.Domains;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace senai_gp3_webApi.Interfaces
{
    public interface IUnidadesenaiRepository
    {
        /// <summary>
        /// Lista todas as decisoes
        /// </summary>
        /// <returns>Uma lista com as decisoes</returns>
        List<Unidadesenai> ListarUniSenai();

        /// <summary>
        /// Deleta uma unidade Senai
        /// </summary>
        /// <param name="idUnidadeSenai">Id da unidade que será deletada</param>
        void DeletarUniSenai(int idUnidadeSenai);

        /// <summary>
        /// Cadastra uma unidade do senai
        /// </summary>
        /// <param name="unidadesenai">unidade que será cadastrada</param>
        void CadastrarUniSenai(Unidadesenai unidadesenai);

        /// <summary>
        /// Calcula a satisfacao
        /// </summary>
        /// <param name="idUnidadeSenai">id do idUnidadeSenai</param>
        /// <returns></returns>
        void CalcularSatisfacao(int idUnidadeSenai);

        /// <summary>
        /// Calcula a produtividade da unidade
        /// </summary>
        /// <param name="idUnidade">id da Unidade</param>
        void CalcularProdutividade(int idUnidade);

        /// <summary>
        /// Atualiza os dados de uma determinadade unidade do senai
        /// </summary>
        /// <param name="idUniSenai">Id da unidade que será atualiza</param>
        /// <param name="UniSenaiAtualizada">Objeto com os atributos da unidade que será atualizada</param>
        /// <returns>A Unidade Senai atualizada</returns>
        Unidadesenai AtualizarUniSenaiPorId(int idUniSenai, Unidadesenai UniSenaiAtualizada);

        /// <summary>
        /// Lista uma unidade específica pelo seu id
        /// </summary>
        /// <param name="idUniSenai">Id correspondente com a unidade senai desejada</param>
        /// <returns>A unidade senai desejada</returns>
        Unidadesenai ListarUniSenaiPorId(int idUniSenai);

        void CalcularFuncionariosAtivos(int idUniSenai);

        void CalcularQtdFuncionarios(int idUniSenai);
    }
}
