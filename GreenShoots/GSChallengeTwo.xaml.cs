using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace GreenShoots
{
    public partial class GSChallengeTwo : ContentPage
    {
        string ChallengeValue;

        public GSChallengeTwo()
        {
            InitializeComponent();
        }

        async void OnTapGestRecogTapOne(object sender, EventArgs args)
        {
            ChallengeValue = "Cloth Towels";

            await Navigation.PushAsync(new GSDetailsC(ChallengeValue));
        }

        async void OnTapGestRecogTapTwo(object sender, EventArgs args)
        {
            ChallengeValue = "Water Bottles";

            await Navigation.PushAsync(new GSDetailsC(ChallengeValue));
        }

        async void OnTapGestRecogTapThree(object sender, EventArgs args)
        {
            ChallengeValue = "Turn off Lights";

            await Navigation.PushAsync(new GSDetailsC(ChallengeValue));
        }

        async void OnTapGestRecogTapFour(object sender, EventArgs args)
        {
            ChallengeValue = "Don't Idle Car";

            await Navigation.PushAsync(new GSDetailsC(ChallengeValue));
        }

        async void OnTapGestRecogTapFive(object sender, EventArgs args)
        {
            ChallengeValue = "Reusable Cups";

            await Navigation.PushAsync(new GSDetailsC(ChallengeValue));
        }

    }
}
