using Senai_SpMedical_webAPI.Domains;
using System.Collections.Generic;

namespace Senai_SpMedical_webAPI.Interfaces
{

    /// <summary>
    /// Interface responsável pelo repositório UsuarioRepository
    /// </summary>
    interface IUsuarioRepository
    {
        /// <summary>
        /// Lista todos os Usuarios
        /// </summary>
        /// <returns>Uma lista de Usuarios</returns>
        List<Usuario> Listar();

        /// <summary>
        /// Busca um Usuario por seu Id
        /// </summary>
        /// <param name="IdUsuario">Id do Usuario</param>
        /// <returns>Usuario buscado</returns>
        Usuario ListarId(int IdUsuario);

        /// <summary>
        /// Cadastra um Usuario
        /// </summary>
        /// <param name="NovoUsuario">Objeto novoUsuario com os novos dados</param>
        void Cadastrar(Usuario NovoUsuario);

        /// <summary>
        /// Atualiza um Usuario específico
        /// </summary>
        /// <param name="IdUsuario">Id do Usuario atualizado</param>
        /// <param name="UsuarioAtualizado">UsuarioAtualizado com os novos dados</param>
        void Atualizar(int IdUsuario, Usuario UsuarioAtualizado);

        /// <summary>
        /// Deleta um Usuario específico
        /// </summary>
        /// <param name="IdUsuario">Id do Usuario deletado</param>
        void Deletar(int IdUsuario);

        /// <summary>
        /// Faz login de um Usuario pelo seu email e senha
        /// </summary>
        /// <param name="email">Email do Usuario</param>
        /// <param name="senha">Senha do Usuario</param>
        /// <returns>Usuario realizando login</returns>
        Usuario Login(string email, string senha);

        /// <summary>
        /// Lista todos os Usuarios com suas respectivas listas de clientes
        /// </summary>
        /// <returns>Uma lista de Usuarios com seus clientes</returns>
        public List<Usuario> ListarComClientes();

        /// <summary>
        /// Lista todos os Usuarios com suas respectivas listas de medicos
        /// </summary>
        /// <returns>Uma lista de Usuarios com seus medicos</returns>
        public List<Usuario> ListarComMedicos();
    }
}