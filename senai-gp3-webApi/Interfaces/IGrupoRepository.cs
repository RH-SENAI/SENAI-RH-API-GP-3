using senai_gp3_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_gp3_webApi.Interfaces
{
    public interface IGrupoRepository
    {

        /// <summary>
        /// Cadastra um novo grupo
        /// </summary>
        /// <param name="novoGrupo">Objeto com o novo grupo que será cadastrado.</param>
        void CadastrarGrupo(Grupo novoGrupo);

        /// <summary>
        /// Lista todos os grupos
        /// </summary>
        /// <returns>Retorna uma lista com todos os grupos</returns>
        List<Grupo> ListarGrupos();
    }
}
