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

        private void VerifyButtonClicked(object sender, EventArgs e)
        {
            //If passwords match and they meet password requirements
            if (newPasswordEntry == verifyNewPasswordEntry)
            {
                //Save the password
                String password = verifyNewPasswordEntry.Text;
                JsonUtil.ToObject<ProfileInfo>(password);
                //Send the user to the main page
                Navigation.PopModalAsync(false);
                Navigation.PushModalAsync(new MainPage());
            }
            else
            {
                //Ask the user to choose a better password
                NotMatchingError.IsVisible = true;
            }
        }


    }
}