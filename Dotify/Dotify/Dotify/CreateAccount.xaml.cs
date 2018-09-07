using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Dotify
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CreateAccount : ContentPage
	{
		public CreateAccount ()
		{
			InitializeComponent ();
        }

        /// <summary>
        /// Once the username entry loses focus, it checks to see if the string in the username
        /// matches the username requirements
        /// </summary>
        /// <param name="sender">The user interface item triggering this method</param>
        /// <param name="args">The arguments passed in as part of this event</param>
        async void CreateAccountUsernameEntryLoseFocus(object sender, FocusEventArgs args)
        {
            // Create the Regex for template matching for the username
            Regex usernameRegex = new Regex("[a-zA-Z]*{3,10}");

            // Retrieve the username 
            string username = CreateAccountUsernameEntry.Text;

            if (!usernameRegex.IsMatch(username))
            {
                CreateAccountUsernameError.IsVisible = true;
            }
            else
            {
                CreateAccountUsernameError.IsVisible = false;
            }

            await;
        }

        async void CreateAccountButtonClicked(object sender, EventArgs args)
        {
            Regex passwordRegex = new Regex("^ (?=.*[a - z])(?=.*[A - Z])(?=.*\\d)(?=.*[^\\da - zA - Z]).{ 8, 15 }$");

            // Retrieve the values from the entries
            string username = CreateAccountUsernameEntry.Text;
            string password = CreateAccountPasswordEntry.Text;
            string verifyPassword = CreateAccountVerifyPasswordEntry.Text;

            if 
        }
	}
}