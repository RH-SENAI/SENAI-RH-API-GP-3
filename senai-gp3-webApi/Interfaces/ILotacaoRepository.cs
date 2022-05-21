using senai_gp3_webApi.Domains;
using senai_gp3_webApi.ViewModels;
using System.Collections.Generic;

namespace senai_gp3_webApi.Interfaces
{
    public interface ILotacaoRepository
    {

        /// <summary>
        /// Associa um funcionario ao seu gestor
        /// </summary>
        /// <param name="novaLotacao"> nova lotação que será cadastrada</param>
        void AssociarUsuario(LotacaoViewModel novaLotacao);

        /// <summary>
        /// Lista todas as associações de todos os usuários
        /// </summary>
        /// <returns>Retorna uma lista com todas as associações</returns>
        List<Lotacao> ListarAssociacoes();

    }
}
