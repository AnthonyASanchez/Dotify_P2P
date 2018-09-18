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
        public Search ()
		{
			InitializeComponent ();
            NavigationPage.SetHasBackButton(this, true);
		}

 //       private void MainSearchBar_SearchButtonPressed(object sender, EventArgs e)
 //       {
 //           string keyword = MainSearchBar.Text;
 //          IEnumerable<Song> results = songs.Where(s => s.Album.Contains(keyword) || s.Artist.Contains(keyword) || s.Title.Contains(keyword));
            //IEnumerable<Song> searchResults = results;

 //           MainListView.ItemsSource = results;
            
 //       }

        private void SearchBarTextChange(object sender, EventArgs e)
        {
            //Get the string that the user has entered in the search bar
            string keyword = MainSearchBar.Text;

            //Get the music list that contains the songs
            MusicList musicList = JsonUtil.GetJsonMusicList();

            IEnumerable<Song> results = musicList.MusicContainer.Where(s => s.Album.Contains(keyword) || s.Artist.Contains(keyword) || s.Title.Contains(keyword));

            MainListView.ItemsSource = results;
        }
    }
}