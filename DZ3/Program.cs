using System;
using System.IO;
using MyLibrary;
using System.Globalization;

namespace Homework_1
{
     class Program
    {
        static void Main(string[] args)
        {

			string fileName = "shows.tv";
			string outputFileName = "storage.tv";

			IPrinter printer = new ConsolePrinter();
			printer.Print($"Reading data from file {fileName}");


			Episode[] episodes = TvUtilities.LoadEpisodesFromFile(fileName);
			Season season = new Season(1, episodes);

			printer.Print(season.ToString());

			
			//This for loop is changed so that it iterates from 0 to 1, since there is only one season; if there were multiple seasons, loop would iterate till' seasons.length
			for (int i = 0; i < 1; i++)
			{
				season.AddView(TvUtilities.GenerateRandomScore());  //and in that case, this line would start ith seasons[i]
			}
		
			printer.Print(season.ToString());

			printer = new FilePrinter(outputFileName);
			printer.Print(season.ToString());
			
		}
	}
}
