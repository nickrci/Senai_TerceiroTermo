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
    public class SituacaosController : ControllerBase
    {
        private ISituacaoRepository _SituacaoRepository { get; set; }

        public SituacaosController()
        {
            _SituacaoRepository = new SituacaoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Situacao> ListaSituacaos = _SituacaoRepository.Listar();
            return Ok(ListaSituacaos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Situacao SituacaoBuscado = _SituacaoRepository.ListarId(id);

            if (SituacaoBuscado == null)
            {
                return NotFound("Nenhum Usuário encontrado.");
            }

            return Ok(SituacaoBuscado);
        }

        [HttpPost]
        public IActionResult Post(Situacao NovaSituacao)
        {
            _SituacaoRepository.Cadastrar(NovaSituacao);

            return StatusCode(201);
        }

        [HttpDelete("excluir/{id}")]
        public IActionResult Delete(int id)
        {
            _SituacaoRepository.Deletar(id);
            return StatusCode(204);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Situacao SituacaoAtualizado)
        {
            Situacao SituacaoBuscado = _SituacaoRepository.ListarId(id);

            if (SituacaoBuscado == null)
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
                _SituacaoRepository.Atualizar(id, SituacaoAtualizado);

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
                return Ok(_SituacaoRepository.ListarComConsultas());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}