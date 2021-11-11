using System;
using Windows.Media.Core;
using Windows.Media.Playback;

namespace game_project.classes
{
    class Music
    {
        public static MediaPlayer Player = new MediaPlayer();  // background music
        public static MediaPlayer Notifiction = new MediaPlayer();  // weather notifiction
        public static MediaPlayer Needs = new MediaPlayer();  // need notifiction
        public static bool IsPlaying = false;
        public static async void Input()
        {
            Windows.Storage.StorageFolder folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync(@"Assets\sounds");
            #region background music
            Windows.Storage.StorageFile file = await folder.GetFileAsync("Chill guitar sound to relax - Som tranquilo de violão para relaxar #sleepmusic.mp3");
            Player.Source = MediaSource.CreateFromStorageFile(file);
            Player.Play();
            #endregion
            #region notifiction music
            Windows.Storage.StorageFile file1 = await folder.GetFileAsync("my_weather.mp3");
            Notifiction.AutoPlay = false;
            Notifiction.Source = MediaSource.CreateFromStorageFile(file1);
            Notifiction.Volume = 0.3; // notification volume.
            #endregion
            #region needs music
            Windows.Storage.StorageFile file2 = await folder.GetFileAsync("Tamagotchi.mp3");
            Needs.AutoPlay = false;
            Needs.Source = MediaSource.CreateFromStorageFile(file2);
            Needs.Volume = 0.3; // needs volume.
            #endregion
        }

    }
}
