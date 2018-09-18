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

        //Bool determining if the SongController has already install songs.
        static bool installedSongs = false;

        /// <summary>
        /// Constructor which call InstallSongs.
        /// </summary>
        static SongController(){

        }

        /// <summary>
        /// Loads the default songs if they are not yet installed.
        /// </summary>
        public static void LoadDefaultSong() {
            if (!installedSongs)
            {
                InstallSongs();
                installedSongs = true;
            }

            MusicList musicList = JsonUtil.GetJsonMusicList();
            Song s = musicList.MusicContainer[0];
            Stream songStream = new MemoryStream(s.Music);
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
        /// Used to Asynchronously call Install Songs.
        /// </summary>
        /// <returns></returns>
        public static Task InstallSongsAsync()
        {
            return Task.Run(() => InstallSongs());
        }

        /// <summary>
        /// Installs songs, that are preinstalled on app, onto JSON file for streaming pruposes.
        /// </summary>
        public static void InstallSongs()
        {
            // Instantiate the music list
            MusicList musicList = new MusicList();

            String[] songPath = { "Help!", "Come_Together", "Pumped_Up_Kicks", "Feel_Good_Inc", "September", "Hooked_on_a_Feeling", "Lucky_You" };
            String[] songFiles = { "samplehelp", "sample", "pumped_up_kicks", "feel_good_nc", "september", "blue_swede_hooked_on_a_feeling","lucky_you" };
            String[] photoFiles = { "beatles", "beatles", "ftp", "gor", "ewf", "kof", "em" };
            String[] titles = {  "Help!","Come Together", "Pumped Up Kicks", "Feel Good Inc", "September", "Hooked on a Feeling", "Lucky You" };
            String[] artists = {"The Beatles", "The Beatles","Foster the People", "Gorillaz", "Earth, Wind & Fire", "Blue Swede",  "Eminem" };
            String[] albums = {"Beatles", "Beatles", "Pumped Up Kicks", "Demon Days", "September", "Guardians of the Galaxy", "Kamikaze"};
            for (int i = 0; i < 2; i++)
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

                musicList.AddSong(song);
            }

            //Turns the List of Songs into a JSON file.
            string jsonString = JsonUtil.Stringify(musicList);
            JsonUtil.SaveJsonToFile(jsonString, JsonUtil.MUSIC_LIST_FILE);
        }
    }
}
