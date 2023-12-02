﻿using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customers customer)
        {
           _customerDal.Add(customer);
            return new SuccessResult();
        }

        public IResult Delete(Customers customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult();
        }

        public IDataResult<List<Customers>> GetALl()
        {
           return new SuccessDataResult<List<Customers>>(_customerDal.GetAll());
        }

        public IDataResult<Customers> GetByCustomerId(int customerId)
        {
            return new SuccessDataResult<Customers>(_customerDal.Get(c=>c.CustomerId==customerId));
        }


        public IDataResult<List<CustomerDetailDto>> GetCustomerDetails()
        {
            return new SuccessDataResult<List<CustomerDetailDto>>();
        }

        public IResult Update(Customers customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult();
        }
    }
}
