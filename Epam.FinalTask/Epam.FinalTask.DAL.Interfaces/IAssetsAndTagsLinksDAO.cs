using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.FinalTask.Entities;

namespace Epam.FinalTask.DAL.Interfaces
{
    public interface IAssetsAndTagsLinksDAO
    {
        void AddLink(int assetId, int tagId);
        IEnumerable<AssetsAndTagsLink> GetAllLinks();
        IEnumerable<AssetsAndTagsLink> GetAllLinksByAssetId(int id);
        IEnumerable<AssetsAndTagsLink> GetAllLinksByTagId(int id);
        AssetsAndTagsLink GetLink(int assetId, int tagId);
        void DeleteLinkByAssetId(int id);
        void DeleteLinkByTagId(int id);
        void DeleteLink(int assetId, int tagId);
    }
}
