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
    public class UserBLL: IUserBLL
    {
        private readonly IUserDAO _userDao;

        public UserBLL(IUserDAO userDAO)
        {
            _userDao = userDAO;
        }
        public int AddUser(User newUser)
        {
            return _userDao.AddUser(newUser);
        }

        public void DeleteById(int id)
        {
            _userDao.DeleteById(id);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userDao.GetAllUsers();
        }

        public User GetUserById(int id)
        {
            return _userDao.GetUserById(id);
        }

        public void UpdateUserById(int id, User updateUser)
        {
            _userDao.UpdateUserById(id, updateUser);
        }

        public void UpdateUserRoleById(int userId, int roleId)
        {
            _userDao.UpdateUserRoleById(userId, roleId);
        }

        public void VerifyUserById(int id)
        {
            _userDao.VerifyUserById(id);
        }

        public bool IsUserInRole(string userName, string role)
        {
            return _userDao.IsUserInRole(userName, role);
        }

        public string[] GetRolesForUser(string userName)
        {
            return _userDao.GetRolesForUser(userName);
        }

        public bool IsEntryExist(string hashLogin, string hashPassword)
        {
            return _userDao.IsEntryExist(hashLogin, hashPassword);
        }

        public bool IsUserExist(string hashLogin)
        {
            return _userDao.IsUserExist(hashLogin);
        }

        public int GetUserIdByLogin(string hashLogin)
        {
            return _userDao.GetUserIdByLogin(hashLogin);
        }
    }
}
