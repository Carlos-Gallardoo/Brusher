using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Brusher.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
            Shell.SetFlyoutBehavior(this, Xamarin.Forms.FlyoutBehavior.Flyout);
           
            Shell.SetNavBarIsVisible(this, true);
        }
        public ICommand ClickCommand => new Command<string>((url) =>
        {
            // Device.OpenUri(new Uri(url));
         
        });

        private void Button_Clicked(object sender, EventArgs e)
        {
            Browser.OpenAsync("https://www.site24x7.com/es/tools/selector-de-codigo-color.html", BrowserLaunchMode.SystemPreferred);
        }
    }
}