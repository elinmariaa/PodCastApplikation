using System;


namespace Models.Undantag
{
    public class InvalidRssUrl : Exception
    {
        public InvalidRssUrl(string message) : base(message) { }
    }
}
