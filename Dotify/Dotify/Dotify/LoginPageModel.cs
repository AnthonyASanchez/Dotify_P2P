using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Dotify
{
    class LoginPageModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        const string emptyEntryError = "Username or Password cannot be empty";
        const string wrongPasswordError = "Invalid Username or Password";
        const String userNameString = "Username";
        const String passwordString = "Password";
        private String _password;
        private String _username;

        //Constructor
        public LoginPageModel()
        {
            LaunchMainPage = new Command(testWrite);
        }

        public Command LaunchMainPage { get; }

        public Command LaunchCreateAccount { get; }

        public Command LaunchForgotPassword { get; }


        public void testWrite()
        {
            
        }

        public string UsernamePlaceHolder
        {
            get { return userNameString; }
        }

        public string PasswordPlaceHolder
        {
            get { return passwordString; }
        }

        public String Username
        {
            get { return _username; }

            set
            {
                _username = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Username)));
            }
        }

        public String Password
        {
            get { return _password; }

            set
            {
                _password = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Password)));
            }
  
        }

    }
}
