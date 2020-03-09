using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.FinalTask.DAL.Interfaces;
using Epam.FinalTask.Entities;

namespace Epam.FinalTask.DAL
{
    public class RoleDAO: IRoleDAO
    {
        public int AddRole(Role newRole)
        {
            int id = 0;
            using (SqlConnection connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.NewRole";
                var titleParameter = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@title",
                    Value = newRole.Title,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(titleParameter);
                var idParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@id",
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(idParameter);
                connection.Open();
                command.ExecuteNonQuery();
                id = (int) idParameter.Value;
            }

            return id;
        }

        public void DeleteRoleById(int id)
        {
            using (SqlConnection connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.DeleteRoleById";
                var idParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@id",
                    Value = id,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(idParameter);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<Role> GetAllRoles()
        {
            List<Role> roles = new List<Role>();
            using (SqlConnection connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetAllRoles";
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    roles.Add(new Role()
                    {
                        Id = (int)reader["id"],
                        Title = (string)reader["title"]
                    });
                }
            }

            return roles;
        }

        public Role GetRoleById(int id)
        {
            Role role = new Role();
            using (SqlConnection connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetRoleById";
                var idParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@id",
                    Value = id,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(idParameter);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    role = new Role()
                    {
                        Id = (int)reader["id"],
                        Title = (string)reader["title"]
                    };
                }
            }

            return role;
        }

        public void UpdateRoleById(int id, Role updateRole)
        {
            using (SqlConnection connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.UpdateRoleById";
                var idParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@id",
                    Value = id,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(idParameter);
                var titleParameter = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@title",
                    Value = updateRole.Title,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(titleParameter);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
