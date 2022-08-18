using SimulaCredito.Models;

namespace SimulaCredito.Business
{
    public interface IFinanciamentoBusiness
    {
        Financiamento Create(Financiamento financiamento);
        Financiamento FindById(long id);
        List<Financiamento> FindAll();
        Financiamento Update(Financiamento financiamento);
        void DeleteById(long id);
    }
}
