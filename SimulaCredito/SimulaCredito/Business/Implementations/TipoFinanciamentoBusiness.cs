using SimulaCredito.Data.Converter.Implementations;
using SimulaCredito.Data.VO;
using SimulaCredito.Models;
using SimulaCredito.Repository;

namespace SimulaCredito.Business.Implementations
{
    public class TipoFinanciamentoBusiness : ITipoFinanciamentoBusiness
    {
        private readonly IRepository<TipoFinanciamento> _repository;
        private readonly TipoFinanciamentoConverter _converter;

        public TipoFinanciamentoBusiness(IRepository<TipoFinanciamento> repository)
        {
            _repository = repository;
            _converter = new TipoFinanciamentoConverter();
        }

        public List<TipoFinanciamentoVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        public TipoFinanciamentoVO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));

        }

        public TipoFinanciamentoVO Create(TipoFinanciamentoVO tipoFinanciamento)
        {
            var tipoFinanciamentoEntity = _converter.Parse(tipoFinanciamento);
            tipoFinanciamentoEntity = _repository.Create(tipoFinanciamentoEntity);
            return _converter.Parse(tipoFinanciamentoEntity);
        }

        public TipoFinanciamentoVO Update(TipoFinanciamentoVO tipoFinanciamento)
        {
            var tipoFinanciamentoEntity = _converter.Parse(tipoFinanciamento);
            tipoFinanciamentoEntity = _repository.Update(tipoFinanciamentoEntity);
            return _converter.Parse(tipoFinanciamentoEntity);
        }

        public void DeleteById(long id)
        {
            _repository.DeleteById(id);
        }
    }
}
