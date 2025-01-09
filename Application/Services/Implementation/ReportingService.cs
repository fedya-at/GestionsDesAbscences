using Application.DTOs;
using Application.Services.Interfaces;
using Core.Interfaces;
using System.Text;

namespace Application.Services.Implementation
{
    public class ReportingService : IReportingService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReportingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<AbsenceSummaryDto>> GetAbsenceSummaryByClassAsync(int classId)
        {
            var fiches = await _unitOfWork.FicheAbsences.GetAllAsync();
            fiches = fiches.Where(f => f.CodeClasse == classId);

            var summary = fiches
                .GroupBy(f => f.CodeClasse)
                .Select(group => new AbsenceSummaryDto
                {
                    CodeClasse = group.Key,
                    NomClasse = group.FirstOrDefault()?.Classe.NomClasse,
                    TotalAbsences = group.Sum(f => f.LigneFicheAbsences.Count)
                });

            return summary;
        }

        public async Task<IEnumerable<AbsenceSummaryDto>> GetAbsenceSummaryByStudentAsync(int studentId)
        {
            var ligneFiches = await _unitOfWork.LigneFicheAbsences.GetAllAsync();
            ligneFiches = ligneFiches.Where(l => l.CodeEtudiant == studentId);

            var summary = ligneFiches
                .GroupBy(l => l.FicheAbsence.CodeClasse)
                .Select(group => new AbsenceSummaryDto
                {
                    CodeClasse = group.Key,
                    NomClasse = group.FirstOrDefault()?.FicheAbsence.Classe.NomClasse,
                    TotalAbsences = group.Count()
                });

            return summary;
        }

        public async Task<byte[]> GenerateDetailedAbsenceReportAsync(int ficheAbsenceId)
        {
            var fiche = await _unitOfWork.FicheAbsences.GetByIdAsync(ficheAbsenceId);
            if (fiche == null) throw new KeyNotFoundException("Fiche Absence not found");

            var reportBuilder = new StringBuilder();
            reportBuilder.AppendLine($"Absence Report for {fiche.Classe.NomClasse}");
            reportBuilder.AppendLine($"Date: {fiche.DateJour:yyyy-MM-dd}");
            reportBuilder.AppendLine("Absence Details:");

            foreach (var ligne in fiche.LigneFicheAbsences)
            {
                reportBuilder.AppendLine($"- {ligne.Etudiant.Nom} {ligne.Etudiant.Prenom}");
            }

            // Convert the report into a byte array (simulate PDF generation)
            return Encoding.UTF8.GetBytes(reportBuilder.ToString());
        }
    }
}
