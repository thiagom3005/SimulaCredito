using Microsoft.AspNetCore.Mvc;
using SimulaCredito.Models;
using SimulaCredito.Business;
using SimulaCredito.Hypermedia.Filters;

namespace SimulaCredito.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class FinanciamentoController : ControllerBase
    {
        private readonly ILogger<FinanciamentoController> _logger;
        private IFinanciamentoBusiness _financiamentoBusiness;

        public FinanciamentoController(ILogger<FinanciamentoController> logger, IFinanciamentoBusiness financiamentoBusiness)
        {
            _logger = logger;
            _financiamentoBusiness = financiamentoBusiness;
        }

        [HttpGet]
        [ProducesResponseType((200), Type = typeof(List<Financiamento>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get()
        {
            return Ok(_financiamentoBusiness.FindAll());
        }

        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(Financiamento))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(long id )
        {
            var financiamento = _financiamentoBusiness.FindById(id);
            if (financiamento == null) return NotFound();
            return Ok(financiamento);
        }

        [HttpPost]
        [ProducesResponseType((200), Type = typeof(Financiamento))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody] Financiamento financiamento)
        {
            if (financiamento == null) return BadRequest();
            return Ok(_financiamentoBusiness.Create(financiamento));
        }

        [HttpPut]
        [ProducesResponseType((200), Type = typeof(Financiamento))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody] Financiamento financiamento)
        {
            if (financiamento == null) return BadRequest();
            return Ok(_financiamentoBusiness.Update(financiamento));
        }

        [HttpDelete("{cpf}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Delete(long id)
        {
            _financiamentoBusiness.DeleteById(id);
            return NoContent();
        }
    }
}