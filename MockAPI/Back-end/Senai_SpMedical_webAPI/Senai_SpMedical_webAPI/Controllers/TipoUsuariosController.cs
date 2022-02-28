using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai_SpMedical_webAPI.Domains;
using Senai_SpMedical_webAPI.Interfaces;
using Senai_SpMedical_webAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_SpMedical_webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TipoUsuariosController : ControllerBase
    {
        private ITipoUsuarioRepository _TipoUsuarioRepository { get; set; }

        public TipoUsuariosController()
        {
            _TipoUsuarioRepository = new TipoUsuarioRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<TipoUsuario> ListaTipoUsuarios = _TipoUsuarioRepository.Listar();
            return Ok(ListaTipoUsuarios);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            TipoUsuario TipoUsuarioBuscado = _TipoUsuarioRepository.ListarId(id);

            if (TipoUsuarioBuscado == null)
            {
                return NotFound("Nenhum Usuário encontrado.");
            }

            return Ok(TipoUsuarioBuscado);
        }

        [HttpPost]
        public IActionResult Post(TipoUsuario NovoTipoUsuario)
        {
            _TipoUsuarioRepository.Cadastrar(NovoTipoUsuario);

            return StatusCode(201);
        }

        [HttpDelete("excluir/{id}")]
        public IActionResult Delete(int id)
        {
            _TipoUsuarioRepository.Deletar(id);
            return StatusCode(204);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, TipoUsuario TipoUsuarioAtualizado)
        {
            TipoUsuario TipoUsuarioBuscado = _TipoUsuarioRepository.ListarId(id);

            if (TipoUsuarioBuscado == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "Usuário não encontrado.",
                        erro = true
                    });
            }

            try
            {
                _TipoUsuarioRepository.Atualizar(id, TipoUsuarioAtualizado);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpGet("usuarios")]
        public IActionResult ListarComUsuarios()
        {
            try
            {
                return Ok(_TipoUsuarioRepository.ListarComUsuarios());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
