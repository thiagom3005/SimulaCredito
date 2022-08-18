using SimulaCredito.Models;
using SimulaCredito.Repository;

namespace SimulaCredito.Business.Implementations
{
    public class ParcelaBusiness : IParcelaBusiness
    {
        private readonly IRepository<Parcela> _repository;

        public ParcelaBusiness(IRepository<Parcela> repository)
        {
            _repository = repository;
        }

        public List<Parcela> FindAll()
        {
            return _repository.FindAll();
        }

        public Parcela FindById(long id)
        {
            return _repository.FindById(id);
        }

        public Parcela Create(Parcela parcela)
        {
            return _repository.Create(parcela);
        }

        public Parcela Update(Parcela parcela)
        {
            return _repository.Update(parcela);
        }

        public void DeleteById(long id)
        {
            _repository.DeleteById(id);
        }
    }
}
