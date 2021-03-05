using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf2_UsersApp
{
    class User
    {
        private int id { get; set; }

        private string login, password, email;

        public User()
        { }

        public User(string login, string email, string password)
        {
            this.login = login;
            this.password = password;
            this.email = email;
        }
    }
}
