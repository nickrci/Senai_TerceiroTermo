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
    public class EspecialidadeMedicosController : ControllerBase
    {
        private IEspecialidadeMedicoRepository _EspecialidadeMedicoRepository { get; set; }

        public EspecialidadeMedicosController()
        {
            _EspecialidadeMedicoRepository = new EspecialidadeMedicoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<EspecialidadeMedico> listaEspecialidadeMedicos = _EspecialidadeMedicoRepository.Listar();
            return Ok(listaEspecialidadeMedicos);  
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            EspecialidadeMedico EspecialidadeMedicoBuscado = _EspecialidadeMedicoRepository.ListarId(id);

            if (EspecialidadeMedicoBuscado == null)
            {
                return NotFound("Nenhum Usuário encontrado.");
            }

            return Ok(EspecialidadeMedicoBuscado);
        }

        [HttpPost]
        public IActionResult Post(EspecialidadeMedico NovoEspecialidadeMedico)
        {
            _EspecialidadeMedicoRepository.Cadastrar(NovoEspecialidadeMedico);

            return StatusCode(201);
        }

        [HttpDelete("excluir/{id}")]
        public IActionResult Delete(int id)
        {
            _EspecialidadeMedicoRepository.Deletar(id);
            return StatusCode(204);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, EspecialidadeMedico EspecialidadeMedicoAtualizado)
        {
            EspecialidadeMedico EspecialidadeMedicoBuscado = _EspecialidadeMedicoRepository.ListarId(id);

            if (EspecialidadeMedicoBuscado == null)
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
                _EspecialidadeMedicoRepository.Atualizar(id, EspecialidadeMedicoAtualizado);

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
                return Ok(_EspecialidadeMedicoRepository.ListarComMedicos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}