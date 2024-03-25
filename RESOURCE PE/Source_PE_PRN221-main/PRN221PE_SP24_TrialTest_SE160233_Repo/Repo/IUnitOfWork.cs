using PRN221PE_SP24_TrialTest_NguyenTan_Repo;

namespace PRN221PE_SP24_TrialTest_SE160233_Repo.Repo
{
    public interface IUnitOfWork
    {
        IGenericRepository<StoreAccount> StoreAccountRepository { get; }
        IGenericRepository<Eyeglass> EyeglassRepository { get; }
        IGenericRepository<LensType> LensTypeRepository { get; }
        void SaveChanges();
    }
}
