using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.FinalTask.Entities;

namespace Epam.FinalTask.BLL.Interfaces
{
    public interface IAssetBLL
    {
        int AddAsset(Asset newAsset);
        void DeleteAssetById(int id);
        IEnumerable<Asset> GetAllAssets();
        IEnumerable<Asset> GetAllModeratedAssets();
        IEnumerable<Asset> GetAllAssetsMin();
        IEnumerable<Asset> GetAllModeratedAssetsMin();
        int UpdateAssetById(int id, Asset updateAsset);
        Asset GetAssetById(int id);
        void ModerateAssetById(int id);
    }
}
