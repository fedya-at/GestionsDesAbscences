using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<string> LoginAsync(string username, string password);
        Task RegisterAsync(string username, string password, string role);
        Task<bool> ChangePasswordAsync(int userId, string newPassword);
    }

}
