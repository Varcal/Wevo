using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Wevo.Api.Models;
using Wevo.Dominio.Commands;
using Wevo.Dominio.Contratos.Servicos;
using Wevo.NucleoCompartilhado.DomainEvents.Core;
using Wevo.NucleoCompartilhado.DomainEvents.Notifications;

namespace Wevo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase, IDisposable
    {
        private readonly IClienteServico _clienteServico;
        private readonly IDomainNotificationHandler _domainNotificationHandler;

        public ClientesController(IClienteServico clienteServico)
        {
            _clienteServico = clienteServico;
            _domainNotificationHandler = (IDomainNotificationHandler)DomainEvent.ServiceProvider.GetService(typeof(IDomainNotificationHandler));
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

            var model = new ClienteModel(cliente);
            return Ok(model);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] ClienteRegistrar model)
        {
            
            _clienteServico.Registrar(model);

            if (_domainNotificationHandler.HasNotification()) return NotFound(_domainNotificationHandler.GetNotifications());

            return Created("", "Registrado com sucesso");
        }
        
        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ClienteAlterar model)
        {
            _clienteServico.Alterar(model);

            if (_domainNotificationHandler.HasNotification()) return NotFound(_domainNotificationHandler.GetNotifications());

            return Ok("Alterado com sucesso");
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _clienteServico.Excluir(id);

            if (_domainNotificationHandler.HasNotification()) return NotFound(_domainNotificationHandler.GetNotifications());

            return Ok("Excluído com sucesso");
        }

        public void Dispose()
        {
            _domainNotificationHandler?.Dispose();
        }
    }
}
