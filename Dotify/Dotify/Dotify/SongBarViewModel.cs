﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;


namespace Dotify
{
    class SongBarViewModel : INotifyPropertyChanged
    {
        //Two paths for the play and pause buttons.
        string[] _iconSources = { "play_icon.png", "pause_icon.png" };

        //Used to alternate between icons, false will be 'play_icon.png' true will be 'pause_icon.png'.
        bool _iconSelector = false;

        //The path that will be used.
        string _iconPath = "play_icon.png";

        //Event provided by the INotifyPropertyChange, will be used for changes to iconSources.
        public event PropertyChangedEventHandler PropertyChanged;

        //Gesture command.
        ICommand changeIconCommand;

        /// <summary>
        /// Constructor which sets commands of ICommand interface to be used by SongBarView.
        /// </summary>
        public SongBarViewModel()
        {
            changeIconCommand = new Command(() =>
            {
                SetNewPath();
                ChangeMusicStatus();
            });
        }

        //Public property to be used for notify SongBarView
        public string IconPath
        {
            set
            {
                if(_iconPath != value)
                {
                    _iconPath = value;
                    OnPropertyChanged("IconPath");
                }
            }
            get { return _iconPath; }
        }

        /// <summary>
        /// Called by ChangeIconCommand, when icon is pressed, changes IconPath Property.
        /// </summary>
        void SetNewPath()
        {
            _iconSelector = !_iconSelector;
            IconPath = _iconSources[(_iconSelector ? 1 : 0)];
        }

        void ChangeMusicStatus() {
            var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            player.Load("sample.mp3");
            if (_iconSelector)
                player.Play();
            else
                player.Pause();
            
        }

        //ICommand implementations
        public ICommand ChangeIconCommand {
            get { return changeIconCommand; }
        }

        /// <summary>
        /// Generic method for calling OnProperyChanged.
        /// </summary>
        /// <param name="propertyName">The proptery being changed.</param>
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
