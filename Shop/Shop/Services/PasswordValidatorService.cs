using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Services
{
    public class PasswordValidatorService
    {


        public bool IsCorrectLength(string password)
        {
            return password.Length >= 6 & password.Length <= 20;
        }

        public bool IsEqual(string passwrod,string confirmpassword)
        {
            return passwrod.Equals(confirmpassword);
        }
    }
}
