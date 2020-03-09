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
    public class UserDAO:IUserDAO
    {
        public int AddUser(User newUser)
        {
            int id = 0;
            using (SqlConnection connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.AddUser";
                var nameParameter = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@name",
                    Value = newUser.Name,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(nameParameter);
                var loginParameter = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@login",
                    Value = newUser.Login,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(loginParameter);
                var passwordParameter = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@password",
                    Value = newUser.Password,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(passwordParameter);
                var descriptionParameter = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@description",
                    Value = newUser.Description,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(descriptionParameter);
                var roleParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@role",
                    Value = newUser.Role,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(roleParameter);
                var registrationDate = new SqlParameter()
                {
                    DbType = DbType.DateTime,
                    ParameterName = "@registrationDate",
                    Value = newUser.RegistrationDate,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(registrationDate);
                var verifiedParameter = new SqlParameter()
                {
                    DbType = DbType.Boolean,
                    ParameterName = "@verified",
                    Value = newUser.Verified,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(verifiedParameter);
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

        public void DeleteById(int id)
        {
            using (SqlConnection connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.DeleteUserById";
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

        public IEnumerable<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            using (SqlConnection connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetAllUsers";
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    users.Add(new User()
                    {
                        Id = (int)reader["id"],
                        Name = (string)reader["name"],
                        Login = (string)reader["login"],
                        Password = (string)reader["password"],
                        Description = (string)reader["description"],
                        Role = (int)reader["role"],
                        RegistrationDate = (DateTime)reader["registrationDate"],
                        Verified = (bool)reader["verified"]
                    });
                }
            }
            return users;
        }

        public User GetUserById(int id)
        {
            User user = new User();
            List<User> users = new List<User>();
            using (SqlConnection connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetUserById";
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
                    user = new User()
                    {
                        Id = (int)reader["id"],
                        Name = (string)reader["name"],
                        Login = (string)reader["login"],
                        Password = (string)reader["password"],
                        Description = (string)reader["description"],
                        Role = (int)reader["role"],
                        RegistrationDate = (DateTime)reader["registrationDate"],
                        Verified = (bool)reader["verified"]
                    };
                }
            }

            return user;
        }

        public void UpdateUserById(int id, User updateUser)
        {
            using (SqlConnection connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.UpdateUserById";
                var nameParameter = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@name",
                    Value = updateUser.Name,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(nameParameter);
                var loginParameter = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@login",
                    Value = updateUser.Login,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(loginParameter);
                var passwordParameter = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@password",
                    Value = updateUser.Password,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(passwordParameter);
                var descriptionParameter = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@description",
                    Value = updateUser.Description,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(descriptionParameter);
                var roleParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@role",
                    Value = updateUser.Role,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(roleParameter);
                var registrationDate = new SqlParameter()
                {
                    DbType = DbType.DateTime,
                    ParameterName = "@registrationDate",
                    Value = updateUser.RegistrationDate,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(registrationDate);
                var verifiedParameter = new SqlParameter()
                {
                    DbType = DbType.Boolean,
                    ParameterName = "@verified",
                    Value = updateUser.Verified,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(verifiedParameter);
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

        public void UpdateUserRoleById(int userId, int roleId)
        {
            using (SqlConnection connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.UpdateUserRoleById";
                var userIdParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@userId",
                    Value = userId,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(userIdParameter);
                var roleIdParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@roleId",
                    Value = roleId,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(roleIdParameter);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void VerifyUserById(int id)
        {
            using (SqlConnection connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.VerifyUserById";
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

        public bool IsUserInRole(string userName, string role)
        {
            throw new NotImplementedException();
        }

        public string[] GetRolesForUser(string userName)
        {
            List<string> roles = new List<string>();
            using (SqlConnection connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetUserRoleByLogin";
                var loginParameter = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@login",
                    Value = userName,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(loginParameter);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    roles.Add((string)reader["title"]);
                }
            }

            return roles.ToArray();
        }

        public bool IsEntryExist(string hashLogin, string hashPassword)
        {
            var users = GetAllUsers();
            if (users.Any(item => item.Login.Equals(hashLogin) && item.Password.Equals(hashPassword)))
            {
                return true;
            }

            return false;
        }

        public bool IsUserExist(string hashLogin)
        {
            var users = GetAllUsers();
            if (users.Any(item => item.Login.Equals(hashLogin)))
            {
                return true;
            }

            return false;
        }

        public int GetUserIdByLogin(string hashLogin)
        {
            var users = GetAllUsers();
            return users.First(item => item.Login.Equals(hashLogin)).Id;
        }
    }
}
