using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using GreenShoots.Entities;
using GreenShoots.Pages;
using System.ComponentModel;
using System.Collections.Generic;
using LinqToTwitter;
using Xamarin.Auth;
using System.Linq;
using Xamarin.Essentials;

namespace GreenShoots
{
    public partial class App : Application
    {
        static NavigationPage _NavigationPage;
        public static UserDetails User;
        
        Xamarin.Auth.Account loggedInAccount;

        public static string saveTwitterLogin;
        private string service_id;

        Xamarin.Auth.Account account;

        public App()
        {
            InitializeComponent();

            var AccountStoreVal = AccountStore.Create().FindAccountsForService("Twitter");

            account = AccountStore.Create().FindAccountsForService("Twitter").FirstOrDefault();

            foreach (Xamarin.Auth.Account account in AccountStoreVal)
            {
                loggedInAccount = account;

                saveTwitterLogin = "TwitterLogin";
                MainPage = new NavigationPage(new MyPage(saveTwitterLogin));
            }

            if (account == null)
            {
                MainPage = new NavigationPage(new MyPage());
            }

        }

        public static Action SuccessfulLoginAction
        {
            get
            {
                return new Action(() =>
                {
                    if (App.User != null)
                    {
                        saveTwitterLogin = "TwitterLogin";
                    }
                    
                    App.Current.MainPage = new NavigationPage(new MyPage(saveTwitterLogin));
                });
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
