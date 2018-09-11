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

        public Song()
        {
            title = artist = album = "";
            picture = new byte[15];
            music = new byte[15];
        }

        public Song(string name, string art, string alb, byte[] pic, byte[] song)
        {
            title = name;
            artist = art;
            album = alb;
            picture = pic;
            music = song;
        }

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
