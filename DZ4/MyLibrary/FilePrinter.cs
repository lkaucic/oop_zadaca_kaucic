using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace MyLibrary
{
    public class FilePrinter : IPrinter
    {
        string outputFileName;

        public FilePrinter(string outputFileName)
        {
            this.outputFileName = outputFileName;
        }

        public void Print(string info)
        {
            StreamWriter writer = new StreamWriter(outputFileName);

            writer.WriteLine(info);

            writer.Close();
        }
    }
}
