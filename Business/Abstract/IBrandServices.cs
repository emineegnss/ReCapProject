using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBrandServices
    {
        IDataResult<List<Brand>> GetAll();
        IDataResult<Brand> GetCarsByBrandId(int brandId);
        IResult Add(Brand brand);

        IResult Delete(Brand brand);
        IResult Update(Brand brand);

    }
}
