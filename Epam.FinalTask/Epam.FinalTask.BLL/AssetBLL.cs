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
    public class AssetBLL: IAssetBLL
    {
        private readonly IAssetDAO _assetDao;

        public AssetBLL(IAssetDAO assetDAO)
        {
            _assetDao = assetDAO;
        }

        public int AddAsset(Asset newAsset)
        {
            return _assetDao.AddAsset(newAsset);
        }

        public void DeleteAssetById(int id)
        {
            _assetDao.DeleteAssetById(id);
        }

        public IEnumerable<Asset> GetAllAssets()
        {
            return _assetDao.GetAllAssets();
        }

        public IEnumerable<Asset> GetAllModeratedAssets()
        {
            return _assetDao.GetAllModeratedAssets();
        }

        public IEnumerable<Asset> GetAllAssetsMin()
        {
            return _assetDao.GetAllAssetsMin();
        }

        public IEnumerable<Asset> GetAllModeratedAssetsMin()
        {
            return _assetDao.GetAllModeratedAssetsMin();
        }

        public int UpdateAssetById(int id, Asset updateAsset)
        {
            return _assetDao.UpdateAssetById(id, updateAsset);
        }

        public Asset GetAssetById(int id)
        {
            return _assetDao.GetAssetById(id);
        }

        public void ModerateAssetById(int id)
        {
            _assetDao.ModerateAssetById(id);
        }
    }
}
