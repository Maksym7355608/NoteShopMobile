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
    public partial class Logout : ContentPage
    {
        public Logout()
        {
            InitializeComponent();
           
           
        }


        async protected override void OnAppearing()
        {
            
            base.OnAppearing();

            App.token = "token";
            TabBar tabBar = AppShell.Current.FindByName<TabBar>("tab");
            tabBar.Items.RemoveAt(tabBar.Items.Count - 1);
            tabBar.Items.Add(new ShellContent() { Title = "Login", Route = "LoginPage", Content = new LoginPage()  });

            await Shell.Current.GoToAsync($"//LoginPage?name={""}&password={""}");
        }
    }
}