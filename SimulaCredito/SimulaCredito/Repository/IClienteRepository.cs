using SimulaCredito.Models;

namespace SimulaCredito.Repository
{
    public interface IClienteRepository
    {
        Cliente FindByCPF(string cpf);
    }
}
