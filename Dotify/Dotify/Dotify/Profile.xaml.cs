using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Dotify
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Profile : ContentPage
	{
		public Profile ()
		{
			InitializeComponent ();

            // Retrieve the stored ProfileInfo information
            ProfileInfo user = JsonUtil.GetJsonUser();

            // Initialize the ProfileUsernameLabel with the user's username
            ProfileUsernameLabel.Text = user.username;
            // Initialize the date that the user has joined in ProfileDateJoinedEntry
            ProfileDateJoinedEntry.Text = user.dateJoined.ToShortDateString();
        }

        /// <summary>
        /// Event of when the user presses the button
        /// </summary>
        /// <param name="sender">The sending object</param>
        /// <param name="args">The event</param>
        private void OnLogOutButtonClicked(object sender, EventArgs args)
        {
            SystemCache systemCache = JsonUtil.GetJsonSystemCache();
            systemCache.isLoggedIn = SystemCache.LOGGED_OUT;
            string jsonObject = JsonUtil.Stringify(systemCache);
            JsonUtil.SaveJsonToFile(jsonObject, JsonUtil.SYSTEM_CACHE_FILE);
            Navigation.PushModalAsync(new LoginPage());
        }


        private void OnProfileButtonClicked(object sender, EventArgs args)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                await DisplayAlert("Warning!", "An account already exists, creating an account" +
                "will delete the existing account.", "OK");
            });
        }
    }
}