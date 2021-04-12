using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Shop.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [QueryProperty("CategoriName", "name")]
    public partial class CategoriesNameList : ContentPage
    {
        public string CategoriName { get; set; } = "";

        public CategoriesNameList()
        {
            InitializeComponent();
           
        }


        protected override void OnAppearing()
        {
            this.CategorieName.Text = CategoriName;

            switch (CategoriName)
            {
                case "Notebooks":
                    addNoteBooks();
                    break;
                case "Pencils":
                    addPencils();
                    break;
                case "Elastics":
                    addElastics();
                    break;
                default:
                    break;
            }

            base.OnAppearing();
        }



        public void addNoteBooks()
        {
            for (int i = 0; i < 6; i++)
            {
               
                
                   this.Popular.Children.Add(new StackLayout { Orientation = StackOrientation.Vertical, Padding = new Thickness(0, 0, 0, 20), Children = { AddImage1("Notebooks") , AddLable1($"Product{i}") } });
                
            }
        }

        public void addPencils()
        {
            for (int i = 6; i < 16; i++)
            {
                
                    this.Popular.Children.Add(new StackLayout { Orientation = StackOrientation.Vertical, Padding = new Thickness(0, 0, 0, 20), Children = { AddImage1("Pencils"), AddLable1($"Product{i}") } });
                
            }
        }

        public void addElastics()
        {
            for (int i = 16; i < 20; i++)
            {
               
                
                this.Popular.Children.Add(new StackLayout { Orientation = StackOrientation.Vertical, Padding = new Thickness(0, 0, 0, 20), Children = { AddImage1("Elastics"), AddLable1($"Product{i}") } });
                
            }
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
                Margin = new Thickness(30, 0, 30, 0),
                HorizontalOptions = LayoutOptions.Center,

            };
            click.Tapped += (s, e) => OnLabelClicked(label.Text);
            label.GestureRecognizers.Add(click);
            return label;
        }
     

        public Image AddImage1(string name)
        {
            string source = "";
            switch (name)
            {
                case "Notebooks":
                    source = "notebooks_dyje_malenki";
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
                Margin = new Thickness(0, 0, 0, 0),
                HorizontalOptions = LayoutOptions.CenterAndExpand,
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
