using System;
using Xamarin.Forms;

namespace GreenShoots.Pages
{
    public class BaseContentPage : ContentPage
    {
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (App.User == null)
            {
                Navigation.PushModalAsync(new LoginPage());
            }
        }

        public BaseContentPage()
        {
        }
    }
}
