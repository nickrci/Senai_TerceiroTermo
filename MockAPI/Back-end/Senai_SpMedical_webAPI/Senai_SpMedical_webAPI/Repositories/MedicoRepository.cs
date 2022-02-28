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
    public class MedicoRepository : IMedicoRepository
    {

        SpMedicalContext ctx = new SpMedicalContext();

        public void Atualizar(int IdMedico, Medico MedicoAtualizado)
        {
            Medico MedicoBuscado = ListarId(IdMedico);

            if (MedicoBuscado != null)
            {
                MedicoBuscado.IdUsuario = MedicoAtualizado.IdUsuario;
                MedicoBuscado.IdEspecialidadeMedico = MedicoAtualizado.IdEspecialidadeMedico;
                MedicoBuscado.IdClinica = MedicoAtualizado.IdClinica;
                MedicoBuscado.CrmMedico = MedicoAtualizado.CrmMedico;
                MedicoBuscado.NomeMedico = MedicoAtualizado.NomeMedico;
                
        
    }

    ctx.Medicos.Update(MedicoBuscado);
            ctx.SaveChanges();
        }

        public void Cadastrar(Medico NovoMedico)
        {
            ctx.Medicos.Add(NovoMedico);
            ctx.SaveChanges();
        }

        public void Deletar(int IdMedico)
        {
            Medico MedicoBuscado = ListarId(IdMedico);
            ctx.Medicos.Remove(MedicoBuscado);
            ctx.SaveChanges();
        }

        public List<Medico> Listar()
        {
            return ctx.Medicos.ToList();
        }

        public Medico ListarId(int IdMedico)
        {
            return ctx.Medicos.FirstOrDefault(c => c.IdMedico == IdMedico);
        }

        public List<Medico> ListarComConsultas()
        {
            return ctx.Medicos.Include(c => c.Consulta).OrderBy(c => c.IdMedico).ToList();
        }
    }
}