using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.UserAuth.Models.Entities.Options
{
    public record RefreshTokenOptions(
        string EncryptionKeyForPrivateKey,
        // Default is one week
        long LifetimeDuration = 60 * 60 * 24 * 7
    );
}
