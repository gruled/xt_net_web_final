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
    public class AssetsAndImagesLinksBLL:IAssetsAndImagesLinksBLL
    {
        private readonly IAssetsAndImagesLinksDAO _assetsAndImagesLinksDao;

        public AssetsAndImagesLinksBLL(IAssetsAndImagesLinksDAO assetsAndImagesLinksDAO)
        {
            _assetsAndImagesLinksDao = assetsAndImagesLinksDAO;
        }
        public void AddLink(int assetId, int imageId)
        {
            _assetsAndImagesLinksDao.AddLink(assetId, imageId);
        }

        public IEnumerable<AssetsAndImagesLinks> GetAllLinks()
        {
            return _assetsAndImagesLinksDao.GetAllLinks();
        }

        public IEnumerable<AssetsAndImagesLinks> GetAllLinksByAssetId(int id)
        {
            return _assetsAndImagesLinksDao.GetAllLinksByAssetId(id);
        }

        public IEnumerable<AssetsAndImagesLinks> GetAllLinksByImageId(int id)
        {
            return _assetsAndImagesLinksDao.GetAllLinksByImageId(id);
        }

        public AssetsAndImagesLinks GetLink(int assetId, int imageId)
        {
            return _assetsAndImagesLinksDao.GetLink(assetId, imageId);
        }

        public void DeleteLinkByAssetId(int id)
        {
            _assetsAndImagesLinksDao.DeleteLinkByAssetId(id);
        }

        public void DeleteLinkByImageId(int id)
        {
            _assetsAndImagesLinksDao.DeleteLinkByImageId(id);
        }

        public void DeleteLink(int assetId, int imageId)
        {
            _assetsAndImagesLinksDao.DeleteLink(assetId, imageId);
        }
    }
}
