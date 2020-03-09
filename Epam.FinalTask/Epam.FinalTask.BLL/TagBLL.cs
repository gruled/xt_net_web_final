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
    public class TagBLL : ITagBLL
    {
        private readonly ITagDAO _tagDao;

        public TagBLL(ITagDAO tagDAO)
        {
            _tagDao = tagDAO;
        }
        public int AddTag(Tag newTag)
        {
            return _tagDao.AddTag(newTag);
        }

        public void DeleteTagById(int id)
        {
            _tagDao.DeleteTagById(id);
        }

        public IEnumerable<Tag> GetAllTags()
        {
            return _tagDao.GetAllTags();
        }

        public Tag GetTagById(int id)
        {
            return _tagDao.GetTagById(id);
        }

        public void UpdateTagById(int id, Tag updateTag)
        {
            _tagDao.UpdateTagById(id, updateTag);
        }
    }
}
