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
    public partial class Categories : ContentPage
    {
        public Categories()
        {

            
            InitializeComponent();

            this.stack.Children.Add(new StackLayout { Orientation = StackOrientation.Horizontal, Padding = new Thickness(0, 0, 0, 30), Children = { AddImage("Notebooks"), AddLable1("Notebooks") } });
            this.stack.Children.Add(new StackLayout { Orientation = StackOrientation.Horizontal, Padding = new Thickness(0, 0, 0, 30), Children = { AddImage("Pencils"), AddLable1("Pencils") } });
            this.stack.Children.Add(new StackLayout { Orientation = StackOrientation.Horizontal, Padding = new Thickness(0, 0, 0, 30), Children = { AddImage("Elastics"), AddLable1("Elastics") } });
        }

        public Label AddLable1(string name)
        {
            var click = new TapGestureRecognizer();

           
            var label = new Label
            {
                Text = name,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                TextColor = Color.FromHex("#000000"),
                FontAttributes = FontAttributes.Bold,
                VerticalOptions = LayoutOptions.Center,
                 

            };
            click.Tapped += (s, e) => OnLabelClicked(label.Text);
            label.GestureRecognizers.Add(click);
            return label;
        }

        async private void OnLabelClicked(string Text)
        {
            var name = Text;
            await Shell.Current.GoToAsync($"CategoriesNameList?name={name}");
        }


        public Image AddImage(string name)
        {
            string source="";
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

    }
}