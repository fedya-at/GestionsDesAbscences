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
    public class SeanceService : ISeanceService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SeanceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<SeanceDTO>> GetAllSeancesAsync()
        {
            var seances = await _unitOfWork.Seances.GetAllAsync();
            return seances.Select(s => new SeanceDTO
            {
                CodeSeance = s.CodeSeance,
                NomSeance = s.NomSeance,
                HeureDebut = s.HeureDebut,
                HeureFin = s.HeureFin
            });
        }

        public async Task<SeanceDTO> GetSeanceByIdAsync(int id)
        {
            var seance = await _unitOfWork.Seances.GetByIdAsync(id);
            if (seance == null) throw new KeyNotFoundException("Seance not found");

            return new SeanceDTO
            {
                CodeSeance = seance.CodeSeance,
                NomSeance = seance.NomSeance,
                HeureDebut = seance.HeureDebut,
                HeureFin = seance.HeureFin
            };
        }

        public async Task AddSeanceAsync(SeanceDTO seanceDto)
        {
            var seance = new Seance
            {
                CodeSeance = seanceDto.CodeSeance,
                NomSeance = seanceDto.NomSeance,
                HeureDebut = seanceDto.HeureDebut,
                HeureFin = seanceDto.HeureFin
            };

            await _unitOfWork.Seances.AddAsync(seance);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateSeanceAsync(SeanceDTO seanceDto)
        {
            var seance = await _unitOfWork.Seances.GetByIdAsync(seanceDto.CodeSeance);
            if (seance == null) throw new KeyNotFoundException("Seance not found");

            seance.NomSeance = seanceDto.NomSeance;
            seance.HeureDebut = seanceDto.HeureDebut;
            seance.HeureFin = seanceDto.HeureFin;

            _unitOfWork.Seances.Update(seance);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteSeanceAsync(int id)
        {
            var seance = await _unitOfWork.Seances.GetByIdAsync(id);
            if (seance == null) throw new KeyNotFoundException("Seance not found");

            _unitOfWork.Seances.Delete(seance);
            await _unitOfWork.SaveChangesAsync();
        }
    }

}
