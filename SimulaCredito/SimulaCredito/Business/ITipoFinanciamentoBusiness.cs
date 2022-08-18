using SimulaCredito.Models;

namespace SimulaCredito.Business
{
    public interface ITipoFinanciamentoBusiness
    {
        TipoFinanciamento Create(TipoFinanciamento tipoFinanciamento);
        TipoFinanciamento FindById(long id);
        List<TipoFinanciamento> FindAll();
        TipoFinanciamento Update(TipoFinanciamento tipoFinanciamento);
        void DeleteById(long id);
    }
}
