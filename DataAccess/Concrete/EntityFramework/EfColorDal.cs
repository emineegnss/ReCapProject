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
    public class EfColorDal : IColorDal
    {
        public void Add(Color entity)
        {
            using (CarDbContext context = new CarDbContext())
            {
               var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Color entity)
        {
            using (CarDbContext context = new CarDbContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            using (CarDbContext context = new CarDbContext())
            {
                return filter == null
                    ? context.Set<Color>().ToList() 
                    : context.Set<Color>().Where(filter).ToList();
            }
        }

        public List<Color> GetById(Expression<Func<Color, bool>> filter)
        {
            using (CarDbContext context = new CarDbContext())
            {
                return context.Set<Color>().Where(filter).ToList();
            }
        }

        public void Update(Color entity)
        {
            using (CarDbContext context = new CarDbContext())
            {
                var updateEntity = context.Entry(entity);
                updateEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }
    }
}
