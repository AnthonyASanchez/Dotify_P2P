using System;
using System.Collections;
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
	public partial class Search : ContentPage
	{
        private readonly ObservableCollection<Song> songs = new ObservableCollection<Song> {
            new Song("Holiday/Boulevard of Broken Dreams", "Green Day", "American Idiot", BitConverter.GetBytes(234), BitConverter.GetBytes(54)),
            new Song("Payphone", "Maroon 5, Wiz Khalifa", "Overexposed", BitConverter.GetBytes(84), BitConverter.GetBytes(254)),
            new Song("Lose Yourself", "Eminem", "Curtain Call (Deluxe)", BitConverter.GetBytes(47), BitConverter.GetBytes(37)),
            new Song("Fix You", "Coldplay", "X & Y", BitConverter.GetBytes(147), BitConverter.GetBytes(124)),
            new Song("Hall of Fame", "The Scipt, will.i.am", "#3", BitConverter.GetBytes(27), BitConverter.GetBytes(116)),
        };
        public Search ()
		{
			InitializeComponent ();
            NavigationPage.SetHasBackButton(this, true);
            MainListView.ItemsSource = songs;
		}

        private void MainSearchBar_SearchButtonPressed(object sender, EventArgs e)
        {
            string keyword = MainSearchBar.Text;
            IEnumerable<Song> results = songs.Where(s => s.Album.Contains(keyword) || s.Artist.Contains(keyword) || s.Title.Contains(keyword));
            //IEnumerable<Song> searchResults = results;

            MainListView.ItemsSource = results;
            
        }

        private void searchForSong()
        {
            //Get the string that the user has entered in the search bar
            string keyword = MainSearchBar.Text;

            //Deserialize the JSON file (SONG_JSON_FILE)

            //Look through it 
            //var data = File.ReadAlltext(JsonUtil.SONG_JSON_FILE);
            //List<Song> database = JsonConvert.DeserializeObject<List<Song>>(data);

            //JsonUtil.ToObject<Song>(JsonUtil.SONG_JSON_FILE);

            //var results = database.Where(i => i.Track.track_category.ToLower().Contains(keyword)).Select(t => t.Track.track_id);
            //Search through this file for a song that matches the one that the user entered.
        }
    }
}