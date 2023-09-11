using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.UserAuth.Models.Entities
{
    public class RegistrationForm
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string RepeatPassword { get; set; }
        public string Email { get; set; }

        public RegistrationForm(
            string userName,
            string password,
            string repeatPassword,
            string email)
        {
            UserName = userName;
            Password = password;
            RepeatPassword = repeatPassword;
            Email = email;
        }
    }
}
