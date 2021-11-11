using game_project.classes;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
namespace game_project
{
    public partial class OpenScreen : Page
    {
        public int _Animal;  // For future animals.
        DispatcherTimer _EasterEgg;
        int _TimerCounter = 4;
        public OpenScreen()
        {
            this.InitializeComponent();
            if(Music.IsPlaying == false) // using a static bool for playing music between frames and not stoping or replay it
            {
                Music.Input();
                Music.IsPlaying = true;
            }
            _EasterEgg = new DispatcherTimer();
            _EasterEgg.Interval = new TimeSpan(0, 0, 0, 1);
            _EasterEgg.Tick += EasterEgg_Tick;
        }
        #region Easter egg
        private void game_name_Holding(object sender, TappedRoutedEventArgs e)
        {
            _EasterEgg.Start();
        }
        private void EasterEgg_Tick(object sender, object e)
        {
            if (_TimerCounter != 0)
            {
                EasterEggImg.Visibility = Visibility.Visible;
                _TimerCounter--;
            }
            else
            {
                _TimerCounter = 4;
                EasterEggImg.Visibility = Visibility.Collapsed;
                _EasterEgg.Stop();
            }
            
        }
        #endregion
        private void penguin_Tapped(object sender, TappedRoutedEventArgs e)
        {
            _Animal = 0; // for future uses if i will add more animals.
            Frame.Navigate(typeof(MainPage));
        }
          // About button: 
        private void DeleteConfirmation_Click(object sender, RoutedEventArgs e)
        {
            about_btn.Flyout.Hide();
            // the main code for the help button is in the xaml.
        }
        #region Pop up
        private void ClosePopupClicked(object sender, RoutedEventArgs e)
        {
            // If the Popup is open, then close it 
            if (StandardPopup.IsOpen) { StandardPopup.IsOpen = false; }
        }
        // Handles the Click event on the Button on the page and opens the Popup. 
        private void ShowPopupOffsetClicked(object sender, TappedRoutedEventArgs e)
        {
            // Open the Popup if it isn't open already 
            if (!StandardPopup.IsOpen) { StandardPopup.IsOpen = true; }
        }

        #endregion  // Blob button press.

 
    }
}
