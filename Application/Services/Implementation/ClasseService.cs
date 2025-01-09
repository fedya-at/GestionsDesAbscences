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
    public class ClasseService : IClasseService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClasseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ClasseDTO>> GetAllClassesAsync()
        {
            var classes = await _unitOfWork.Classes.GetAllAsync();
            return classes.Select(c => new ClasseDTO
            {
                CodeClasse = c.CodeClasse,
                NomClasse = c.NomClasse,
                CodeGroupe = c.CodeGroupe,
                CodeDepartement = c.CodeDepartement
            });
        }

        public async Task<ClasseDTO> GetClassByIdAsync(int id)
        {
            var classe = await _unitOfWork.Classes.GetByIdAsync(id);
            if (classe == null) throw new KeyNotFoundException("Class not found");

            return new ClasseDTO
            {
                CodeClasse = classe.CodeClasse,
                NomClasse = classe.NomClasse,
                CodeGroupe = classe.CodeGroupe,
                CodeDepartement = classe.CodeDepartement
            };
        }

        public async Task AddClassAsync(ClasseDTO classeDto)
        {
            var classe = new Classe
            {
                CodeClasse = classeDto.CodeClasse,
                NomClasse = classeDto.NomClasse,
                CodeGroupe = classeDto.CodeGroupe,
                CodeDepartement = classeDto.CodeDepartement
            };

            await _unitOfWork.Classes.AddAsync(classe);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateClassAsync(ClasseDTO classeDto)
        {
            var classe = await _unitOfWork.Classes.GetByIdAsync(classeDto.CodeClasse);
            if (classe == null) throw new KeyNotFoundException("Class not found");

            classe.NomClasse = classeDto.NomClasse;
            classe.CodeGroupe = classeDto.CodeGroupe;
            classe.CodeDepartement = classeDto.CodeDepartement;

            _unitOfWork.Classes.Update(classe);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteClassAsync(int id)
        {
            var classe = await _unitOfWork.Classes.GetByIdAsync(id);
            if (classe == null) throw new KeyNotFoundException("Class not found");

            _unitOfWork.Classes.Delete(classe);
            await _unitOfWork.SaveChangesAsync();
        }

      
    }

}
