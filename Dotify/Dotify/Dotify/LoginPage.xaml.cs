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
                BindingContext = new LoginPageModel(Navigation);
            }
        }

    }

}
