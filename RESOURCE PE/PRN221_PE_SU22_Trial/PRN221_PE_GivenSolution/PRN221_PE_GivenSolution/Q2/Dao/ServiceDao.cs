using Microsoft.EntityFrameworkCore;
using Q2.Models;

namespace Q2.Dao
{
    public class ServiceDao
    {
        private static ServiceDao instance = null;
        private static readonly object instanceLock = new object();
        private static PRN221_Spr22Context dbcontext = new PRN221_Spr22Context();

        private ServiceDao() { }

        public static ServiceDao Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ServiceDao();
                    }
                }
                return instance;
            }
        }


        public IEnumerable<Service> findAll()
        {
            var x = new List<Service>();
            try
            {
                x = dbcontext.Services.Include(o => o.EmployeeNavigation).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return x;
        }

        public List<Service> findAllByMonth(int x)
        {
            List<Service> a = new List<Service>();
            try
            {
                a = dbcontext.Services.Include(o => o.EmployeeNavigation).Where(o => o.Month == x).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return a;
        }

        public List<Service> search(string title)
        {
            List<Service> a = new List<Service>();
            try
            {
                a = dbcontext.Services.Include(o => o.EmployeeNavigation).Where(o => o.RoomTitle.Contains(title)).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return a;
        }


    }



}
