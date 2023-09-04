using Business.Abstract;
using Business.Constants;
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
    public class RentalManager : IRentalServices
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.Success);
        }

        public IResult AddRental(Rental entity)
        {
            var result = _rentalDal.GetAll(r => r.CarId == entity.CarId && r.ReturnDate == null);
           if (result.Count > 0)
           {
                return new ErrorResult(Messages.Error);

                
            }
           else
            {
                _rentalDal.Add(entity);
                return new SuccessResult(Messages.Success);
            }
            
                
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.GetById(p=>p.RentalId ==id), Messages.Success);
        }
    }
}
