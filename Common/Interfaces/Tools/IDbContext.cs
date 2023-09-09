namespace Common.Interfaces.Tools
{
    public interface IDbContext
    {
        void Add(object item);
        void AddRange(IEnumerable<object> items);
        void Remove(object item);
        void RemoveRange(List<object> item);

        /**
         * <summary>
         * A function that marks the db context as having an open transaction.
         * The first time this method is called before commiting the transaction, 
         * the db context will be marked as unused and therefore able to commit.
         * The second and later times this method is called, the db context will be marked
         * as used, and will not commit any changes to the database. Unless ForceSaveAsync get's called.
         * </summary>
         */
        IUnitOfWork StartTransaction();
        Task<int> CommitTransaction();
        void CancelTransaction();
    }
}