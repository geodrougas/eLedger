using Common.Interfaces.Tools;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Helper.EntityFramework
{
    public class UnitOfWorkImpl : IUnitOfWork
    {
        private IDbContext _dbContext;
        private bool _used;
        public UnitOfWorkImpl(IDbContext dbContext, bool used) { 
            this._dbContext = dbContext;
            this._used = used;
        }

        /**
         * <summary>
         * When the '_used' flag is not active
         * Commits the db context changes and activates the flag
         * Otherwise the function does nothing
         * </summary>
         */
        public async Task<int> SaveAsync()
        {
            if (_used)
                return 0;
            
            return await ForceSaveAsync();
        }

        /**
         * <summary>
         * Commits the db context changes and marks the flas '_used' as active
         * </summary>
         */
        public async Task<int> ForceSaveAsync()
        {
            _used = true;
            return await _dbContext.CommitTransaction();
        }

        public bool EndTransaction()
        {
            if (_used)
                return false;

            return ForceCancelTransaction();
        }

        private bool ForceCancelTransaction()
        {
            _used = true;
            _dbContext.CancelTransaction();
            return true;
        }
    }
}
