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
        public LoginPage()
        {
            Console.WriteLine("Start");
            InitializeComponent();
        }

        //Sign in button click
        private void SignIn_onClicked(object sender, EventArgs e)
        {
            var userName = userNameEntry.Text;
            var password = passwordEntry.Text;

            ProfileInfo user = JsonUtil.GetJsonUser();
        }

        //Sign up button click
        private void SignUp_onClicked(object sender, EventArgs e)
        {
            //Open create account page
            Navigation.PushModalAsync(new CreateAccount());
        }

    }
}
