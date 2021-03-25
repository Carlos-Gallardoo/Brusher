using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Brusher.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ColorComb : ContentPage
    {
        public ColorComb()
        {
            InitializeComponent();
            CarouselView carouselView = new CarouselView();
            
            //var list = new List<string>
            //{
            //    "Hey",
            //    "Did you check the",
            //    "The CarouselView",
            //    "In Xamarin.Forms?"
            //};
            
            //MyCarousel.ItemsSource = list;
           


        }
    }
}