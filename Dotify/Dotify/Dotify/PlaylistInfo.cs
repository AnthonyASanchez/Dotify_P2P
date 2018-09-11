using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Dotify
{
    public class PlaylistInfo
    {
        string listName;
        List<Song> songs;

        public PlaylistInfo(string name)
        {
            this.ListName = name;
            songs = new List<Song>();
        }
        public string ListName
        {
            get { return listName; }
            set { listName = value; }
        }
       
    }
}
