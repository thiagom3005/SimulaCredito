using Microsoft.AspNetCore.Mvc;
using SimulaCredito.Models;
using SimulaCredito.Business;
using SimulaCredito.Hypermedia.Filters;

namespace SimulaCredito.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class ClienteController : ControllerBase
    {
        private readonly ILogger<ClienteController> _logger;
        private IClienteBusiness _clienteBusiness;

        public ClienteController(ILogger<ClienteController> logger, IClienteBusiness clienteBusiness)
        {
            _logger = logger;
            _clienteBusiness = clienteBusiness;
        }

        [HttpGet]
        [ProducesResponseType((200), Type = typeof(List<Cliente>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get()
        {
            return Ok(_clienteBusiness.FindAll());
        }

        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(Cliente))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(long id )
        {
            var cliente = _clienteBusiness.FindById(id);
            if (cliente == null) return NotFound();
            return Ok(cliente);
        }

        [HttpPost]
        [ProducesResponseType((200), Type = typeof(Cliente))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody] Cliente cliente)
        {
            if (cliente == null) return BadRequest();
            return Ok(_clienteBusiness.Create(cliente));
        }

        [HttpPut]
        [ProducesResponseType((200), Type = typeof(Cliente))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody] Cliente cliente)
        {
            if (cliente == null) return BadRequest();
            return Ok(_clienteBusiness.Update(cliente));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Delete(long id)
        {
            _clienteBusiness.DeleteById(id);
            return NoContent();
        }
    }
}