using LinqToTwitter;

using System;
using System.Collections.Generic;
using System.Linq;

using GreenShoots.Entities;

namespace GreenShoots.Services
{
    public class TwitterService
    {
        public static TwitterContext GetTwitterContext()
        {
            var auth = new XAuthAuthorizer()
            {
                CredentialStore = new InMemoryCredentialStore
                {
                    ConsumerKey = "6S9pEMHSbVGswU08RqacNSTMT",
                    ConsumerSecret = "GMYueo1qseedj4VJWGIdwL66jh4tIcCy4JLfKlhW7CIYtRKJ0T",
                    OAuthToken = App.User.Token,
                    OAuthTokenSecret = App.User.TokenSecret,
                    ScreenName = App.User.ScreenName,
                    UserID = ulong.Parse(App.User.TwitterId)
                },
            };
            auth.AuthorizeAsync();

            var ctx = new TwitterContext(auth);

            return ctx;
        }

        public TwitterService()
        {
        }
    }
}
