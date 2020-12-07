using System;
using System.Globalization;
using System.Collections.Generic;
using System.Text;

namespace MyLibrary
{
    public class Description
    {
        int numberOfEpisode;
        TimeSpan durationOfEpisode;
        string nameOfEpisode;

        public Description() { }

        public Description(int number, TimeSpan duration, string name)
        {
            numberOfEpisode = number;
            durationOfEpisode = duration;
            nameOfEpisode = name;
        }

        public override String ToString()
        {
            return numberOfEpisode + "," + durationOfEpisode + "," + nameOfEpisode;
        }
        public int GetNumberOfEpisode()
        {
            return numberOfEpisode;
        }
        public TimeSpan GetDurationOfEpisode()
        {
            return durationOfEpisode;
        }
        public string GetNameOfEpisode()
        {
            return nameOfEpisode;
        }


    }
}
