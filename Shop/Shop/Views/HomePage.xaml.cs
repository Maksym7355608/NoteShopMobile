using Shop.Models;
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
    public partial class HomePage : ContentPage
    {
        readonly DummyProduct DP;
        public HomePage()
        {
            InitializeComponent();
            DP = new DummyProduct();
            init();

           

        }



        public void init()
        {

            foreach (var item in DP.GetAllProducts())
            {
                this.Popular.Children.Add(new StackLayout { Orientation = StackOrientation.Vertical, VerticalOptions = LayoutOptions.CenterAndExpand, Padding = new Thickness(0, 0, 0, 0), Children = { AddImage(item.Categorie), AddLable(item.name, item.id) } });
            }
            foreach (var item in DP.GetAllProductsWithDiscounts())
            {
                this.Promotions.Children.Add(new StackLayout { Orientation = StackOrientation.Vertical, VerticalOptions = LayoutOptions.CenterAndExpand, Padding = new Thickness(0, 0, 0, 0), Children = { AddImage(item.Categorie), AddLable(item.name, item.id) } });
            }
        } 
        public Label AddLable(string name,int id)
        {
            var click = new TapGestureRecognizer();


            var label = new Label
            {
                Text = name,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                TextColor = Color.FromHex("#000000"),
                FontAttributes = FontAttributes.Bold,
                Margin = new Thickness(30, 0, 30, 0),
             

            };
            click.Tapped += (s, e) => OnLabelClicked(id);
            label.GestureRecognizers.Add(click);
            return label;
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
            

            };
            return image;
        }


        async private void OnLabelClicked(int id)
        {
            Int32 Id = id;
            await Shell.Current.GoToAsync($"Product?id="+id);
        }

        

      
    }
}