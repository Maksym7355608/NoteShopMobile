using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Shop.Services
{
    public class EmailValidaTionService
    {
        public string regex = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";

        public bool IsNullOrEmpty(string email)
        {
            return string.IsNullOrWhiteSpace(email);
        }

        public bool IsEmail(string email)
        {
            return Regex.IsMatch(email, regex);
        }

    }
}
