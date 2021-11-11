using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_project.classes
{
    public class seasons
    {
        int SummerCounter;
        int WinterCounter;
        //bool Season; // true = summer, false = winter
        Random r = new Random();
        public seasons(int summerCounter = 3, int winterCounter = 3)
        {
            SummerCounter = summerCounter;
            WinterCounter = winterCounter;
        }
        public int Random()
        {
            return r.Next(0,9);
        }
    }
}
