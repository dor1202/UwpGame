using game_project.classes;
using Windows.ApplicationModel.Core;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
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
            Counter.Seconds = 0; // For reaseting the showen timer.
            Frame.Navigate(typeof(MainPage));
        }
    }
}
