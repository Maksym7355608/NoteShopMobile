using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Models
{
    public class Login
    {
        private string _email;
        private string _password;
        public string Email { get { return _email; } set { _email = value; } }
        public string Password { get { return _password; } set { _password = value; } }
       public string name { get; set; }
       public string token { get; set; }
        public List<Product> products { get; set; } = new List<Product>();
    }
}
