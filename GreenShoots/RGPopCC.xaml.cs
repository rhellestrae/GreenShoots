using System;
using System.Collections.Generic;
using System.Net;
using GreenShoots.Services;
using LinqToTwitter;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Auth;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace GreenShoots
{
    public partial class RGPopCC : PopupPage
    {
        Xamarin.Auth.Account loggedInAccount;
        PinAuthorizer auth0;

        string saveChallenge;

        private IAuthorizer _auth;

        public RGPopCC(string myObject)
        {
            InitializeComponent();

            App.User = new Entities.UserDetails();

            saveChallenge = myObject;

            if (App.User.IsAuthenticated == true)
            {
                grdShareTwitter.IsVisible = true;
            }

            if (App.User.IsAuthenticated == false)
            {
                var AccountStoreVal = AccountStore.Create().FindAccountsForService("Twitter");

                // if (AccountStoreVal != null)
                //{

                foreach (Xamarin.Auth.Account account in AccountStoreVal)
                {
                    loggedInAccount = account;
                    break;
                }

                grdShareTwitter.IsVisible = true;
                    
                // }
                // else
                //{

                // }
            }

            lblEarnBadge.Text = saveChallenge + " Badge Earned!";

        }

        async private void Button_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.RemovePageAsync(this);
        }

        async void OnTapGestRecogTapOne(object sender, EventArgs args)
        {
            bool answer = await DisplayAlert("Challenge Complete", "Share Out a Tweet?", "Yes", "No");

            // var labelTest = new Uri("https://apple.co/31pfZiv");
            var labelTest = new Uri("https://bit.ly/2ZPx82e");

            if (answer == true)
            {
                if (App.User.IsAuthenticated == true)
                {
                    var testAuth = TwitterService.GetTwitterContext();

                    _auth = testAuth.Authorizer;

                    try
                    {
                        using (var ctx = new TwitterContext(_auth))
                        {
                            await ctx.TweetAsync("Green Shoots " + saveChallenge + " challenge is complete!" + " learn more @ " + labelTest);
                            await DisplayAlert("Green Shoots", "Congrats - Tweet Sent Out", "OK");
                        }
                    }
                    catch (TwitterQueryException ex) when (ex.StatusCode == HttpStatusCode.Forbidden) // In case of duplicate
                    {
                        // return false;
                        await DisplayAlert("Green Shoots", "Duplicate Tweet", "OK");
                    }
                }
                else if (App.User.IsAuthenticated == false)
                {
                    var twitterAuth = new XAuthAuthorizer();
                    var cred = new InMemoryCredentialStore();

                    cred.ConsumerKey = loggedInAccount.Properties["oauth_consumer_key"];
                    cred.ConsumerSecret = loggedInAccount.Properties["oauth_consumer_secret"];
                    cred.OAuthToken = loggedInAccount.Properties["oauth_token"];
                    cred.OAuthTokenSecret = loggedInAccount.Properties["oauth_token_secret"];
                    cred.UserID = ulong.Parse(loggedInAccount.Properties["user_id"]);
                    cred.ScreenName = loggedInAccount.Properties["screen_name"];

                    auth0 = new PinAuthorizer()
                    {
                        CredentialStore = cred,
                    };

                    try
                    {
                        var TwitterCtx = new TwitterContext(auth0);
                        await TwitterCtx.TweetAsync("Green Shoots " + saveChallenge + " challenge is complete!" + " learn more @ " + labelTest);
                        await DisplayAlert("Green Shoots", "Congrats - Tweet Sent Out", "OK");
                    }
                    catch (TwitterQueryException ex) when (ex.StatusCode == HttpStatusCode.Forbidden) // In case of duplicate
                    {
                        // return false;
                        await DisplayAlert("Green Shoots", "Duplicate Tweet", "OK");
                    }

                }
            }
            else if (answer == false)
            {
                
            }
        }

        private async void OSOButton_Clicked(object sender, EventArgs e)
        {
            // var labelTest = new Uri("https://apple.co/31pfZiv");
            var labelTest = new Uri("https://bit.ly/2ZPx82e");

            await Share.RequestAsync(new ShareTextRequest
            {
                Text = "Green Shoots " + saveChallenge + " challenge is complete!" + " learn more @ " + labelTest,
                Title = "Share!"
            });
        }

    }
}
