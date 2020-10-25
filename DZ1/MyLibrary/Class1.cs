using System;
using System.Collections.Generic;

namespace MyLibrary
{
    public class Episode
    {

        List<double> scores = new List<double>();  //a list which will keep track of all generated ratings


        public int AudienceCount { get; private set; }
        public double SumOfRatings { get; private set; }
        public double MaxRating { get; private set; }

        public Episode() { AudienceCount = 0; SumOfRatings = 0; MaxRating = 0; }
        public Episode(int audienceCount, double sumOfRatings, double maxRating) { AudienceCount = audienceCount; SumOfRatings = sumOfRatings; MaxRating = maxRating; }


        public static double Generate()  
        {

            Random generator = new Random();
            double rating = (generator.NextDouble()) * 10; //since generator.NextDouble() will return a double value in range from 0.0 to 1.0, we have to multyply it by 10 to get desirable rating in rango from 0.0 to 10.0
            return rating;
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
    }

}
