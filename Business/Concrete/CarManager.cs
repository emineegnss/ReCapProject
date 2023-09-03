﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarServices
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
           if (car.DailyPrice > 0)
            {
                _carDal.Add(car);
                return new ErrorResult(Messages.Error);
            }
            else
            {
                Console.WriteLine("Araba fiyatı 0'dan fazla olmalıdır");
                return new SuccessResult(Messages.Success);
            }
        }

        public IDataResult<List<CarDetailDto>>  carDetailDtos()
        {
           return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetail(),Messages.Success);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new Result(true); 

        }

       

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<Car>>(_carDal.GetAll(), Messages.Error);
            }
            else
            {
                return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.Success);
            }
         
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetById(p => p.BrandId == id).ToList(), Messages.Success);
        }

        public IDataResult<List<Car>>  GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetById(p => p.ColorId == id).ToList())  ;
        }

        public IResult Update(Car car)
        {
           _carDal.Update(car);
            return new Result(true, Messages.Success);
        }
    }
}
