using game_project.classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
namespace game_project
{
    public partial class ResetScreen : Page
    {
        public ResetScreen()
        {
            this.InitializeComponent();
            time_txt.Text = Counter.Time;
        }
        private void quit_btn_Tapped(object sender, TappedRoutedEventArgs e)
        {
            CoreApplication.Exit();
        }
        private void reset_btn_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Counter.Seconds = 0;
            Frame.Navigate(typeof(MainPage));
        }
    }
}
