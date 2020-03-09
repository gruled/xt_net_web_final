using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.FinalTask.Entities;

namespace Epam.FinalTask.BLL.Interfaces
{
    public interface IAssetsAndImagesLinksBLL
    {
        void AddLink(int assetId, int imageId);
        IEnumerable<AssetsAndImagesLinks> GetAllLinks();
        IEnumerable<AssetsAndImagesLinks> GetAllLinksByAssetId(int id);
        IEnumerable<AssetsAndImagesLinks> GetAllLinksByImageId(int id);
        AssetsAndImagesLinks GetLink(int assetId, int imageId);
        void DeleteLinkByAssetId(int id);
        void DeleteLinkByImageId(int id);
        void DeleteLink(int assetId, int imageId);
    }
}
