using SimulaCredito.Data.VO;
using SimulaCredito.Hypermedia.Utils;

namespace SimulaCredito.Business
{
    public interface IClienteBusiness
    {
        ClienteVO Create(ClienteVO cliente);
        ClienteVO FindById(long id);
        List<ClienteVO> FindByName(string name);
        List<ClienteVO> FindAll();
        PagedSearchVO<ClienteVO> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page);
        ClienteVO Update(ClienteVO cliente);
        ClienteVO ChangeAtivo(long id);
        void DeleteById(long id);
    }
}
