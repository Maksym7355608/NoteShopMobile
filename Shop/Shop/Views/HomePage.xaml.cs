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
        public HomePage()
        {
            InitializeComponent();
            for (int i = 0; i < 4; i++)
            {
                
                this.Popular.Children.Add(new StackLayout { Orientation = StackOrientation.Vertical, VerticalOptions= LayoutOptions.CenterAndExpand, Padding = new Thickness(0, 0, 0, 0), Children = { AddImage(),AddLable($"Product{i}") } });
               
            }

            for (int i = 3; i < 7; i++)
            {

                this.Promotions.Children.Add(new StackLayout { Orientation = StackOrientation.Vertical, VerticalOptions = LayoutOptions.CenterAndExpand, Padding = new Thickness(0, 0, 0, 0), Children = { AddImage(), AddLable($"Product{i}") } });

            }

        }




        public Label AddLable(string name)
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
            click.Tapped += (s, e) => OnLabelClicked(label.Text);
            label.GestureRecognizers.Add(click);
            return label;
        }
      

        public Image AddImage()
        {
            var image = new Image
            {
                Source = "linia",
           
            };
            return image;
        }


        async private void OnLabelClicked(string Text)
        {
            var name = Text;
            await Shell.Current.GoToAsync($"Product?name={name}");
        }

        

      
    }
}