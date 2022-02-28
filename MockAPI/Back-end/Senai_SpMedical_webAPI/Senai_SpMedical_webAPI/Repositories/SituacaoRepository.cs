using Microsoft.EntityFrameworkCore;
using Senai_SpMedical_webAPI.Contexts;
using Senai_SpMedical_webAPI.Domains;
using Senai_SpMedical_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_SpMedical_webAPI.Repositories
{
    public class SituacaoRepository : ISituacaoRepository
    {

        SpMedicalContext ctx = new SpMedicalContext();

        public void Atualizar(int IdSituacao, Situacao SituacaoAtualizado)
        {
            Situacao SituacaoBuscado = ListarId(IdSituacao);

            if (SituacaoBuscado != null)
            {
                SituacaoBuscado.TipoSituacao = SituacaoAtualizado.TipoSituacao;
               
            }

            ctx.Situacaos.Update(SituacaoBuscado);
            ctx.SaveChanges();
        }

        public void Cadastrar(Situacao NovoSituacao)
        {
            ctx.Situacaos.Add(NovoSituacao);
            ctx.SaveChanges();
        }

        public void Deletar(int IdSituacao)
        {
            Situacao SituacaoBuscado = ListarId(IdSituacao);
            ctx.Situacaos.Remove(SituacaoBuscado);
            ctx.SaveChanges();
        }

        public List<Situacao> Listar()
        {
            return ctx.Situacaos.ToList();
        }

        public Situacao ListarId(int IdSituacao)
        {
            return ctx.Situacaos.FirstOrDefault(c => c.IdSituacao == IdSituacao);
        }

        public List<Situacao> ListarComConsultas()
        {
            return ctx.Situacaos.Include(c => c.Consulta).OrderBy(c => c.IdSituacao).ToList();
        }
    }
}
