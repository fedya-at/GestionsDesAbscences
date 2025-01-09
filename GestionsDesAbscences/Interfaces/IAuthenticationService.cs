using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IAuthenticationService
    {
        Task<string> AuthenticateAsync(string username, string password);
        Task<bool> RegisterAsync(string username, string password, string role);
        Task<bool> ChangePasswordAsync(int userId, string newPassword);
    }

}
