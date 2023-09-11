using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.UserAuth.Models.Entities.Options
{
    public record JwtTokenOptions(
        string EncryptionKeyForPrivateKey,
        // Default is 8 hours
        long LifetimeDuration = 60 * 60 * 8
    );
    
}
