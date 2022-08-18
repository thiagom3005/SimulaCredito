using Microsoft.AspNetCore.Mvc;
using SimulaCredito.Models;
using SimulaCredito.Business;

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
        public IActionResult Get()
        {
            return Ok(_financiamentoBusiness.FindAll());
        }

        [HttpGet("´{id}")]
        public IActionResult Get(long id )
        {
            var financiamento = _financiamentoBusiness.FindById(id);
            if (financiamento == null) return NotFound();
            return Ok(financiamento);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Financiamento financiamento)
        {
            if (financiamento == null) return BadRequest();
            return Ok(_financiamentoBusiness.Create(financiamento));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Financiamento financiamento)
        {
            if (financiamento == null) return BadRequest();
            return Ok(_financiamentoBusiness.Update(financiamento));
        }

        [HttpDelete("{cpf}")]
        public IActionResult Delete(long id)
        {
            _financiamentoBusiness.DeleteById(id);
            return NoContent();
        }
    }
}