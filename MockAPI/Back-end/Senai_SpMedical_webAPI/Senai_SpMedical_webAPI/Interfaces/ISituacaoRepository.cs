using Senai_SpMedical_webAPI.Domains;
using System.Collections.Generic;

namespace Senai_SpMedical_webAPI.Interfaces
{

    /// <summary>
    /// Interface responsável pelo repositório SituacaoRepository
    /// </summary>
    interface ISituacaoRepository
    {
        /// <summary>
        /// Lista todas as Situacao
        /// </summary>
        /// <returns>Uma lista de Situacao</returns>
        List<Situacao> Listar();

        /// <summary>
        /// Busca uma Situacao por seu Id
        /// </summary>
        /// <param name="IdSituacao">Id da Situacao</param>
        /// <returns>Situacao buscada</returns>
        Situacao ListarId(int IdSituacao);

        /// <summary>
        /// Cadastrar uma Situacao
        /// </summary>
        /// <param name="NovaSituacao">Objeto NovaSituacao com os novos dados</param>
        void Cadastrar(Situacao NovaSituacao);

        /// <summary>
        /// Atualiza uma Situacao específico
        /// </summary>
        /// <param name="IdSituacao">Id do Situacao atualizado</param>
        /// <param name="SituacaoAtualizada">SituacaoAtualizado com os novos dados</param>
        void Atualizar(int IdSituacao, Situacao SituacaoAtualizada);

        /// <summary>
        /// Deleta uma Situacao específica
        /// </summary>
        /// <param name="IdSituacao">Id do Situacao deletada</param>
        void Deletar(int IdSituacao);

        /// <summary>
        /// Lista todas as Situacoes com suas respectivas listas de consultas
        /// </summary>
        /// <returns>Uma lista de Situacoes com suas consultas</returns>
        public List<Situacao> ListarComConsultas();
    }
}