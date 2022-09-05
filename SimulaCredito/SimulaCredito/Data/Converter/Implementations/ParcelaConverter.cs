using SimulaCredito.Data.VO;
using SimulaCredito.Models;

namespace SimulaCredito.Data.Converter.Implementations
{
    public class ParcelaConverter : IParser<ParcelaVO, Parcela>, IParser<Parcela, ParcelaVO>
    {
        public Parcela Parse(ParcelaVO origin)
        {
            if (origin == null) return null;

            return new Parcela
            {
                Id = origin.Id,
                DataPagamento = origin.DataPagamento,
                DataVencimento = origin.DataVencimento,
                financiamento = origin.financiamento,
                FinanciamentoId = origin.FinanciamentoId,
                NumeroParcela = origin.NumeroParcela,
                Valor=origin.Valor
            };
        }

        public List<Parcela> Parse(List<ParcelaVO> origin)
        {
            if (origin == null) return null;

            return origin.Select(item => Parse(item)).ToList();
        }

        public ParcelaVO Parse(Parcela origin)
        {
            if (origin == null) return null;

            return new ParcelaVO
            {
                Id = origin.Id,
                DataPagamento = origin.DataPagamento,
                DataVencimento = origin.DataVencimento,
                financiamento = origin.financiamento,
                FinanciamentoId = origin.FinanciamentoId,
                NumeroParcela = origin.NumeroParcela,
                Valor = origin.Valor
            };
        }

        public List<ParcelaVO> Parse(List<Parcela> origin)
        {
            if (origin == null) return null;

            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
