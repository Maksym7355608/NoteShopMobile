using Shop.ViewModels;
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
        ProdcutViewModel pd;
        public CategoriesNameList()
        {
            InitializeComponent();
            pd = new ProdcutViewModel();
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
            foreach (var item in pd.service.GetAllProducts().Where(r=>r.Categorie== "Notebooks").ToList())
            {
               
                
                   this.Popular.Children.Add(new StackLayout { Orientation = StackOrientation.Vertical, Padding = new Thickness(0, 0, 0, 20), Children = { AddImage1("Notebooks") , AddLable1(item.name, item.id) } });
                
            }
        }

        public void addPencils()
        {
            foreach (var item in pd.service.GetAllProducts().Where(r => r.Categorie == "Pencils").ToList())
            {
                
                    this.Popular.Children.Add(new StackLayout { Orientation = StackOrientation.Vertical, Padding = new Thickness(0, 0, 0, 20), Children = { AddImage1("Pencils"), AddLable1(item.name, item.id) } });
                
            }
        }

        public void addElastics()
        {
            foreach (var item in pd.service.GetAllProducts().Where(r => r.Categorie == "Elastics").ToList())
            {


                this.Popular.Children.Add(new StackLayout { Orientation = StackOrientation.Vertical, Padding = new Thickness(0, 0, 0, 20), Children = { AddImage1("Elastics"), AddLable1(item.name,item.id) } });
                
            }
        }

        public Label AddLable1(string name,int id)
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
            click.Tapped += (s, e) => OnLabelClicked(id);
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
    

        async private void OnLabelClicked(int id)
        {
            var name = id;
            await Shell.Current.GoToAsync($"Product?id="+id);
        }

    }
}
