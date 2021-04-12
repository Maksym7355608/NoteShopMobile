using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Shop.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Cart : ContentPage
    {
        public Cart()
        {
           
            InitializeComponent();
          
        }


         protected override void OnAppearing()
        {
            CheckLogin();
            base.OnAppearing();

        }

        private async Task CheckLogin()
        {
            await Task.Delay(10);
            if (App.token.Equals("token"))
            {
              await  Shell.Current.GoToAsync($"//LoginPage?name={""}&password={""}");
            }
        }
        


    }
}