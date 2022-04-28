using senai_gp3_webApi.Domains;
using System.Collections.Generic;

namespace senai_gp3_webApi.Interfaces
{
    public interface IIdTipoUsuarioRepository
    {
        /// <summary>
        /// LIsta todos os tipos usuarios
        /// </summary>
        /// <returns>Uma lista com todos os tipos de usuarios</returns>
        List<Tipousuario> ListarTipoUsuario();

        /// <summary>
        /// Cadastra um novo tipo de usuario
        /// </summary>
        /// <param name="novoTipoUsurio">tipo usuario que será cadastrado</param>
        void CadastrarTipoUsuario(Tipousuario novoTipoUsurio);


    }
}
