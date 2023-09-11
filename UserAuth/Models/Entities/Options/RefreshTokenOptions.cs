using System.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Common.Models.Helper;
using Microsoft.Extensions.Configuration;

namespace Auth.UserAuth.Models.Entities.Options
{
    public record RefreshTokenOptions(
        byte[] RefreshTokenKey,
        // Default is one week
        long LifetimeDuration = 60 * 60 * 24 * 7
    )
    {
        public static RefreshTokenOptions GenerateOptions(IConfiguration configuration)
        {
            long value = configuration["ACCESS_TOKEN_LIFETIME"].ToLong() ?? 60 * 60 * 8;
            string? path = configuration["REFRESH_TOKEN_KEY_PATH"];

            if (path == null || !File.Exists(path))
                throw new ApplicationException("Missing or incorrect access token certificate path.");

            byte[] key = File.ReadAllBytes(path);

            return new RefreshTokenOptions(
                key,
                value
            );
        }
    }
}
