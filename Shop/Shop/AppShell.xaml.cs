using Shop.Views;
using Xamarin.Forms;

namespace Shop
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(Cart), typeof(Cart));
            Routing.RegisterRoute(nameof(Categories), typeof(Categories));
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(Logout), typeof(Logout));
            Routing.RegisterRoute(nameof(Product), typeof(Product));
            Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
            Routing.RegisterRoute(nameof(Registration), typeof(Registration));
            Routing.RegisterRoute("CategoriesNameList", typeof(CategoriesNameList));
            if (App.token.ToLower().Equals("token"))
            {
                tab.Items.Add(new ShellContent() { Title = "Login", Route = "LoginPage", Content = new LoginPage()});
            }

        }

       

    }
}
