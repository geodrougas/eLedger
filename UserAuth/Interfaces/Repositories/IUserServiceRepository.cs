using Auth.Base.Models.Entities;
using Auth.Base.Models.Entities.Criteria;
using Common.Interfaces.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.UserAuth.Interfaces.Repositories
{
    public interface IUserServiceRepository: IDbContext
    {
        public Task<IReadOnlyList<Role>> GetRoles(RoleCriteria roleCriteria);
    }
}
