using Auth.Base.Models;
using Auth.Base.Models.Entities;
using Auth.Base.Models.Entities.Criteria;
using Auth.UserAuth.Interfaces.Repositories;
using Auth.UserAuth.Models;
using Common.Models.Helper.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Infrastructure.Repositories
{
    public class UserRepository: DbContextImpl, IUserServiceRepository
    {
        private readonly AuthDbContext _dbContext;

        public UserRepository(AuthDbContext dbContext): base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyList<Role>> GetRoles(RoleCriteria roleCriteria)
        {
            IQueryable<Role> roles = _dbContext.Roles;

            if (roleCriteria.IsBase != null)
                roles = roles.Where(m => m.IsBase == roleCriteria.IsBase);

            return await roles.ToListAsync();
        }
    }
}
