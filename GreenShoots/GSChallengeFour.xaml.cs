using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace GreenShoots
{
    public partial class GSChallengeFour : ContentPage
    {
        string ChallengeValue;

        public GSChallengeFour()
        {
            InitializeComponent();
        }

        async void OnTapGestRecogTapOne(object sender, EventArgs args)
        {
            ChallengeValue = "Carbon Footprint";

            await Navigation.PushAsync(new GSDetailsC(ChallengeValue));
        }

        async void OnTapGestRecogTapTwo(object sender, EventArgs args)
        {
            ChallengeValue = "Car @ Home";

            await Navigation.PushAsync(new GSDetailsC(ChallengeValue));
        }

        async void OnTapGestRecogTapThree(object sender, EventArgs args)
        {
            ChallengeValue = "Green Makeover";

            await Navigation.PushAsync(new GSDetailsC(ChallengeValue));
        }

        async void OnTapGestRecogTapFour(object sender, EventArgs args)
        {
            ChallengeValue = "Fix Something";

            await Navigation.PushAsync(new GSDetailsC(ChallengeValue));
        }

        async void OnTapGestRecogTapFive(object sender, EventArgs args)
        {
            ChallengeValue = "Junk Mail";

            await Navigation.PushAsync(new GSDetailsC(ChallengeValue));
        }

    }
}
