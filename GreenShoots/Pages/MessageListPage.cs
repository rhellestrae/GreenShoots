using System;
using LinqToTwitter;
using Xamarin.Forms;
using GreenShoots.Services;

namespace GreenShoots.Pages
{
    public class MessageListPage : BaseContentPage
    {
        TwitterService testTS = new TwitterService();

        private IAuthorizer _auth;

        XAuthAuthorizer testAuth = new XAuthAuthorizer();

        private Command _sendTweet;

        private Editor editorTweet;

        public MessageListPage()
        {
            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                Children = {
                    new Label {
                        HorizontalTextAlignment = TextAlignment.Center,
                        Text = "Welcome to Xamarin!!"
                    }
                }
            };
        }

        public Page GetTimeline()
        {
            var listView = new ListView
            {
                RowHeight = 50
            };

            editorTweet = new Editor
            {
                WidthRequest = 200,
                HeightRequest = 50,
                BackgroundColor = Color.LightBlue
            };

            var btnSendTweet = new Button
            {
                WidthRequest = 100,
                HeightRequest = 50,
                BackgroundColor = Color.Red,
                TextColor = Color.White,
                Text = "Send Tweet"
            };
            btnSendTweet.Clicked += OnButtonClicked;

            var stackLayoutTweet = new StackLayout
            {
                Margin = new Thickness(10, 10, 10, 20),
                Orientation = StackOrientation.Horizontal,
                Children = { editorTweet, btnSendTweet }
            };

            // listView.ItemsSource = TwitterService.Search();
            listView.ItemTemplate = new DataTemplate(typeof(TextCell));
            listView.ItemTemplate.SetBinding(TextCell.TextProperty, "Value");

            return new ContentPage
            {
                Content = new StackLayout
                {
                    Orientation = StackOrientation.Vertical,
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    Children = { listView, stackLayoutTweet }
                }
            };
        }

        async void OnButtonClicked(object sender, EventArgs args)
        {
            // await label.RelRotateTo(360, 1000);
            await DisplayAlert("Alert", "Share Out a Tweet?", "Yes", "No");

            var testAuth = TwitterService.GetTwitterContext();

            _auth = testAuth.Authorizer;

            using (var ctx = new TwitterContext(_auth))
            {
                await ctx.TweetAsync(editorTweet.Text);
            }

            // _auth = (IAuthorizer)testAuth;

            // _auth = (IAuthorizer)TwitterService.GetTwitterContext();

            // SendTweet.ChangeCanExecute();
        }

    }
}
