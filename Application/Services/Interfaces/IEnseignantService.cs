using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IEnseignantService
    {
        Task<IEnumerable<EnseignantDTO>> GetAllEnseignantsAsync();
        Task<EnseignantDTO> GetEnseignantByIdAsync(int id);
        Task AddEnseignantAsync(EnseignantDTO enseignantDto);
        Task UpdateEnseignantAsync(EnseignantDTO enseignantDto);
        Task DeleteEnseignantAsync(int id);
    }
}
