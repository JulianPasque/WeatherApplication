using Prism.Ioc;
using WeatherApplication.ViewModels;
using WeatherApplication.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace WeatherApplication
{
    public partial class App
    {
        /*
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor.
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */

        public App()
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("/WeatherOverview");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<LocationBasedWeather>();
            containerRegistry.RegisterForNavigation<AdressBasedWeather>();
            containerRegistry.RegisterForNavigation<WeatherOverview, WeatherOverviewViewModel>();
            containerRegistry.RegisterForNavigation<CountryPickerPage>();
        }
    }
}
