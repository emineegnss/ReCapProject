﻿using Core.DataAccess.EntityFramework;
using Core.Entities;
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
      

        public List<CarDetailDto> GetCarDetail(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (CarDbContext context = new CarDbContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join cc in context.Colors
                             on c.ColorId equals cc.ColorId
                             join carImage in context.CarImages on c.CarId equals carImage.CarId into Images
                             from image in Images.DefaultIfEmpty()
                             select new CarDetailDto { BrandName = b.BrandName, CarId = c.CarId, ModelYear = c.ModelYear, DailyPrice = c.DailyPrice , ColorName = cc.ColorName };
                if(filter == null)
                {
                    return result.ToList();
                }
                else
                {
                    result = result.Where(filter);
                    return result.ToList();
                }
            }
        }

    }
}
