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
    public class UsersAndAssetsLinksDAO:IUsersAndAssetsLinksDAO
    {
        public void AddLink(int assetId, int userId)
        {
            using (SqlConnection connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.AddUsersAndAssetsLink";
                var assetParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@assetId",
                    Value = assetId,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(assetParameter);
                var imageParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@userId",
                    Value = userId,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(imageParameter);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<UsersAndAssetsLink> GetAllLinks()
        {
            List<UsersAndAssetsLink> assetsAndImagesLinkses = new List<UsersAndAssetsLink>();
            using (SqlConnection connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetAllUsersAndAssetsLinks";
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    assetsAndImagesLinkses.Add(new UsersAndAssetsLink()
                    {
                        AssetId = (int)reader["assetId"],
                        UserId = (int)reader["userId"]
                    });
                }
            }

            return assetsAndImagesLinkses;
        }

        public IEnumerable<UsersAndAssetsLink> GetAllLinksByAssetId(int id)
        {
            List<UsersAndAssetsLink> assetsAndImagesLinkses = new List<UsersAndAssetsLink>();
            using (SqlConnection connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetAllUsersAndAssetsLinksByAssetId";
                var idParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@assetId",
                    Value = id,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(idParameter);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    assetsAndImagesLinkses.Add(new UsersAndAssetsLink()
                    {
                        AssetId = (int)reader["assetId"],
                        UserId = (int)reader["userId"]
                    });
                }
            }

            return assetsAndImagesLinkses;
        }

        public IEnumerable<UsersAndAssetsLink> GetAllLinksByUserId(int id)
        {
            List<UsersAndAssetsLink> assetsAndImagesLinkses = new List<UsersAndAssetsLink>();
            using (SqlConnection connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetAllUsersAndAssetsLinksByUserId";
                var idParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@userId",
                    Value = id,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(idParameter);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    assetsAndImagesLinkses.Add(new UsersAndAssetsLink()
                    {
                        AssetId = (int)reader["assetId"],
                        UserId = (int)reader["userId"]
                    });
                }
            }

            return assetsAndImagesLinkses;
        }

        public UsersAndAssetsLink GetLink(int assetId, int userId)
        {
            UsersAndAssetsLink assetsAndImagesLinks = new UsersAndAssetsLink();
            using (SqlConnection connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetUsersAndAssetsLink";
                var assetParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@assetId",
                    Value = assetId,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(assetParameter);
                var imageParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@userId",
                    Value = userId,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(imageParameter);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    assetsAndImagesLinks = new UsersAndAssetsLink()
                    {
                        AssetId = (int)reader["assetId"],
                        UserId = (int)reader["userId"]
                    };
                }
            }
            return assetsAndImagesLinks;
        }

        public void DeleteLinkByAssetId(int id)
        {
            using (SqlConnection connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.DeleteUsersAndAssetsLinkByAssetId";
                var idParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@assetId",
                    Value = id,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(idParameter);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteLinkByUserId(int id)
        {
            using (SqlConnection connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.DeleteUsersAndAssetsLinkByUserId";
                var idParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@userId",
                    Value = id,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(idParameter);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteLink(int assetId, int userId)
        {
            using (SqlConnection connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.DeleteUsersAndAssetsLink";
                var idParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@userId",
                    Value = userId,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(idParameter);
                var idParameterB = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@assetId",
                    Value = assetId,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(idParameterB);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
