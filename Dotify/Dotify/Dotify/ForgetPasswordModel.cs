using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Dotify
{
	public class ForgetPasswordModel : ContentPage
	{

        public event PropertyChangedEventHandler PropertyChanged;

        private const string wrongPasswordError = "Either one or both of the answers are incorrect. Try again.";
        private const String answerString = "Answer";
        private String securityQ1 = string.Empty;
        private String securityQ2 = string.Empty;
        private String securityAnswer1 = string.Empty;
        private String securityAnswer2 = string.Empty;
        private String currErrorMessage = string.Empty;
        private ProfileInfo user = JsonUtil.GetJsonUser();

        public INavigation MyNavigation { get; set; }

        public ForgetPasswordModel (INavigation navigation)
		{
            MyNavigation = navigation;
            securityQ1 = user.securityQuestion1;
            securityQ2 = user.securityQuestion2;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(SecurityQuestion1));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(SecurityQuestion2));     
            ResetCommand = new Command(async () => await ResetPassword());
        }

        public Command ResetCommand { get; }

       //The user press the reset button
        private async Task ResetPassword()
        {
            //Hash the security answers
            String hashPassword1 = Security.Hash(securityAnswer1);
            String hashPassword2 = Security.Hash(securityAnswer2);

            //Get the security answers from the user profile
            //Compare it to the hash and if it matches, and allow the user to verify
            if (user.securityAnswer1.Equals(hashPassword1) && user.securityAnswer2.Equals(hashPassword2))
            {
                await Navigation.PushModalAsync(new ResetPassword());
            }
            else
            {
                currErrorMessage = wrongPasswordError;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(wrongPasswordError));
            }
        }

        //Set place holder for answer entry
        public string AnswerHolder
        {
            get { return answerString; }
        }

        //Bind to securityAnswer1 entry text
        public String SecurityAnswer1
        {
            get { return securityAnswer1; }

            set
            {
                securityAnswer1 = value;
            }
        }

        //Bind to securityAnswer2 entry text
        public String SecurityAnswer2
        {
            get { return securityAnswer2; }

            set
            {
                securityAnswer2 = value;
            }
        }

        //Set error message to the label
        public String ErrorLabelMessage
        {
            get { return currErrorMessage; }
        }
        
        //Bind Security Question 1
        public String SecurityQuestion1
        {
            get { return securityQ1; }

            set
            {
                securityQ1 = user.securityQuestion1;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(SecurityQuestion1));
            }
        }

        //Bind Security Question 2
        public String SecurityQuestion2
        {
            get { return securityQ2; }

            set
            {
                securityQ2 = user.securityQuestion2;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(SecurityQuestion2));
            }
        }

    }
}