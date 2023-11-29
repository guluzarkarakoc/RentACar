using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ICarManager : ICarService
    {
        ICarDal _CarDal;

        public ICarManager(ICarDal carDal)
        {
            _CarDal = carDal;
        }

        public List<Car> GetAll()
        {
            return _CarDal.GetAll();
        }

        public List<Car> GetAllByBrandId(int id)
        {
            return _CarDal.GetAll(t=>t.BrandId == id);
        }

        public List<Car> GetAllByDailyPrice(decimal min, decimal max)
        {
            return _CarDal.GetAll(t => t.DailyPrice >= min && t.DailyPrice <= max);
        }

        public Car GetById(int CarId)
        {
            return _CarDal.Get(t=>t.CarId==CarId);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _CarDal.GetCarDetails();
        }

        IResult ICarService.Add(Car car)
        {

            if (car.CarName.Length<2)
            {
                return new ErrorResult("Araç ismi en az iki karakter olmalıdır.");
            }
            _CarDal.Add(car);
            return new Result( true, "Araç eklendi.");
        }
    }
}
