using System;
using System.Collections.Generic;
using GreenShoots.Pages;
using Xamarin.Forms;

namespace GreenShoots
{
    public partial class MyPage : ContentPage
    {
        public MyPage()
        {
            InitializeComponent();
        }

        public MyPage(string myObject)
        {
            InitializeComponent();

            if (myObject == "TwitterLogin")
            {
                slSCC.IsVisible = false;
            }

        }

        async void OnTapGestRecogTapOne(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new GSChallengeOne());
        }

        async void OnTapGestRecogTapTwo(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new GSChallengeTwo());
        }

        async void OnTapGestRecogTapThree(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new GSChallengeThree());
        }

        async void OnTapGestRecogTapFour(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new GSChallengeFour());
        }

        async void OnTapGestRecogTapFive(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new GSChallengeFive());
        }

        async private void XAMLSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            bool answer = await DisplayAlert("Login to Twitter?", "Share Completed Challenges", "Yes", "No");

            if (answer == true)
            {
                slSCC.IsVisible = false;
                imgTwitterLogin.IsVisible = true;
            }
            else if (answer == false)
            {
                slSCC.IsVisible = false;
                slSCCTwo.IsVisible = true;
                imgTwitterLogin.IsVisible = false;
            }
        }

        async private void XAMLSwitch_ToggledNew(object sender, ToggledEventArgs e)
        {
            bool answer = await DisplayAlert("Login to Twitter?", "Share Completed Challenges", "Yes", "No");

            if (answer == true)
            {
                slSCC.IsVisible = false;
                slSCCTwo.IsVisible = false;
                imgTwitterLogin.IsVisible = true;
            }
            else if (answer == false)
            {
                slSCC.IsVisible = false;
                slSCCTwo.IsVisible = false;
                imgTwitterLogin.IsVisible = false;
            }
        }

        async void OnTapGestTwitterLogin(object sender, EventArgs args)
        {
            // await DisplayAlert("Alert", "Green Shoots - Twitter Login", "OK");

            if (App.User == null)
            {
                await Navigation.PushModalAsync(new LoginPage());
            }

        }

    }
}
