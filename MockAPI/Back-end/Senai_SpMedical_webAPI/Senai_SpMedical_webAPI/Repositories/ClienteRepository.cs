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
    public class ClienteRepository : IClienteRepository
    {

        SpMedicalContext ctx = new SpMedicalContext();

        public void Atualizar(int IdCliente, Cliente ClienteAtualizado)
        {
            Cliente ClienteBuscado = ListarId(IdCliente);

            if (ClienteBuscado != null)
            {
                ClienteBuscado.IdUsuario = ClienteAtualizado.IdUsuario;
                ClienteBuscado.NomeCliente = ClienteAtualizado.NomeCliente;
                ClienteBuscado.DataNascCliente = ClienteAtualizado.DataNascCliente;
                ClienteBuscado.TelefoneCliente = ClienteAtualizado.TelefoneCliente;
                ClienteBuscado.RgCliente = ClienteAtualizado.RgCliente;
                ClienteBuscado.CpfCliente = ClienteAtualizado.CpfCliente;
                ClienteBuscado.EnderecoCliente = ClienteAtualizado.EnderecoCliente;
            }

            ctx.Clientes.Update(ClienteBuscado);
            ctx.SaveChanges();
        }

        public void Cadastrar(Cliente NovoCliente)
        {
            ctx.Clientes.Add(NovoCliente);
            ctx.SaveChanges();
        }

        public void Deletar(int IdCliente)
        {
            Cliente ClienteBuscado = ListarId(IdCliente);
            ctx.Clientes.Remove(ClienteBuscado);
            ctx.SaveChanges();
        }

        public List<Cliente> Listar()
        {
            return ctx.Clientes.ToList();
        }

        public Cliente ListarId(int IdCliente)
        {
            return ctx.Clientes.FirstOrDefault(c => c.IdCliente == IdCliente);
        }

        public List<Cliente> ListarComConsultas()
        {
            return ctx.Clientes.Include(c => c.Consulta).OrderBy(c => c.IdCliente).ToList();
        }
    }
}
