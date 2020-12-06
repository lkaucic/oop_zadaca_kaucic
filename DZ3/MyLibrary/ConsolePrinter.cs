using System;
using System.Collections.Generic;
using System.Text;

namespace MyLibrary
{
    public class ConsolePrinter : IPrinter
    {

        public void Print(string info)
        {
            Console.WriteLine(info);
        }
    }
}
