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
    public class ConsultaRepository : IConsultaRepository
    {

        SpMedicalContext ctx = new SpMedicalContext();

        public void Atualizar(int IdConsulta, Consultum ConsultaAtualizado)
        {
            Consultum ConsultaBuscado = ListarId(IdConsulta);

            if (ConsultaBuscado != null)
            {
                ConsultaBuscado.IdCliente = ConsultaAtualizado.IdCliente;
                ConsultaBuscado.IdMedico = ConsultaAtualizado.IdMedico;
                ConsultaBuscado.IdSituacao = ConsultaAtualizado.IdSituacao;
                ConsultaBuscado.DataConsulta = ConsultaAtualizado.DataConsulta;
                ConsultaBuscado.DescricaoConsulta = ConsultaAtualizado.DescricaoConsulta;


            }

            ctx.Consulta.Update(ConsultaBuscado);
            ctx.SaveChanges();
        }

        public void Cadastrar(Consultum NovaConsulta)
        {
            ctx.Consulta.Add(NovaConsulta);
            ctx.SaveChanges();
        }

        public void Deletar(int IdConsulta)
        {
            Consultum ConsultaBuscado = ListarId(IdConsulta);
            ctx.Consulta.Remove(ConsultaBuscado);
            ctx.SaveChanges();
        }

        public List<Consultum> Listar()
        {
            return ctx.Consulta
                .Include(c => c.IdClienteNavigation)
                .Include(c => c.IdMedicoNavigation)
                .Include(c => c.IdSituacaoNavigation)
                .Include(c => c.IdMedicoNavigation.IdEspecialidadeMedicoNavigation)
                .ToList();
        }

        public Consultum ListarId(int IdConsulta)
        {
            return ctx.Consulta.FirstOrDefault(c => c.IdConsulta == IdConsulta);
        }

        public List<Consultum> ListarMinhas(int idUsuario)
        {
            // Retorna uma lista com todas as informações das presenças
            return ctx.Consulta
                .Include(c => c.IdClienteNavigation)
                .Include(c => c.IdMedicoNavigation)
                .Include(c => c.IdSituacaoNavigation)
                .Include(c => c.IdMedicoNavigation.IdEspecialidadeMedicoNavigation)
                .Where(c => c.IdMedicoNavigation.IdUsuario == idUsuario || c.IdClienteNavigation.IdUsuario == idUsuario)
                .ToList();
        }
    }
}
