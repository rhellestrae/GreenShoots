using System;
using System.Collections.Generic;
using System.Diagnostics;
using GreenShoots.Models;
using GreenShoots.ViewModels;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace GreenShoots
{
    public partial class GSDetailsC : ContentPage
    {
        ItemDetailViewModel ViewModel;

        ToDoItem ToDoItem;

        string ChallengeValue;

        bool IsNew;

        public GSDetailsC(string testCV)
        {
            InitializeComponent();

            ChallengeValue = testCV;

            ToDoItem = new ToDoItem();

            ViewModel = new ItemDetailViewModel();

            // first set of five...
            if (ChallengeValue == "Turn off Faucet")
            {
                imgChallenge.Source = ImageSource.FromFile("WaterFaucetLS.jpg");
                lblGreenShoots.Text = "Turn off Faucet";
                lblTurnOffFaucet.Text = "Eight gallons of water a day can be saved by shutting off faucet when brushing teeth; similarly, lots of water can be conserved while washing hands - turn off tap for 20 seconds while scrubbing with soap;";
            }

            if (ChallengeValue == "Unplug Appliances")
            {
                imgChallenge.Source = ImageSource.FromFile("UnplugAppliances.jpg");
                lblGreenShoots.Text = "Unplug Appliances";
                lblTurnOffFaucet.Text = "Household appliances waste energy even if not turned on; instead of leaving coffee makers, toasters, lamps plugged in - make small effort to unplug if not being utilized;";
            }

            if (ChallengeValue == "Cold Water Laundry")
            {
                imgChallenge.Source = ImageSource.FromFile("CWL.jpg");
                lblGreenShoots.Text = "Cold Water Laundry";
                lblTurnOffFaucet.Text = "About 90% of energy used by a washing machine goes towards heating water; to save energy, wash laundry on cold water setting for at least one load a week; plus, cold water may be better for clothes - can remove many stains from clothing;";
            }

            if (ChallengeValue == "Air Dry Cycle")
            {
                imgChallenge.Source = ImageSource.FromFile("AirDryLS.jpg");
                lblGreenShoots.Text = "Air Dry Cycle";
                lblTurnOffFaucet.Text = "Consider selecting an air-dry cycle to dry dishes; this will save 15 percent of dishwasher's energy use; if this option is not available on dishwasher, open door to let dishes dry once load has finished washing;";
            }

            if (ChallengeValue == "Eco-Friendly Products")
            {
                imgChallenge.Source = ImageSource.FromFile("EFP.jpg");
                lblGreenShoots.Text = "Eco-Friendly Products";
                lblTurnOffFaucet.Text = "When it comes to household products, shopping eco-friendly goes a long way; instead of single-use, disposable items, look for green products that are reusable, sustainably sourced, or made of recycled materials;";
            }

            // second set of five...
            if (ChallengeValue == "Cloth Towels")
            {
                imgChallenge.Source = ImageSource.FromFile("CTLS.jpg");
                lblGreenShoots.Text = "Cloth Towels";
                lblTurnOffFaucet.Text = "It is certainly cheaper to hold onto a cloth towel than to buy a new roll of paper towels every week;";
            }

            if (ChallengeValue == "Water Bottles")
            {
                imgChallenge.Source = ImageSource.FromFile("WaterBottles300x200.jpg");
                lblGreenShoots.Text = "Water Bottles";
                lblTurnOffFaucet.Text = "Replace regular single use plastic bottles with some of plastic, glass, and stainless steel reusable water bottles that are all the rage;";
            }

            if (ChallengeValue == "Turn off Lights")
            {
                imgChallenge.Source = ImageSource.FromFile("LightsLS.jpg");
                lblGreenShoots.Text = "Turn off Lights";
                lblTurnOffFaucet.Text = "Turning off lights if not home, or even not in a room, can significantly cut down how much energy is utilized;";
            }

            if (ChallengeValue == "Don't Idle Car")
            {
                imgChallenge.Source = ImageSource.FromFile("IdleCarLS.jpg");
                lblGreenShoots.Text = "Don't Idle Car";
                lblTurnOffFaucet.Text = "If idling in car for more than 2 minutes, turn off engine; this way, car is only releasing emissions while driving;";
            }

            if (ChallengeValue == "Reusable Cups")
            {
                imgChallenge.Source = ImageSource.FromFile("RCLS.jpg");
                lblGreenShoots.Text = "Reusable Cups";
                lblTurnOffFaucet.Text = "Bring a reusable coffee mug to regular coffee shop and ask to put coffee in there - chains like Starbucks and Dunkin will give you a discount;";
            }

            // third set of five...
            if (ChallengeValue == "Rain Water")
            {
                imgChallenge.Source = ImageSource.FromFile("RainWaterBase.jpg");
                lblGreenShoots.Text = "Rain Water";
                lblTurnOffFaucet.Text = "Invest in a rainwater collection system; non-drinking water can be utilized in many ways - like cleaning, watering plants;";
            }

            if (ChallengeValue == "Reuseable Batteries")
            {
                imgChallenge.Source = ImageSource.FromFile("ReuseBatteriesBase.jpg");
                lblGreenShoots.Text = "Reuseable Batteries";
                lblTurnOffFaucet.Text = "Running out of batteries? late night drugstore runs for replacements can be curtailed by using reusable batteries instead;";
            }

            if (ChallengeValue == "Fix Leaky Faucet")
            {
                imgChallenge.Source = ImageSource.FromFile("FixLeakyFaucetBase.jpg");
                lblGreenShoots.Text = "Fix Leaky Faucet";
                lblTurnOffFaucet.Text = "Tiny drops of water add up when it comes to a water bill; tighten up a drippy faucet - cut down on consumption of water;";
            }

            if (ChallengeValue == "Take Stairs")
            {
                imgChallenge.Source = ImageSource.FromFile("TakeStairsBase.jpg");
                lblGreenShoots.Text = "Take Stairs";
                lblTurnOffFaucet.Text = "Taking stairs cuts down on required energy to power an elevator - plus, it is a great workout;";
            }

            if (ChallengeValue == "Ditch Plastic Straws")
            {
                imgChallenge.Source = ImageSource.FromFile("DitchPS.jpg");
                lblGreenShoots.Text = "Ditch Plastic Straws";
                lblTurnOffFaucet.Text = "Americans use 500 million plastic straws each day; replace plastic straws with a set of reusables - made from stainless steel, silicone, bamboo; sea turtles will thank you;";
            }

            // fourth set of five...
            if (ChallengeValue == "Carbon Footprint")
            {
                imgChallenge.Source = ImageSource.FromFile("CarbonFootprintBase.jpg");
                lblGreenShoots.Text = "Carbon Footprint";
                lblTurnOffFaucet.Text = "Calculate carbon footprint - determining amount of CO2 produced through daily routines is a first step; warning: results come with a little sense of guilt;";
            }

            if (ChallengeValue == "Car @ Home")
            {
                imgChallenge.Source = ImageSource.FromFile("CarAtHomeBase.jpg");
                lblGreenShoots.Text = "Car @ Home";
                lblTurnOffFaucet.Text = "Leave car @ home - it has never been easier to ditch a car; organize a carpool with co-workers, use a rideshare app, take public transit - or be most health-conscious, and ride a bike; less cars on road not only means less air pollution, it also means less traffic; not to mention saved gas money :)";
            }

            if (ChallengeValue == "Green Makeover")
            {
                imgChallenge.Source = ImageSource.FromFile("GreenMakeoverBase.jpg");
                lblGreenShoots.Text = "Green Makeover";
                lblTurnOffFaucet.Text = "Give home a green makeover - going green does not necessarily require solar panels; little switches such as buying energy-efficient light bulbs that can save a few dollars in long run;";
            }

            if (ChallengeValue == "Fix Something")
            {
                imgChallenge.Source = ImageSource.FromFile("FixSomethingBase.jpg");
                lblGreenShoots.Text = "Fix Something";
                lblTurnOffFaucet.Text = "There is no reason to throw away something that's on fritz; online tutorials, apps such as TaskRabbit have made it possible to salvage malfunctioning products - without having to shell out money for a replacement;";
            }

            if (ChallengeValue == "Junk Mail")
            {
                imgChallenge.Source = ImageSource.FromFile("JunkMailBase.jpg");
                lblGreenShoots.Text = "Junk Mail";
                lblTurnOffFaucet.Text = "Unsubscribe from junk mail; it is time to save some trees, get name off mailing lists once and for all; also, opting out of a printed phone directory might be worth considering;";
            }

            // fifth set of five...
            if (ChallengeValue == "Go Paperless")
            {
                imgChallenge.Source = ImageSource.FromFile("GoPaperlessBase.jpg");
                lblGreenShoots.Text = "Go Paperless";
                lblTurnOffFaucet.Text = "Everything is online; think about how much paper can be saved by getting bank statements, bills sent electronically - and paid same way; same deal with event, travel tickets; most places don't require physical copies;";
            }

            if (ChallengeValue == "Switch to E-Books")
            {
                imgChallenge.Source = ImageSource.FromFile("EbooksBase.jpg");
                lblGreenShoots.Text = "Switch to E-Books";
                lblTurnOffFaucet.Text = "Switch to e-books - turn page with a single swipe; sure, there is a certain excitement that comes along with cracking open a new book - there is also a certain satisfaction that comes from sliding fingers across a screen; publishers offer interactive editions when an e-book is purchased;";
            }

            if (ChallengeValue == "Unplug at Night")
            {
                imgChallenge.Source = ImageSource.FromFile("UnplugNightBase.jpg");
                lblGreenShoots.Text = "Unplug at Night";
                lblTurnOffFaucet.Text = "Similar to kitchen, household appliances - it helps to get into practice of powering down electronics overnight; it is worth noting devices are wasting energy even if not turned on; best way to maximize energy efficiency is to unplug, shutdown;";
            }

            if (ChallengeValue == "Recycle Electronics")
            {
                imgChallenge.Source = ImageSource.FromFile("RecycleElectronicsBase.jpg");
                lblGreenShoots.Text = "Recycle Electronics";
                lblTurnOffFaucet.Text = "An old iPhone does not need to collect dust in a drawer - and does not need to go in trash; phones, other electronics can be brought to special centers in any area - and some places have buyback programs;";
            }

            if (ChallengeValue == "Add Plants to Home")
            {
                imgChallenge.Source = ImageSource.FromFile("AddPlantsHomeBase.jpg");
                lblGreenShoots.Text = "Add Plants to Home";
                lblTurnOffFaucet.Text = "Bringing a little greenery into a home can help regulate temperature through moisture released into air; this helps reduce energy required to heat, cool a home - plus, they look good!";
            }

        }

        async private void Button_Clicked(object sender, EventArgs e)
        {
            
            string myObject = ChallengeValue;

            ToDoItem.EuroCapital = "Green Shoots";
            ToDoItem.NameNew = myObject;

            IsNew = true;

            ViewModel = new ItemDetailViewModel(ToDoItem, IsNew);
            
            await PopupNavigation.PushAsync(new RGPopCC(myObject), true);

        }

        async private void btnCurrentBadges_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.PushAsync(new RGPopEB(), true);
        }

    }
}
