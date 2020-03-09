using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.FinalTask.Entities;

namespace Epam.FinalTask.DAL.Interfaces
{
    public interface ITagDAO
    {
        int AddTag(Tag newTag);
        void DeleteTagById(int id);
        IEnumerable<Tag> GetAllTags();
        Tag GetTagById(int id);
        void UpdateTagById(int id, Tag updateTag);
    }
}
