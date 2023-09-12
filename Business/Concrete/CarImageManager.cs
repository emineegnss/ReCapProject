using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.FileSystem;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageServices
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(CarImage carImage, IFormFile file)
        {
            carImage.ImagePath = new FileManagerOnDisk().Add(file,CreateNewPath(file));
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }

        public IResult Delete(CarImage carImage)
        {
            new FileManagerOnDisk().Delete(carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId);
            IfCarImageOfCarExistsAddDefault(ref result);
            return new SuccessDataResult<List<CarImage>>(result);
        }

        public IDataResult<CarImage> GetByImageId(int imageId)
        {
            var result = _carImageDal.GetById(c => c.CarImageId == imageId);
            IfCarImageOfCarExistsAddDefault(ref result);
           return new SuccessDataResult<CarImage>(result);
        }

        public IResult Update(CarImage carImage, IFormFile file)
        {
            var carImageToUptade = _carImageDal.GetById(c => c.CarId == carImage.CarId);
            carImage.CarId = carImageToUptade.CarId;
            carImage.ImagePath = new FileManagerOnDisk().Update(carImageToUptade.ImagePath, file, CreateNewPath(file));
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }
        private string CreateNewPath(IFormFile file)
        {
            var fileInfo = new FileInfo(file.FileName);
            var newPath = $@"{Environment.CurrentDirectory}\Public\Image\CarImage\Upload\{Guid.NewGuid()}_{DateTime.Now.Month}_{DateTime.Now.Day}_{DateTime.Now.Year}{fileInfo.Extension}";
            return newPath;
        }
        private void IfCarImageOfCarExistsAddDefault(ref List<CarImage> result)
        {
            if (!result.Any()) result.Add(CreateDefaultCarImage());
        }
        private void IfCarImageOfCarExistsAddDefault(ref CarImage result)
        {
            if (result == null) result = CreateDefaultCarImage();
        }
        private CarImage CreateDefaultCarImage()
        {
            var defaultCarImage = new CarImage
            {
                ImagePath = $@"{Environment.CurrentDirectory}\Public\Images\CarImage\default-img.png",Date = DateTime.Now
            };
            return defaultCarImage;
        }
    }
}
