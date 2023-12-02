using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IResult Add(Customers customer);
        IResult Update(Customers customer);
        IResult Delete(Customers customer);
        IDataResult<List<Customers>> GetALl();
        IDataResult<Customers> GetByCustomerId(int CustomerId);
        IDataResult<List<CustomerDetailDto>> GetCustomerDetails();
    }
}
