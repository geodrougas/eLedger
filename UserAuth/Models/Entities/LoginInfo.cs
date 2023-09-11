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
        public string Application { get; set; }

        public string IPAddress { get; set; }
        public bool RememberMe { get; set; }

        public LoginInfo(
            string userName,
            string password,
            string device,
            string iPAddress,
            bool rememberMe)
        {
            UserName = userName;
            Password = password;
            Application = device;
            RememberMe = rememberMe;
            IPAddress = iPAddress;
        }
    }
}
