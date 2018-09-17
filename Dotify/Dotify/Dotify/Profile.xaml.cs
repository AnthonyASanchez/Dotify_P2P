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
	public partial class Profile : ContentPage
	{
		public Profile ()
		{
			InitializeComponent ();

            // Retrieve the stored ProfileInfo information
            ProfileInfo user = JsonUtil.GetJsonUser();

            // Initialize the ProfileUsernameLabel with the user's username
            ProfileUsernameLabel.Text = user.username;
            // Initialize the date that the user has joined in ProfileDateJoinedEntry
            ProfileDateJoinedEntry.Text = user.dateJoined.ToShortDateString();

            
		}
	}
}