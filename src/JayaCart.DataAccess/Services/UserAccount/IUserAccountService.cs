﻿using JayaCart.DataAccess.Models;
using System.Threading.Tasks;

namespace JayaCart.DataAccess.Services
{
    public interface IUserAccountService
    {
        UserAccount GetLocalAccount();

        Task<UserAccount> SignIn(string phone, string password);

        Task<UserAccount> Create(UserAccount account);

        Task SignOut();
    }
}
