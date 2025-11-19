using System;

namespace Models.Exceptions
{
    public class RssHämtningMisslyckades : Exception
    {
        public RssHämtningMisslyckades(string message) : base(message) { }

    }
}
