using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IDepartementService
    {
        Task<IEnumerable<DepartmentDTO>> GetAllDepartmentsAsync();
        Task<DepartmentDTO> GetDepartmentByIdAsync(int id);
        Task AddDepartmentAsync(DepartmentDTO departmentDto);
        Task UpdateDepartmentAsync(DepartmentDTO departmentDto);
        Task DeleteDepartmentAsync(int id);
    }
}
