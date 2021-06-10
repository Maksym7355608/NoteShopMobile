using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Shop.Services;

using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using System;
using Shop.ViewModels;

namespace Shop.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [QueryProperty("NAME", "name")]
    [QueryProperty("PASS", "password")]
    public partial class LoginPage : ContentPage
    {

        public string NAME { get; set; } = "";
        public string PASS { get; set; } = "";
        readonly EmailValidaTionService service = new EmailValidaTionService();
        readonly PasswordValidatorService service2 = new PasswordValidatorService();
        readonly LoginViewModel lvm;
        public LoginPage()
        {

            InitializeComponent();
            lvm = new LoginViewModel();
            

        }

        private async void Registration_Clicked(object sender, System.EventArgs e)
        {
            await Shell.Current.GoToAsync("Registration");
        }

        private async void Button_Clicked(object sender, System.EventArgs e)
        {
            if (service.IsNullOrEmpty(name.Text))
            {
                EmailValidator.Text = "Emaill cant be empty";
            }
            else if (!service.IsEmail(name.Text))
            {
                EmailValidator.Text = "Invalid Email Input ";
            }

            else
            {
                EmailValidator.Text = "";
                if (!service2.IsCorrectLength(pass.Text))
                {
                    passwrodvalidator.Text = "passwrod must be betwenn 6 and 20 characters";
                }
                else
                {
                    Login();
                    await Shell.Current.GoToAsync($"//HomePage?");
                }
            }

        }


        protected override void OnAppearing()
        {

            this.name.Text = NAME;
            this.pass.Text = PASS;
            this.EmailValidator.Text = "";
            this.passwrodvalidator.Text = "";
            base.OnAppearing();
        }
        protected override void OnDisappearing()
        {
            NAME = "";
            PASS = "";

            base.OnDisappearing();
        }

        private void Login()
        {
            if (lvm.service.LoginUser(name.Text,pass.Text))
            {
                App.token = lvm.service.GetToken(name.Text, pass.Text);
                TabBar tabBar = AppShell.Current.FindByName<TabBar>("tab");
                tabBar.Items.RemoveAt(tabBar.Items.Count - 1);
                tabBar.Items.Add(new ShellContent() { Title = "Logout", Route = "Logout", Content = new Logout() });
            }
            else
            {
                passwrodvalidator.Text = "Invalid Login";
            }
            

        }




    }
}