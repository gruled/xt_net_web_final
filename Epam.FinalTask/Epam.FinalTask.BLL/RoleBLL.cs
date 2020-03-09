using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.FinalTask.BLL.Interfaces;
using Epam.FinalTask.DAL.Interfaces;
using Epam.FinalTask.Entities;

namespace Epam.FinalTask.BLL
{
    public class RoleBLL : IRoleBLL
    {
        private readonly IRoleDAO _roleDao;

        public RoleBLL(IRoleDAO roleDao)
        {
            _roleDao = roleDao;
        }

        public int AddRole(Role newRole)
        {
            return _roleDao.AddRole(newRole);
        }

        public void DeleteRoleById(int id)
        {
            _roleDao.DeleteRoleById(id);
        }

        public IEnumerable<Role> GetAllRoles()
        {
            return _roleDao.GetAllRoles();
        }

        public Role GetRoleById(int id)
        {
            return _roleDao.GetRoleById(id);
        }

        public void UpdateRoleById(int id, Role updateRole)
        {
            _roleDao.UpdateRoleById(id, updateRole);
        }
    }
}
