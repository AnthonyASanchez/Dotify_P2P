using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using Xamarin.Forms;

namespace Dotify
{
    /// <summary>
    /// Music List encapsulating
    /// </summary>
    [DataContract]
    class MusicList
    {
        // Data values that are stored in Json
        [DataMember(Name = "Music_List")]
        public List<Song> MusicContainer { get; set; }

        public MusicList()
        {
            MusicContainer = new List<Song>();
        }

        public void AddSong(Song obj)
        {
            MusicContainer.Add(obj);
        }
    }
}
