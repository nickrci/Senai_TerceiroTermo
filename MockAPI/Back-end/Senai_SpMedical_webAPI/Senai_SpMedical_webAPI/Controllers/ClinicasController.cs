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
    public class ClinicasController : ControllerBase
    {
        private IClinicaRepository _ClinicaRepository { get; set; }

        public ClinicasController()
        {
            _ClinicaRepository = new ClinicaRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Clinica> ListaClinicas = _ClinicaRepository.Listar();
            return Ok(ListaClinicas);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Clinica ClinicaBuscado = _ClinicaRepository.ListarId(id);

            if (ClinicaBuscado == null)
            {
                return NotFound("Nenhum Usuário encontrado.");
            }

            return Ok(ClinicaBuscado);
        }

        [HttpPost]
        public IActionResult Post(Clinica NovoClinica)
        {
            _ClinicaRepository.Cadastrar(NovoClinica);

            return StatusCode(201);
        }

        [HttpDelete("excluir/{id}")]
        public IActionResult Delete(int id)
        {
            _ClinicaRepository.Deletar(id);
            return StatusCode(204);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Clinica ClinicaAtualizado)
        {
            Clinica ClinicaBuscado = _ClinicaRepository.ListarId(id);

            if (ClinicaBuscado == null)
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
                _ClinicaRepository.Atualizar(id, ClinicaAtualizado);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpGet("medicos")]
        public IActionResult ListarComMedicos()
        {
            try
            {
                return Ok(_ClinicaRepository.ListarComMedicos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}