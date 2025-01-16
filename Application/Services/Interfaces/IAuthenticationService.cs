using Core.Entities;

namespace Application.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<Utilisateur> LoginAsync(string username, string password); 
        Task<bool> RegisterAsync(string username, string password, string role);
        Task<bool> ChangePasswordAsync(int userId, string newPassword);

    }
}
