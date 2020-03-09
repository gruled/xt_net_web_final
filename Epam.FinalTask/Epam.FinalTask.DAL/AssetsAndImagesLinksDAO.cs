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
    public class AssetsAndImagesLinksDAO: IAssetsAndImagesLinksDAO
    {
        public void AddLink(int assetId, int imageId)
        {
            using (SqlConnection connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.AddAssetAndImageLink";
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
                    ParameterName = "@imageId",
                    Value = imageId,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(imageParameter);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<AssetsAndImagesLinks> GetAllLinks()
        {
            List<AssetsAndImagesLinks> assetsAndImagesLinkses = new List<AssetsAndImagesLinks>();
            using (SqlConnection connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetAllAssetAndImageLinks";
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    assetsAndImagesLinkses.Add(new AssetsAndImagesLinks()
                    {
                        AssetId = (int)reader["assetId"],
                        ImageId = (int)reader["imageId"]
                    });
                }
            }

            return assetsAndImagesLinkses;
        }

        public IEnumerable<AssetsAndImagesLinks> GetAllLinksByAssetId(int id)
        {
            List<AssetsAndImagesLinks> assetsAndImagesLinkses = new List<AssetsAndImagesLinks>();
            using (SqlConnection connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetAllAssetAndImageLinksByAssetId";
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
                    assetsAndImagesLinkses.Add(new AssetsAndImagesLinks()
                    {
                        AssetId = (int)reader["assetId"],
                        ImageId = (int)reader["imageId"]
                    });
                }
            }

            return assetsAndImagesLinkses;
        }

        public IEnumerable<AssetsAndImagesLinks> GetAllLinksByImageId(int id)
        {
            List<AssetsAndImagesLinks> assetsAndImagesLinkses = new List<AssetsAndImagesLinks>();
            using (SqlConnection connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetAllAssetAndImageLinksByImageId";
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
                    assetsAndImagesLinkses.Add(new AssetsAndImagesLinks()
                    {
                        AssetId = (int)reader["assetId"],
                        ImageId = (int)reader["imageId"]
                    });
                }
            }

            return assetsAndImagesLinkses;
        }

        public AssetsAndImagesLinks GetLink(int assetId, int imageId)
        {
            AssetsAndImagesLinks assetsAndImagesLinks = new AssetsAndImagesLinks();
            using (SqlConnection connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetAllAssetAndImageLink";
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
                    ParameterName = "@imageId",
                    Value = imageId,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(imageParameter);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    assetsAndImagesLinks = new AssetsAndImagesLinks()
                    {
                        AssetId = (int)reader["assetId"],
                        ImageId = (int)reader["imageId"]
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
                command.CommandText = "dbo.DeleteAssetAndImageLinkByAssetId";
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

        public void DeleteLinkByImageId(int id)
        {
            using (SqlConnection connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.DeleteAssetAndImageLinkByImageId";
                var idParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@imageId",
                    Value = id,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(idParameter);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteLink(int assetId, int imageId)
        {
            using (SqlConnection connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.DeleteAssetAndImageLink";
                var idParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@imageId",
                    Value = imageId,
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
