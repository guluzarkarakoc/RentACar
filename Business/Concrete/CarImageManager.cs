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
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _ICarImageDal;
        public CarImageManager(ICarImageDal carImageDal)
        {
            _ICarImageDal = carImageDal;
        }

        public IDataResult<List<CarImages>> GetALl()
        {
            return new SuccessDataResult<List<CarImages>>(_ICarImageDal.GetAll());
        }

        public IDataResult<CarImages> GetById(int CarImageId)
        {
            return new SuccessDataResult<CarImages>(_ICarImageDal.Get(i => i.CarImageId == CarImageId));
        }
    }
}
