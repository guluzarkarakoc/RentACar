using Business.Abstract;
using Business.Contants;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _ICarImageDal;
        IFileHelperService _fileHelperService;

        public CarImageManager(ICarImageDal carImageDal, IFileHelperService fileHelperService)
        {
            _ICarImageDal = carImageDal;
            _fileHelperService = fileHelperService;
        }

        public IDataResult<List<CarImages>> GetAll()
        {
            return new SuccessDataResult<List<CarImages>>(_ICarImageDal.GetAll());
        }

        public IDataResult<CarImages> GetById(int CarImageId)
        {
            return new SuccessDataResult<CarImages>(_ICarImageDal.Get(i => i.CarImageId == CarImageId));

        }

        public IDataResult<List<CarImages>> GetImagesByCarId(int carId)
        {
            var result =BusinessRules.Run(CheckCarImageExists(carId));
            if (result!=null)
            {
                return new ErrorDataResult<List<CarImages>>(GetDefaultImage(carId).Data);
            }
            return new SuccessDataResult<List<CarImages>>(_ICarImageDal.GetAll(t=>t.CarId == carId));
        }


        public IResult Add(IFormFile file,CarImages carImage)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageLimit(carImage.CarId));
            if (result != null)
            {
                return result;
            }
            carImage.ImagePath = _fileHelperService.Upload(file, PathConstants.CarImagePath);
            carImage.ImageDate = DateTime.Now;
            _ICarImageDal.Add(carImage);
            return new SuccessResult(Messages.ImageAdded);
        }

        public IResult Delete(CarImages carImage)
        {
            _fileHelperService.Delete(PathConstants.CarImagePath+ carImage.ImagePath);
            _ICarImageDal.Delete(carImage);
            return new SuccessResult(Messages.ImageDeleted);
        }

        public IResult Update(IFormFile file, CarImages carImage)
        {
            _fileHelperService.Update(file, PathConstants.CarImagePath + carImage.ImagePath, PathConstants.CarImagePath);
            _ICarImageDal.Update(carImage);

            return new SuccessResult(Messages.ImagesUpdated);
        }

        private IResult CheckIfCarImageLimit(int carId)
        {
            var result = _ICarImageDal.GetAll(c => c.CarId == carId).Count;
            if (result >= 5)
            {
                return new ErrorResult(Messages.CarImageLimitReached);
            }
            return new SuccessResult();
        }
        private IDataResult<List<CarImages>> GetDefaultImage(int carId)
        {

            List<CarImages> carImage = new List<CarImages>();
            carImage.Add(new CarImages { CarId = carId, ImageDate = DateTime.Now, ImagePath = "DefaultImage.jpg" });
            return new SuccessDataResult<List<CarImages>>(carImage);
        }
        private IResult CheckCarImageExists(int carId)
        {
            var result = _ICarImageDal.GetAll(c => c.CarId == carId).Count;
            if (result > 0)
            {
                return new SuccessResult(Messages.CarImageAlreadyExists);
            }
            return new ErrorResult();
        }
    }


   

}
