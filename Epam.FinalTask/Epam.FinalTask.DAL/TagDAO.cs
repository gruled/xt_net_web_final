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
    public class TagDAO:ITagDAO
    {
        public int AddTag(Tag newTag)
        {
            int id = 0;
            using (SqlConnection connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.AddTag";
                var titleParameter = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@title",
                    Value = newTag.Title,
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

        public void DeleteTagById(int id)
        {
            using (SqlConnection connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.DeleteTagById";
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

        public IEnumerable<Tag> GetAllTags()
        {
            List<Tag> tags = new List<Tag>();
            using (SqlConnection connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetAllTags";
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    tags.Add(new Tag()
                    {
                        Id = (int)reader["id"],
                        Title = (string)reader["title"]
                    });
                }
            }

            return tags;
        }

        public Tag GetTagById(int id)
        {
            Tag tag = new Tag();
            using (SqlConnection connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetTagById";
                var idParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "id",
                    Value = id,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(idParameter);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    tag = new Tag()
                    {
                        Id = (int) reader["id"],
                        Title = (string) reader["title"]
                    };
                }
            }

            return tag;
        }

        public void UpdateTagById(int id, Tag updateTag)
        {
            using (SqlConnection connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.UpdateTagById";
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
                    Value = updateTag.Title,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(titleParameter);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
