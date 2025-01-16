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
    public class GroupService : IGroupService
    {
        private readonly IUnitOfWork _unitOfWork;

        public GroupService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddGroupAsync(GroupDTO groupDTO)
        {
            var group = new Groupe
            {
                GroupeName = groupDTO.GroupeName
            };
            await _unitOfWork.Groupes.AddAsync(group);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteGroupAsync(int id)
        {
            var group = await _unitOfWork.Groupes.GetByIdAsync(id);
            if (group == null) throw new KeyNotFoundException("Group not found");
            _unitOfWork.Groupes.Delete(group);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<GroupDTO>> GetAllGroupsAsync()
        {
            var groups = await _unitOfWork.Groupes.GetAllAsync();
            return groups.Select(g => new GroupDTO
            {
                CodeGroupe = g.CodeGroupe,
                GroupeName = g.GroupeName
            });
        }

        public async Task<GroupDTO> GetGroupByIdAsync(int id)
        {
            var group = await _unitOfWork.Groupes.GetByIdAsync(id);
            if (group == null) throw new KeyNotFoundException("Group not found");
            return new GroupDTO
            {
                CodeGroupe = group.CodeGroupe,
                GroupeName = group.GroupeName
            };
        }

        public async Task<GroupDTO> GetGroupByNameAsync(string groupName)
        {
            var groups = await _unitOfWork.Groupes.GetAllAsync();
            var group = groups.FirstOrDefault(g => g.GroupeName == groupName);
            if (group == null) throw new KeyNotFoundException("Group not found");
            return new GroupDTO
            {
                CodeGroupe = group.CodeGroupe,
                GroupeName = group.GroupeName
            };

        }

        public async Task UpdateGroupAsync(GroupDTO groupDTO)
        {
            var group = await _unitOfWork.Groupes.GetByIdAsync(groupDTO.CodeGroupe);
            if (group == null) throw new KeyNotFoundException("Group not found");
            group.GroupeName = groupDTO.GroupeName;
            _unitOfWork.Groupes.Update(group);
            await _unitOfWork.SaveChangesAsync();

        }
    }
}
