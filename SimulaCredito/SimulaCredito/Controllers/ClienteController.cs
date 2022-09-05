using Microsoft.AspNetCore.Mvc;
using SimulaCredito.Business;
using SimulaCredito.Hypermedia.Filters;
using SimulaCredito.Data.VO;
using Microsoft.AspNetCore.Authorization;

namespace SimulaCredito.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Authorize("Bearer")]
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

        [HttpGet("{sortDirection}/{pageSize}/{page}")]
        [ProducesResponseType((200), Type = typeof(List<ClienteVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get([FromQuery] string? name, string sortDirection, int pageSize, int page)
        {
            return Ok(_clienteBusiness.FindWithPagedSearch(name, sortDirection, pageSize, page));
        }

        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(ClienteVO))]
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

        [HttpGet("findClienteByName")]
        [ProducesResponseType((200), Type = typeof(ClienteVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get([FromQuery] string name)
        {
            var clientes = _clienteBusiness.FindByName(name);
            if (clientes == null) return NotFound();
            return Ok(clientes);
        }

        [HttpPost]
        [ProducesResponseType((200), Type = typeof(ClienteVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody] ClienteVO cliente)
        {
            if (cliente == null) return BadRequest();
            return Ok(_clienteBusiness.Create(cliente));
        }

        [HttpPut]
        [ProducesResponseType((200), Type = typeof(ClienteVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody] ClienteVO cliente)
        {
            if (cliente == null) return BadRequest();
            return Ok(_clienteBusiness.Update(cliente));
        }

        [HttpPatch("{id}")]
        [ProducesResponseType((200), Type = typeof(ClienteVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Patch(long id)
        {
            var cliente = _clienteBusiness.ChangeAtivo(id);
            return Ok(cliente);
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