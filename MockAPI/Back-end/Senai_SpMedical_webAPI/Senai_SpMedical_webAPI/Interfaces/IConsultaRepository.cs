using Senai_SpMedical_webAPI.Domains;
using System.Collections.Generic;

namespace Senai_SpMedical_webAPI.Interfaces
{

    /// <summary>
    /// Interface responsável pelo repositório ConsultaRepository
    /// </summary>
    interface IConsultaRepository
    {
        /// <summary>
        /// Lista todos os Consultas
        /// </summary>
        /// <returns>Uma lista de Consultas</returns>
        List<Consultum> Listar();

        /// <summary>
        /// Busca um Consulta por seu Id
        /// </summary>
        /// <param name="IdConsulta">Id do Consulta</param>
        /// <returns>Consulta buscado</returns>
        Consultum ListarId(int IdConsulta);

        /// <summary>
        /// Cadastra um Consulta
        /// </summary>
        /// <param name="NovaConsulta">Objeto novoConsulta com os novos dados</param>
        void Cadastrar(Consultum NovaConsulta);

        /// <summary>
        /// Atualiza um Consulta específico
        /// </summary>
        /// <param name="IdConsulta">Id do Consulta atualizado</param>
        /// <param name="ConsultaAtualizado">ConsultaAtualizado com os novos dados</param>
        void Atualizar(int IdConsulta, Consultum ConsultaAtualizado);

        /// <summary>
        /// Lista todas as consultas que um determinado usuário participa
        /// </summary>
        /// <param name="idUsuario">ID do usuário que participa das consultas listadas</param>
        /// <returns>Uma lista de presenças com os dados das consultas</returns>
        List<Consultum> ListarMinhas(int idUsuario);

        /// <summary>
        /// Deleta uma Consulta específica
        /// </summary>
        /// <param name="IdConsulta">Id do Consulta deletado</param>
        void Deletar(int IdConsulta);
    }
}