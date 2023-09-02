using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityReposiyoryBase<Car, CarDbContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetail()
        {
            using (CarDbContext context = new CarDbContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join cc in context.Colors
                             on c.ColorId equals cc.ColorId
                             select new CarDetailDto { BrandName = b.BrandName, CarId = c.CarId, ModelYear = c.ModelYear, DailyPrice = c.DailyPrice , ColorName = cc.ColorName };
                return result.ToList();
            }
        }
    }
}
