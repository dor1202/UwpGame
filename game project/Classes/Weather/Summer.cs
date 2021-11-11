using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_project.classes
{
    class Summer : seasons
    {
        string[] WeatherNews =
        {"today- 33°c",  //_weather_news[0]
        "today- 36°c",  //_weather_news[1]
        "today- 30°c",  //_weather_news[2]
        "today- 40°c",  //_weather_news[3]
        "today- 44°c"};  //_weather_news[4]
        string[] WeatherSuggest =
        {"partially cloudy",  //_weather_suggest[0]
        "no clouds",  //_weather_suggest[1]
        "chilly",  //_weather_suggest[2]
        "really hot",  //_weather_suggest[3]
        "heat wave"};  //_weather_suggest[4]
        string[] WeatherPerDay =
        {"high: 36°c  low: 32°c feels like: 35°c",  //_weather_per_day[0]
        "high: 36°c  low: 32°c feels like: 35°c",  //_weather_per_day[1]
        "high: 31°c  low: 26°c feels like: 29°c",  //_weather_per_day[2]
        "high: 41°c  low: 38°c feels like: 40°c",  //_weather_per_day[3]
        "high: 48°c  low: 42°c feels like: 45°c"};  //_weather_per_day[4]
        public string NewsOutput(int index)
        {
            return WeatherNews[index];
        }
        public string SuggestOutput(int index)
        {
            return WeatherSuggest[index];
        }
        public string PerDayOutput(int index)
        {
            return WeatherPerDay[index];
        }
    }
}
