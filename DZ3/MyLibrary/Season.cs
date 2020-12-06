using System;
using System.Collections.Generic;
using System.Text;

namespace MyLibrary
{
   public class Season
    {
        int noOfSeason;
        Episode[] episodes;

        public Season(int noOfSeason, Episode[] episodes)
        {
            this.noOfSeason = noOfSeason;
            this.episodes = episodes;
        }

        public void AddView(double randomRating)
            //adding view to each episode in season
        {
            for(int i = 0; i<episodes.Length; i++)
            {
                episodes[i].AddView(randomRating);
            }
        }

        public override string ToString()
        {
            int audienceCount = 0;
            TimeSpan totalDuration = new TimeSpan(0,0,0);
          

            string returnSeason = null;


            for(int i = 0; i<episodes.Length; i++)
            {
                audienceCount += episodes[i].AudienceCount;
                totalDuration = totalDuration.Add(episodes[i].GetDescription().GetDurationOfEpisode());
            }
            returnSeason += $"Season{noOfSeason}:\n=================================================\n";

            for (int i = 0; i<episodes.Length; i++)
            {
                returnSeason += episodes[i].ToString();
                returnSeason += "\n";
            }

            returnSeason += "Report:\n";
            returnSeason += "=================================================\n";
            returnSeason += $"Total viewers: {audienceCount}\nTotal duration: {totalDuration}\n";
            returnSeason += "=================================================\n";

            return returnSeason;

        }

    }
}
