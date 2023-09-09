using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces.Tools
{
    public interface IUnitOfWork
    {
        /**
         * <summary>
         * When the '_used' flag is not active
         * Commits the db context changes and activates the flag
         * Otherwise the function does nothing
         * </summary>
         */
        public Task<int> SaveAsync();


        /**
         * <summary>
         * Commits the db context changes and marks the flas '_used' as active
         * </summary>
         */
        public Task<int> ForceSaveAsync();

        bool EndTransaction();
    }
}
