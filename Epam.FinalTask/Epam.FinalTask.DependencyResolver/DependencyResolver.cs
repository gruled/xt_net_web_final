using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.FinalTask.BLL;
using Epam.FinalTask.BLL.Interfaces;
using Epam.FinalTask.DAL;
using Epam.FinalTask.DAL.Interfaces;

namespace Epam.FinalTask.DependencyResolver
{
    public static class DependencyResolver
    {
        private static readonly IAssetDAO _assetDao;
        private static readonly IAssetsAndImagesLinksDAO _assetsAndImagesLinksDao;
        private static readonly IAssetsAndTagsLinksDAO _assetsAndTagsLinksDao;
        private static readonly IImageDAO _imageDao;
        private static readonly ITagDAO _tagDao;
        private static readonly IUserDAO _userDao;
        private static readonly IAssetBLL _assetBll;
        private static readonly IAssetsAndImagesLinksBLL _assetsAndImagesLinksBll;
        private static readonly IAssetsAndTagsLinksBLL _assetsAndTagsLinksBll;
        private static readonly IImageBLL _imageBll;
        private static readonly ITagBLL _tagBll;
        private static readonly IUserBLL _userBll;
        private static readonly IUsersAndAssetsLinksDAO _usersAndAssetsLinksDao;
        private static readonly IUsersAndAssetsLinksBLL _usersAndAssetsLinksBll;
        private static readonly IRoleDAO _roleDao;
        private static readonly IRoleBLL _roleBll;


        public static IAssetDAO AssetDao => _assetDao;
        public static IAssetsAndImagesLinksDAO AssetsAndImagesLinksDao => _assetsAndImagesLinksDao;
        public static IAssetsAndTagsLinksDAO AssetsAndTagsLinksDao => _assetsAndTagsLinksDao;
        public static IImageDAO ImageDao => _imageDao;
        public static ITagDAO TagDao => _tagDao;
        public static IUserDAO UserDao => _userDao;
        public static IAssetBLL AssetBll => _assetBll;
        public static IAssetsAndImagesLinksBLL AssetsAndImagesLinksBll => _assetsAndImagesLinksBll;
        public static IAssetsAndTagsLinksBLL AssetsAndTagsLinksBll => _assetsAndTagsLinksBll;
        public static IImageBLL ImageBll => _imageBll;
        public static ITagBLL TagBll => _tagBll;
        public static IUserBLL UserBll => _userBll;
        public static IUsersAndAssetsLinksDAO UsersAndAssetsLinksDao => _usersAndAssetsLinksDao;
        public static IUsersAndAssetsLinksBLL UsersAndAssetsLinksBll => _usersAndAssetsLinksBll;
        public static IRoleDAO RoleDao => _roleDao;
        public static IRoleBLL RoleBll => _roleBll;

        static DependencyResolver()
        {
            _assetDao = new AssetDAO();
            _tagDao = new TagDAO();
            _assetsAndImagesLinksDao = new AssetsAndImagesLinksDAO();
            _assetsAndTagsLinksDao = new AssetsAndTagsLinksDAO();
            _imageDao = new ImageDAO();
            _userDao = new UserDAO();
            _usersAndAssetsLinksDao = new UsersAndAssetsLinksDAO();
            _roleDao = new RoleDAO();

            _assetBll = new AssetBLL(_assetDao);
            _tagBll = new TagBLL(_tagDao);
            _assetsAndImagesLinksBll = new AssetsAndImagesLinksBLL(_assetsAndImagesLinksDao);
            _assetsAndTagsLinksBll = new AssetsAndTagsLinksBLL(_assetsAndTagsLinksDao);
            _imageBll = new ImageBLL(_imageDao);
            _userBll = new UserBLL(_userDao);
            _usersAndAssetsLinksBll = new UsersAndAssetsLinksBLL(_usersAndAssetsLinksDao);
            _roleBll = new RoleBLL(_roleDao);
        }
    }
}
