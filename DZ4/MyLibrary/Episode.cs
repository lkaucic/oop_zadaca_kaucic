using System;
using System.Globalization;
using System.Collections.Generic;

namespace MyLibrary
{
    public class Episode
    {

        List<double> scores = new List<double>();  //a list which will keep track of all generated ratings
        Description description = new Description();

        public Description GetDescription()
        {
            return description;
        }
        public int AudienceCount { get; private set; }
        public double SumOfRatings { get; private set; }
        public double MaxRating { get; private set; }

        public Episode() { }
        public Episode(int audienceCount, double sumOfRatings, double maxRating, Description about) { AudienceCount = audienceCount; SumOfRatings = sumOfRatings; MaxRating = maxRating; description = about; }

        // deep copy constructor, must be included here so one in class Season can work (If not written, we would get error message given in Program.cs)
        public Episode(Episode other)
        {
            AudienceCount = other.AudienceCount;
            SumOfRatings = other.SumOfRatings;
            MaxRating = other.MaxRating;
            description = new Description(other.description.GetNumberOfEpisode(), other.description.GetDurationOfEpisode(), other.description.GetNameOfEpisode());
        }

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
            return AudienceCount.ToString(System.Globalization.CultureInfo.InvariantCulture) + ", " + SumOfRatings.ToString("0.####",System.Globalization.CultureInfo.InvariantCulture) + ", " + MaxRating.ToString(System.Globalization.CultureInfo.InvariantCulture) + ", " + description.GetNumberOfEpisode() + ", " + description.GetDurationOfEpisode() + ", " + description.GetNameOfEpisode();
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
