using Xamarin.Forms;

namespace WeatherApplication.Views
{
    public partial class WeatherOverview : TabbedPage
    {
        public WeatherOverview()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}
