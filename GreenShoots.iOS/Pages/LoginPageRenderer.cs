using System;

using Xamarin.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using GreenShoots;
using GreenShoots.iOS.Pages;
using GreenShoots.Pages;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Json;

[assembly: ExportRenderer(typeof(LoginPage), typeof(LoginPageRenderer))]
namespace GreenShoots.iOS.Pages
{
    public class LoginPageRenderer : PageRenderer
    {
		bool showLogin = true;
		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);

			if (showLogin && App.User == null)
			{
				showLogin = false;

                // Twitter with OAuth1 
                var auth = new OAuth1Authenticator(
                    consumerKey: "6S9pEMHSbVGswU08RqacNSTMT",
                    consumerSecret: "GMYueo1qseedj4VJWGIdwL66jh4tIcCy4JLfKlhW7CIYtRKJ0T",
                    requestTokenUrl: new Uri("https://api.twitter.com/oauth/request_token"), // redirect URL for service;
                    authorizeUrl: new Uri("https://api.twitter.com/oauth/authorize"), // auth URL for service;
                    accessTokenUrl: new Uri("https://api.twitter.com/oauth/access_token"),
                    callbackUrl: new Uri("https://mobile.twitter.com/home")
                );

                var ui = auth.GetUI();

                auth.Completed += (sender, eventArgs) =>
                {
                    DismissViewController(true, null);

                    if (eventArgs.IsAuthenticated)
                    {
                        App.User = new Entities.UserDetails();

                        App.User.Token = eventArgs.Account.Properties["oauth_token"];
                        App.User.TokenSecret = eventArgs.Account.Properties["oauth_token_secret"];
                        App.User.TwitterId = eventArgs.Account.Properties["user_id"];
                        App.User.ScreenName = eventArgs.Account.Properties["screen_name"];

                        // store details for future use;
                        AccountStore.Create().Save(eventArgs.Account, "Twitter");

                        App.SuccessfulLoginAction.Invoke();
                    }

                };

                PresentViewController(ui, true, null);

            }
		}

		public LoginPageRenderer()
        {
        }
    }
}
