using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using Security;
using UIKit;

namespace GreenShoots.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

            // code for removing previous login details - ToDo: remove after testing...

            //const string FIRST_RUN = "hasRunBefore";
            //var userDefaults = NSUserDefaults.StandardUserDefaults;
            //if (!userDefaults.BoolForKey(FIRST_RUN))
            //{
            //    //TODO: remove keychain items
            //    userDefaults.SetBool(true, FIRST_RUN);
            //    userDefaults.Synchronize();

            //    var securityRecords = new[] { SecKind.GenericPassword,
            //                        SecKind.Certificate,
            //                        SecKind.Identity,
            //                        SecKind.InternetPassword,
            //                        SecKind.Key
            //                    };
            //    foreach (var recordKind in securityRecords)
            //    {
            //        SecRecord query = new SecRecord(recordKind);
            //        SecKeyChain.Remove(query);
            //    }

            //}

            // transparent popup page plugin
            Rg.Plugins.Popup.Popup.Init();

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
