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
        [ProducesResponseType((200), Type = typeof(List<TipoFinanciamentoVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get()
        {
            return Ok(_tipoFinanciamentoBusiness.FindAll());
        }

        [HttpGet("{id}")]
        [ProducesResponseType((200),Type = typeof(TipoFinanciamentoVO))]
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
        [ProducesResponseType((200), Type = typeof(TipoFinanciamentoVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody] TipoFinanciamentoVO tipoFinanciamento)
        {
            if (tipoFinanciamento == null) return BadRequest();
            return Ok(_tipoFinanciamentoBusiness.Create(tipoFinanciamento));
        }

        [HttpPut]
        [ProducesResponseType((200), Type = typeof(TipoFinanciamentoVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody] TipoFinanciamentoVO tipoFinanciamento)
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