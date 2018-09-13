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
	public partial class UserInput : ContentPage
	{
        
        public UserInput ()
		{
			InitializeComponent ();
		}

        private void Button_Clicked(object sender, EventArgs e)
        {
            string input = PlaylistName.Text;
            PlaylistInfo playlist = new PlaylistInfo(input);
            Playlist.PlaylistSet.Add(playlist);
            DisplayAlert("Confirmation", input + " has been added.", "Cancel");
        }

        private async void Clicked(object sender, EventArgs e)
        {
            var backPage = new MainPage();
            await Navigation.PushModalAsync(backPage);
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            string input = PlaylistName.Text;
            PlaylistInfo playlist = new PlaylistInfo(input);
            Playlist.PlaylistSet.Remove(playlist);
            DisplayAlert("Confirmation", input + " has been deleted.", "Cancel");
        }
    }
}