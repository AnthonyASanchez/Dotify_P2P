using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Dotify
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Playlist : ContentPage
	{
        private static ObservableCollection<PlaylistInfo> playlists = new ObservableCollection<PlaylistInfo> {
            new PlaylistInfo("Workout"),
            new PlaylistInfo("Studying"),
            new PlaylistInfo("Travel")
        };
        
        public Playlist ()
		{
			InitializeComponent ();
            PlaylistView.ItemsSource = playlists;
        }
        public static ObservableCollection<PlaylistInfo> PlaylistSet
        {
            get { return playlists; }
            set { playlists = value; }
        }
        private async void OnButtonClicked(object sender, EventArgs e)
        {            
            var newPage = new UserInput();
            await Navigation.PushModalAsync(newPage);
        }
    }
}