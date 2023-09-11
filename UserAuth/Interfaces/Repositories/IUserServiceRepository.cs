using Auth.Base.Models.Entities;
using Auth.Base.Models.Entities.Criteria;
using Common.Interfaces.Tools;

namespace Auth.UserAuth.Interfaces.Repositories
{
    public interface IUserServiceRepository: IDbContext
    {
        public Task<IReadOnlyList<Role>> GetRoles(RoleCriteria roleCriteria);
    }
}
