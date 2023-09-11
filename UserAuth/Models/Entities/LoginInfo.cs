using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.UserAuth.Models.Entities
{
    public class LoginInfo
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }

        public LoginInfo(
            string userName,
            string password,
            bool rememberMe)
        {
            UserName = userName;
            Password = password;
            RememberMe = rememberMe;
        }
    }
}
