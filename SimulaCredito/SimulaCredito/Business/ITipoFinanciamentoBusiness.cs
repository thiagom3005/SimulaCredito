using SimulaCredito.Data.VO;

namespace SimulaCredito.Business
{
    public interface ITipoFinanciamentoBusiness
    {
        TipoFinanciamentoVO Create(TipoFinanciamentoVO tipoFinanciamento);
        TipoFinanciamentoVO FindById(long id);
        List<TipoFinanciamentoVO> FindAll();
        TipoFinanciamentoVO Update(TipoFinanciamentoVO tipoFinanciamento);
        void DeleteById(long id);
    }
}
