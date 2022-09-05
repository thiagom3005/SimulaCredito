using SimulaCredito.Models;
using SimulaCredito.Models.Base;

namespace SimulaCredito.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T tipoFinanciamento);
        T FindById(long id);
        List<T> FindAll();
        T Update(T tipoFinanciamento);
        void DeleteById(long id);
        bool Exists(long id);
        List<T> FindWithPagedSearch(string query);
        int GetCount(string query);
    }
}
