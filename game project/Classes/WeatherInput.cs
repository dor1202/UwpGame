using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_project.classes
{
    public class WeatherInput
    {
        string[] _weather_news =
        {"today- 33°c",  //_weather_news[0]
        "today- 28°c",  //_weather_news[1]
        "today- 30°c",  //_weather_news[2]
        "today- 22°c",  //_weather_news[3]
        "today- 44°c"};  //_weather_news[4]
        string[] _weather_suggest =
        {"partially cloudy",  //_weather_suggest[0]
        "no clouds",  //_weather_suggest[1]
        "may be rain",  //_weather_suggest[2]
        "will be rain today",  //_weather_suggest[3]
        "heat wave"};  //_weather_suggest[4]
        string[] _weather_per_day =
        {"high: 36°c  low: 32°c feels like: 35°c",  //_weather_per_day[0]
        "high: 30°c  low: 25°c feels like: 27°c",  //_weather_per_day[1]
        "high: 34°c  low: 29°c feels like: 33°c",  //_weather_per_day[2]
        "high: 23°c  low: 19°c feels like: 20°c",  //_weather_per_day[3]
        "high: 48°c  low: 42°c feels like: 45°c"};  //_weather_per_day[4]

        public string NewsOutput(int index)
        {
            return _weather_news[index];
        }
        public string SuggestOutput(int index)
        {
            return _weather_suggest[index];
        }
        public string PerDayOutput(int index)
        {
            return _weather_per_day[index];
        }
    }
}
