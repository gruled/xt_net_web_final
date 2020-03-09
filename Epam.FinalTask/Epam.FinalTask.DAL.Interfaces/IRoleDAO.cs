using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.FinalTask.Entities;

namespace Epam.FinalTask.DAL.Interfaces
{
    public interface IRoleDAO
    {
        int AddRole(Role newRole);
        void DeleteRoleById(int id);
        IEnumerable<Role> GetAllRoles();
        Role GetRoleById(int id);
        void UpdateRoleById(int id, Role updateRole);
    }
}
