using Senai_SpMedical_webAPI.Domains;
using System.Collections.Generic;

namespace Senai_SpMedical_webAPI.Interfaces
{

    /// <summary>
    /// Interface responsável pelo repositório ClienteRepository
    /// </summary>
    interface IClienteRepository
    {
        /// <summary>
        /// Lista todos os Clientes
        /// </summary>
        /// <returns>Uma lista de Clientes</returns>
        List<Cliente> Listar();

        /// <summary>
        /// Busca um Cliente por seu Id
        /// </summary>
        /// <param name="IdCliente">Id do Cliente</param>
        /// <returns>Cliente buscado</returns>
        Cliente ListarId(int IdCliente);

        /// <summary>
        /// Cadastra um Cliente
        /// </summary>
        /// <param name="NovoCliente">Objeto novoCliente com os novos dados</param>
        void Cadastrar(Cliente NovoCliente);

        /// <summary>
        /// Atualiza um Cliente específico
        /// </summary>
        /// <param name="IdCliente">Id do Cliente atualizado</param>
        /// <param name="ClienteAtualizado">ClienteAtualizado com os novos dados</param>
        void Atualizar(int IdCliente, Cliente ClienteAtualizado);

        /// <summary>
        /// Deleta um Cliente específico
        /// </summary>
        /// <param name="IdCliente">Id do Cliente deletado</param>
        void Deletar(int IdCliente);


        /// <summary>
        /// Lista todos os Clientes com suas respectivas listas de consultas
        /// </summary>
        /// <returns>Uma lista de Clientes com suas consultas</returns>
        public List<Cliente> ListarComConsultas();
    }
}