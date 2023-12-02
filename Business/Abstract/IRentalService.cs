using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IResult Add(Rentals rental);
        IResult Update(Rentals rental);
        IResult Delete(Rentals rental);

        IDataResult<List<Rentals>> GetALl();
        IDataResult<Rentals> GetByRentalId(int RentalId);

        List<decimal> CalculateTotalPrice(DateTime rentDate, DateTime returnDate, int carId);
    }
}
