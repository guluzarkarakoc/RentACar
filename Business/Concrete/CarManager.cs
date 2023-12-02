using Business.Abstract;
using Business.Contants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using ValidationException = FluentValidation.ValidationException;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _CarDal;

        

        public CarManager(ICarDal carDal)
        {
            _CarDal = carDal;
        }

        [ValidationAspect(typeof(CarValidator))]

        public IResult Add(Car car)
        {
          IResult result = BusinessRules.Run(CheckIfCarNameExist(car.CarName), CheckIfCarCountOfBrandCorrect(car.BrandId));

            if (result != null)
            {
                return result;
            }
            _CarDal.Add(car);
            return new Result(true, Messages.CarAdded);

            //if   (CheckIfCarCountOfBrandCorrect(car.BrandId).Success)
            //   {
            //       if(CheckIfCarNameExist(car.CarName).Success)
            //       {
            //           _CarDal.Add(car);
            //           return new Result(true, Messages.CarAdded);
            //       }

            //   }
            //   return new ErrorResult();

        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 00)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Car>>( _CarDal.GetAll(),Messages.CarsListed);
        }

        public IDataResult<List<Car>> GetAllByBrandId(int id)
        {
            return new SuccessDataResult<List< Car >> (_CarDal.GetAll(t=>t.BrandId == id));
        }

        public IDataResult<List<Car>> GetAllByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_CarDal.GetAll(t => t.DailyPrice >= min && t.DailyPrice <= max));
        }

        public IDataResult<Car> GetById(int CarId)
        {
            return new SuccessDataResult<Car>(_CarDal.Get(t=>t.CarId==CarId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>> (_CarDal.GetCarDetails());
        }
        

        private IResult CheckIfCarCountOfBrandCorrect(int BrandId)
        {
            var result = _CarDal.GetAll(t => t.BrandId == BrandId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.CarCountError);
            }
            return new SuccessResult();
        }

        private IResult CheckIfCarNameExist(string carName)
        {
            var result = _CarDal.GetAll(t => t.CarName == carName).Any();
            if (result)
            {
                return new ErrorResult(Messages.CarNameAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}
