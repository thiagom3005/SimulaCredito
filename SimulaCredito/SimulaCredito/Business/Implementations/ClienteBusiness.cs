using SimulaCredito.Data.Converter.Implementations;
using SimulaCredito.Data.VO;
using SimulaCredito.Models;
using SimulaCredito.Repository;

namespace SimulaCredito.Business.Implementations
{
    public class ClienteBusiness : IClienteBusiness
    {
        private readonly IClienteRepository _repository;
        private readonly ClienteConverter _converter;

        public ClienteBusiness(IClienteRepository repository)
        {
            _converter = new ClienteConverter();
            _repository = repository;
        }

        public List<ClienteVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        public ClienteVO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        public List<ClienteVO> FindByName(string name)
        {
            return _converter.Parse(_repository.FindByName(name));
        }

        public ClienteVO Create(ClienteVO cliente)
        {
            var clienteCadastrado = _repository.FindByCPF(cliente.CPF);
            if (clienteCadastrado != null)
                throw new Exception("CPF já cadastrado");

            var clienteEntity = _converter.Parse(cliente);
            clienteEntity = _repository.Create(clienteEntity);
            return _converter.Parse(clienteEntity);
        }

        public ClienteVO Update(ClienteVO cliente)
        {
            var clienteEntity = _converter.Parse(cliente);
            clienteEntity = _repository.Update(clienteEntity);
            return _converter.Parse(clienteEntity);
        }

        public ClienteVO ChangeAtivo(long id)
        {
            var clienteEntity = _repository.ChangeAtivo(id);
            return _converter.Parse(clienteEntity);
        }

        public void DeleteById(long id)
        {
            _repository.DeleteById(id);
        }
    }
}
