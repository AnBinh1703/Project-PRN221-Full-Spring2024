using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rpository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly Equipments2024DBContext context;
        private readonly DbSet<T> dbSet;

        public BaseRepository()
        {
            context = new Equipments2024DBContext();
            dbSet = context.Set<T>();
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
            context.SaveChanges();
        }

        public virtual List<T> GetAll()
        {
            return dbSet.ToList();
        }

        public void Save(T entity)
        {
            dbSet.Add(entity);
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            dbSet.Update(entity);
            context.SaveChanges();
        }

        public Equipments2024DBContext GetContext()
        {
            return context;
        }
    }
}
