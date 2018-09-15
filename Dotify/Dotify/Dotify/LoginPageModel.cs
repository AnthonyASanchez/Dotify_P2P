using System;
using System.ComponentModel;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace Dotify
{
    class LoginPageModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private const string emptyEntryError = "Username or Password cannot be empty";
        private const string wrongPasswordError = "Invalid Username or Password";
        private const String userNameString = "Username";
        private const String passwordString = "Password";
        private String password = string.Empty;
        private String username = string.Empty;
        private String currErrorMessage = string.Empty;

        public INavigation MyNavigation { get; set; }

        //Constructor
        public LoginPageModel(INavigation navigation)
        {
            MyNavigation = navigation;
            SignInCommand = new Command(async () => await SignIn());
            SignUpCommand = new Command(async () => await CreateAccount());
            ForgetPasswordCommand = new Command(async () => await ForgetPassword());
        }

        public Command SignInCommand { get; }

        public Command SignUpCommand { get; }

        public Command ForgetPasswordCommand { get; }

        void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        //Error message to be display
        private void SetErrorMessage(int messageNum)
        {
            switch (messageNum)
            {
                //Empty username or password error
                case 0:
                    currErrorMessage = emptyEntryError;
                    break;
                //Invalid password or username error
                case 1:
                    currErrorMessage = wrongPasswordError;
                    break;
            }
        }

        //The user press the sign in button
        private async Task SignIn()
        {
            ProfileInfo user = JsonUtil.GetJsonUser();
            //If the user didn't enter anything in username or password
            if (String.IsNullOrWhiteSpace(username) || String.IsNullOrWhiteSpace(password))
            {
                //Empty username or password entry
                SetErrorMessage(0);
                OnPropertyChanged(nameof(ErrorLabelMessage));
            }
            else if (!user.username.Equals(username) || !user.password.Equals(Security.Hash(password)))
            {
                //Invalid username or password
                SetErrorMessage(1);
                OnPropertyChanged(nameof(ErrorLabelMessage));
            }
            else
            {
                await MyNavigation.PushModalAsync(new MainPage());
            }


        }

        //The user press the sign up button
        public async Task CreateAccount()
        {
            await MyNavigation.PushModalAsync(new CreateAccount());
        }

        //The user press the forgot password button
        private async Task ForgetPassword()
        {
            await MyNavigation.PushModalAsync(new MainPage());
        }

        public String TestLabel
        {
            get { return $"The username is {Username}"; }
        }

        //Set place holder for username entry
        public string UsernamePlaceHolder
        {
            get { return userNameString; }
        }

        //Set place holder for password entry
        public string PasswordPlaceHolder
        {
            get { return passwordString; }
        }

        //Bind to username entry text
        public String Username
        {
            get { return username; }

            set
            {
                username = value;
            }
        }

        //Bind to password entry text
        public String Password
        {
            get { return password; }

            set
            {
                password = value;
            }

        }

        //Set error message to the label
        public String ErrorLabelMessage
        {
            get { return currErrorMessage; }
        }

    }
}
