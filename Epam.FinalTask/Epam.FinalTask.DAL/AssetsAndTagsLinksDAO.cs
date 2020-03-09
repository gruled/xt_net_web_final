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
    public class AssetsAndTagsLinksDAO: IAssetsAndTagsLinksDAO
    {
        public void AddLink(int assetId, int tagId)
        {
            using (SqlConnection connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.AddAssetsAndTagsLink";
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
                    ParameterName = "@tagId",
                    Value = tagId,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(imageParameter);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<AssetsAndTagsLink> GetAllLinks()
        {
            List<AssetsAndTagsLink> assetsAndImagesLinkses = new List<AssetsAndTagsLink>();
            using (SqlConnection connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetAllAssetsAndTagsLinks";
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    assetsAndImagesLinkses.Add(new AssetsAndTagsLink()
                    {
                        AssetId = (int)reader["assetId"],
                        TagId = (int)reader["tagId"]
                    });
                }
            }

            return assetsAndImagesLinkses;
        }

        public IEnumerable<AssetsAndTagsLink> GetAllLinksByAssetId(int id)
        {
            List<AssetsAndTagsLink> assetsAndImagesLinkses = new List<AssetsAndTagsLink>();
            using (SqlConnection connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetAllAssetsAndTagsLinksByAssetId";
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
                    assetsAndImagesLinkses.Add(new AssetsAndTagsLink()
                    {
                        AssetId = (int)reader["assetId"],
                        TagId = (int)reader["tagId"]
                    });
                }
            }

            return assetsAndImagesLinkses;
        }

        public IEnumerable<AssetsAndTagsLink> GetAllLinksByTagId(int id)
        {
            List<AssetsAndTagsLink> assetsAndImagesLinkses = new List<AssetsAndTagsLink>();
            using (SqlConnection connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetAllAssetsAndTagsLinksByTagId";
                var idParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@tagId",
                    Value = id,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(idParameter);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    assetsAndImagesLinkses.Add(new AssetsAndTagsLink()
                    {
                        AssetId = (int)reader["assetId"],
                        TagId = (int)reader["tagId"]
                    });
                }
            }

            return assetsAndImagesLinkses;
        }

        public AssetsAndTagsLink GetLink(int assetId, int tagId)
        {
            AssetsAndTagsLink assetsAndImagesLinks = new AssetsAndTagsLink();
            using (SqlConnection connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetAssetsAndTagsLink";
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
                    ParameterName = "@tagId",
                    Value = tagId,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(imageParameter);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    assetsAndImagesLinks = new AssetsAndTagsLink()
                    {
                        AssetId = (int)reader["assetId"],
                        TagId = (int)reader["tagId"]
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
                command.CommandText = "dbo.DeleteAssetsAndTagsLinkByAssetId";
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

        public void DeleteLinkByTagId(int id)
        {
            using (SqlConnection connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.DeleteAssetsAndTagsLinkByTagId";
                var idParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@tagId",
                    Value = id,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(idParameter);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteLink(int assetId, int tagId)
        {
            using (SqlConnection connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.DeleteAssetsAndTagsLink";
                var idParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@tagId",
                    Value = tagId,
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
