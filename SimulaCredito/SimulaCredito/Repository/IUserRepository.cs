﻿using SimulaCredito.Data.VO;
using SimulaCredito.Models;

namespace SimulaCredito.Repository
{
    public interface IUserRepository
    {
        User ValidateCredentials(UserVO user);
        User ValidateCredentials(string userName);
        bool RevokeToken(string userName);
        User RefreshUserInfo(User user);
    }
}
