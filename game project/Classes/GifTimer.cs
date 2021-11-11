using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace game_project.classes
{
	public class GifTimer
	{
		public bool Active; // a public bool to prevent multipul animations. for example pressing eat and 1 sec later pressing love.
		public DispatcherTimer Timer = new DispatcherTimer();
		Image Gif;
		string[] animations = new string[] {
			"ms-appx:///Assets/gifs/stand_gif.GIF", // animations[0]
			"ms-appx:///Assets/gifs/jump_gif.GIF",  // animations[1]
			"ms-appx:///Assets/gifs/food_gif.GIF",  // animations[2]
			"ms-appx:///Assets/gifs/dead_gif.GIF",  // animations[3]
			"ms-appx:///Assets/gifs/hungry_gif.GIF",  // animations[4]
			"ms-appx:///Assets/gifs/love_gif.GIF",  // animations[5]
			"ms-appx:///Assets/gifs/play_gif.GIF",  // animations[6]
			"ms-appx:///Assets/gifs/sleep_gif.GIF",  // animations[7]
			"ms-appx:///Assets/gifs/tired_gif.GIF",  // animations[8]
			"ms-appx:///Assets/gifs/need_love_gif.GIF",  // animation[9]
			"ms-appx:///Assets/gifs/need_play_gif.GIF" };  // animation[10]
		int AnimationInArray = 0;
		int SecCounter = 0;
		bool IsRunning; // IsRunning is used for keep the animation running and not looping every second.
		public GifTimer(Image gif)
		{
			Gif = gif;
			Timer.Interval = new TimeSpan(0, 0, 0, 1);
			Timer.Tick += Atimer_Tick;
			Timer.Start();
		}
		public void StartAnimation(int sec, int animation)
		{
			if (animation == 3)
				Timer.Stop();
			// if (OpenScreen.Animal == 0) _animation = animation + 11 // option for making a database for 2 animals.
			AnimationInArray = animation;
			SecCounter = sec;
			IsRunning = false;
		}
		private void Atimer_Tick(object sender, object e)
		{
			if (SecCounter == 0)
			{
				Gif.Source = new BitmapImage(new Uri(("ms-appx:///Assets/gifs/stand_gif.GIF"))); // showing the defult gif
				Active = false;
			}
			else
			{
				if(AnimationInArray == 4 || AnimationInArray == 8 || AnimationInArray == 9 || AnimationInArray == 10) // if needs, we can cut the animation
				{
					IsRunning = false;
					Active = false;
				}
				else
					Active = true;
				if (IsRunning == true)
				{
					SecCounter--; // making a loop that isn't giving a new source and keeping the animation.
					return;
				}
				else
				{
					Gif.Source = new BitmapImage(new Uri(animations[AnimationInArray])); // changing to the wanted animation
					SecCounter--;
					IsRunning = true; // declaring that there is an animation in progress.
				}
			}
		}
    }
}
