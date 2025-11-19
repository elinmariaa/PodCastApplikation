using System;


namespace Models.Exceptions
{
    public class InvalidRssUrl : Exception
    {
        public InvalidRssUrl(string message) : base(message) { }
    }
}
