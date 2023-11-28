using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        private readonly List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>()
            {

                new Car {CarId=1, BrandId=2, ColorId=1, DailyPrice=750, ModelYear=2017, Description="Kia Stonic"},
                new Car {CarId=2, BrandId=2, ColorId=5, DailyPrice=650, ModelYear=2010, Description="Kia Rio"},
                new Car {CarId=3, BrandId=6, ColorId=3, DailyPrice=900, ModelYear=2020, Description="Opel Mokka"},
                new Car {CarId=4, BrandId=3, ColorId=3, DailyPrice=970, ModelYear= 2010, Description="Dacia Duster"},
                new Car {CarId=5, BrandId=4, ColorId=4, DailyPrice=950, ModelYear=2020, Description="Skoda Scala"}
            };

        }


        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {

            Car CarToDelete;
            CarToDelete = _cars.SingleOrDefault(t => t.CarId == car.CarId);
            _cars.Remove(CarToDelete);

            //Car CarToDelete = null;
            //foreach (Car t in _cars)
            //{
            //    if (t.CarId == car.CarId) { CarToDelete = t; }
            //}_cars.Remove(CarToDelete);

        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return _cars;
        }

        public List<Car> GetById(int BrandId)
        {
            return _cars.Where(t => t.BrandId == BrandId).ToList();
        }

        public void Update(Car car)
        {
            Car CarToUpdate = _cars.SingleOrDefault(t => t.CarId == car.CarId);
            CarToUpdate.ModelYear = car.ModelYear;
            CarToUpdate.Description = car.Description;
            CarToUpdate.DailyPrice = car.DailyPrice;
        }
    }
}

      

       
     
