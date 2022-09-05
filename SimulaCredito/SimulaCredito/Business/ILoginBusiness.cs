using SimulaCredito.Data.VO;

namespace SimulaCredito.Business
{
    public interface ILoginBusiness
    {
        TokenVO ValidateCredentials(UserVO user);
        TokenVO ValidateCredentials(TokenVO token);
        TokenVO RevokeToken(string userName);
    }
}
