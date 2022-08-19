using SimulaCredito.Models;
using SimulaCredito.Repository;

namespace SimulaCredito.Business.Implementations
{
    public class FinanciamentoBusiness : IFinanciamentoBusiness
    {
        private readonly IRepository<Financiamento> _repository;
        private readonly IRepository<TipoFinanciamento> _repositoryTipoFinanciamento;
        private readonly IRepository<Cliente> _repositoryCliente;

        public FinanciamentoBusiness(IRepository<Financiamento> repository, IRepository<TipoFinanciamento> repositoryTipoFinanciamento, IRepository<Cliente> repositoryCliente)
        {
            _repository = repository;
            _repositoryTipoFinanciamento = repositoryTipoFinanciamento;
            _repositoryCliente = repositoryCliente;
        }

        public List<Financiamento> FindAll()
        {
            return _repository.FindAll();
        }

        public Financiamento FindById(long id)
        {
            return _repository.FindById(id);
        }

        public Financiamento Create(Financiamento financiamento)
        {
            try
            {
                ValidaFinanciamento(financiamento);
                var qtdParcelas = CalculaQtdParcelas(financiamento);
                financiamento.parcelas = CriaParcelas(financiamento, qtdParcelas);

                return _repository.Create(financiamento);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Financiamento Update(Financiamento financiamento)
        {
            try
            {
                ValidaFinanciamento(financiamento);

                return _repository.Update(financiamento);
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

        private void ValidaFinanciamento(Financiamento financiamento)
        {
            var tipoFinanciamento = _repositoryTipoFinanciamento.FindById(financiamento.TipoFinanciamentoId);
            if (tipoFinanciamento is null)
                throw new Exception("Tipo de financiamento inexistente");

            var cliente = _repositoryCliente.FindById(financiamento.ClienteId);
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

        private int CalculaQtdParcelas(Financiamento financiamento)
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

        private ICollection<Parcela> CriaParcelas(Financiamento financiamento, int qtdParcelas)
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
