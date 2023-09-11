using Auth.Base.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace Auth.UserAuth.Models.Entities
{
    public class User : IdentityUser<Guid>
    {
        public List<Role> Roles { get; set; } = new List<Role>();
    }
}