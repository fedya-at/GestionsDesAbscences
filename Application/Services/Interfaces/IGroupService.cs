using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IGroupService
    {
        Task<IEnumerable<GroupDTO>> GetAllGroupsAsync();
        Task<GroupDTO> GetGroupByIdAsync(int id);
        Task<GroupDTO> GetGroupByNameAsync(string groupName);

        Task AddGroupAsync(GroupDTO groupDTO);
        Task UpdateGroupAsync(GroupDTO groupDTO);
        Task DeleteGroupAsync(int id);
    }
}
