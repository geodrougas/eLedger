using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.UserAuth.Models.Entities
{
    public record IdentityToken(
        string UserName,
        string Email,
        bool EmailConfirmed,
        IReadOnlyList<string> Roles
    );
    
}
