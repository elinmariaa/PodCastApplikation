using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PodCastApplikation.Business.Validation
{
    public static class RssValidator
    {
        // Kollar att rssUrl är en giltig URL (inte tom, korrekt format)
        public static bool ÄrGiltigUrl(string rssUrl)
        {
            return !string.IsNullOrWhiteSpace(rssUrl) 
                && Uri.TryCreate(rssUrl, UriKind.Absolute, out var uri)
                && (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps);
        }

        // Kollar att xmlText är giltig XML och innehåller en <channel>-element
        public static bool ÄrGiltigXml (string xmlText)
        {
            try
            {
                var xml = XDocument.Parse(xmlText);
                return xml.Root != null && xml.Root.Element("channel") != null;
            }
            catch
            {
                return false;
            }
        }

    }
}
