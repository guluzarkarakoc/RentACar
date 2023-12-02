using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _IUserDal;
        public UserManager(IUserDal userDal)
        {
            _IUserDal = userDal;
        }

        

        IDataResult<List<Users>> IUserService.GetALl()
        {
            return new SuccessDataResult<List<Users>>( _IUserDal.GetAll());
        }

        IDataResult<Users> IUserService.GetById(int UserId)
        {
            return new SuccessDataResult<Users>(_IUserDal.Get(u => u.Id == UserId));
        }
    }
}
