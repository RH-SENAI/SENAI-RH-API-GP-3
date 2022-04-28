using senai_gp3_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_gp3_webApi.Interfaces
{
    public interface ICargoRepository
    {
        /// <summary>
        /// Lista todos os cargos
        /// </summary>
        /// <returns>Uma lista com todos os cargos</returns>
        List<Cargo> ListarCargos();

        /// <summary>
        /// Deleta um cargo
        /// </summary>
        /// <param name="idCargo">id do cargo que será deletado</param>
        void DeletarCargo(int idCargo);

        /// <summary>
        /// Cadastra um novo cargo
        /// </summary>
        /// <param name="novoCargo">Cargo que será cadastrado</param>
        void CadastrarCargo(Cargo novoCargo);

        /// <summary>
        /// Atualiza um determinado cargo
        /// </summary>
        /// <param name="idCargo">Id do cargo que ele séra </param>
        /// <param name="cargoAtualizado">cargo que foi atualizado</param>
        void AtualizarCargo(int idCargo, Cargo cargoAtualizado);

        /// <summary>
        /// Lista o cargo 
        /// </summary>
        /// <param name="idCargo"></param>
        /// <returns>O cargo correspondente com seu id</returns>
        Cargo ListarCargoPorId(int idCargo);
    }
}
