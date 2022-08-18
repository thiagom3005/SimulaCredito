using SimulaCredito.Models;
using SimulaCredito.Models.Context;

namespace SimulaCredito.Repository.Implementations
{
    public class ClienteRepository : IClienteRepository
    {
        private SqlContext _context;

        public ClienteRepository(SqlContext context)
        {
            _context = context;
        }

        public Cliente FindByCPF(string cpf)
        {
            return _context.Cliente.SingleOrDefault(c => c.CPF == cpf);
        }
    }
}
