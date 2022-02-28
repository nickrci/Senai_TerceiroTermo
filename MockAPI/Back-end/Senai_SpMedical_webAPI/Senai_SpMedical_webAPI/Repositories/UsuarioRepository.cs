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
    public class UsuarioRepository : IUsuarioRepository
    {

        SpMedicalContext ctx = new SpMedicalContext();

        public void Atualizar(int IdUsuario, Usuario UsuarioAtualizado)
        {
            Usuario UsuarioBuscado = ListarId(IdUsuario);

            if (UsuarioBuscado != null)
            {
                UsuarioBuscado.IdTipoUsuario = UsuarioAtualizado.IdTipoUsuario;
                UsuarioBuscado.Email = UsuarioAtualizado.Email;
                UsuarioBuscado.Senha = UsuarioAtualizado.Senha;
            }

            ctx.Usuarios.Update(UsuarioBuscado);
            ctx.SaveChanges();
        }

        public void Cadastrar(Usuario NovoUsuario)
        {
            ctx.Usuarios.Add(NovoUsuario);
            ctx.SaveChanges();
        }

        public void Deletar(int IdUsuario)
        {
            Usuario UsuarioBuscado = ListarId(IdUsuario);
            ctx.Usuarios.Remove(UsuarioBuscado);
            ctx.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            return ctx.Usuarios.ToList();
        }

        public Usuario ListarId(int IdUsuario)
        {
            return ctx.Usuarios.FirstOrDefault(c => c.IdUsuario == IdUsuario);
        }

        public Usuario Login(string email, string senha)
        {
            return ctx.Usuarios.FirstOrDefault(x => x.Email == email && x.Senha == senha);
        }

        public List<Usuario> ListarComClientes()
        {
            return ctx.Usuarios.Include(c => c.Cliente).OrderBy(c => c.IdUsuario).ToList();
        }

        public List<Usuario> ListarComMedicos()
        {
            return ctx.Usuarios.Include(c => c.Medico).OrderBy(c => c.IdUsuario).ToList();
        }
    }
}
