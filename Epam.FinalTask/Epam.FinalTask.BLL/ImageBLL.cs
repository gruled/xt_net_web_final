using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.FinalTask.BLL.Interfaces;
using Epam.FinalTask.DAL.Interfaces;
using Epam.FinalTask.Entities;

namespace Epam.FinalTask.BLL
{
    public class ImageBLL: IImageBLL
    {
        private readonly IImageDAO _imageDao;

        public ImageBLL(IImageDAO imageDAO)
        {
            _imageDao = imageDAO;
        }
        public int AddImage(Image newImage)
        {
            return _imageDao.AddImage(newImage);
        }

        public void DeleteImageById(int id)
        {
            _imageDao.DeleteImageById(id);
        }

        public IEnumerable<Image> GetAllImages()
        {
            return _imageDao.GetAllImages();
        }

        public Image GetImageById(int id)
        {
            return _imageDao.GetImageById(id);
        }

        public void UpdateImageById(int id, Image updateImage)
        {
            _imageDao.UpdateImageById(id, updateImage);
        }
    }
}
