using SimulaCredito.Data.VO;
using SimulaCredito.Models;
using SimulaCredito.Models.Context;
using System.Security.Cryptography;
using System.Text;

namespace SimulaCredito.Repository.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly SqlContext _context;

        public UserRepository(SqlContext context)
        {
            _context = context;
        }

        public User ValidateCredentials(UserVO user)
        {
            if (user == null) return null;

            var pass = ComputeHash(user.Password, new SHA256CryptoServiceProvider());
            return _context.User.FirstOrDefault(u => (u.UserName == user.UserName) && (u.Password == pass));
        }

        public User ValidateCredentials(string userName)
        {
            return _context.User.SingleOrDefault(u => u.UserName == userName);
        }

        public bool RevokeToken(string userName)
        {
            var user = _context.User.SingleOrDefault(u => u.UserName == userName);
            if (user is null) return false;
            user.RefreshToken = null;
            _context.SaveChanges();
            return true;
        }

        public User RefreshUserInfo(User user)
        {
            if (!_context.User.Any(u => u.Id.Equals(user.Id))) return null;

            var result = _context.User.SingleOrDefault(t => t.Id.Equals(user.Id));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(user);
                    _context.SaveChanges();
                    return result;
                }
                catch (Exception)
                {

                    throw;
                }
            }

            return result;
        }

        private object ComputeHash(string password, SHA256 algorithm)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(password);
            byte[] outputBytes = algorithm.ComputeHash(inputBytes);
            return BitConverter.ToString(outputBytes);
        }
    }
}
