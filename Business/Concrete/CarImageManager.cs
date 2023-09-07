using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageServices
    {
        ICarDal _carDal;

        public CarImageManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(CarImage carImagee)
        {
            throw new NotImplementedException();


        }

        public IResult Delete(CarImage carImage)
        {
            throw new NotImplementedException();
        }

        public IResult Update(CarImage carImage)
        {
            throw new NotImplementedException();
        }
    }
}
