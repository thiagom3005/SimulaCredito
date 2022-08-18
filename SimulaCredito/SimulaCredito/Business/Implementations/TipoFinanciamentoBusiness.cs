using SimulaCredito.Models;
using SimulaCredito.Models.Context;
using SimulaCredito.Repository;

namespace SimulaCredito.Business.Implementations
{
    public class TipoFinanciamentoBusiness : ITipoFinanciamentoBusiness
    {
        private IRepository<TipoFinanciamento> _repository;

        public TipoFinanciamentoBusiness(IRepository<TipoFinanciamento> repository)
        {
            _repository = repository;
        }

        public List<TipoFinanciamento> FindAll()
        {
            return _repository.FindAll();
        }

        public TipoFinanciamento FindById(long id)
        {
            return _repository.FindById(id);

        }

        public TipoFinanciamento Create(TipoFinanciamento tipoFinanciamento)
        {
            return _repository.Create(tipoFinanciamento);
        }

        public TipoFinanciamento Update(TipoFinanciamento tipoFinanciamento)
        {
            return _repository.Update(tipoFinanciamento);
        }

        public void DeleteById(long id)
        {
            _repository.DeleteById(id);
        }
    }
}
