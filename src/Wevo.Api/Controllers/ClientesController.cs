using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Wevo.Api.Models;
using Wevo.Dominio.Commands;
using Wevo.Dominio.Contratos.Servicos;

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
        public IActionResult Get()
        {
            var clientes = _clienteServico.SelecionarTodos(0, 0);
            return Ok(clientes.Select(x => new ClienteModel(x)).ToList());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var cliente = _clienteServico.ObterPorId(id);

            if (cliente == null) return NoContent();
 
            return Ok(cliente);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] ClienteRegistrar model)
        {
            _clienteServico.Registrar(model);

            //if (notifications.Any()) return NotFound(new List<string>());

            return Created("", @"Registrado com sucesso");
        }
        
        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ClienteAlterar model)
        {
            _clienteServico.Alterar(model);
            //if (notifications.Any()) return NotFound(new List<string>());

            return Ok("Alterado com sucesso");
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _clienteServico.Excluir(id);

            //if (notifications.Any()) return NotFound(new List<string>());

            return Ok("Excluído com sucesso");
        }
    }
}
