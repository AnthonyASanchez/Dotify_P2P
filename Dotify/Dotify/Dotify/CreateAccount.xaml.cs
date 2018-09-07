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
        // Variables for checking the state of the Entry contents
        private bool usernameGood = false;
        private bool passwordGood = false;
        private bool verifyPasswordGood = false;

		public CreateAccount ()
		{
			InitializeComponent ();
        }

        // ------------------------------ Entry Methods ------------------------------

        /// <summary>
        /// Once the username entry loses focus, it checks to see if the string in the username entry
        /// matches the username requirements
        /// </summary>
        /// <param name="sender">The user interface item triggering this method</param>
        /// <param name="args">The arguments passed in as part of this event</param>
        private void CreateAccountUsernameTextChanged(object sender, TextChangedEventArgs args)
        {
            // Create the Regex for template matching for the username
            Regex usernameRegex = new Regex("[a-zA-Z][a-zA-Z0-9]{3,10}$");

            // Retrieve the username 
            string username = CreateAccountUsernameEntry.Text;

            // Check if the username matches the requirements
            if (!usernameRegex.IsMatch(username))
            {
                CreateAccountUsernameError.IsVisible = true;
                usernameGood = false;
            }
            else
            {
                CreateAccountUsernameError.IsVisible = false;
                usernameGood = true;
            }
        }

        /// <summary>
        /// Once the password entry loses focus, it checks to see if the string in the password entry
        /// matches the password requirements
        /// </summary>
        /// <param name="sender">The user interface item triggering this method.</param>
        /// <param name="args">The arguments passed in as part of this event.</param>
        private void CreateAccountPasswordTextChanged(object sender, TextChangedEventArgs args)
        {
            // Create the Regex for template matching for the password
            Regex passwordRegex = new Regex("^ (?=.*[a - z])(?=.*[A - Z])(?=.*\\d)(?=.*[^\\da - zA - Z]).{ 8, 15 }$");

            //Retrieve the password
            string password = CreateAccountPasswordEntry.Text;

            // Check if the password matches the requirements
            if (!passwordRegex.IsMatch(password))
            {
                CreateAccountPasswordError.IsVisible = true;
                passwordGood = false;
            }
            else
            {
                CreateAccountUsernameError.IsVisible = false;
                passwordGood = true;
            }
        }

        private void CreateAccountVerifyPasswordTextChanged(object sender, TextChangedEventArgs args)
        {
            if (passwordGood)
            {
                // Check whether the verify password text matches the password
                string password = CreateAccountPasswordEntry.Text;
                string verifyPassword = CreateAccountVerifyPasswordEntry.Text;

                // Check whether the passwords match each other
                if(String.Equals(password, verifyPassword))
                {
                    CreateAccountVerifyPasswordError.IsVisible = false;
                    verifyPasswordGood = true;
                }
                else
                {
                    CreateAccountVerifyPasswordError.IsVisible = true;
                    verifyPasswordGood = false;
                }
            }
        }

        //------------------------------ Button Methods ------------------------------

        
        private void ChangeCreateAccountButtonColor()
        {
            if (usernameGood && passwordGood && verifyPasswordGood)
            {
                CreateAccountButton.TextColor = Color.Black;
                CreateAccountButton.IsEnabled = true;
            }
            else
            {
                CreateAccountButton.TextColor = Color.Gray;
                CreateAccountButton.IsEnabled = false;
            }
        }

        private void CreateAccountButtonClicked(object sender, EventArgs args)
        {

        }

        private void BackButtonClicked(object sender, EventArgs args)
        {

        }
	}
}