using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Linq;

namespace MyLibrary
{
    [Serializable]
    // in order for foreach with season to work, we need to implement IEnumberable interface, but with class Episode as a type
    public class Season : IEnumerable<Episode>
    {
        

        int noOfSeason;
        List<Episode> episodes = new List<Episode>();
        
        public int Length{ get; }
        

        public Episode this[int i]
        {
            get { return episodes[i]; }
            set { episodes[i] = value; }
        }

        public Season(int noOfSeason, List<Episode> episodes)
        {
            
            this.noOfSeason = noOfSeason;
            this.episodes = episodes;
            this.Length = episodes.Count;
        }

        // deep copy constructor...since episodes is a list, we're using foreach loop to make a deep copy of each original episode and asign it's value to corresponding episode in copied episodes list in object other
        public Season(Season other)
        {
            episodes = new List<Episode>();
            noOfSeason = other.noOfSeason;
            Length = other.Length;

            foreach(var episode in other.episodes)
            {
                episodes.Add(new Episode(episode));
            }
        }


        public void AddView(double randomRating)
            //adding view to each episode in season
        {
            for(int i = 0; i<episodes.Count; i++)
            {
                episodes[i].AddView(randomRating);
            }
        }

        public override string ToString()
        {
            int audienceCount = 0;
            TimeSpan totalDuration = new TimeSpan(0,0,0);
          

            string returnSeason = null;


            for(int i = 0; i<episodes.Count; i++)
            {
                audienceCount += episodes[i].AudienceCount;
                totalDuration = totalDuration.Add(episodes[i].GetDescription().GetDurationOfEpisode());
            }
            returnSeason += $"Season {noOfSeason}:\n=================================================\n";

            for (int i = 0; i<episodes.Count; i++)
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

        // we're using linq to find if there's any episode with the name passed to the method and later we're using RemoveAll method to remove all episodes with that name
        // using $\textbf{\lambda}$ expressions (x represents an episode)
        public void Remove(string name)
        {
           

            if (!episodes.Any(x => x.GetDescription().GetNameOfEpisode() == name))
            {
                throw new TvException($"No such episode found.", name);
            }

            episodes.RemoveAll(x => x.GetDescription().GetNameOfEpisode() == name);
        }

        public void Add(Episode episode)
        {
            episodes.Add(episode);
        }

        // since we're implementing IEnumberable<T> interface, we must give definitions of lower two methods
        public IEnumerator<Episode> GetEnumerator()
        {
            foreach (var episode in episodes)
            {
             yield return episode;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}
