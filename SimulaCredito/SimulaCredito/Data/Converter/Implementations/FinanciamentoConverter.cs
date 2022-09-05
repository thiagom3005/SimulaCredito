using SimulaCredito.Data.VO;
using SimulaCredito.Models;

namespace SimulaCredito.Data.Converter.Implementations
{
    public class FinanciamentoConverter : IParser<FinanciamentoVO, Financiamento>, IParser<Financiamento, FinanciamentoVO>
    {
        public Financiamento Parse(FinanciamentoVO origin)
        {
            if (origin == null) return null;

            return new Financiamento
            {
                Id = origin.Id,
                Cliente = origin.Cliente,
                ClienteId = origin.ClienteId,
                parcelas=origin.parcelas,
                TipoFinanciamento=origin.TipoFinanciamento,
                TipoFinanciamentoId=origin.TipoFinanciamentoId,
                TotalJuros=origin.TotalJuros,
                UltimoVencimento=origin.UltimoVencimento,
                ValorTotal=origin.ValorTotal,
                ValorTotalJuros=origin.ValorTotalJuros
            };
        }

        public List<Financiamento> Parse(List<FinanciamentoVO> origin)
        {
            if (origin == null) return null;

            return origin.Select(item => Parse(item)).ToList();
        }

        public FinanciamentoVO Parse(Financiamento origin)
        {
            if (origin == null) return null;

            return new FinanciamentoVO
            {
                Id = origin.Id,
                Cliente = origin.Cliente,
                ClienteId = origin.ClienteId,
                parcelas = origin.parcelas,
                TipoFinanciamento = origin.TipoFinanciamento,
                TipoFinanciamentoId = origin.TipoFinanciamentoId,
                TotalJuros = origin.TotalJuros,
                UltimoVencimento = origin.UltimoVencimento,
                ValorTotal = origin.ValorTotal,
                ValorTotalJuros = origin.ValorTotalJuros
            };
        }

        public List<FinanciamentoVO> Parse(List<Financiamento> origin)
        {
            if (origin == null) return null;

            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
