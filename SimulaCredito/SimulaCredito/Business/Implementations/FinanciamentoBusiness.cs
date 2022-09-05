using SimulaCredito.Data.Converter.Implementations;
using SimulaCredito.Data.VO;
using SimulaCredito.Models;
using SimulaCredito.Repository;

namespace SimulaCredito.Business.Implementations
{
    public class FinanciamentoBusiness : IFinanciamentoBusiness
    {
        private readonly IRepository<Financiamento> _repository;
        private readonly FinanciamentoConverter _converter;
        private readonly ITipoFinanciamentoBusiness _tipoFinanciamentoBusiness;
        private readonly IClienteBusiness _clienteBusiness;

        public FinanciamentoBusiness(IRepository<Financiamento> repository, ITipoFinanciamentoBusiness tipoFinanciamentoBusiness, IClienteBusiness clienteBusiness)
        {
            _repository = repository;
            _converter = new FinanciamentoConverter();
            _tipoFinanciamentoBusiness = tipoFinanciamentoBusiness;
            _clienteBusiness = clienteBusiness;
        }

        public List<FinanciamentoVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        public FinanciamentoVO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        public FinanciamentoVO Create(FinanciamentoVO financiamento)
        {
            try
            {
                ValidaFinanciamento(financiamento);
                var qtdParcelas = CalculaQtdParcelas(financiamento);
                financiamento.parcelas = CriaParcelas(financiamento, qtdParcelas);

                var financiamentoEntity = _converter.Parse(financiamento);
                financiamentoEntity = _repository.Create(financiamentoEntity);
                return _converter.Parse(financiamentoEntity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public FinanciamentoVO Update(FinanciamentoVO financiamento)
        {
            try
            {
                ValidaFinanciamento(financiamento);

                var financiamentoEntity = _converter.Parse(financiamento);
                financiamentoEntity = _repository.Update(financiamentoEntity);
                return _converter.Parse(financiamentoEntity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteById(long id)
        {
            _repository.DeleteById(id);
        }

        private void ValidaFinanciamento(FinanciamentoVO financiamento)
        {
            var tipoFinanciamento = _tipoFinanciamentoBusiness.FindById(financiamento.TipoFinanciamentoId);
            if (tipoFinanciamento is null)
                throw new Exception("Tipo de financiamento inexistente");

            var cliente = _clienteBusiness.FindById(financiamento.ClienteId);
            if (tipoFinanciamento is null)
                throw new Exception("Cliente inexistente");

            DateTime primeiroVencimento = DateTime.Now.AddDays(15);

            if (tipoFinanciamento.ValorMin > financiamento.ValorTotal)
                throw new Exception("Financiamento recusado! Financiamento abaixo do valor mínimo");

            if (tipoFinanciamento.ValorMax < financiamento.ValorTotal)
                throw new Exception("Financiamento recusado! Financiamento acima do valor máximo");

            if (primeiroVencimento > financiamento.UltimoVencimento)
                throw new Exception("Financiamento recusado! Data do último vencimento deve ser posterior a 15 dias a contar da data de hoje");

            var qtdParcelas = CalculaQtdParcelas(financiamento);

            financiamento.ValorTotalJuros = (((((double)tipoFinanciamento.Taxa / 100)) * financiamento.ValorTotal) * qtdParcelas) + financiamento.ValorTotal;
            financiamento.TotalJuros = financiamento.ValorTotalJuros - financiamento.ValorTotal;
        }

        private int CalculaQtdParcelas(FinanciamentoVO financiamento)
        {

            DateTime primeiroVencimento = DateTime.Now.AddDays(15);
            int qtdParcelas = 0;

            while (primeiroVencimento < financiamento.UltimoVencimento)
            {
                qtdParcelas++;
                primeiroVencimento = primeiroVencimento.AddMonths(1);
            }

            return qtdParcelas;
        }

        private ICollection<Parcela> CriaParcelas(FinanciamentoVO financiamento, int qtdParcelas)
        {
            var valorParcela = financiamento.ValorTotalJuros / qtdParcelas;
            DateTime primeiroVencimento = DateTime.Now.AddDays(15);
            var parcelas = new List<Parcela>();

            for (int i = 0; i < qtdParcelas; i++)
            {
                parcelas.Add(new Parcela
                {
                    NumeroParcela = i + 1,
                    DataPagamento = null,
                    DataVencimento = primeiroVencimento,
                    Valor = valorParcela
                });

                primeiroVencimento = primeiroVencimento.AddMonths(1);
            }

            return parcelas;
        }
    }
}
