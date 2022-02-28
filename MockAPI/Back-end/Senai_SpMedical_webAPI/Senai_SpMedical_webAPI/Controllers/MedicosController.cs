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
    public class MedicosController : ControllerBase
    {
        private IMedicoRepository _MedicoRepository { get; set; }

        public MedicosController()
        {
            _MedicoRepository = new MedicoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Medico> ListaMedicos = _MedicoRepository.Listar();
            return Ok(ListaMedicos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Medico MedicoBuscado = _MedicoRepository.ListarId(id);

            if (MedicoBuscado == null)
            {
                return NotFound("Nenhum Usuário encontrado.");
            }

            return Ok(MedicoBuscado);
        }

        [HttpPost]
        public IActionResult Post(Medico NovoMedico)
        {
            _MedicoRepository.Cadastrar(NovoMedico);

            return StatusCode(201);
        }

        [HttpDelete("excluir/{id}")]
        public IActionResult Delete(int id)
        {
            _MedicoRepository.Deletar(id);
            return StatusCode(204);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Medico MedicoAtualizado)
        {
            Medico MedicoBuscado = _MedicoRepository.ListarId(id);

            if (MedicoBuscado == null)
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
                _MedicoRepository.Atualizar(id, MedicoAtualizado);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpGet("consultas")]
        public IActionResult ListarComConsultas()
        {
            try
            {
                return Ok(_MedicoRepository.ListarComConsultas());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}