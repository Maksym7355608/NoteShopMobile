using Shop.Models;
using Shop.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.ViewModels
{
    public class LoginViewModel
    {
        public IDummyLoginRegistrationService service { get; set; }
        public LoginViewModel()
        {
            service = new DummyLoginModel(); //ApiLoginModel
        }
    }
}
