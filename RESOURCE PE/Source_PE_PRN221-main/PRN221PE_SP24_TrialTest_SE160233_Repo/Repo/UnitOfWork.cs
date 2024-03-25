using Microsoft.EntityFrameworkCore;
using PRN221PE_SP24_TrialTest_NguyenTan_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace PRN221PE_SP24_TrialTest_SE160233_Repo.Repo
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly Eyeglasses2024DBContext _context;
        private IGenericRepository<StoreAccount> storeAccountRepository;
        private IGenericRepository<Eyeglass> eyeGlassRepository;
        private IGenericRepository<LensType> lensTypeRepository;

        /*public UnitOfWork(PizzaStoreContext context)
        {
            this.context = context;
            productRepository = new GenericRepository<Product>(context);
            accountRepository = new GenericRepository<Account>(context);
        }*/

        public UnitOfWork(Eyeglasses2024DBContext context)

        {
            _context = context;
        }
        public IGenericRepository<StoreAccount> StoreAccountRepository
        {
            get
            {
                if (storeAccountRepository == null) storeAccountRepository = new GenericRepository<StoreAccount>(_context);
                return storeAccountRepository;
            }
        }
        public IGenericRepository<Eyeglass> EyeglassRepository
        {
            get
            {
                if (eyeGlassRepository == null) eyeGlassRepository = new GenericRepository<Eyeglass>(_context);
                return eyeGlassRepository;
            }
        }
        public IGenericRepository<LensType> LensTypeRepository
        {
            get
            {
                if (lensTypeRepository == null) lensTypeRepository = new GenericRepository<LensType>(_context);
                return lensTypeRepository;
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
