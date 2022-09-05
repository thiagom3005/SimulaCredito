using SimulaCredito.Models;

namespace SimulaCredito.Repository
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Cliente FindByCPF(string cpf);
        List<Cliente> FindByName(string name);
        Cliente ChangeAtivo(long id);
    }
}
