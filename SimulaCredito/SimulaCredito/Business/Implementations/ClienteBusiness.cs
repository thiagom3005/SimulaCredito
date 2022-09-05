using SimulaCredito.Data.Converter.Implementations;
using SimulaCredito.Data.VO;
using SimulaCredito.Hypermedia.Utils;
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

        public PagedSearchVO<ClienteVO> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page)
        {   
            var sort = (!string.IsNullOrWhiteSpace(sortDirection)) && !sortDirection.Equals("desc") ? "asc" : "desc";
            var size = (pageSize < 1) ? 10 : pageSize;
            var offset = page > 0 ? (page - 1) * size : 0;

            string query = @"SELECT * FROM Cliente WHERE 1 = 1 ";
            if (!string.IsNullOrWhiteSpace(name))
                query = query + $" AND Nome LIKE '%{name}%'";
            query = query + $" ORDER BY Nome {sort} OFFSET {offset} ROWS FETCH NEXT {size} ROWS ONLY ";

            string countQuery = @"SELECT count(*) FROM Cliente WHERE 1 = 1 "; 
            if (!string.IsNullOrWhiteSpace(name))
                countQuery = countQuery + $" AND Nome LIKE '%{name}%'";

            var clientes = _repository.FindWithPagedSearch(query);
            int totalResults = _repository.GetCount(countQuery);

            return new PagedSearchVO<ClienteVO>
            {
                CurrentPage = page,
                List = _converter.Parse(clientes),
                PageSize = size,
                SortDirections = sort,
                TotalResults = totalResults
            };
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
