using Business.Abstract;
using Business.Contants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        ICarDal _carDal;
        public RentalManager(IRentalDal rentalDal, ICarDal carDal)
        {
            
            rentalDal = _rentalDal;
            _carDal = carDal;
        }

        public IResult Add(Rentals rental)
        {
            var result = _rentalDal.GetAll(r => r.CarId == r.CarId && r.ReturnDate == null);
            if (result.Count > 0)
            {
                return new ErrorResult(Messages.RentalNotAdded);
            }

            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        public List<decimal> CalculateTotalPrice(DateTime rentDate, DateTime returnDate, int carId)
        {
            List<decimal> totalPay = new List<decimal>();
            var dateDifference = (returnDate - rentDate).Days;
            var dailyPrice = Convert.ToInt32(_carDal.Get(t => t.CarId == carId).DailyPrice);

            var totalPrice = Convert.ToDecimal( dateDifference * dailyPrice);
            totalPay.Add(Convert.ToDecimal(dateDifference));
            totalPay.Add(totalPrice);

            return totalPay;

        }

        public IResult Delete(Rentals rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult();
        }

        public IDataResult<List<Rentals>> GetALl()
        {
           return new SuccessDataResult<List<Rentals>>(_rentalDal.GetAll());
        }

        public IDataResult<Rentals> GetByRentalId(int rentalId)
        {
            return new SuccessDataResult<Rentals>(_rentalDal.Get(r=>r.RentalId == rentalId));
        }


        public IResult Update(Rentals rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult();
        }
    }
}
