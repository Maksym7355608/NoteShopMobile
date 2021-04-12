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
    [QueryProperty("ProductName", "name")]
    public partial class Product : ContentPage
    {
        public string ProductName { get; set; } = "";
        public Product()
        {
       
            InitializeComponent();
         
        }

       async private void Button_Clicked(object sender, EventArgs e)
        {
            if (App.token=="token")
            {
                await Shell.Current.GoToAsync($"//LoginPage?name={""}&password={""}");
            }
            else
            {
                await Shell.Current.GoToAsync($"//Cart?");
            }
        }

        protected override void OnAppearing()
        {
            this.ProdName.Text = ProductName;
            base.OnAppearing();
        }

       
        
      
    }
}