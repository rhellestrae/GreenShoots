using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace GreenShoots
{
    public partial class GSChallengeOne : ContentPage
    {

        string ChallengeValue;

        public GSChallengeOne()
        {
            InitializeComponent();
        }

        async void OnTapGestRecogTapOne(object sender, EventArgs args)
        {
            ChallengeValue = "Turn off Faucet";

            await Navigation.PushAsync(new GSDetailsC(ChallengeValue));
        }

        async void OnTapGestRecogTapTwo(object sender, EventArgs args)
        {
            ChallengeValue = "Unplug Appliances";

            await Navigation.PushAsync(new GSDetailsC(ChallengeValue));
        }

        async void OnTapGestRecogTapThree(object sender, EventArgs args)
        {
            ChallengeValue = "Cold Water Laundry";

            await Navigation.PushAsync(new GSDetailsC(ChallengeValue));
        }

        async void OnTapGestRecogTapFour(object sender, EventArgs args)
        {
            ChallengeValue = "Air Dry Cycle";

            await Navigation.PushAsync(new GSDetailsC(ChallengeValue));
        }

        async void OnTapGestRecogTapFive(object sender, EventArgs args)
        {
            ChallengeValue = "Eco-Friendly Products";

            await Navigation.PushAsync(new GSDetailsC(ChallengeValue));
        }

    }
}
