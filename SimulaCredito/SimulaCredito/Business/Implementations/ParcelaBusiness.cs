using SimulaCredito.Data.Converter.Implementations;
using SimulaCredito.Data.VO;
using SimulaCredito.Models;
using SimulaCredito.Repository;

namespace SimulaCredito.Business.Implementations
{
    public class ParcelaBusiness : IParcelaBusiness
    {
        private readonly IRepository<Parcela> _repository;
        private readonly ParcelaConverter _converter;

        public ParcelaBusiness(IRepository<Parcela> repository)
        {
            _repository = repository;
            _converter = new ParcelaConverter();
        }

        public List<ParcelaVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        public ParcelaVO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        public ParcelaVO Create(ParcelaVO parcela)
        {
            var parcelaEntity = _converter.Parse(parcela);
            parcelaEntity = _repository.Create(parcelaEntity);
            return _converter.Parse(parcelaEntity);
        }

        public ParcelaVO Update(ParcelaVO parcela)
        {
            var parcelaEntity = _converter.Parse(parcela);
            parcelaEntity = _repository.Update(parcelaEntity);
            return _converter.Parse(parcelaEntity);
        }

        public void DeleteById(long id)
        {
            _repository.DeleteById(id);
        }
    }
}
