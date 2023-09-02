using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //CarManager carManager = new CarManager(new EfCarDal());
            //foreach (var data in carManager.GetById(4))
            //{
            //    Console.WriteLine(data.ModelYear);
            //}
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.carDetailDtos();
            foreach (var item in result.Data)
            {
                Console.WriteLine(item.BrandName + " " + item.CarId + " " + item.ColorName);
            }
            Console.WriteLine(result.Messages);

        }
    }
}