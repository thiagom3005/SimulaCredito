using SimulaCredito.Data.VO;

namespace SimulaCredito.Business
{
    public interface IParcelaBusiness
    {
        ParcelaVO Create(ParcelaVO parcela);
        ParcelaVO FindById(long id);
        List<ParcelaVO> FindAll();
        ParcelaVO Update(ParcelaVO parcela);
        void DeleteById(long id);
    }
}
