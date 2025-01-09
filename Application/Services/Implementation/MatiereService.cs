using Application.DTOs;
using Application.Services.Interfaces;
using AutoMapper;
using Core.Entities;
using Core.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Implementation
{
    public class MatiereService : IMatiereService
    {
        private readonly IMatiereRepository _matiereRepository;
        private readonly IMapper _mapper;

        public MatiereService(IMatiereRepository matiereRepository, IMapper mapper)
        {
            _matiereRepository = matiereRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MatiereDTO>> GetAllMatieresAsync()
        {
            var matieres = await _matiereRepository.ListAllAsync();
            return _mapper.Map<IEnumerable<MatiereDTO>>(matieres);
        }

        public async Task<MatiereDTO> GetMatiereByIdAsync(int id)
        {
            var matiere = await _matiereRepository.GetByIdAsync(id);
            return _mapper.Map<MatiereDTO>(matiere);
        }

        public async Task AddMatiereAsync(MatiereDTO matiereDto)
        {
            var matiere = _mapper.Map<Matiere>(matiereDto);
            await _matiereRepository.AddAsync(matiere);
        }

        public async Task UpdateMatiereAsync(MatiereDTO matiereDto)
        {
            var matiere = _mapper.Map<Matiere>(matiereDto);
            await _matiereRepository.UpdateAsync(matiere);
        }

        public async Task DeleteMatiereAsync(int id)
        {
            var matiere = await _matiereRepository.GetByIdAsync(id);
            if (matiere != null)
            {
                await _matiereRepository.DeleteAsync(matiere);
            }
        }
    }
}
