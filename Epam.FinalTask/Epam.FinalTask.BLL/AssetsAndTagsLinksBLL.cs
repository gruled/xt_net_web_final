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
    public class AssetsAndTagsLinksBLL: IAssetsAndTagsLinksBLL
    {
        private readonly IAssetsAndTagsLinksDAO _assetsAndTagsLinksDao;

        public AssetsAndTagsLinksBLL(IAssetsAndTagsLinksDAO assetsAndTagsLinksDAO)
        {
            _assetsAndTagsLinksDao = assetsAndTagsLinksDAO;
        }
        public void AddLink(int assetId, int tagId)
        {
            _assetsAndTagsLinksDao.AddLink(assetId, tagId);
        }

        public IEnumerable<AssetsAndTagsLink> GetAllLinks()
        {
            return _assetsAndTagsLinksDao.GetAllLinks();
        }

        public IEnumerable<AssetsAndTagsLink> GetAllLinksByAssetId(int id)
        {
            return _assetsAndTagsLinksDao.GetAllLinksByAssetId(id);
        }

        public IEnumerable<AssetsAndTagsLink> GetAllLinksByTagId(int id)
        {
            return _assetsAndTagsLinksDao.GetAllLinksByTagId(id);
        }

        public AssetsAndTagsLink GetLink(int assetId, int tagId)
        {
            return _assetsAndTagsLinksDao.GetLink(assetId, tagId);
        }

        public void DeleteLinkByAssetId(int id)
        {
            _assetsAndTagsLinksDao.DeleteLinkByAssetId(id);
        }

        public void DeleteLinkByTagId(int id)
        {
            _assetsAndTagsLinksDao.DeleteLinkByTagId(id);
        }

        public void DeleteLink(int assetId, int tagId)
        {
            _assetsAndTagsLinksDao.DeleteLink(assetId, tagId);
        }
    }
}
