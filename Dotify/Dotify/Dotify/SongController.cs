using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Text;
using Plugin.SimpleAudioPlayer;

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
        
        //Loads default song.
        public static void LoadDefaultSong(){
            var assembly = typeof(App).GetTypeInfo().Assembly;
            Stream audioStream = assembly.GetManifestResourceStream("Dotify.SongResources." + "sample.mp3");
            player.Load(audioStream);
        }

        /// <summary>
        /// Loads a song onto the audio player.
        /// </summary>
        /// <param name="song_name"></param>
        static void LoadSong(string song_name){
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
        /// Pauses the song on the audio player.
        /// </summary>
        public static void PauseSong()
        {
            player.Pause();
        }
    }
}
