using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Dotify
{

    public partial class LoginPage : ContentPage
    {
        const string emptyEntryError = "Username or Password cannot be empty";
        const string wrongPasswordError = "Invalid Username or Password";
        SystemCache sysCache;

        public LoginPage()
        {
            InitializeComponent();

            // Check whether the user is logged in
            sysCache = JsonUtil.GetJsonSystemCache();
            if (sysCache != null && sysCache.isLoggedIn == true)
            {
                Navigation.PushModalAsync(new MainPage());
            }
        }

        //Sign in button click
        private void SignIn_onClicked(object sender, EventArgs e)
        {
            //Declare a variable to tempary store username and password
            var userName = userNameEntry.Text;
            var password = passwordEntry.Text;


            //Get the user profile information
            ProfileInfo user = JsonUtil.GetJsonUser();


            //Check weather username or password entry is empty or contained white spaces
            if(String.IsNullOrWhiteSpace(userName) || String.IsNullOrWhiteSpace(password)){
                errorLabel.Text = emptyEntryError;
                errorLabel.TextColor = Color.Red;
            }
            //Check if the entered password is the same as the user set password
            else if(user.username.Equals(userName) && user.password.Equals(password)){
                errorLabel.TextColor = Color.Transparent;
                sysCache.isLoggedIn = true;
                Navigation.PushModalAsync(new MainPage());
            }
            //Username or password did not match
            else{
                errorLabel.Text = wrongPasswordError;
                errorLabel.TextColor = Color.Red;
            }

        }

        private void Handle_Focused()
        {

        }

        //Sign up button click
        private void SignUp_onClicked(object sender, EventArgs e)
        {
            //Open create account page
            Navigation.PushModalAsync(new CreateAccount());
        }

    }
}
