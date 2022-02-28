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
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {

        SpMedicalContext ctx = new SpMedicalContext();

        public void Atualizar(int IdTipoUsuario, TipoUsuario TipoUsuarioAtualizado)
        {
            TipoUsuario TipoUsuarioBuscado = ListarId(IdTipoUsuario);

            if (TipoUsuarioBuscado != null)
            {
                TipoUsuarioBuscado.TipoUsuario1 = TipoUsuarioAtualizado.TipoUsuario1;
               
            }

            ctx.TipoUsuarios.Update(TipoUsuarioBuscado);
            ctx.SaveChanges();
        }

        public void Cadastrar(TipoUsuario NovoTipoUsuario)
        {
            ctx.TipoUsuarios.Add(NovoTipoUsuario);
            ctx.SaveChanges();
        }

        public void Deletar(int IdTipoUsuario)
        {
            TipoUsuario TipoUsuarioBuscado = ListarId(IdTipoUsuario);
            ctx.TipoUsuarios.Remove(TipoUsuarioBuscado);
            ctx.SaveChanges();
        }

        public List<TipoUsuario> Listar()
        {
            return ctx.TipoUsuarios.ToList();
        }

        public TipoUsuario ListarId(int IdTipoUsuario)
        {
            return ctx.TipoUsuarios.FirstOrDefault(c => c.IdTipoUsuario == IdTipoUsuario);
        }

        List<TipoUsuario> ITipoUsuarioRepository.ListarComUsuarios()
        {
            return ctx.TipoUsuarios.Include(c => c.Usuarios).OrderBy(c => c.IdTipoUsuario).ToList();
        }
    }
}
