using Business.Abstract;
using DataAccess.Abstract;
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

        public List<Users> GetALl()
        {
        return _IUserDal.GetAll();
        }

        public Users GetById(int UserId)
        {
            return _IUserDal.Get(u=>u.Id == UserId);
        }
    }
}
