using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

//ICarManager carManager = new ICarManager(new InMemoryCarDal());
//foreach (var car in carManager.GetAll())
//{
//    Console.WriteLine(car.Description);
//}

ICarManager carManager1 = new ICarManager(new EfCarDal());
foreach (var car in carManager1.GetAll())
{
    Console.WriteLine(car.Description);
}

ICarManager carManager2 = new ICarManager(new EfCarDal());
foreach (var car in carManager2.GetAllByBrandId(2))
{
    Console.WriteLine(car.Description);
}

ICarManager carManager = new ICarManager(new EfCarDal());
foreach (var car in carManager.GetAll())
{
    Console.WriteLine(car.ModelYear);
}


CarTest(carManager);

static void CarTest(ICarManager carManager)
{
    ICarManager carManager3 = new ICarManager(new EfCarDal());
    foreach (var car in carManager.GetAllByDailyPrice(500, 900))
    {
        Console.WriteLine(car.Description);
    }
}