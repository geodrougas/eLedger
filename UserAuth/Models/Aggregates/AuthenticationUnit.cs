using Auth.UserAuth.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.UserAuth.Models.Aggregates
{
    public record AuthenticationUnit(
        string? RefreshToken,
        string AccessToken,
        IdentityToken IdentityToken
    );
}
