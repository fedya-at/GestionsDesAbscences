using Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IEtudiantService
    {
        Task<IEnumerable<EtudiantDTO>> GetAllEtudiantsAsync();
        Task<EtudiantDTO> GetEtudiantByIdAsync(int id);
        Task<IEnumerable<EtudiantDTO>> GetEtudiantsByClasseAsync(int classeId);
        Task AddEtudiantAsync(EtudiantDTO etudiantDto);
        Task UpdateEtudiantAsync(EtudiantDTO etudiantDto);
        Task DeleteEtudiantAsync(int id);
    }
}
