using Auth.UserAuth.Models.Entities.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Auth.UserAuth.Tools
{
    public class JwtHelper
    {
        JwtBearerOptions jwtOptions;
        JwtTokenOptions tokenOptions;
        public JwtHelper(
            JwtBearerOptions jwtBearerOptions,
            JwtTokenOptions tokenOptions)
        {
            this.jwtOptions = jwtBearerOptions;
            this.tokenOptions = tokenOptions;
        }

        public string CreateJwt(string token)
        {
            throw new Exception();
        }
    }
}
