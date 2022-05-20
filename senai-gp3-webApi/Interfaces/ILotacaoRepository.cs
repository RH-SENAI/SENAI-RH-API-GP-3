using senai_gp3_webApi.Domains;
using System.Collections.Generic;

namespace senai_gp3_webApi.Interfaces
{
    public interface ILotacaoRepository
    {
        /// <summary>
        /// Associa um Usuario ao seu gestor
        /// </summary>
        /// <param name="idFuncionario">id do funcionario que será associado</param>
        /// <param name="idGrupo"> id do Grupo a quem esse funcionário será associado</param>
        void AssociarUsuario(int idFuncionario, int idGrupo);

        /// <summary>
        /// Lista todas as associações de todos os usuários
        /// </summary>
        /// <returns>Retorna uma lista com todas as associações</returns>
        List<Lotacao> ListarAssociacoes();

    }
}
