using Senai_SpMedical_webAPI.Domains;
using System.Collections.Generic;

namespace Senai_SpMedical_webAPI.Interfaces
{

    /// <summary>
    /// Interface responsável pelo repositório TipoUsuarioRepository
    /// </summary>
    interface ITipoUsuarioRepository
    {
        /// <summary>
        /// Lista todos os TipoUsuarios
        /// </summary>
        /// <returns>Uma lista de TipoUsuarios</returns>
        List<TipoUsuario> Listar();

        /// <summary>
        /// Busca um TipoUsuario por seu Id
        /// </summary>
        /// <param name="IdTipoUsuario">Id do TipoUsuario</param>
        /// <returns>TipoUsuario buscado</returns>
        TipoUsuario ListarId(int IdTipoUsuario);

        /// <summary>
        /// Cadastra um TipoUsuario
        /// </summary>
        /// <param name="NovoTipoUsuario">Objeto novoTipoUsuario com os novos dados</param>
        void Cadastrar(TipoUsuario NovoTipoUsuario);

        /// <summary>
        /// Atualiza um TipoUsuario específico
        /// </summary>
        /// <param name="IdTipoUsuario">Id do TipoUsuario atualizado</param>
        /// <param name="TipoUsuarioAtualizado">TipoUsuarioAtualizado com os novos dados</param>
        void Atualizar(int IdTipoUsuario, TipoUsuario TipoUsuarioAtualizado);

        /// <summary>
        /// Deleta um TipoUsuario específico
        /// </summary>
        /// <param name="IdTipoUsuario">Id do TipoUsuario deletado</param>
        void Deletar(int IdTipoUsuario);

        /// <summary>
        /// Lista todos os TiposUsuario com suas respectivas listas de usuarios
        /// </summary>
        /// <returns>Uma lista de TiposUsuario com seus usuarios</returns>
        public List<TipoUsuario> ListarComUsuarios();
    }
}