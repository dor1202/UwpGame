using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_project.classes
{
    class Winter : seasons
    {
        public Winter()
        {

        }
        string[] WeatherNews =
        {"today- 28°c",  //_weather_news[0]
        "today- 26°c",  //_weather_news[1]
        "today- 20°c",  //_weather_news[2]
        "today- 17°c",  //_weather_news[3]
        "today- 10°c"};  //_weather_news[4]
        string[] WeatherSuggest =
        {"partially cloudy",  //_weather_suggest[0]
        "no clouds",  //_weather_suggest[1]
        "will be rain today",  //_weather_suggest[2]
        "chance for snow",  //_weather_suggest[3]
        "snowing"};  //_weather_suggest[4]
        string[] WeatherPerDay =
        {"high: 29°c  low: 22°c feels like: 27°c",  //_weather_per_day[0]
        "high: 27°c  low: 20°c feels like: 26°c",  //_weather_per_day[1]
        "high: 20°c  low: 15°c feels like: 18°c",  //_weather_per_day[2]
        "high: 18°c  low: 12°c feels like: 16°c",  //_weather_per_day[3]
        "high: 10°c  low: 2°c feels like: 5°c"};  //_weather_per_day[4]
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
