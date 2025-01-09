using Application.DTOs;
using Application.Services.Interfaces;
using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Implementation
{
    public class FicheAbsenceService : IFicheAbsenceService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FicheAbsenceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<FicheAbsenceDTO>> GetAllFicheAbsencesAsync()
        {
            var fiches = await _unitOfWork.FicheAbsences.GetAllAsync();
            return fiches.Select(f => new FicheAbsenceDTO
            {
                CodeFicheAbsence = f.CodeFicheAbsence,
                DateJour = f.DateJour,
                CodeMatiere = f.CodeMatiere,
                CodeEnseignant = f.CodeEnseignant,
                CodeClasse = f.CodeClasse
            });
        }

        public async Task<FicheAbsenceDTO> GetFicheAbsenceByIdAsync(int id)
        {
            var fiche = await _unitOfWork.FicheAbsences.GetByIdAsync(id);
            if (fiche == null) throw new KeyNotFoundException("Absence record not found");

            return new FicheAbsenceDTO
            {
                CodeFicheAbsence = fiche.CodeFicheAbsence,
                DateJour = fiche.DateJour,
                CodeMatiere = fiche.CodeMatiere,
                CodeEnseignant = fiche.CodeEnseignant,
                CodeClasse = fiche.CodeClasse
            };
        }

        public async Task AddFicheAbsenceAsync(FicheAbsenceDTO ficheAbsenceDto)
        {
            var fiche = new FicheAbsence
            {
                CodeFicheAbsence = ficheAbsenceDto.CodeFicheAbsence,
                DateJour = ficheAbsenceDto.DateJour,
                CodeMatiere = ficheAbsenceDto.CodeMatiere,
                CodeEnseignant = ficheAbsenceDto.CodeEnseignant,
                CodeClasse = ficheAbsenceDto.CodeClasse
            };

            await _unitOfWork.FicheAbsences.AddAsync(fiche);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateFicheAbsenceAsync(FicheAbsenceDTO ficheAbsenceDto)
        {
            var fiche = await _unitOfWork.FicheAbsences.GetByIdAsync(ficheAbsenceDto.CodeFicheAbsence);
            if (fiche == null) throw new KeyNotFoundException("Absence record not found");

            fiche.DateJour = ficheAbsenceDto.DateJour;
            fiche.CodeMatiere = ficheAbsenceDto.CodeMatiere;
            fiche.CodeEnseignant = ficheAbsenceDto.CodeEnseignant;
            fiche.CodeClasse = ficheAbsenceDto.CodeClasse;

            _unitOfWork.FicheAbsences.Update(fiche);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteFicheAbsenceAsync(int id)
        {
            var fiche = await _unitOfWork.FicheAbsences.GetByIdAsync(id);
            if (fiche == null) throw new KeyNotFoundException("Absence record not found");

            _unitOfWork.FicheAbsences.Delete(fiche);
            await _unitOfWork.SaveChangesAsync();
        }
    }

}
