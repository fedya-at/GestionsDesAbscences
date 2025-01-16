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
    public class DepartmentService : IDepartementService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddDepartmentAsync(DepartmentDTO departmentDto)
        {
            var department = new Departement
            {
                NomDepartement = departmentDto.DepartmentName,
            };

            await _unitOfWork.Departements.AddAsync(department);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteDepartmentAsync(int id)
        {
            var department = await _unitOfWork.Departements.GetByIdAsync(id);
            if (department == null) throw new KeyNotFoundException("Department not found");
            _unitOfWork.Departements.Delete(department); 
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<DepartmentDTO>> GetAllDepartmentsAsync()
        {
            var departments = await _unitOfWork.Departements.GetAllAsync();
            return departments.Select(d => new DepartmentDTO
            {
                DepartmentId = (int)d.CodeDepartement,
                DepartmentName = d.NomDepartement
            });



        }

        public async Task<DepartmentDTO> GetDepartmentByIdAsync(int id)
        {
            var department = await _unitOfWork.Departements.GetByIdAsync(id);
            if (department == null) throw new KeyNotFoundException("Department not found");

            return new DepartmentDTO
            {
                DepartmentId = (int)department.CodeDepartement,
                DepartmentName = department.NomDepartement
            };
        }

        public async Task UpdateDepartmentAsync(DepartmentDTO departmentDto)
        {
            if (departmentDto == null)
            {
                throw new ArgumentNullException(nameof(departmentDto), "DepartmentDTO cannot be null");
            }

            if (departmentDto.DepartmentId <= 0)
            {
                throw new ArgumentException("Invalid DepartmentId", nameof(departmentDto.DepartmentId));
            }

            if (string.IsNullOrWhiteSpace(departmentDto.DepartmentName))
            {
                throw new ArgumentException("DepartmentName cannot be null or empty", nameof(departmentDto.DepartmentName));
            }

            var department = await _unitOfWork.Departements.GetByIdAsync(departmentDto.DepartmentId);
            if (department == null)
            {
                throw new KeyNotFoundException("Department not found");
            }

            department.NomDepartement = departmentDto.DepartmentName;

            _unitOfWork.Departements.Update(department);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
