using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IMatiereService
    {
        Task<IEnumerable<MatiereDTO>> GetAllMatieresAsync();
        Task<MatiereDTO> GetMatiereByIdAsync(int id);
        Task AddMatiereAsync(MatiereDTO matiereDto);
        Task UpdateMatiereAsync(MatiereDTO matiereDto);
        Task DeleteMatiereAsync(int id);
    }
}
