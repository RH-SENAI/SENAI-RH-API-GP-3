using senai_gp3_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_gp3_webApi.Interfaces
{
    interface ISetorRepository
    {
        /// <summary>
        /// Lista todos os setores 
        /// </summary>
        /// <returns>Uma lista com todos os setores</returns>
        List<Setor> ListarSetores();

        /// <summary>
        /// Deleta um setor
        /// </summary>
        /// <param name="idSetor">id do Setor que será deletado</param>
        void DeletarSetor(int idSetor);

        /// <summary>
        /// Cadastra um novo setor 
        /// </summary>
        /// <param name="novoSetor">Novo que será Cadastrado</param>
        void CadastrarSetor(Setor novoSetor);

        /// <summary>
        /// Atualiza as informações de um setor
        /// </summary>
        /// <param name="idSetor">Id do setor que será atualizado</param>
        /// <param name="setorAtualizado">Um setor com os atributos atualizados</param>
        /// <returns> O setor</returns>
        Setor AtualizarSetor(int idSetor, Setor setorAtualizado);

        /// <summary>
        /// Lista um setor por id que será atualizado
        /// </summary>
        /// <param name="idSetor">Id do setor que será buscado</param>
        /// <returns>Retorna o corresponde com o id</returns>
        Setor ListarSetorPorId(int idSetor);
    }
}
