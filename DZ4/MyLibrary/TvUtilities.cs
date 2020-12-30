using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace MyLibrary
{
    public class TvUtilities
    {
        public static double GenerateRandomScore()
        {

            Random generator = new Random();
            double rating = (generator.NextDouble()) * 10; //since generator.NextDouble() will return a double value in range from 0.0 to 1.0, we have to multyply it by 10 to get desirable rating in rango from 0.0 to 10.0
            double roundedRating = Math.Round(rating, 4, MidpointRounding.ToEven);
            return roundedRating;
        }

        public static void Sort(Episode[] episodes)

            // basically just Bubble sort function that sorts House M.D. episodes by duration

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
            // Getting array from string and assigning each element to a certain atribute of Episode

            string[] episodeString = episodeFlow.Split(',');
            int AudienceCount = int.Parse(episodeString[0]);
            double SumOfRatings = double.Parse(episodeString[1])/100;
            double MaxRating = double.Parse(episodeString[2])/100;
            int numberOfEpisode = int.Parse(episodeString[3]);
            TimeSpan durationOfEpisode = TimeSpan.FromMinutes(double.Parse(episodeString[4]));
            string nameOfEpisode = episodeString[5];

            Description description = new Description(numberOfEpisode, durationOfEpisode, nameOfEpisode);
            return new Episode(AudienceCount, SumOfRatings, MaxRating, description);
            
        }

        public static List<Episode> LoadEpisodesFromFile(string fileName) 
            
            // Passing through file with streamreader to get num of lines (n), declaring array of episodes of size n and initializing each element through Parse method
        {
            StreamReader reader = new StreamReader(fileName);

            string line;
            int i = 0;
            int noOfRows = 0;

            while((line = reader.ReadLine()) != null)
            {
                noOfRows++;
            }

            //getting reader back to the beginning of opened file
            reader.DiscardBufferedData();
            reader.BaseStream.Seek(0, SeekOrigin.Begin);

            List<Episode> episodes = new List<Episode>();

            while((line = reader.ReadLine()) != null)
            {
                episodes.Add(Parse(line));
                i++;
            }

            return episodes;
        }



    }
}
