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
    public partial class ForgetPassword : ContentPage
    {
        ProfileInfo user = JsonUtil.GetJsonUser();

        int firstPass;
        private bool securityEntry1Empty = true;
        private bool securityEntry2Empty = true;

        public ForgetPassword()
        {
            firstPass = 0;
            SelectQuestions();
            InitializeComponent();
        }

        /**
         * A method that parses the JSON File for the security questions that the user
         * created when they first created their account. 
         * 
         **/
        private void SelectQuestions()
        {
            //Parse the JSON Files and retrieve the four questions
            //From the four, select a random 2
            if (firstPass == 1)
            {
                //Randomize the questions
                FirstQuestion.Text = user.securityQuestion1;
                SecondQuestion.Text = user.securityQuestion2;
            }
            else
            {
                FirstQuestion.Text = user.securityQuestion1;
                SecondQuestion.Text = user.securityQuestion2;
                firstPass = 1;
            }
        }

        //If the verify button is clicked, check to see if the security answer matches the users saved ones
        //If true, send the user to the reset page
        private void VerifyButtonClicked(object sender, EventArgs e)
        {
            //Get the security answers that was randomly selected
            string securityAnswer1 = FirstEntry.Text;
            string securityAnswer2 = SecondEntry.Text;

            //Hash the security answers

            //Get the security answers from the user profile
            //Compare it to the hash and if it matches, and allow the user to verify
            if (user.securityAnswer1.Equals(securityAnswer1) && user.securityAnswer2.Equals(securityAnswer2))
            {
                ResetError.IsVisible = false;
                //Go to the reset page so the user can reset their password.
                Navigation.PopModalAsync(false);
                Navigation.PushModalAsync(new ResetPassword());
            }
            else
            {
                //Disable Verify Button until delay ends
                ButtonVerify.IsEnabled = false;
                ButtonVerify.TextColor = Color.Gray;
                //Display error message
                ResetError.IsVisible = true;
                SelectQuestions();
                //Start lockdown timer
                StartDelay(1000);
                //Reenable verify button
                ButtonVerify.IsEnabled = true;
                ButtonVerify.TextColor = Color.Black;
            }
        }

        //Checks to see if text is entered in the first security entry and allow verify button to be
        //clickable if true and second is true
        private void FirstEntryTextChanged(object sender, EventArgs e)
        {
            Entry securityEntry1 = (Entry)sender;
            if (String.IsNullOrEmpty(FirstEntry.Text))
            {
                securityEntry1Empty = true;
            }
            else
            {
                securityEntry1Empty = false;
            }
            ChangeVerifyButton();
        }

        //Checks to see if text is entered in the second security entry and allow verify button to be
        //clickable if true and first is true
        private void SecondEntryTextChanged(object sender, EventArgs e)
        {
            Entry securityEntry2 = (Entry)sender;
            if (String.IsNullOrEmpty(SecondEntry.Text))
            {
                securityEntry2Empty = true;
            }
            else
            {
                securityEntry2Empty = false;
            }
            ChangeVerifyButton();
        }

        //Allows verify button to be clicked if the fields are not empty
        private void ChangeVerifyButton()
        {
            if (securityEntry1Empty || securityEntry2Empty)
            {
                ButtonVerify.IsEnabled = false;
                ButtonVerify.TextColor = Color.Gray;
            }
            else
            {
                ButtonVerify.IsEnabled = true;
                ButtonVerify.TextColor = Color.Black;
            }
        }

        //Starts a delay of the parameter in milliseconds
        private async void StartDelay(int delay)
        {
            //Get the task delay in the JSON file
            await Task.Delay(delay);
        }
    }
}

