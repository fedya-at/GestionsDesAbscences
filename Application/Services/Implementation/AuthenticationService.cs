using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Implementation
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthenticationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<string> AuthenticateAsync(string username, string password)
        {
            var users = await _unitOfWork.Utilisateurs.GetAllAsync();
            var user = users.FirstOrDefault(u => u.NomUtilisateur == username && u.MotDePasse == password);

            if (user == null)
                throw new UnauthorizedAccessException("Invalid username or password");

            // Simulate JWT token generation
            return $"GeneratedTokenFor:{username}";
        }

        public async Task<bool> RegisterAsync(string username, string password, string role)
        {
            var user = new Utilisateur
            {
                NomUtilisateur = username,
                MotDePasse = password,
                Role = role
            };

            await _unitOfWork.Utilisateurs.AddAsync(user);
            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public async Task<bool> ChangePasswordAsync(int userId, string newPassword)
        {
            var user = await _unitOfWork.Utilisateurs.GetByIdAsync(userId);
            if (user == null) throw new KeyNotFoundException("User not found");

            user.MotDePasse = newPassword;
            _unitOfWork.Utilisateurs.Update(user);
            return await _unitOfWork.SaveChangesAsync() > 0;
        }
    }

}
