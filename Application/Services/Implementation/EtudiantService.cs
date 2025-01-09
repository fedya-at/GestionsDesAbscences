using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class EtudiantService : IEtudiantService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EtudiantService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddEtudiantAsync(EtudiantDTO etudiantDto)
        {
            var etudiant = new Etudiant
            {
                Nom = etudiantDto.Nom,
                Prenom = etudiantDto.Prenom,
                CodeClasse = etudiantDto.CodeClasse,
                DateNaissance = etudiantDto.DateNaissance,
                Adresse = etudiantDto.Adresse,
                Mail = etudiantDto.Mail,
                Tel = etudiantDto.Tel
            };

            await _unitOfWork.Etudiants.AddAsync(etudiant);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteEtudiantAsync(int id)
        {
            var etudiant =await  _unitOfWork.Etudiants.GetByIdAsync(id);
            if (etudiant == null) throw new KeyNotFoundException("Etudiant introuvable");

            _unitOfWork.Etudiants.Delete(etudiant);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<EtudiantDTO>> GetAllEtudiantsAsync()
        {
            var etudiants = await _unitOfWork.Etudiants.GetAllAsync();
            return etudiants.Select(e => new EtudiantDTO
            {
                CodeEtudiant = e.CodeEtudiant,
                Nom = e.Nom,
                Prenom = e.Prenom,
                DateNaissance = e.DateNaissance,
                CodeClasse = e.CodeClasse,
                NumInscription = e.NumInscription,
                Adresse = e.Adresse,
                Mail = e.Mail,
                Tel = e.Tel
            });
        }

        public async Task<EtudiantDTO> GetEtudiantByIdAsync(int id)
        {
            var etudiant = await _unitOfWork.Etudiants.GetByIdAsync(id);
            if (etudiant == null) return null;
            return new EtudiantDTO
            {
                CodeEtudiant = etudiant.CodeEtudiant,
                Nom = etudiant.Nom,
                Prenom = etudiant.Prenom,
                DateNaissance = etudiant.DateNaissance,
                CodeClasse = etudiant.CodeClasse,
                NumInscription = etudiant.NumInscription,
                Adresse = etudiant.Adresse,
                Mail = etudiant.Mail,
                Tel = etudiant.Tel
            };
        }

        public async Task<IEnumerable<EtudiantDTO>> GetEtudiantsByClasseAsync(int classeId)
        {
            var etudiants = await _unitOfWork.Etudiants.GetAllAsync();
            var filteredEtudiants = etudiants.Where(e => e.CodeClasse == classeId);
            return filteredEtudiants.Select(e => new EtudiantDTO
            {
                CodeEtudiant = e.CodeEtudiant,
                Nom = e.Nom,
                Prenom = e.Prenom,
                DateNaissance = e.DateNaissance,
                CodeClasse = e.CodeClasse,
                NumInscription = e.NumInscription,
                Adresse = e.Adresse,
                Mail = e.Mail,
                Tel = e.Tel
            });
        }

        public async Task UpdateEtudiantAsync(EtudiantDTO etudiantDto)
        {
            var etudiant = new Etudiant
            {
                CodeEtudiant = etudiantDto.CodeEtudiant,
                Nom = etudiantDto.Nom,
                Prenom = etudiantDto.Prenom,
                DateNaissance = etudiantDto.DateNaissance,
                CodeClasse = etudiantDto.CodeClasse,
                NumInscription = etudiantDto.NumInscription,
                Adresse = etudiantDto.Adresse,
                Mail = etudiantDto.Mail,
                Tel = etudiantDto.Tel
            };
            _unitOfWork.Etudiants.Update(etudiant);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
