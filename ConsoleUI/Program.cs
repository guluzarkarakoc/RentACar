using Business.Concrete;
using DataAccess.Concrete.InMemory;

ICarManager carManager = new ICarManager(new InMemoryCarDal());
foreach (var car in carManager.GetAll())
{
    Console.WriteLine(car.Description);
}
