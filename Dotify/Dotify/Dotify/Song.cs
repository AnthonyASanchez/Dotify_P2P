using System;
using System.Collections.Generic;
using System.Text;

namespace Dotify
{
    class Song
    {
        string title;
        string artist;
        string album;
        byte[] picture;
        byte[] music;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Artist
        {
            get { return artist; }
            set { artist = value; }
        }

        public string Album
        {
            get { return album; }
            set { album = value; }
        }
        public byte[] Picture
        {
            get { return picture; }
            set { picture = value; }
        }
        public byte[] Music
        {
            get { return music; }
            set { music = value; }
        }
    }
}
