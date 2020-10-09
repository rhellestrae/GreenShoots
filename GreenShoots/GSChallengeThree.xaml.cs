using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace GreenShoots
{
    public partial class GSChallengeThree : ContentPage
    {
        string ChallengeValue;

        public GSChallengeThree()
        {
            InitializeComponent();
        }

        async void OnTapGestRecogTapOne(object sender, EventArgs args)
        {
            ChallengeValue = "Rain Water";

            await Navigation.PushAsync(new GSDetailsC(ChallengeValue));
        }

        async void OnTapGestRecogTapTwo(object sender, EventArgs args)
        {
            ChallengeValue = "Reuseable Batteries";

            await Navigation.PushAsync(new GSDetailsC(ChallengeValue));
        }

        async void OnTapGestRecogTapThree(object sender, EventArgs args)
        {
            ChallengeValue = "Fix Leaky Faucet";

            await Navigation.PushAsync(new GSDetailsC(ChallengeValue));
        }

        async void OnTapGestRecogTapFour(object sender, EventArgs args)
        {
            ChallengeValue = "Take Stairs";

            await Navigation.PushAsync(new GSDetailsC(ChallengeValue));
        }

        async void OnTapGestRecogTapFive(object sender, EventArgs args)
        {
            ChallengeValue = "Ditch Plastic Straws";

            await Navigation.PushAsync(new GSDetailsC(ChallengeValue));
        }

    }
}
