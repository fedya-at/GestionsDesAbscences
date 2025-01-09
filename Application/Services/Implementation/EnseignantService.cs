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
    public class EnseignantService : IEnseignantService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EnseignantService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddEnseignantAsync(EnseignantDTO enseignantDto)
        {
            var enseignant = new Enseignant
            {
                CodeEnseignant = enseignantDto.CodeEnseignant,
                Nom = enseignantDto.Nom,
                Prenom = enseignantDto.Prenom,
                Mail = enseignantDto.Mail,
                Tel = enseignantDto.Tel,
                CodeGrade = enseignantDto.CodeGrade,
                CodeDepartement = enseignantDto.CodeDepartement
            };
            await _unitOfWork.Enseignants.AddAsync(enseignant);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteEnseignantAsync(int id)
        {
            var enseignant = await _unitOfWork.Enseignants.GetByIdAsync(id);
            if (enseignant == null)
            {
                throw new Exception("Enseignant not found");
            }
            _unitOfWork.Enseignants.Delete(enseignant);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<EnseignantDTO>> GetAllEnseignantsAsync()
        {
            var enseignants = await _unitOfWork.Enseignants.GetAllAsync();
            return enseignants.Select(e => new EnseignantDTO
            {
                CodeEnseignant = e.CodeEnseignant,
                Nom = e.Nom,
                Prenom = e.Prenom,
                Mail = e.Mail,
                Tel = e.Tel,
                CodeGrade = e.CodeGrade,
                CodeDepartement = e.CodeDepartement
            });
        }

        public async Task<EnseignantDTO> GetEnseignantByIdAsync(int id)
        {
            var enseignant = await _unitOfWork.Enseignants.GetByIdAsync(id);
            if (enseignant == null)
            {
                throw new Exception("Enseignant not found");
            }
            return new EnseignantDTO
            {
                CodeEnseignant = enseignant.CodeEnseignant,
                Nom = enseignant.Nom,
                Prenom = enseignant.Prenom,
                Mail = enseignant.Mail,
                Tel = enseignant.Tel,
                CodeGrade = enseignant.CodeGrade,
                CodeDepartement = enseignant.CodeDepartement
            };
        }

        public async Task UpdateEnseignantAsync(EnseignantDTO enseignantDto)
        {
            var enseignant = await _unitOfWork.Enseignants.GetByIdAsync(enseignantDto.CodeEnseignant);
            if (enseignant == null) throw new KeyNotFoundException("Enseignant not found");

            enseignant.Nom = enseignantDto.Nom;
            enseignant.Prenom = enseignantDto.Prenom;
            enseignant.Mail = enseignantDto.Mail;
            enseignant.Tel = enseignantDto.Tel;
            enseignant.CodeGrade = enseignantDto.CodeGrade;
            enseignant.CodeDepartement = enseignantDto.CodeDepartement;
            _unitOfWork.Enseignants.Update(enseignant);

            await _unitOfWork.SaveChangesAsync();



        }
    }
}
