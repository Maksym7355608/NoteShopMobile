using Shop.ViewModels;
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
        readonly LoginViewModel lvm;
        static double sum = 0;
        public Cart()
        {

            InitializeComponent();
            lvm = new LoginViewModel();
        }


        protected override void OnAppearing()
        {
            cart.Children.Clear();
            sum = 0;
            CheckLogin();
            
            Initcart();
            Sum.Text = string.Format("Sum Price:{0}$", sum);
            base.OnAppearing();

        }

        private async Task CheckLogin()
        {
            await Task.Delay(10);
            if (App.token.Equals("token"))
            {
                await Shell.Current.GoToAsync($"//LoginPage?name={""}&password={""}");
            }
        }

        async private void Button_Clicked(object sender, EventArgs e)
        {
            lvm.service.BuyProductsIncart(App.token);
            await Task.Delay(10);
            await Shell.Current.GoToAsync($"//HomePage?");
        }


        private void Initcart()
        {
            if (App.token != "token")
            {
                foreach (var item in lvm.service.GetProductsFromCart(App.token))
                {
                    this.cart.Children.Add(new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        Padding = new Thickness(0, 0, 0, 30),
                        Children = { AddImage(item.Categorie),
                        new StackLayout() { Padding= new Thickness(0,0,0,30),
                            Children = { AddLable(item.name+"$"),AddLable(item.price.ToString())} } }
                    });
                    sum += item.price;
                }
            }
           
           
        }

        public Image AddImage(string name)
        {
            string source = "";
            switch (name)
            {
                case "Notebooks":
                    source = "notebooks_trohu_bilshi_dyje_malenki";
                    break;
                case "Pencils":
                    source = "pencil_dyje_malenkii";
                    break;
                case "Elastics":
                    source = "elastic_dyje_malenkii";
                    break;

            }

            var image = new Image
            {
                Source = source,
                Margin = new Thickness(0, 0, 40, 0),

            };
            return image;
        }
        public Label AddLable(string name)
        {
            var label = new Label
            {
                Text = name,
                HorizontalTextAlignment = TextAlignment.Center,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                TextColor = Color.FromHex("#000000"),
                FontAttributes = FontAttributes.Bold,
            };
            
            return label;
        }
    }
}