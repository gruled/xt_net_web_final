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
    public class AssetDAO: IAssetDAO
    {
        public int AddAsset(Asset newAsset)
        {
            int id = 0;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.AddAsset";
                var titleParameter = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@title",
                    Value = newAsset.Title,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(titleParameter);
                var descParameter = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@description",
                    Value = newAsset.Description,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(descParameter);
                var licenseParameter = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@license",
                    Value = newAsset.License,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(licenseParameter);
                var pathParameter = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@path",
                    Value = newAsset.Path,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(pathParameter);
                var moderatedParameter = new SqlParameter()
                {
                    DbType = DbType.Boolean,
                    ParameterName = "@moderated",
                    Value = newAsset.Moderated,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(moderatedParameter);
                var sizeParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@size",
                    Value = newAsset.Size,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(sizeParameter);
                var versionParameter = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@version",
                    Value = newAsset.Version,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(versionParameter);
                var patchParameter = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@patchNote",
                    Value = newAsset.PatchNote,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(patchParameter);
                var hierarchyParameter = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@hierarchy",
                    Value = newAsset.Hierarchy,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(hierarchyParameter);
                var idParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@id",
                    Direction = ParameterDirection.Output
                };
                var parentParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@parent",
                    Value = newAsset.Parent,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(parentParameter);
                command.Parameters.Add(idParameter);
                connection.Open();
                command.ExecuteNonQuery();
                id = (int) idParameter.Value;
            }

            return id;
        }

        public void DeleteAssetById(int id)
        {
            using (SqlConnection connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.DeleteAssetById";
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

        public IEnumerable<Asset> GetAllAssets()
        {
            List<Asset> assets = new List<Asset>();
            using (SqlConnection connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetAllAssets";
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    assets.Add(new Asset()
                    {
                        Id = (int)reader["id"],
                        Title = (string)reader["title"],
                        Description = (string)reader["description"],
                        License = (string)reader["license"],
                        Path = (string)reader["path"],
                        Moderated = (bool)reader["moderated"],
                        Size = (int)reader["size"],
                        Version = (string)reader["version"],
                        PatchNote = (string)reader["patchNote"],
                        Hierarchy = (string)reader["hierarchy"],
                        Parent = (int)reader["parent"]
                    });
                }
            }

            return assets;
        }

        public IEnumerable<Asset> GetAllModeratedAssets()
        {
            List<Asset> assets = new List<Asset>();
            using (SqlConnection connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetAllModeratedAssets";
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    assets.Add(new Asset()
                    {
                        Id = (int)reader["id"],
                        Title = (string)reader["title"],
                        Description = (string)reader["description"],
                        License = (string)reader["license"],
                        Path = (string)reader["path"],
                        Moderated = (bool)reader["moderated"],
                        Size = (int)reader["size"],
                        Version = (string)reader["version"],
                        PatchNote = (string)reader["patchNote"],
                        Hierarchy = (string)reader["hierarchy"],
                        Parent = (int)reader["parent"]
                    });
                }
            }

            return assets;
        }

        public IEnumerable<Asset> GetAllAssetsMin()
        {
            List<Asset> assets = new List<Asset>();
            using (SqlConnection connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetAllAssetsMin";
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    assets.Add(new Asset()
                    {
                        Id = (int)reader["id"],
                        Title = (string)reader["title"],
                        Version = (string)reader["version"]
                    });
                }
            }

            return assets;
        }

        public IEnumerable<Asset> GetAllModeratedAssetsMin()
        {
            List<Asset> assets = new List<Asset>();
            using (SqlConnection connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetAllModeratedAssetsMin";
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    assets.Add(new Asset()
                    {
                        Id = (int)reader["id"],
                        Title = (string)reader["title"],
                        Version = (string)reader["version"]
                    });
                }
            }

            return assets;
        }

        public int UpdateAssetById(int id, Asset updateAsset)
        {
            using (SqlConnection connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.UpdateAssetById";
                var titleParameter = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@title",
                    Value = updateAsset.Title,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(titleParameter);
                var descParameter = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@description",
                    Value = updateAsset.Description,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(descParameter);
                var licenseParameter = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@license",
                    Value = updateAsset.License,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(licenseParameter);
                var pathParameter = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@path",
                    Value = updateAsset.Path,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(pathParameter);
                var moderatedParameter = new SqlParameter()
                {
                    DbType = DbType.Boolean,
                    ParameterName = "@moderated",
                    Value = updateAsset.Moderated,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(moderatedParameter);
                var sizeParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@size",
                    Value = updateAsset.Size,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(sizeParameter);
                var versionParameter = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@version",
                    Value = updateAsset.Version,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(versionParameter);
                var patchParameter = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@patchNote",
                    Value = updateAsset.PatchNote,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(patchParameter);
                var hierarchyParameter = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@hierarchy",
                    Value = updateAsset.Hierarchy,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(hierarchyParameter);
                var idParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@id",
                    Value = id,
                    Direction = ParameterDirection.Input
                };
                var parentParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@parent",
                    Value = updateAsset.Parent,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(parentParameter);
                command.Parameters.Add(idParameter);
                connection.Open();
                command.ExecuteNonQuery();
            }

            return id;
        }

        public Asset GetAssetById(int id)
        {
            Asset asset = new Asset();

            using (SqlConnection connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetAssetById";
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
                    asset = new Asset()
                    {
                        Id = (int)reader["id"],
                        Title = (string)reader["title"],
                        Description = (string)reader["description"],
                        License = (string)reader["license"],
                        Path = (string)reader["path"],
                        Moderated = (bool)reader["moderated"],
                        Size = (int)reader["size"],
                        Version = (string)reader["version"],
                        PatchNote = (string)reader["patchNote"],
                        Hierarchy = (string)reader["hierarchy"],
                        Parent = (int)reader["parent"]
                    };
                }
            }

            return asset;
        }

        public void ModerateAssetById(int id)
        {
            using (SqlConnection connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.ModerateAssetById";
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
    }
}
