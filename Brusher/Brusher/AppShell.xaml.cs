using System;
using System.Collections.Generic;
using Brusher.ViewModels;
using Brusher.Views;
using Xamarin.Forms;

namespace Brusher
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Shell.SetTabBarIsVisible(this, true);
            Shell.SetFlyoutBehavior(this, Xamarin.Forms.FlyoutBehavior.Flyout);
            Shell.SetNavBarHasShadow(this, false);
            Shell.SetNavBarIsVisible(this, true);

        }

        //private async void OnMenuItemClicked(object sender, EventArgs e)
        //{
        //   // await Shell.Current.GoToAsync("//LoginPage");
        //}
    }
}
