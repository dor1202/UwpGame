using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_project.classes
{
    public class Counter
    {
        public static int Seconds { get; set; } // reciving time from main page
        public static string Time // for displaying the time
        { get
            {
                TimeSpan timeSpan = TimeSpan.FromSeconds(Seconds);
                return timeSpan.ToString(@"hh\:mm\:ss");
            }
        }
    }
}
