using Rg.Plugins.Popup.Pages;
using System;
using Xamarin.Forms.Xaml;

namespace Dotify
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Popup : PopupPage
	{
		public Popup ()
		{
			InitializeComponent ();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            string input = PlaylistName.Text;
            PlaylistInfo playlist = new PlaylistInfo(input);
            bool newlistExists = Playlist.PlaylistSet.Contains(playlist);
            if(newlistExists == true)
            {
                await DisplayAlert("Create Failed:", input + " already exists.", "Ok");
            }
            else
            {
                Playlist.PlaylistSet.Add(playlist);
                await DisplayAlert("Confirmation", input + " has been added.", "Ok");
            }
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            string input = PlaylistName.Text;
            PlaylistInfo playlist = new PlaylistInfo(input);
            bool removed = Playlist.PlaylistSet.Remove(playlist);
            if(removed == true)
            {
                await DisplayAlert("Confirmation", input + " has been removed.", "Cancel");
            }
            else
            {
                await DisplayAlert("Could Not Remove", input + " could not be found.", "Cancel");
            }
                 
        }

        private async void Button_Clicked_2(object sender, EventArgs e)
        {
            var main = new MainPage();
            await Navigation.PushModalAsync(main);
        }
    }
}