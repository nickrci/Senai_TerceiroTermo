using Senai_SpMedical_webAPI.Domains;
using System.Collections.Generic;

namespace Senai_SpMedical_webAPI.Interfaces
{

    /// <summary>
    /// Interface responsável pelo repositório ClinicaRepository
    /// </summary>
    interface IClinicaRepository
    {
        /// <summary>
        /// Lista todos os Clinicas
        /// </summary>
        /// <returns>Uma lista de Clinicas</returns>
        List<Clinica> Listar();

        /// <summary>
        /// Busca um Clinica por seu Id
        /// </summary>
        /// <param name="IdClinica">Id do Clinica</param>
        /// <returns>Clinica buscado</returns>
        Clinica ListarId(int IdClinica);

        /// <summary>
        /// Cadastra um Clinica
        /// </summary>
        /// <param name="NovoClinica">Objeto novoClinica com os novos dados</param>
        void Cadastrar(Clinica NovoClinica);

        /// <summary>
        /// Atualiza um Clinica específico
        /// </summary>
        /// <param name="IdClinica">Id do Clinica atualizado</param>
        /// <param name="ClinicaAtualizado">ClinicaAtualizado com os novos dados</param>
        void Atualizar(int IdClinica, Clinica ClinicaAtualizado);

        /// <summary>
        /// Deleta um Clinica específico
        /// </summary>
        /// <param name="IdClinica">Id do Clinica deletado</param>
        void Deletar(int IdClinica);

        /// <summary>
        /// Lista todas as Clinicas com suas respectivas listas de medicos
        /// </summary>
        /// <returns>Uma lista de Clinicas com seus medicos</returns>
        public List<Clinica> ListarComMedicos();
    }
}