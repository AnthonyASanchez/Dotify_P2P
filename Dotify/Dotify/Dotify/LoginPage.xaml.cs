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

        public LoginPage()
        {
            InitializeComponent();

            // Check if the user is already logged in
            SystemCache systemCache = JsonUtil.GetJsonSystemCache();
            if (systemCache != null && systemCache.isLoggedIn == SystemCache.LOGGED_IN)
            {
                Navigation.PushModalAsync(new MainPage());
            }
            else
            {
                UsernameLabel.IsVisible = false;
                PasswordLabel.IsVisible = false;
                BindingContext = new LoginPageModel(Navigation);
            }
        }

        //Use to check when to make username label visible
        private void UsernameEntryFocused(object sender, FocusEventArgs e)
        {
            UsernameLabel.IsVisible = true;
        }

        private void UsernameEntryUnfocused(object sender, FocusEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(UsernameEntry.Text))
            {
                UsernameLabel.IsVisible = false;
            }
        }

        //Use to check when to make password label visible
        private void PasswordEntryFocused(object sender, FocusEventArgs e)
        {
            PasswordLabel.IsVisible = true;
        }

        private void PasswordEntryUnfocused(object sender, FocusEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(PasswordEntry.Text))
            {
                PasswordLabel.IsVisible = false;
            }
        }
    }

}
