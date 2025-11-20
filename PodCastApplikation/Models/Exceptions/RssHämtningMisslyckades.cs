using System;

namespace Models.Undantag
{
    public class RssHämtningMisslyckades : Exception
    {
        public RssHämtningMisslyckades(string message) : base(message) { }

    }
}
