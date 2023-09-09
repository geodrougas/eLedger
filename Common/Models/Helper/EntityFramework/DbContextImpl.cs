using Common.Interfaces.Tools;
using Microsoft.EntityFrameworkCore;

namespace Common.Models.Helper.EntityFramework
{
    public class DbContextImpl : IDbContext
    {
        internal readonly DbContext dbContext;
        private bool _activeTransaction;

        public DbContextImpl(DbContext dbContext)
        {
            this.dbContext = dbContext;
            _activeTransaction = false;
        }

        public void Add(object item)
        {
            dbContext.Add(item);
        }

        public void AddRange(IEnumerable<object> items)
        {
            dbContext.AddRange(items);
        }

        public void Remove(object item)
        {
            dbContext.Remove(item);
        }

        public void RemoveRange(List<object> item)
        {
            dbContext.RemoveRange(item);
        }
        public IUnitOfWork StartTransaction()
        {
            UnitOfWorkImpl unitOfWork = new UnitOfWorkImpl(this, _activeTransaction);
            _activeTransaction = true;
            return unitOfWork;
        }

        public Task<int> CommitTransaction()
        {
            try 
            {
                return dbContext.SaveChangesAsync();
            }
            finally
            {
                _activeTransaction = false;
            }
        }

        public void CancelTransaction()
        {
            try { 
                foreach (var entry in dbContext.ChangeTracker.Entries())
                {
                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            entry.State = EntityState.Unchanged;
                            break;
                        case EntityState.Added:
                            entry.State = EntityState.Detached;
                            break;
                        case EntityState.Deleted:
                            entry.Reload();
                            break;
                        default: break;
                    }
                }
            } finally
            {
                _activeTransaction = false;
            }
        }
    }
}
