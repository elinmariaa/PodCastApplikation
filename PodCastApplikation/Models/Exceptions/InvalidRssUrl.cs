using System;


namespace PodCastApplikation.Models.Exceptions
{
    public class InvalidRssUrl : Exception
    {
        public InvalidRssUrl(string message) : base(message) { }
    }
}
