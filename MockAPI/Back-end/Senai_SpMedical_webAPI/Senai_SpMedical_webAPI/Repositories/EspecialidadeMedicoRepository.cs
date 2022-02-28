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
    public class EspecialidadeMedicoRepository : IEspecialidadeMedicoRepository
    {

        SpMedicalContext ctx = new SpMedicalContext();

        public void Atualizar(int IdEspecialidadeMedico, EspecialidadeMedico EspecialidadeMedicoAtualizado)
        {
            EspecialidadeMedico EspecialidadeMedicoBuscado = ListarId(IdEspecialidadeMedico);

            if (EspecialidadeMedicoBuscado != null)
            {
                EspecialidadeMedicoBuscado.NomeEspecialidade = EspecialidadeMedicoAtualizado.NomeEspecialidade;

            }

            ctx.EspecialidadeMedicos.Update(EspecialidadeMedicoBuscado);
            ctx.SaveChanges();
        }

        public void Cadastrar(EspecialidadeMedico NovoEspecialidadeMedico)
        {
            ctx.EspecialidadeMedicos.Add(NovoEspecialidadeMedico);
            ctx.SaveChanges();
        }

        public void Deletar(int IdEspecialidadeMedico)
        {
            EspecialidadeMedico EspecialidadeMedicoBuscado = ListarId(IdEspecialidadeMedico);
            ctx.EspecialidadeMedicos.Remove(EspecialidadeMedicoBuscado);
            ctx.SaveChanges();
        }

        public List<EspecialidadeMedico> Listar()
        {
            return ctx.EspecialidadeMedicos.ToList();
        }

        public EspecialidadeMedico ListarId(int IdEspecialidadeMedico)
        {
            return ctx.EspecialidadeMedicos.FirstOrDefault(c => c.IdEspecialidadeMedico == IdEspecialidadeMedico);
        }

        public List<EspecialidadeMedico> ListarComMedicos()
        {
            return ctx.EspecialidadeMedicos.Include(c => c.Medicos).OrderBy(c => c.IdEspecialidadeMedico).ToList();
        }
    }
}
