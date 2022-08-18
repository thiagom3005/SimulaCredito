using SimulaCredito.Models;

namespace SimulaCredito.Business
{
    public interface IClienteBusiness
    {
        Cliente Create(Cliente cliente);
        Cliente FindById(long id);
        List<Cliente> FindAll();
        Cliente Update(Cliente cliente);
        void DeleteById(long id);
    }
}
