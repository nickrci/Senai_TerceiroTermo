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
    public class ClinicaRepository : IClinicaRepository
    {

        SpMedicalContext ctx = new SpMedicalContext();

        public void Atualizar(int IdClinica, Clinica ClinicaAtualizado)
        {
            Clinica ClinicaBuscado = ListarId(IdClinica);

            if (ClinicaBuscado != null)
            {
                ClinicaBuscado.EnderecoClinica = ClinicaAtualizado.EnderecoClinica;
                ClinicaBuscado.HorarioInicio = ClinicaAtualizado.HorarioInicio;
                ClinicaBuscado.HorarioFim = ClinicaAtualizado.HorarioFim;
                ClinicaBuscado.Cnpj = ClinicaAtualizado.Cnpj;
                ClinicaBuscado.NomeFantasia = ClinicaAtualizado.NomeFantasia;
                ClinicaBuscado.RazaoSocial = ClinicaAtualizado.RazaoSocial;
               
            }

            ctx.Clinicas.Update(ClinicaBuscado);
            ctx.SaveChanges();
        }

        public void Cadastrar(Clinica NovoClinica)
        {
            ctx.Clinicas.Add(NovoClinica);
            ctx.SaveChanges();
        }

        public void Deletar(int IdClinica)
        {
            Clinica ClinicaBuscado = ListarId(IdClinica);
            ctx.Clinicas.Remove(ClinicaBuscado);
            ctx.SaveChanges();
        }

        public List<Clinica> Listar()
        {
            return ctx.Clinicas.ToList();
        }

        public Clinica ListarId(int IdClinica)
        {
            return ctx.Clinicas.FirstOrDefault(c => c.IdClinica == IdClinica);
        }

        public List<Clinica> ListarComMedicos()
        {
            return ctx.Clinicas.Include(c => c.Medicos).OrderBy(c => c.IdClinica).ToList();
        }
    }
}
