using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace GreenShoots
{
    public partial class GSChallengeFive : ContentPage
    {
        string ChallengeValue;

        public GSChallengeFive()
        {
            InitializeComponent();
        }

        async void OnTapGestRecogTapOne(object sender, EventArgs args)
        {
            ChallengeValue = "Go Paperless";

            await Navigation.PushAsync(new GSDetailsC(ChallengeValue));
        }

        async void OnTapGestRecogTapTwo(object sender, EventArgs args)
        {
            ChallengeValue = "Switch to E-Books";

            await Navigation.PushAsync(new GSDetailsC(ChallengeValue));
        }

        async void OnTapGestRecogTapThree(object sender, EventArgs args)
        {
            ChallengeValue = "Unplug at Night";

            await Navigation.PushAsync(new GSDetailsC(ChallengeValue));
        }

        async void OnTapGestRecogTapFour(object sender, EventArgs args)
        {
            ChallengeValue = "Recycle Electronics";

            await Navigation.PushAsync(new GSDetailsC(ChallengeValue));
        }

        async void OnTapGestRecogTapFive(object sender, EventArgs args)
        {
            ChallengeValue = "Add Plants to Home";

            await Navigation.PushAsync(new GSDetailsC(ChallengeValue));
        }

    }
}
