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
        /// Lista os usuarios em ranking
        /// </summary>
        /// <returns>Uma lista de usuarios</returns>
        List<Usuario> RankingUsuarios();

        /// <summary>
        /// Retorna um usuario
        /// </summary>
        /// <param name="idUsuario">id do Usuario</param>
        /// <returns>Um usuario que foi achado</returns>
        Usuario ListarUsuarioPorId(int idUsuario);

        /// <summary>
        /// Calcula as medias da IA
        /// </summary>
        /// <param name="idUsuario">id Usuario que será analisado</param>
        public void CalcularValoresMediosIA_SatisfacaoGeral(int idUsuario);

        /// <summary>
        /// Calcula a média das avaliações do usuario
        /// </summary>
        /// <param name="idUsuario">id do Usuario</param>
        /// <returns>A média de avaliaca do usuario</returns>
        void CalcularMediaAvaliacao(int idUsuario);

        /// <summary>
        /// Calcula a produtividade do usuário
        /// </summary>
        /// <param name="idUsuario">id do usuario</param>
        void CalcularProdutividade(int idUsuario);

        /// <summary>
        /// Lista todos os funcionários
        /// </summary>
        /// <param name="idGestor">id do gestor que será buscado</param>
        /// <returns>Uma lista com todos os funcionarios por lotação</returns>
        List<Usuario> ListarFuncionariosLot(int idGestor);
    }
}
