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
    public class ClientesController : ControllerBase
    {
        private IClienteRepository _ClienteRepository { get; set; }

        public ClientesController()
        {
            _ClienteRepository = new ClienteRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Cliente> ListaClientes = _ClienteRepository.Listar();
            return Ok(ListaClientes);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Cliente ClienteBuscado = _ClienteRepository.ListarId(id);

            if (ClienteBuscado == null)
            {
                return NotFound("Nenhum Usuário encontrado.");
            }

            return Ok(ClienteBuscado);
        }

        [HttpPost]
        public IActionResult Post(Cliente NovoCliente)
        {
            _ClienteRepository.Cadastrar(NovoCliente);

            return StatusCode(201);
        }

        [HttpDelete("excluir/{id}")]
        public IActionResult Delete(int id)
        {
            _ClienteRepository.Deletar(id);
            return StatusCode(204);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Cliente ClienteAtualizado)
        {
            Cliente ClienteBuscado = _ClienteRepository.ListarId(id);

            if (ClienteBuscado == null)
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
                _ClienteRepository.Atualizar(id, ClienteAtualizado);

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
                return Ok(_ClienteRepository.ListarComConsultas());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}