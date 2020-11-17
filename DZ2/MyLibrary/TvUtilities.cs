using System;
using System.Collections.Generic;
using System.Text;

namespace MyLibrary
{
    public class TvUtilities
    {
        public static double Generate()
        {

            Random generator = new Random();
            double rating = (generator.NextDouble()) * 10; //since generator.NextDouble() will return a double value in range from 0.0 to 1.0, we have to multyply it by 10 to get desirable rating in rango from 0.0 to 10.0
            return rating;
        }

        public static void Sort(Episode[] episodes)
        {
            Episode temp;

            for (int i = episodes.Length - 1; i >= 0; i--)
            {
                for (int j = episodes.Length-1; j > episodes.Length - 1 - i; j--)
                {
                    if (episodes[j] > episodes[j - 1])
                    {
                        temp = episodes[j];
                        episodes[j] = episodes[j - 1];
                        episodes[j - 1] = temp;
                    }
                }
            }
        }

        public static Episode Parse(string episodeFlow)
        {
            
            string[] episodeString = episodeFlow.Split(',');
            int AudienceCount = int.Parse(episodeString[0]);
            double SumOfRatings = double.Parse(episodeString[1])/100;
            double MaxRating = double.Parse(episodeString[2])/100;
            int numberOfEpisode = int.Parse(episodeString[3]);
            TimeSpan durationOfEpisode = TimeSpan.Parse(episodeString[4]);
            string nameOfEpisode = episodeString[5];

            Description description = new Description(numberOfEpisode, durationOfEpisode, nameOfEpisode);
            return new Episode(AudienceCount, SumOfRatings, MaxRating, description);
            
        }
           

    }
}
