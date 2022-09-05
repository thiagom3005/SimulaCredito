using SimulaCredito.Data.VO;
using SimulaCredito.Models;

namespace SimulaCredito.Data.Converter.Implementations
{
    public class TipoFinanciamentoConverter : IParser<TipoFinanciamentoVO, TipoFinanciamento>, IParser<TipoFinanciamento, TipoFinanciamentoVO>
    {
        public TipoFinanciamento Parse(TipoFinanciamentoVO origin)
        {
            if (origin == null) return null;

            return new TipoFinanciamento
            {
                Id = origin.Id,
                Nome = origin.Nome,
                Financiamentos = origin.Financiamentos,
                QtdMaxParcelas = origin.QtdMaxParcelas,
                QtdMinParcelas = origin.QtdMinParcelas,
                Taxa = origin.Taxa,
                ValorMax = origin.ValorMax,
                ValorMin = origin.ValorMin
            };
        }

        public List<TipoFinanciamento> Parse(List<TipoFinanciamentoVO> origin)
        {
            if (origin == null) return null;

            return origin.Select(item => Parse(item)).ToList();
        }

        public TipoFinanciamentoVO Parse(TipoFinanciamento origin)
        {
            if (origin == null) return null;

            return new TipoFinanciamentoVO
            {
                Id = origin.Id,
                Nome = origin.Nome,
                Financiamentos = origin.Financiamentos,
                QtdMaxParcelas = origin.QtdMaxParcelas,
                QtdMinParcelas = origin.QtdMinParcelas,
                Taxa = origin.Taxa,
                ValorMax = origin.ValorMax,
                ValorMin = origin.ValorMin
            };
        }

        public List<TipoFinanciamentoVO> Parse(List<TipoFinanciamento> origin)
        {
            if (origin == null) return null;

            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
