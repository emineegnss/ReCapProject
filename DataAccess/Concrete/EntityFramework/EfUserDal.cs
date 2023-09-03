using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityReposiyoryBase<User, CarDbContext>, IUserDal
    {
        

        public void AddAll(List<User> users)
        {
            using (CarDbContext context = new CarDbContext())
            {

                context.AddRange(users);
                context.SaveChanges();
            }
        }
    }
}
