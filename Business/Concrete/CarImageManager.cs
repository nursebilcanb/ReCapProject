using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(IFormFile formFile, CarImage carImage)
        {
            var result = BusinessRules.Run(CheckIfCarImageExceed(carImage.CarId));
            if (result != null)
            {
                return result;
            }
            carImage.ImagePath = FileHelper.Add(formFile);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);

            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(CarImage carImage)
        {
            FileHelper.Delete(carImage.ImagePath);
            _carImageDal.Delete(carImage);

            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<CarImage> Get(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(ı => ı.CarImageId == id));
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.ImagesListed);
        }

        public IDataResult<List<CarImage>> GetByImageId(int id)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(ı => ı.CarImageId == id));
        }

        public IDataResult<List<CarImage>> GetImageByCarId(int id)
        {
            var getListByCarId = _carImageDal.GetAll(car => car.CarId == id);
            if (getListByCarId.Count > 0)
            {
                return new SuccessDataResult<List<CarImage>>(getListByCarId);
            }

            return CheckIfCarImageNull(id);
        }

        public IResult Update(IFormFile formFile, CarImage carImage)
        {
            carImage.ImagePath = FileHelper.Update(_carImageDal.Get(p => p.CarImageId == carImage.CarImageId).ImagePath, formFile);
            carImage.Date = DateTime.Now;

            _carImageDal.Update(carImage);

            return new SuccessResult(Messages.Updated);
        }

        private IResult CheckIfCarImageExceed(int id)
        {
            var result = _carImageDal.GetAll(ı => ı.CarId == id).Count;
            if (result > 5)
            {
                return new ErrorResult(Messages.CarImageExceed);
            }
            return new SuccessResult();
        }

        private IDataResult<List<CarImage>> CheckIfCarImageNull(int id)
        {
            string path = @"logo.jpg";
            var result = _carImageDal.GetAll(ı => ı.CarId == id).Any();


            var defaultImage = new List<CarImage> { new CarImage { CarId = id, ImagePath = path, Date = DateTime.Now } };
            return new SuccessDataResult<List<CarImage>>(defaultImage);

        }
    }
}
