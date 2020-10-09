using System;

using Xamarin.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using GreenShoots;
using GreenShoots.Droid.Pages;
using GreenShoots.Pages;
using Android.App;

[assembly: ExportRenderer(typeof(LoginPage), typeof(LoginPageRenderer))]
namespace GreenShoots.Droid.Pages
{
    public class LoginPageRenderer : PageRenderer
    {
        bool showLogin = true;

        public LoginPageRenderer()
        {
        }

		protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
		{
			base.OnElementChanged(e);

			// this is a ViewGroup - so should be able to load an AXML file and FindView<>
			var activity = this.Context as Activity;

			if (showLogin && App.User == null)
			{
				showLogin = false;

				//Twitter with oauth1 
				var auth = new OAuth1Authenticator(
					consumerKey: "6S9pEMHSbVGswU08RqacNSTMT",
					consumerSecret: "GMYueo1qseedj4VJWGIdwL66jh4tIcCy4JLfKlhW7CIYtRKJ0T",
					requestTokenUrl: new Uri("https://api.twitter.com/oauth/request_token"), // the redirect URL for the service
					authorizeUrl: new Uri("https://api.twitter.com/oauth/authorize"), // the auth URL for the service
					accessTokenUrl: new Uri("https://api.twitter.com/oauth/access_token"),
					callbackUrl: new Uri("https://mobile.twitter.com/home")
				);

				auth.Completed += (sender, eventArgs) =>
				{
					// DismissViewController(true, null);

					if (eventArgs.IsAuthenticated)
					{
						App.User = new Entities.UserDetails();
						// Use eventArgs.Account to do wonderful things
						App.User.Token = eventArgs.Account.Properties["oauth_token"];
						App.User.TokenSecret = eventArgs.Account.Properties["oauth_token_secret"];
						App.User.TwitterId = eventArgs.Account.Properties["user_id"];
						App.User.ScreenName = eventArgs.Account.Properties["screen_name"];

						//Store details for future use, 
						//so we don't have to promt authentication screen everytime
						AccountStore.Create().Save(eventArgs.Account, "Twitter");

						// Xamarin.Essentials.SecureStorage.

						App.SuccessfulLoginAction.Invoke();
					}
					//else
					//{
					//    // The user cancelled
					//}
				};

				// PresentViewController(auth.GetUI(), true, null);
				activity.StartActivity(auth.GetUI(activity));
			}

			
		}

	}
}
