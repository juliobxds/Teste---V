using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Teste___V.Models;
using System;
using System.Collections.Generic;
using Teste___V.Repositorios.Interfaces;
using System.Threading.Tasks;
using Teste___V.Repositorios;
using System.Linq.Expressions;
using Teste___V.ViewModels;

namespace Teste___V.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase {
        private readonly IClienteRepository icliente;

        public ClienteController(IClienteRepository icliente) {
            this.icliente = icliente;
        }

        [HttpGet("TodosClientes")]
        public async Task<ActionResult> TodosClientes() {
            List <ClienteM> clientes = await icliente.TodosClientes();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> BuscarPorId(int id) {

            ClienteM cliente = await icliente.BuscarPorId(id);
            return Ok(cliente);
        }

        [HttpPost("Adicionar")]
        public async Task<ActionResult> Adicionar(ClienteViewModel cliente) {

            ClienteViewModel clienteAdd = await icliente.Adicionar(cliente);
            return Ok(clienteAdd);
        }

        [HttpPut]
        public async Task<ActionResult> Atualizar(ClienteAtualizarViewModel cliente) {

            ClienteM clienteAtt = await icliente.Atualizar(cliente);
            return Ok(clienteAtt);
        }

        [HttpDelete]
        public async Task<ActionResult> Apagar(int id) {
            bool clienteApg = await icliente.Apagar(id);
            return Ok(clienteApg);
        }
        }
    }


