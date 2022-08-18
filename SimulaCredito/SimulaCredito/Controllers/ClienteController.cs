using Microsoft.AspNetCore.Mvc;
using SimulaCredito.Models;
using SimulaCredito.Business;

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
        public IActionResult Get()
        {
            return Ok(_clienteBusiness.FindAll());
        }

        [HttpGet("´{id}")]
        public IActionResult Get(long id )
        {
            var cliente = _clienteBusiness.FindById(id);
            if (cliente == null) return NotFound();
            return Ok(cliente);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Cliente cliente)
        {
            if (cliente == null) return BadRequest();
            return Ok(_clienteBusiness.Create(cliente));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Cliente cliente)
        {
            if (cliente == null) return BadRequest();
            return Ok(_clienteBusiness.Update(cliente));
        }

        [HttpDelete("{cpf}")]
        public IActionResult Delete(long id)
        {
            _clienteBusiness.DeleteById(id);
            return NoContent();
        }
    }
}