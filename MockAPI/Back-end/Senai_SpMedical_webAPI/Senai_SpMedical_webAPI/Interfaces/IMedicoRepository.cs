using Senai_SpMedical_webAPI.Domains;
using System.Collections.Generic;

namespace Senai_SpMedical_webAPI.Interfaces
{

    /// <summary>
    /// Interface responsável pelo repositório MedicoRepository
    /// </summary>
    interface IMedicoRepository
    {
        /// <summary>
        /// Lista todos os Medicos
        /// </summary>
        /// <returns>Uma lista de Medicos</returns>
        List<Medico> Listar();

        /// <summary>
        /// Busca um Medico por seu Id
        /// </summary>
        /// <param name="IdMedico">Id do Medico</param>
        /// <returns>Medico buscado</returns>
        Medico ListarId(int IdMedico);

        /// <summary>
        /// Cadastra um Medico
        /// </summary>
        /// <param name="NovoMedico">Objeto novoMedico com os novos dados</param>
        void Cadastrar(Medico NovoMedico);

        /// <summary>
        /// Atualiza um Medico específico
        /// </summary>
        /// <param name="IdMedico">Id do Medico atualizado</param>
        /// <param name="MedicoAtualizado">MedicoAtualizado com os novos dados</param>
        void Atualizar(int IdMedico, Medico MedicoAtualizado);

        /// <summary>
        /// Deleta um Medico específico
        /// </summary>
        /// <param name="IdMedico">Id do Medico deletado</param>
        void Deletar(int IdMedico);

        /// <summary>
        /// Lista todos os Medicos com suas respectivas listas de consultas
        /// </summary>
        /// <returns>Uma lista de Medicos com suas consultas</returns>
        public List<Medico> ListarComConsultas();
    }
}