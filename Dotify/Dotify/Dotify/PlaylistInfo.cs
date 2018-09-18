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
        public override bool Equals(object obj)
        {
            // Check for null  
            if (ReferenceEquals(obj, null))
                return false;
            // Check for same reference  
            if (ReferenceEquals(this, obj))
                return true;
            var playlist = (PlaylistInfo)obj;
            return this.ListName == playlist.ListName;
        }
        public override int GetHashCode()
        {
            return ListName.GetHashCode();
        }
       
    }
}
