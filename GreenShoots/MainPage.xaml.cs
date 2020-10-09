using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GreenShoots
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            // await Navigation.PushAsync(new Page1());
        }

        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            // await Navigation.PushAsync(new Page2());
        }

        private async void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            // await Navigation.PushAsync(new Page3());
        }

        private async void TapGestureRecognizer_Tapped_3(object sender, EventArgs e)
        {
            // await Navigation.PushAsync(new Page4());
        }

    }
}
