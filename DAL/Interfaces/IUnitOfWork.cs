namespace DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<TEntity, TIdentifier> GetRepository<TEntity, TIdentifier>() where TEntity : class;
        void SaveChanges();
    }
}
