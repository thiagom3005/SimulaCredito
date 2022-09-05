using SimulaCredito.Models;
using SimulaCredito.Models.Context;
using SimulaCredito.Repository.Generic;

namespace SimulaCredito.Repository.Implementations
{
    public class ClienteRepository : GenericRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(SqlContext context) : base(context) { }

        public Cliente FindByCPF(string cpf)
        {
            return _context.Cliente.SingleOrDefault(c => c.CPF == cpf);
        }

        public List<Cliente> FindByName(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
                return _context.Cliente.Where(c => c.Nome.Contains(name)).ToList();
            else
                return null;
        }

        public Cliente ChangeAtivo(long id)
        {
            if (!_context.Cliente.Any(c => c.Id.Equals(id))) return null;
            var cliente = _context.Cliente.FirstOrDefault(c => c.Id.Equals(id));
            if (cliente != null)
            {
                var ativo = cliente.Ativo;
                cliente.Ativo = !ativo;

                try
                {
                    _context.Entry(cliente).CurrentValues.SetValues(cliente);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return cliente;
        }
    }
}
