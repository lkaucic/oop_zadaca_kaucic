using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Linq;

namespace MyLibrary
{
    [Serializable]
    public class Season : IEnumerable<Episode>
    {
        List<Season> seasons = new List<Season>();

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
