using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfColorDal : IColorDal
    {
        public void Add(Color item)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var addedEntity = context.Entry(item);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Color item)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var deletedEntity = context.Entry(item);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Color Get(Expression<Func<Color, bool>> filter)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                return context.Set<Color>().SingleOrDefault(filter);
            }
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                return filter == null ? context.Set<Color>().ToList() : context.Set<Color>().Where(filter).ToList();
            }
        }

        public void Update(Color item)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var updatedEntity = context.Entry(item);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
