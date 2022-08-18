using SimulaCredito.Models;

namespace SimulaCredito.Business
{
    public interface IParcelaBusiness
    {
        Parcela Create(Parcela parcela);
        Parcela FindById(long id);
        List<Parcela> FindAll();
        Parcela Update(Parcela parcela);
        void DeleteById(long id);
    }
}
