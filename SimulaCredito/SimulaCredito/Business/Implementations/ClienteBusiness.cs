using SimulaCredito.Models;
using SimulaCredito.Repository;

namespace SimulaCredito.Business.Implementations
{
    public class ClienteBusiness : IClienteBusiness
    {
        private readonly IRepository<Cliente> _repository;
        private readonly IClienteRepository _clienteRepository;

        public ClienteBusiness(IRepository<Cliente> repository, IClienteRepository clienteRepository)
        {
            _repository = repository;
            _clienteRepository = clienteRepository;
        }

        public List<Cliente> FindAll()
        {
            return _repository.FindAll();
        }

        public Cliente FindById(long id)
        {
            return _repository.FindById(id);
        }

        public Cliente Create(Cliente cliente)
        {
            var clienteCadastrado = _clienteRepository.FindByCPF(cliente.CPF);
            if (clienteCadastrado != null)
                throw new Exception("CPF já cadastrado");

            return _repository.Create(cliente);
        }

        public Cliente Update(Cliente cliente)
        {
            return _repository.Update(cliente);
        }

        public void DeleteById(long id)
        {
            _repository.DeleteById(id);
        }
    }
}
