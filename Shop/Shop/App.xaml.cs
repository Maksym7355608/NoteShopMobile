using Xamarin.Forms;

namespace Shop
{
    public partial class App : Application
    {
        public static string token { get; set; }
        public App()
        {

            InitializeComponent();
            token = "token";

            MainPage = new AppShell();
            
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
