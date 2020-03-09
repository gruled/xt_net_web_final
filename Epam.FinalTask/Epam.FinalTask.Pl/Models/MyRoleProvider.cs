using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Security;
using Microsoft.SqlServer.Server;

namespace Epam.FinalTask.Pl.Models
{
    public class MyRoleProvider: RoleProvider
    {
        public override bool IsUserInRole(string username, string roleName)
        {
            string[] roles = GetRolesForUser(username);
            foreach (var role in roles)
            {
                if (role.Equals(roleName))
                {
                    return true;
                }
            }
            return false;
        }

        public override string[] GetRolesForUser(string username)
        {
            return DependencyResolver.DependencyResolver.UserBll.GetRolesForUser(username);
        }

        #region MyRegion

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }
        #endregion
        public override string ApplicationName { get; set; }
    }
}