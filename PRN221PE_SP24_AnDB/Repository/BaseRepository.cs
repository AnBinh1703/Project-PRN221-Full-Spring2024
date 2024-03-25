using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly Eyeglasses2024DBContext context;
        private readonly DbSet<T> dbSet;

        public BaseRepository()
        {
            context = new Eyeglasses2024DBContext();
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

        public Eyeglasses2024DBContext GetContext()
        {
            return context;
        }
    }
}
