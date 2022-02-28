using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai_SpMedical_webAPI.Domains;
using Senai_SpMedical_webAPI.Interfaces;
using Senai_SpMedical_webAPI.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace senai_SpMedical_webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultasController : ControllerBase
    {
        private IConsultaRepository _ConsultaRepository { get; set; }

        public ConsultasController()
        {
            _ConsultaRepository = new ConsultaRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Consultum> listaConsultas = _ConsultaRepository.Listar();
            return Ok(listaConsultas);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Consultum ConsultaBuscado = _ConsultaRepository.ListarId(id);

            if (ConsultaBuscado == null)
            {
                return NotFound("Nenhum Usuário encontrado.");
            }

            return Ok(ConsultaBuscado);
        }

        [HttpPost]
        public IActionResult Post(Consultum NovaConsulta)
        {
            _ConsultaRepository.Cadastrar(NovaConsulta);

            return StatusCode(201);
        }

        [HttpDelete("excluir/{id}")]
        public IActionResult Delete(int id)
        {
            _ConsultaRepository.Deletar(id);
            return StatusCode(204);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Consultum ConsultaAtualizado)
        {
            Consultum ConsultaBuscado = _ConsultaRepository.ListarId(id);

            if (ConsultaBuscado == null)
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
                _ConsultaRepository.Atualizar(id, ConsultaAtualizado);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        //[Authorize(Roles = "2")]
        [HttpGet("minhas")]
        public IActionResult ListarMinhas()
        {
            try
            {
                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                // Caso fosse necessário trazer o valor do e-mail do usuário, a partir do token
                // string emailUsuario = HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Email).Value;

                return Ok(_ConsultaRepository.ListarMinhas(idUsuario));
            }
            catch (Exception error)
            {
                return BadRequest(new
                {
                    mensagem = "Não é possível mostrar as consultas se o usuário não estiver logado!",
                    erro = error

                });
            }
        }
    }
}