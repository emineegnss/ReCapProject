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
            //DTOTestResult();

            // AddUsers();
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            var result= rentalManager.AddRental(new Rental { RentalId = 5, CarId = 3, CustomerId = 3, RentDate = new DateTime(2023, 07,01), ReturnDate= null });
            Console.WriteLine(result.Messages);


        }

        private static void AddUsers()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            userManager.AddAll(new()
            {
                new() { UserId = 5, FirstName= "Mehmet", LastName= "Gök", Email= "mjhm", Password="fgdf"},
                new() { UserId = 6, FirstName= "Necibe", LastName= "Ayer", Email= "fdgdf", Password="vbcb"},


            });
        }

        private static void DTOTestResult()
        {
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