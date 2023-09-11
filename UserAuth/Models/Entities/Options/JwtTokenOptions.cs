using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Common.Models.Helper;
using Microsoft.Extensions.Configuration;

namespace Auth.UserAuth.Models.Entities.Options
{
    public record JwtTokenOptions(
        ECDsa JwtTokenAsymCertificateKey,
        // Default is 8 hours
        long LifetimeDuration
    )
    {
        public static JwtTokenOptions GenerateOptions(IConfiguration configuration)
        {
            long value = configuration["ACCESS_TOKEN_LIFETIME"].ToLong() ?? 60 * 60 * 8;
            string? path = configuration["ACCESS_TOKEN_CERTIFICATE_PATH"];

            if (path == null || !File.Exists(path))
                throw new ApplicationException("Missing or incorrect access token certificate path.");

            var ecdSa = ECDsa.Create();
            ecdSa.ImportFromPem(File.ReadAllText(path));
            
            return new JwtTokenOptions(
                ecdSa,
                value
            );
        }
    }
    
}
