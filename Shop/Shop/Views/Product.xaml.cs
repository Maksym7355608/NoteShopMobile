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
    [QueryProperty("ProductId", "id")]
    public partial class Product : ContentPage
    {
        public string ProductId { get; set; }="";
        readonly ProdcutViewModel PD;
        readonly LoginViewModel lvm;
        public Product()
        {
       
            InitializeComponent();
            PD = new ProdcutViewModel();
            lvm = new LoginViewModel();
        }

       async private void Button_Clicked(object sender, EventArgs e)
        {

            if (App.token=="token")
            {
                await Shell.Current.GoToAsync($"//LoginPage?name={""}&password={""}");
            }
            else
            {
                var product = PD.service.GetProductById(Int32.Parse(ProductId));
                lvm.service.addProductTocart(product, App.token);
                await Shell.Current.GoToAsync($"//Cart?");
            }
        }


        protected override void OnAppearing()
        {
            this.ProdName.Text =PD.service.GetProductById(Int32.Parse(ProductId)).name.ToString();
            this.Description.Text = PD.service.GetProductById(Int32.Parse(ProductId)).Description.ToString();
            this.Price.Text = PD.service.GetProductById(Int32.Parse(ProductId)).price.ToString()+"$";
            AddImage();
            base.OnAppearing();
        }

        public void AddImage()
        {
            string categorie = PD.service.GetProductById(Int32.Parse(ProductId)).Categorie.ToString();
            string source = "";
            switch (categorie)
            {
                case "Notebooks":
                    source = "notebooks_malenki.jpg";
                    break;
                case "Pencils":
                    source = "pen";
                    break;
                case "Elastics":
                    source = "elastic";
                    break;

            }

            image.Source = source;
         
        }



    }
}