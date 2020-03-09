using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.FinalTask.Entities;

namespace Epam.FinalTask.DAL.Interfaces
{
    public interface IUsersAndAssetsLinksDAO
    {
        void AddLink(int assetId, int userId);
        IEnumerable<UsersAndAssetsLink> GetAllLinks();
        IEnumerable<UsersAndAssetsLink> GetAllLinksByAssetId(int id);
        IEnumerable<UsersAndAssetsLink> GetAllLinksByUserId(int id);
        UsersAndAssetsLink GetLink(int assetId, int userId);
        void DeleteLinkByAssetId(int id);
        void DeleteLinkByUserId(int id);
        void DeleteLink(int assetId, int userId);
    }
}
