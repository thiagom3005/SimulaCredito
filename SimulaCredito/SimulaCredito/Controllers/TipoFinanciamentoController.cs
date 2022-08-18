using Microsoft.AspNetCore.Mvc;
using SimulaCredito.Models;
using SimulaCredito.Business;
using SimulaCredito.Hypermedia.Filters;

namespace SimulaCredito.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class TipoFinanciamentoController : ControllerBase
    {
        private readonly ILogger<TipoFinanciamentoController> _logger;
        private ITipoFinanciamentoBusiness _tipoFinanciamentoBusiness;

        public TipoFinanciamentoController(ILogger<TipoFinanciamentoController> logger, ITipoFinanciamentoBusiness tipoFinanciamentoBusiness)
        {
            _logger = logger;
            _tipoFinanciamentoBusiness = tipoFinanciamentoBusiness;
        }

        [HttpGet]
        [ProducesResponseType((200), Type = typeof(List<TipoFinanciamento>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get()
        {
            return Ok(_tipoFinanciamentoBusiness.FindAll());
        }

        [HttpGet("{id}")]
        [ProducesResponseType((200),Type = typeof(TipoFinanciamento))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(long id )
        {
            var tipoFinanciamento = _tipoFinanciamentoBusiness.FindById(id);
            if (tipoFinanciamento == null) return NotFound();
            return Ok(tipoFinanciamento);
        }

        [HttpPost]
        [ProducesResponseType((200), Type = typeof(TipoFinanciamento))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody] TipoFinanciamento tipoFinanciamento)
        {
            if (tipoFinanciamento == null) return BadRequest();
            return Ok(_tipoFinanciamentoBusiness.Create(tipoFinanciamento));
        }

        [HttpPut]
        [ProducesResponseType((200), Type = typeof(TipoFinanciamento))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody] TipoFinanciamento tipoFinanciamento)
        {
            if (tipoFinanciamento == null) return BadRequest();
            return Ok(_tipoFinanciamentoBusiness.Update(tipoFinanciamento));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Delete(long id)
        {
            _tipoFinanciamentoBusiness.DeleteById(id);
            return NoContent();
        }
    }
}