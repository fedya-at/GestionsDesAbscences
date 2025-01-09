using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IFicheAbsenceService
    {
        Task<IEnumerable<FicheAbsenceDTO>> GetAllFicheAbsencesAsync();
        Task<FicheAbsenceDTO> GetFicheAbsenceByIdAsync(int id);
        Task AddFicheAbsenceAsync(FicheAbsenceDTO ficheAbsenceDto);
        Task UpdateFicheAbsenceAsync(FicheAbsenceDTO ficheAbsenceDto);
        Task DeleteFicheAbsenceAsync(int id);
    }
}
