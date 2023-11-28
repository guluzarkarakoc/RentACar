using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

//ICarManager carManager = new ICarManager(new InMemoryCarDal());
//foreach (var car in carManager.GetAll())
//{
//    Console.WriteLine(car.Description);
//}

ICarManager carManager = new ICarManager(new EfCarDal());
foreach (var car in carManager.GetAll())
{
    Console.WriteLine(car.Description);
}

ICarManager carManager2 = new ICarManager(new EfCarDal());
foreach (var car in carManager.GetAllByBrandId(2))
{
    Console.WriteLine(car.Description);
}
ICarManager carManager3 = new ICarManager(new EfCarDal());
foreach (var car in carManager.GetAllByDailyPrice(500,900))
{
    Console.WriteLine(car.Description);
}