using DMGM.Core.Domain.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DMGM.Services.Authentication
{
    public interface IAuthRepository
    {
        Task<User> Register(User user, string password);
        Task<User> Login(string username, string password);
        Task<bool> UserExists(string username);
    }
}
