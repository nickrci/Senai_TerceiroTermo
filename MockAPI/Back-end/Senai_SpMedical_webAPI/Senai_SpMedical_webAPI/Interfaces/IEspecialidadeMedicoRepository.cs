using Senai_SpMedical_webAPI.Domains;
using System.Collections.Generic;

namespace Senai_SpMedical_webAPI.Interfaces
{

    /// <summary>
    /// Interface responsável pelo repositório EspecialidadeMedicoRepository
    /// </summary>
    interface IEspecialidadeMedicoRepository
    {
        /// <summary>
        /// Lista todos os EspecialidadeMedicos
        /// </summary>
        /// <returns>Uma lista de EspecialidadeMedicos</returns>
        List<EspecialidadeMedico> Listar();

        /// <summary>
        /// Busca um EspecialidadeMedico por seu Id
        /// </summary>
        /// <param name="IdEspecialidadeMedico">Id do EspecialidadeMedico</param>
        /// <returns>EspecialidadeMedico buscado</returns>
        EspecialidadeMedico ListarId(int IdEspecialidadeMedico);

        /// <summary>
        /// Cadastra um EspecialidadeMedico
        /// </summary>
        /// <param name="NovoEspecialidadeMedico">Objeto novoEspecialidadeMedico com os novos dados</param>
        void Cadastrar(EspecialidadeMedico NovoEspecialidadeMedico);

        /// <summary>
        /// Atualiza um EspecialidadeMedico específico
        /// </summary>
        /// <param name="IdEspecialidadeMedico">Id do EspecialidadeMedico atualizado</param>
        /// <param name="EspecialidadeMedicoAtualizado">EspecialidadeMedicoAtualizado com os novos dados</param>
        void Atualizar(int IdEspecialidadeMedico, EspecialidadeMedico EspecialidadeMedicoAtualizado);

        /// <summary>
        /// Deleta um EspecialidadeMedico específico
        /// </summary>
        /// <param name="IdEspecialidadeMedico">Id do EspecialidadeMedico deletado</param>
        void Deletar(int IdEspecialidadeMedico);

        /// <summary>
        /// Lista todas as EspecialidadesMedico com suas respectivas listas de medicos
        /// </summary>
        /// <returns>Uma lista de EspecialidadesMedico com seus medicos</returns>
        public List<EspecialidadeMedico> ListarComMedicos();
    }
}