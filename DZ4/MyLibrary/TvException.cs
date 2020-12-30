using System;
using System.Collections.Generic;
using System.Text;

namespace MyLibrary
{
    [Serializable]
    public class TvException : Exception
    {
        public string Title { get; private set; }

        public TvException() { }
        public TvException(string message) : base(message) { }
        
        //this one we must have so a proper message would be printed, also have to have line 18 so title of episode could be fetched and appended to error message
        public TvException(string message, string title) : base(message)
        {
            Title = title;
        }
        public TvException(string message, Exception innerException) : base(message, innerException) { }
    }
}
