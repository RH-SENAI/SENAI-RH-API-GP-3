using senai_gp3_webApi.Domains;
using senai_gp3_webApi.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace senai_gp3_webApi
{
    public interface IUsuarioRepository
    {
        /// <summary>
        /// Efetua o Login
        /// </summary>
        /// <param name="email">Email do usuario</param>
        /// <param name="senha">Senha do usuario</param>
        /// <returns>O token do usuario</returns>
        Usuario Login(string email, string senha);

        /// <summary>
        /// Deletar um usuario
        /// </summary>
        /// <param name="idUsuario">Id do usuario</param>
        void DeletarUsuario(int idUsuario);

        /// <summary>
        /// Cadastrar um usuario
        /// </summary>
        /// <param name="novoUsuario">Objeto de usuario</param>
        void CadastrarUsuario(UsuarioCadastroViewModel novoUsuario);

        /// <summary>
        /// Atualiza um usuario
        /// </summary>
        /// <param name="idUsuario">Id do Usuario</param>
        /// <param name="GestorAtualizado">Objeto que pertence a um gestor atualizado</param>
        Usuario AtualizarGestor(int idUsuario, GestorAtualizadoViewModel GestorAtualizado);

        /// <summary>
        /// Atualiza um usuario
        /// </summary>
        /// <param name="idUsuario">Id do Usuario</param>
        /// <param name="funcionarioAtualizado">Objeto que pertence a um funcionario atualizado</param>
        Usuario AtualizarFuncionario(int idUsuario, FuncionarioAtualizadoViewModel funcionarioAtualizado);

        /// <summary>
        /// Lista os usuarios
        /// </summary>
        /// <returns>Uma lista de usuarios</returns>
        List<Usuario> ListarUsuario();

        /// <summary>
        /// Retorna um usuario
        /// </summary>
        /// <param name="idUsuario">id do Usuario</param>
        /// <returns>Um usuario que foi achado</returns>
        Usuario ListarUsuarioPorId(int idUsuario);

        /// <summary>
        /// Calcula a satisfacao
        /// </summary>
        /// <param name="idUsuario">id do Usuario</param>
        /// <returns></returns>
        string CalcularSatisfacao(int idUsuario);

        /// <summary>
        /// Calcula a média das avaliações do usuario
        /// </summary>
        /// <param name="idUsuario">id do Usuario</param>
        /// <returns>A média de avaliaca do usuario</returns>
        string CalcularMediaAvaliacao(int idUsuario);

        /// <summary>
        /// Remove a foto de perfil do usuário
        /// </summary>
        /// <param name="idUsuario">id do usuario que foto será resolvida</param>
        void RemoverFotoDePerfil(int idUsuario);
    }
}
