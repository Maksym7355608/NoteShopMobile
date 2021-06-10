using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Shop.Services;
using Shop.ViewModels;

namespace Shop.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registration : ContentPage
    {

        readonly EmailValidaTionService serv = new EmailValidaTionService();
        readonly PasswordValidatorService serv2 = new PasswordValidatorService();
        readonly LoginViewModel rvm;
        public Registration()
        {
            InitializeComponent();
            rvm = new LoginViewModel();
        }


        async private void Button_Clicked(object sender, EventArgs e)
        {
            emailvalidator.Text = "";
            passwordvalidator.Text = "";

            if (serv.IsNullOrEmpty(Name1.Text))
            {
                namevalid.Text = "Name cant be empty";
            }

            else if (serv.IsNullOrEmpty(Name.Text))
            {
                namevalid.Text = "";
                emailvalidator.Text = "Emaill cant be empty";
            }
            else if (!serv.IsEmail(Name.Text))
            {
                emailvalidator.Text = "Invalid Email Input ";
            }

            else
            {

                 if (serv.IsNullOrEmpty(password.Text)||!serv2.IsCorrectLength(password.Text))
                {
                    passwordvalidator.Text = "passwrod must be betwenn 6 and 20 characters";
                }
                else if (!serv2.IsEqual(password.Text, confirm.Text)){
                    passwordvalidator.Text = "Passwords not equal";
                }

                else
                {
                   
                     Regist();
                }
            }

        }




        public async void Regist()
        {
            if (rvm.service.LoginUser(Name.Text,password.Text))
            {
                passwordvalidator.Text = "User With this login already exist";
            }
            else
            {
                rvm.service.Registration(Name.Text, Name1.Text, password.Text);
                string name = this.Name.Text;
                string pass = this.password.Text;
                await Shell.Current.GoToAsync($"//LoginPage?name={name}&password={pass}");
            }
        }



    }
}