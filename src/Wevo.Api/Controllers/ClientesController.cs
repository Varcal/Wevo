using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Wevo.Api.Models;
using Wevo.Dominio.Commands;
using Wevo.Dominio.Contratos.Servicos;
using Wevo.Dominio.Enums;

namespace Wevo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteServico _clienteServico;

        public ClientesController(IClienteServico clienteServico)
        {
            _clienteServico = clienteServico;
        }


        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<ClienteModel>> Get()
        {
            var clientes = _clienteServico.SelecionarTodos(0, 0);
            return clientes.Select(x => new ClienteModel(x)).ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<ClienteModel> Get(int id)
        {
            var cliente = _clienteServico.ObterPorId(id);
            return new ClienteModel(cliente);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] ClienteRegistrar model)
        {
            _clienteServico.Registrar(model);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ClienteAlterar model)
        {
            _clienteServico.Alterar(model);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _clienteServico.Excluir(id);
        }
    }
}
