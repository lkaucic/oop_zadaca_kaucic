using System;
using System.Globalization;
using System.Collections.Generic;

namespace MyLibrary
{
    public class Episode
    {

        List<double> scores = new List<double>();  //a list which will keep track of all generated ratings
        Description description = new Description();

        public int AudienceCount { get; private set; }
        public double SumOfRatings { get; private set; }
        public double MaxRating { get; private set; }

        public Episode() { }
        public Episode(int audienceCount, double sumOfRatings, double maxRating, Description about) { AudienceCount = audienceCount; SumOfRatings = sumOfRatings; MaxRating = maxRating; description = about; }



        public void AddView(double rating)  // when adding a viewer, Audience count is increased by 1, we're adding generated rating to our list and also adding that rating to sum of all ratings
        {

            AudienceCount += 1;
            scores.Add(rating);
            SumOfRatings += rating;
        }

        public double GetMaxScore()  //with foreach loop we're going through the list and searching for the max value
        {
            double max = 0;
            foreach (double score in scores)
            {
                if (score > max)
                {
                    max = score;
                }
            }
            return max;
        }

        public double GetAverageScore() 
        {
           
            return SumOfRatings/AudienceCount;
        }

        public int GetViewerCount()
        {
            return AudienceCount;
        }

        public override string ToString()
        {
            return AudienceCount + ", " + SumOfRatings + ", " + MaxRating + ", " + description.GetNumberOfEpisode() + ", " + description.GetDurationOfEpisode() + ", " + description.GetNameOfEpisode();
        }

        public static bool operator <(Episode lhs, Episode rhs)
        {
            if (lhs is null) return rhs is null;
            return lhs.GetAverageScore() < rhs.GetAverageScore();
        }

        public static bool operator >(Episode lhs, Episode rhs)
        {
            return !(lhs.GetAverageScore() < rhs.GetAverageScore());
        }
    }

}
