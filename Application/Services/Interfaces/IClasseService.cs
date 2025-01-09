using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IClasseService
    {
        Task<IEnumerable<ClasseDTO>> GetAllClassesAsync();
        Task<ClasseDTO> GetClassByIdAsync(int id);
        Task AddClassAsync(ClasseDTO classeDto);
        Task UpdateClassAsync(ClasseDTO classeDto);
        Task DeleteClassAsync(int id);
    }
}
