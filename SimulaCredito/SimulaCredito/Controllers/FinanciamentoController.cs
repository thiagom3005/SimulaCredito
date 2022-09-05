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
        [ProducesResponseType((200), Type = typeof(List<FinanciamentoVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get()
        {
            return Ok(_financiamentoBusiness.FindAll());
        }

        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(FinanciamentoVO))]
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
        [ProducesResponseType((200), Type = typeof(FinanciamentoVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody] FinanciamentoVO financiamento)
        {
            if (financiamento == null) return BadRequest();
            return Ok(_financiamentoBusiness.Create(financiamento));
        }

        [HttpPut]
        [ProducesResponseType((200), Type = typeof(FinanciamentoVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody] FinanciamentoVO financiamento)
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