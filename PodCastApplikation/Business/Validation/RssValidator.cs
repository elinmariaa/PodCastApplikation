using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

using System;

namespace PodCastApplikation.Business.Validation
{
    public static class RssValidator
    {
        public static void ValideraRssUrl(string rssUrl)
        {
            if (string.IsNullOrWhiteSpace(rssUrl))
                throw new ArgumentException("RSS URL får inte vara tom.");

            if (!rssUrl.StartsWith("http"))
                throw new ArgumentException("RSS URL måste börja med http eller https.");
        }

    }








    // Kollar att xmlText är giltig XML och innehåller en <channel>-element
    //public static bool ÄrGiltigXml(string xmlText)
    //        {
    //            try
    //            {
    //                var xml = XDocument.Parse(xmlText);
    //                return xml.Root != null && xml.Root.Element("channel") != null;
    //            }
    //            catch
    //            {
    //                return false;
    //            }
    //        }
}


