﻿using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarServices
    {
        IDataResult<List<Car>> GetAll();
        IResult Add(Car car);
        IDataResult<Car> GetCarsByBrandId(int id);
        IDataResult<Car> GetCarsByColorId(int id);

        IDataResult<List<CarDetailDto>> GetCarDetail();
        IResult Delete(Car car);
        IResult Update(Car car);
        IDataResult<Car> GetById(int id);


    }
}
