using SimulaCredito.Data.VO;

namespace SimulaCredito.Business
{
    public interface IFinanciamentoBusiness
    {
        FinanciamentoVO Create(FinanciamentoVO financiamento);
        FinanciamentoVO FindById(long id);
        List<FinanciamentoVO> FindAll();
        FinanciamentoVO Update(FinanciamentoVO financiamento);
        void DeleteById(long id);
    }
}
