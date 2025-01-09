using Application.DTOs;
using Application.Services.Interfaces;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Implementation
{
    public class MatiereService : IMatiereService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MatiereService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddMatiereAsync(MatiereDTO matiereDto)
        {
            var matiere = new Matiere
            {
                CodeMatiere = matiereDto.CodeMatiere,
                NomMatiere = matiereDto.NomMatiere,
                NbreHeureCoursParSemaine = matiereDto.NbreHeureCoursParSemaine,
                NbreHeureTDParSemaine = matiereDto.NbreHeureTDParSemaine,
                NbreHeureTPParSemaine = matiereDto.NbreHeureTPParSemaine
            };
            await _unitOfWork.Matieres.AddAsync(matiere);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteMatiereAsync(int id)
        {
            var matiere = await _unitOfWork.Matieres.GetByIdAsync(id);
            if (matiere == null) throw new KeyNotFoundException("Matiere not found");
            _unitOfWork.Matieres.Delete(matiere);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<MatiereDTO>> GetAllMatieresAsync()
        {
            var matieres = await _unitOfWork.Matieres.GetAllAsync();
            return matieres.Select(m => new MatiereDTO
            {
                CodeMatiere = m.CodeMatiere,
                NomMatiere = m.NomMatiere,
                NbreHeureCoursParSemaine = m.NbreHeureCoursParSemaine,
                NbreHeureTDParSemaine = m.NbreHeureTDParSemaine,
                NbreHeureTPParSemaine = m.NbreHeureTPParSemaine
            });
        }

        public async Task<MatiereDTO> GetMatiereByIdAsync(int id)
        {
            var matiere = await _unitOfWork.Matieres.GetByIdAsync(id);
            if (matiere == null) throw new KeyNotFoundException("Matiere not found");
            return new MatiereDTO
            {
                CodeMatiere = matiere.CodeMatiere,
                NomMatiere = matiere.NomMatiere,
                NbreHeureCoursParSemaine = matiere.NbreHeureCoursParSemaine,
                NbreHeureTDParSemaine = matiere.NbreHeureTDParSemaine,
                NbreHeureTPParSemaine = matiere.NbreHeureTPParSemaine
            };
        }

        public async Task UpdateMatiereAsync(MatiereDTO matiereDto)
        {
            var matiere = await _unitOfWork.Matieres.GetByIdAsync(matiereDto.CodeMatiere);
            if (matiere == null) throw new KeyNotFoundException("Matiere not found");
            matiere.NomMatiere = matiereDto.NomMatiere;
            matiere.NbreHeureCoursParSemaine = matiereDto.NbreHeureCoursParSemaine;
        }
    }
}
