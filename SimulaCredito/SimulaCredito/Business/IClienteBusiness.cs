using SimulaCredito.Data.VO;

namespace SimulaCredito.Business
{
    public interface IClienteBusiness
    {
        ClienteVO Create(ClienteVO cliente);
        ClienteVO FindById(long id);
        List<ClienteVO> FindByName(string name);
        List<ClienteVO> FindAll();
        ClienteVO Update(ClienteVO cliente);
        ClienteVO ChangeAtivo(long id);
        void DeleteById(long id);
    }
}
