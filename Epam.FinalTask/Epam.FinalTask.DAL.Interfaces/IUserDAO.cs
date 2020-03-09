using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.FinalTask.Entities;

namespace Epam.FinalTask.DAL.Interfaces
{
    public interface IUserDAO
    {
        int AddUser(User newUser);
        void DeleteById(int id);
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
        void UpdateUserById(int id, User updateUser);
        void UpdateUserRoleById(int userId, int roleId);
        void VerifyUserById(int id);
        bool IsUserInRole(string userName, string role);
        string[] GetRolesForUser(string userName);
        bool IsEntryExist(string hashLogin, string hashPassword);
        bool IsUserExist(string hashLogin);
        int GetUserIdByLogin(string hashLogin);
    }
}
