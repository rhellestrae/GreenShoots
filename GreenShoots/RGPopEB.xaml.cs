using System;
using System.Collections.Generic;
using GreenShoots.Services;
using GreenShoots.ViewModels;
using LinqToTwitter;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace GreenShoots
{
    public partial class RGPopEB : PopupPage
    {
        MapsViewModel vm;

        public RGPopEB()
        {
            InitializeComponent();

            vm = new MapsViewModel();

            BindingContext = vm;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            vm.RefreshCommand.Execute(null);
        }

        async private void Button_Clicked(object sender, EventArgs e)
        {
            // await Navigation.PopAsync();

            await PopupNavigation.Instance.RemovePageAsync(this);

        }

    }
}
