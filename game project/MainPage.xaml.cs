using game_project.classes;
using System;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
using Windows.UI.ViewManagement;
using Windows.ApplicationModel.Core;
namespace game_project
{
    public partial class MainPage
    {
        #region Data members
        #region Clocks
        DispatcherTimer _Timer = new DispatcherTimer();
        DispatcherTimer _BarTimeWeather = new DispatcherTimer();
        #endregion
        Random Rand = new Random(); // For random weather option
        GifTimer _Animation;
        seasons _WeatherChoices;
        Winter _Winter;
        Summer _Summer;
        int _WeatherOption; // for interaction with bars.
        int _WeatherLastPlace; // for saving the last weather option.
        #endregion
        public MainPage()
        {
            this.InitializeComponent();
            // For openning size.
            ApplicationView.PreferredLaunchViewSize = new Size(1280, 720);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            // Calibration befor starting.
            _WeatherChoices = new seasons(); // Weather choices class.
            _Winter = new Winter();
            _Summer = new Summer();
            _Animation = new GifTimer(gif_image);  // Gif animation class
            _BarTimeWeather.Interval = new TimeSpan(0, 0, 30); // Every 30 sec change weather
            _BarTimeWeather.Tick += BarTimeWeatherTick;
            _Timer.Interval = new TimeSpan(0, 0, 0, 1); // count each sec in the game for timer view and bars
            _Timer.Tick += GameProgress;
            _Timer.Start();
        }
        #region Help button
        private void DeleteConfirmation_Click(object sender, RoutedEventArgs e)
        {
            help_btn.Flyout.Hide();
            // the main code for the help button is in the xaml.
        }
        #endregion
        #region Game_counters
        // For real game add a "0" to the counters: eat, sleep. love and play.
        int EatCounter = 20;
        int SleepCounter = 25;
        int LoveCounter = 15;
        int PlayCounter = 22;
        int SoundCounterEat = 0;
        int SoundCounterSleep = 0;
        int SoundCounterLove = 0;
        int SoundCounterPlay = 0;
        int DeathCounter = 0;
        private void GameProgress(object sender, object e)
        {
            if (EatCounter == 0)
            {
                if (_WeatherOption == 3 || _WeatherOption == 1) // for weather options, if hot the pet will be hungry faster.
                    eat_bar.Value -= 2;
                else 
                    eat_bar.Value--; // regular option
                if (eat_bar.Value == 0)
                {
                    // tamaguchi RIP
                    if (DeathCounter < 3) // delay the reset screen by 3 sec to see the death animation
                    {
                        _Animation.StartAnimation(3, 3);
                        DeathCounter++;
                    }
                    else
                    {
                        Frame.Navigate(typeof(ResetScreen));
                        _BarTimeWeather.Stop();
                        _Timer.Stop();
                    }
                }
                if (eat_bar.Value < 40) // for needs
                {
                    SoundCounterEat++;
                    if (SoundCounterEat % 5 == 0) // every 5 seconds notify
                    {
                        _Animation.StartAnimation(3, 4);
                        Music.Needs.Play();
                    }
                }
            }
            else EatCounter--;
            if (SleepCounter == 0)
            {
                if (_WeatherOption == 3 || _WeatherOption == 4) // for weather options, if hot the pet will be tired faster.
                    sleep_bar.Value -= 4;
                else
                    sleep_bar.Value--; // regulat option
                if (sleep_bar.Value == 0)
                {
                    // tamaguchi RIP
                    if (DeathCounter < 3) // delay the reset screen by 3 sec to see the death animation
                    {
                        _Animation.StartAnimation(3, 3);
                        DeathCounter++;
                    }
                    else
                    {
                        Frame.Navigate(typeof(ResetScreen));
                        _BarTimeWeather.Stop();
                        _Timer.Stop();
                    }
                }
                if (sleep_bar.Value < 30) // for needs
                {
                    SoundCounterSleep++;
                    if (SoundCounterSleep % 6 == 0) // every 6 seconds notify
                    {
                        _Animation.StartAnimation(3, 8);
                        Music.Needs.Play();
                    }
                }
                else SoundCounterSleep = 0;
            }
            else SleepCounter--;
            if (LoveCounter == 0)
            {
                love_bar.Value--;
                if (love_bar.Value == 0)
                {
                    // tamaguchi RIP
                    if (DeathCounter < 3)  // delay the reset screen by 3 sec to see the death animation
                    {
                        _Animation.StartAnimation(3, 3);
                        DeathCounter++;
                    }
                    else
                    {
                        Frame.Navigate(typeof(ResetScreen));
                        _BarTimeWeather.Stop();
                        _Timer.Stop();

                    }
                }
                if (love_bar.Value < 60) // for needs
                {
                    SoundCounterLove++;
                    if (SoundCounterLove % 3 == 0)
                    {
                        _Animation.StartAnimation(3, 9);
                        Music.Needs.Play();
                    }
                }
                else SoundCounterLove = 0;
            }
            else LoveCounter--;
            if (PlayCounter == 0)
            {
                play_bar.Value--;
                if (play_bar.Value == 0)
                {
                    // tamaguchi RIP
                    if (DeathCounter < 3) // delay the reset screen by 3 sec to see the death animation
                    {
                        _Animation.StartAnimation(3, 3);
                        DeathCounter++;
                    }
                    else
                    {
                        Frame.Navigate(typeof(ResetScreen));
                        _BarTimeWeather.Stop();
                        _Timer.Stop();

                    }
                }
                if (play_bar.Value < 33) // for needs
                {
                    SoundCounterPlay++;
                    if (SoundCounterPlay % 4 == 0)
                    {
                        _Animation.StartAnimation(3, 10);
                        Music.Needs.Play();
                    }
                }
                else SoundCounterPlay = 0;
            }
            else PlayCounter--;
            #region alive timer
            Counter.Seconds++;
            TimerTxt.Text = Counter.Time;
            #endregion
        }
        #endregion
        #region Music
        private void sound_volum_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            if(mute_icon.Visibility == Visibility.Visible)
            {
                Music.Player.Volume = 0;
            }
            else
            Music.Player.Volume = sound_volum.Value / 100;
        } // slide_bar volume change
        #region icons
        private void sound_icon_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Music.Player.Volume = 0;
            sound_icon.Visibility = Visibility.Collapsed;
            mute_icon.Visibility = Visibility.Visible;
        }

        private void mute_icon_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Music.Player.Volume = sound_volum.Value / 100;
            sound_icon.Visibility = Visibility.Visible;
        }
        #endregion
        #endregion
        #region Weather
        private void ToggleSwitchToggled(object sender, RoutedEventArgs e)
        {
            if (weater_btn.IsOn == true)
            {
                weather.Visibility = Visibility.Visible; // displaying the grid with the colors.
                weather_icon.Visibility = Visibility.Visible;
                if(news_txt != null) // for displaying after the first display
                {
                    news_txt.Visibility = Visibility.Visible;
                    per_day_txt.Visibility = Visibility.Visible;
                    suggest_txt.Visibility = Visibility.Visible;
                    _WeatherOption = _WeatherLastPlace; // for return the last weather option. if you get 2 and close and reopen the weather the option will be saved
                    // and not equel to 0;
                }
                _BarTimeWeather.Start();
            }
            else
            {
                weather.Visibility = Visibility.Collapsed;
                weather_icon.Visibility = Visibility.Collapsed;
                news_txt.Visibility = Visibility.Collapsed;
                per_day_txt.Visibility = Visibility.Collapsed;
                suggest_txt.Visibility = Visibility.Collapsed;
                _BarTimeWeather.Stop();
                _WeatherOption = 0;
            }
        } // display
        
        private void BarTimeWeatherTick(object sender, object e)
        {
            
            int tmp = _WeatherChoices.Random();
            if (_WeatherOption == tmp) tmp = _WeatherChoices.Random(); // for not diplaying the same thing.
            if (tmp <= 4)
            {
                news_txt.Text = _Summer.NewsOutput(tmp);
                per_day_txt.Text = _Summer.PerDayOutput(tmp);
                suggest_txt.Text = _Summer.SuggestOutput(tmp);
                _WeatherLastPlace = tmp;
                _WeatherOption = tmp;
                Music.Notifiction.Play();
            }
            else
            {
                news_txt.Text = _Winter.NewsOutput(tmp - 5);
                per_day_txt.Text = _Winter.PerDayOutput(tmp - 5);
                suggest_txt.Text = _Winter.SuggestOutput(tmp - 5);
                _WeatherLastPlace = tmp;
                _WeatherOption = tmp;
                Music.Notifiction.Play();
            }
        }
        #endregion
        #region Animations
        private void gif_image_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (_Animation.Active == true)
            {
                return;  // disbales button went we have an active animation.
            }
            else
            {
                _Animation.StartAnimation(2, 1);
            }
        }
        private void play_btn_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (_Animation.Active == true)
            {
                return;  // disbales button went we have an active animation.
            }
            else
            {
                _Animation.StartAnimation(9, 6);
                play_bar.Value += 20;
            }
        }
        private void love_btn_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (_Animation.Active == true)
            {
                return;  // disbales button went we have an active animation.
            }
            else
            {
                _Animation.StartAnimation(4, 5);
                love_bar.Value += 20;
            }
        }
        private void sleep_btn_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (_Animation.Active == true)
            {
                return;  // disbales button went we have an active animation.
            }
            else
            {
                _Animation.StartAnimation(6, 7);
                sleep_bar.Value += 20;
            }
        }
        private void feed_btn_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (_Animation.Active == true)
            {
                return;  // disbales button went we have an active animation.
            }
            else
            {
                _Animation.StartAnimation(3, 2);
                eat_bar.Value += 20;
            }
        }
        #endregion
        #region Bars + timmer view
        private void ToggleMenuFlyoutItem_Click_1(object sender, RoutedEventArgs e)
        {
            if (grid_btn.IsChecked == true)
            {
                bar_grid.Visibility = Visibility.Visible;
                eat_bar.Visibility = Visibility.Visible;
                sleep_bar.Visibility = Visibility.Visible;
                love_bar.Visibility = Visibility.Visible;
                play_bar.Visibility = Visibility.Visible;
                eat_txt.Visibility = Visibility.Visible;
                sleep_txt.Visibility = Visibility.Visible;
                love_txt.Visibility = Visibility.Visible;
                play_txt.Visibility = Visibility.Visible;
            }
            else
            {
                bar_grid.Visibility = Visibility.Collapsed;
                eat_bar.Visibility = Visibility.Collapsed;
                sleep_bar.Visibility = Visibility.Collapsed;
                love_bar.Visibility = Visibility.Collapsed;
                play_bar.Visibility = Visibility.Collapsed;
                eat_txt.Visibility = Visibility.Collapsed;
                sleep_txt.Visibility = Visibility.Collapsed;
                love_txt.Visibility = Visibility.Collapsed;
                play_txt.Visibility = Visibility.Collapsed;
            }

        }
        private void time_btn_Click(object sender, RoutedEventArgs e)
        {
            if (time_btn.IsChecked == true)
                TimerTxt.Visibility = Visibility.Visible;
            else
                TimerTxt.Visibility = Visibility.Collapsed;
        }// for seeing the timmer
        #endregion
        #region warnning pop up
        private void close_pop_up_click(object sender, RoutedEventArgs e) // decline btn
        {
            if (warning.IsOpen) warning.IsOpen = false;
        }
        private void menu_btn_Click(object sender, RoutedEventArgs e) // open pop up
        {
            if (!warning.IsOpen) warning.IsOpen = true;
        }
        private void menu(object sender, RoutedEventArgs e) // accept btn
        {
            Frame.Navigate(typeof(OpenScreen));
            _Timer.Stop();
            Music.Notifiction.Pause();
            Music.Needs.Pause();
        }
        #endregion
        private void MenuFlyoutItem_Click(object sender, RoutedEventArgs e)
        {
            CoreApplication.Exit();
        } // end of code. exit app.
    }
}
