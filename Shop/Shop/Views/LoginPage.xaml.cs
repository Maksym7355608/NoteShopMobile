using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Shop.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [QueryProperty("NAME", "name")]
    [QueryProperty("PASS", "password")]
    public partial class LoginPage : ContentPage
    {
        public string NAME { get; set; } = "";
        public string PASS { get; set; } = "";
        public LoginPage()
        {
            InitializeComponent();
           
        }

        private async void Registration_Clicked(object sender, System.EventArgs e)
        {
            await Shell.Current.GoToAsync("Registration");
        }

        private async void Button_Clicked(object sender, System.EventArgs e)
        {
            App.token = "asdasdasddad";
            TabBar tabBar = AppShell.Current.FindByName<TabBar>("tab");
            tabBar.Items.RemoveAt(tabBar.Items.Count-1);
            tabBar.Items.Add(new ShellContent() { Title = "Logout", Route = "Logout", Content = new Logout() });
            await Shell.Current.GoToAsync($"//HomePage?");
        }


        protected override void OnAppearing()
        {
            
            this.name.Text = NAME;
            this.pass.Text = PASS;
            base.OnAppearing();
        }
       protected override void OnDisappearing()
        {
            NAME ="";
            PASS ="";
         
            base.OnDisappearing();
        }
    }
}