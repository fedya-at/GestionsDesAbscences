using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IReportingService
    {
        Task<IEnumerable<AbsenceSummaryDto>> GetAbsenceSummaryByClassAsync(int classId);
        Task<IEnumerable<AbsenceSummaryDto>> GetAbsenceSummaryByStudentAsync(int studentId);
        Task<byte[]> GenerateDetailedAbsenceReportAsync(int ficheAbsenceId);
    }

}
