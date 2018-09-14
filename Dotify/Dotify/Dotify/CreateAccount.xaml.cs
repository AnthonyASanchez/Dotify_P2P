using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

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
        private bool securityEntry1Good = false;
        private bool securityEntry2Good = false;

        /// <summary>
        /// Constructor object for the CreateAccount content page
        /// </summary>
		public CreateAccount ()
		{
			InitializeComponent ();

            // The list of items to be shown in the security picker lists
            List<string> securityQuestions = new List<string>();
            //Populate the security questions list
            securityQuestions.Add("Favorite Anime");
            securityQuestions.Add("Favorite Ice Cream Flavor");
            securityQuestions.Add("Favorite Color");
            securityQuestions.Add("Favorite Tree");
            securityQuestions.Add("Favorite Sand");
            securityQuestions.Add("Favorite Ox");
            // Populate the Pickers
            SecurityPicker1.ItemsSource = securityQuestions;
            SecurityPicker2.ItemsSource = securityQuestions;
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
            Regex usernameRegex = new Regex("^[a-zA-Z][a-zA-Z0-9]{3,10}$");

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

            // Changes the create account button color if necessary
            ChangeCreateAccountButtonColor();
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
            Regex passwordRegex = new Regex("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[^\\da-zA-Z]).{8,15}$");

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
                CreateAccountPasswordError.IsVisible = false;
                passwordGood = true;
            }

            // Changes the create account button color if necessary
            ChangeCreateAccountButtonColor();
        }

        /// <summary>
        /// Checks whether the password being typed within the verify password entry field matches
        /// the password within the password entry field
        /// </summary>
        /// <param name="sender">The user interface item triggering this method.</param>
        /// <param name="args">The arguments passed in as part of this event.</param>
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

                // Changes the create account button color if necessary
                ChangeCreateAccountButtonColor();
            }
        }

        /// <summary>
        /// Event listener to check whether the security fields are filled in
        /// </summary>
        /// <param name="sender">The user interface item triggering this method.</param>
        /// <param name="args">The arguments passed in as part of this event.</param>
        private void SecurityEntryTextChanged(object sender, TextChangedEventArgs args)
        {
            // Cast the entry object passed in
            Entry securityEntry = (Entry)sender;

            // Get the text from the Entry
            string userInput = securityEntry.Text;
            if (String.IsNullOrEmpty(userInput))
            {
                if(securityEntry.Id == SecurityEntry1.Id)
                {
                    securityEntry1Good = false;
                }
                else
                {
                    securityEntry2Good = false;
                }
            }
            else
            {
                if(securityEntry.Id == SecurityEntry1.Id)
                {
                    securityEntry1Good = true;
                }
                else
                {
                    securityEntry2Good = true;
                }
            }

            // Changes the create account button color if necessary
            ChangeCreateAccountButtonColor();
        }

        //------------------------------ Button Methods ------------------------------

        /// <summary>
        /// Changes the create account button based on the status of the username, password, 
        /// and verify password entry fields
        /// </summary>
        private void ChangeCreateAccountButtonColor()
        {
            if (usernameGood && passwordGood && verifyPasswordGood && securityEntry1Good && securityEntry2Good)
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

        /// <summary>
        /// Once the account button is clicked, allows the creation of a user object
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void CreateAccountButtonClicked(object sender, EventArgs args)
        {
            // Retrieve all of the entries
            string username = CreateAccountUsernameEntry.Text;
            string password = CreateAccountPasswordEntry.Text;
            string securityQuestion1 = (string)SecurityPicker1.SelectedItem;
            string securityAnswer1 = SecurityEntry1.Text;
            string securityQuestion2 = (string)SecurityPicker2.SelectedItem;
            string securityAnswer2 = SecurityEntry2.Text;

            // Create a Profile info
            ProfileInfo userProfile = new ProfileInfo(username, password, 
                securityQuestion1, securityQuestion2, securityAnswer1, securityAnswer2);

            // The json object in string mode
            string jsonString = JsonUtil.Stringify(userProfile);

            // Save the JSon object to file
            JsonUtil.SaveJsonToFile(jsonString, JsonUtil.USER_JSON_FILE);

            // Create a SystemCache object and save it to disk
            SystemCache systemCache = new SystemCache();
            systemCache.isLoggedIn = true;
            string systemCacheString = JsonUtil.Stringify(systemCache);
            JsonUtil.SaveJsonToFile(jsonString, JsonUtil.SYSTEM_CACHE_FILE);

            // Remove the Account Creation and Login page from the stack
            Navigation.PopModalAsync(false);

            // Move to the MainPage after account creation
            Navigation.PushModalAsync(new MainPage());
        }

        /// <summary>
        /// Moves back to the Login Screen
        /// </summary>
        /// <param name="sender">The user interface item triggering this method.</param>
        /// <param name="args">The arguments passed in as part of this event.</param>
        private void BackButtonClicked(object sender, EventArgs args)
        {
            Navigation.PopModalAsync();
        }

        //------------------------------ Picker Methods ------------------------------
        /// <summary>
        /// Allows the user to choose the security questions they would like to answer
        /// </summary>
        /// <param name="sender">The user interface item triggering this method.</param>
        /// <param name="args">The arguments passed in as part of this event.</param>
        private void OnPickerSelectedItem(object sender, EventArgs e)
        {
            // The corresponding security picker object
            Picker securityPicker = (Picker)sender;

            // The item that was selected by the picker
            int selectedIndex = securityPicker.SelectedIndex;

            // If the selected item is valid
            if(selectedIndex != -1)
            {
                // Enable the corresponding entry fields
                if(securityPicker.Id == SecurityPicker1.Id)
                {
                    SecurityEntry1.IsEnabled = true;
                    SecurityPicker2.IsEnabled = true;
                }
                else
                {
                    SecurityEntry2.IsEnabled = true;
                }
            }
        }
    }
}