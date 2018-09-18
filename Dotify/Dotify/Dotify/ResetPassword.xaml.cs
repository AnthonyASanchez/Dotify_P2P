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
	public partial class ResetPassword : ContentPage
	{
        ProfileInfo user = JsonUtil.GetJsonUser();

        private bool passwordEntry1Empty;
        private bool passwordEntry2Empty;

        public ResetPassword ()
		{
            passwordEntry1Empty = true;
            passwordEntry2Empty = true;
			InitializeComponent ();
		}

        //Checks to see if text is entered in the first security entry and allow verify button to be
        //clickable if true and second is true
        private void PasswordEntryTextChanged(object sender, EventArgs e)
        {
            Entry securityEntry1 = (Entry)sender;
            if (String.IsNullOrEmpty(newPasswordEntry.Text))
            {
                passwordEntry1Empty = true;
            }
            else
            {
                passwordEntry1Empty = false;
            }
            ChangeVerifyButton();
        }

        //Checks to see if text is entered in the second security entry and allow verify button to be
        //clickable if true and first is true
        private void VerifyPasswordEntryTextChanged(object sender, EventArgs e)
        {
            Entry securityEntry2 = (Entry)sender;
            if (String.IsNullOrEmpty(verifyNewPasswordEntry.Text))
            {
                passwordEntry2Empty = true;
            }
            else
            {
                passwordEntry2Empty = false;
            }
            ChangeVerifyButton();
        }
        //Allows verify button to be clicked if the fields are not empty
        private void ChangeVerifyButton()
        {

            if (passwordEntry1Empty || passwordEntry2Empty)
            {
                resetPasswordButton.IsEnabled = false;
                resetPasswordButton.TextColor = Color.Gray;
            }
            else
            {
                resetPasswordButton.IsEnabled = true;
                resetPasswordButton.TextColor = Color.Black;
            }
        }

        //If the verify button is clicked, check to see if the passwords match. If true, allow the user to
        //reset the password, otherwise ask the user to choose a better password.
        private void VerifyButtonClicked(object sender, EventArgs e)
        {
            Regex passwordRegex = new Regex("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[^\\da-zA-Z]).{8,15}$");
            //If passwords match and they meet password requirements
            NotComplexError.IsVisible = false;
            NotMatchingError.IsVisible = false;
            if (!passwordRegex.IsMatch(newPasswordEntry.Text) || !passwordRegex.IsMatch(verifyNewPasswordEntry.Text))
            {
                NotComplexError.IsVisible = true;
            }
            else if (newPasswordEntry.Text.Equals(verifyNewPasswordEntry.Text))
            {
                //Save the password to JSON file
                //Get the password that the user entered and hash it
                String passwordEntered = Security.Hash(verifyNewPasswordEntry.Text);
                //set the user.password to the new hashed passwor
                user.password = passwordEntered;
                //Stringy the profile info object with the saved changes
                String stringifiedPass = JsonUtil.Stringify(user);
                //Save to Json file
                JsonUtil.SaveJsonToFile(stringifiedPass, JsonUtil.USER_JSON_FILE);
                
                //Send the user to the login page
                Navigation.PopModalAsync(false);
                Navigation.PushModalAsync(new LoginPage());
            }
            else
            {
                NotComplexError.IsVisible = false;
                NotMatchingError.IsVisible = true;
            }
        }
    }
}