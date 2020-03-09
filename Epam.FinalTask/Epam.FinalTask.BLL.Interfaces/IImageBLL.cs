using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.FinalTask.Entities;

namespace Epam.FinalTask.BLL.Interfaces
{
    public interface IImageBLL
    {
        int AddImage(Image newImage);
        void DeleteImageById(int id);
        IEnumerable<Image> GetAllImages();
        Image GetImageById(int id);
        void UpdateImageById(int id, Image updateImage);
    }
}
