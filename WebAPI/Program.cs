using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddControllers();
            builder.Services.AddSingleton<ICarServices, CarManager>();
            builder.Services.AddSingleton<ICarDal, EfCarDal>();
            builder.Services.AddSingleton<IUserServices, UserManager>();
            builder.Services.AddSingleton<IUserDal, EfUserDal>();
            builder.Services.AddSingleton<IRentalServices, RentalManager>();
            builder.Services.AddSingleton<IRentalDal, EfRentalDal>();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}