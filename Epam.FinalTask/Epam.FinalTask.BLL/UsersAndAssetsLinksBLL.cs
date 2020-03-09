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
    public class UsersAndAssetsLinksBLL: IUsersAndAssetsLinksBLL
    {
        private readonly IUsersAndAssetsLinksDAO _usersAndAssetsLinksDao;

        public UsersAndAssetsLinksBLL(IUsersAndAssetsLinksDAO usersAndAssetsLinksDao)
        {
            _usersAndAssetsLinksDao = usersAndAssetsLinksDao;
        }
        public void AddLink(int assetId, int userId)
        {
            _usersAndAssetsLinksDao.AddLink(assetId, userId);
        }

        public IEnumerable<UsersAndAssetsLink> GetAllLinks()
        {
            return _usersAndAssetsLinksDao.GetAllLinks();
        }

        public IEnumerable<UsersAndAssetsLink> GetAllLinksByAssetId(int id)
        {
            return _usersAndAssetsLinksDao.GetAllLinksByAssetId(id);
        }

        public IEnumerable<UsersAndAssetsLink> GetAllLinksByUserId(int id)
        {
            return _usersAndAssetsLinksDao.GetAllLinksByUserId(id);
        }

        public UsersAndAssetsLink GetLink(int assetId, int userId)
        {
            return _usersAndAssetsLinksDao.GetLink(assetId, userId);
        }

        public void DeleteLinkByAssetId(int id)
        {
            _usersAndAssetsLinksDao.DeleteLinkByAssetId(id);
        }

        public void DeleteLinkByUserId(int id)
        {
            _usersAndAssetsLinksDao.DeleteLinkByUserId(id);
        }

        public void DeleteLink(int assetId, int userId)
        {
            _usersAndAssetsLinksDao.DeleteLink(assetId, userId);
        }
    }
}
