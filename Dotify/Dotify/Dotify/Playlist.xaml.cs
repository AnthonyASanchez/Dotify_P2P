
using Android.App;
using Android.Views;
using Android.Widget;
using Rg.Plugins.Popup.Services;
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
        private static ObservableCollection<PlaylistInfo> playlists = new ObservableCollection<PlaylistInfo>();
        
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
        private void OnButtonClicked(object sender, EventArgs e)
        {
            var page = new Popup();
            Navigation.PushModalAsync(page);
        }
    }
}