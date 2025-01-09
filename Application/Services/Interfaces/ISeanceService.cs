using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface ISeanceService
    {
        Task<IEnumerable<SeanceDTO>> GetAllSeancesAsync();
        Task<SeanceDTO> GetSeanceByIdAsync(int id);
        Task AddSeanceAsync(SeanceDTO seanceDto);
        Task UpdateSeanceAsync(SeanceDTO seanceDto);
        Task DeleteSeanceAsync(int id);
    }
}
