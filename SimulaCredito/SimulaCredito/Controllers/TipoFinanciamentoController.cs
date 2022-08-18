using Microsoft.AspNetCore.Mvc;
using SimulaCredito.Models;
using SimulaCredito.Business;

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
        public IActionResult Get()
        {
            return Ok(_tipoFinanciamentoBusiness.FindAll());
        }

        [HttpGet("´{id}")]
        public IActionResult Get(long id )
        {
            var tipoFinanciamento = _tipoFinanciamentoBusiness.FindById(id);
            if (tipoFinanciamento == null) return NotFound();
            return Ok(tipoFinanciamento);
        }

        [HttpPost]
        public IActionResult Post([FromBody] TipoFinanciamento tipoFinanciamento)
        {
            if (tipoFinanciamento == null) return BadRequest();
            return Ok(_tipoFinanciamentoBusiness.Create(tipoFinanciamento));
        }

        [HttpPut]
        public IActionResult Put([FromBody] TipoFinanciamento tipoFinanciamento)
        {
            if (tipoFinanciamento == null) return BadRequest();
            return Ok(_tipoFinanciamentoBusiness.Update(tipoFinanciamento));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _tipoFinanciamentoBusiness.DeleteById(id);
            return NoContent();
        }
    }
}