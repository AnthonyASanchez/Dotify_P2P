using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Text;
using PCLStorage;
using Plugin.SimpleAudioPlayer;
using System.Diagnostics;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace Dotify
{
    /// <summary>
    /// Controller for functionality of playing songs.
    /// </summary>
    static class SongController
    {
        //Audio player.
        public static ISimpleAudioPlayer player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;

        //Queue for next songs to be played.
        static Queue<Song> songQueue;

        //List of songs loaded in the controller.
        private static List<Song> songList;

        //Boolean determining if SongController has installed songs yet.
        static bool songsInstalled = false;

        /// <summary>
        /// Constructor which call InstallSongs.
        /// </summary>
        static SongController(){
                InstallSongs();
                songsInstalled = true;
            }

        //Loads default song.
        public static void LoadDefaultSong() {
            songList = JsonUtil.GetJsonSong();
            Song[] s = songList.ToArray();
            Stream songStream = new MemoryStream(s[1].Music);
           player.Load(songStream);
        }

        /// <summary>
        /// Loads a song onto the audio player.
        /// </summary>
        /// <param name="song_name"></param>
        static void LoadSong(string song_name)
        {
            
            var assembly = typeof(App).GetTypeInfo().Assembly;
            Stream audioStream = assembly.GetManifestResourceStream("Dotify.SongResources." + song_name + ".mp3");
            player.Load(audioStream);
        }

        /// <summary>
        /// Plays a song on the audio player.
        /// </summary>
        public static void PlaySong()
        {
            player.Play();
        }

        /// <summary>
        /// Plays a song on the audio player with requested string.
        /// </summary>
        public static void PlaySong(string name)
        {
            player.Play();
        }


        /// <summary>
        /// Pauses the song on the audio player.
        /// </summary>
        public static void PauseSong()
        {
            player.Pause();
        }

        /// <summary>
        /// Installs songs, that are preinstalled on app, onto JSON file for streaming pruposes.
        /// </summary>
        public static void InstallSongs()
        {
           
            String[] songFiles = { "samplehelp", "lucky_you" };
            String[] photoFiles = { "beatles", "em" };
            String[] titles = {  "Help!", "Lucky You" };
            String[] artists = {"The Beatles", "Eminem"};
            String[] albums = {"beatles", "Kamikaze"};
            List<Song> musicList = new List<Song>();
            for (int i = 0; i < songFiles.Length; i++)
            {
                Debug.WriteLine(titles[i]);
                //Gets the assemly where sample songs are located and Converts them into a byte array.
                var assembly = typeof(App).GetTypeInfo().Assembly;
                Stream audioStream = assembly.GetManifestResourceStream("Dotify.SongResources." + songFiles[i] + ".mp3");
                Stream photoStream = assembly.GetManifestResourceStream("Dotify.AlbumCoverResources." + photoFiles[i] + ".jpg");
                Byte[] musicBytes = new byte[audioStream.Length];
                Byte[] photoBytes = new byte[photoStream.Length];

                //Gets the Stream and turns them into byte arrays to construct Song Instance.
                using (MemoryStream ms = new MemoryStream())
                {
                    audioStream.CopyTo(ms);
                    musicBytes = ms.ToArray();
                    photoStream.CopyTo(ms);
                    photoBytes = ms.ToArray();
                }
                String title = titles[i];
                String artist = artists[i];
                String album = albums[i];
                Song song = new Song(title, artist, album, photoBytes, musicBytes);
                musicList.Add(song);

            }

            //Turns the List of Songs into a JSON file.
            string jsonString = JsonUtil.Stringify(musicList);
            JsonUtil.SaveJsonToFile(jsonString, JsonUtil.SONG_JSON_FILE);
        }
    }
}
