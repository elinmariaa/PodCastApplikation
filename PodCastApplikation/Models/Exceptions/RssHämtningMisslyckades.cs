using System;

namespace PodCastApplikation.Models.Exceptions
{
    public class RssHämtningMisslyckades : Exception
    {
        public RssHämtningMisslyckades(string message) : base(message) { }

    }
}
