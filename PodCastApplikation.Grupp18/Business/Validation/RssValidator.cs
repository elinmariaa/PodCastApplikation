using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;

namespace PodCastApplikation.Business.Validation
{
    public static class RssValidator
    {
        public static void ValideraRssUrl(string rssUrl) // Kollar att länken inte är tom och har rätt format
        {
            if (string.IsNullOrWhiteSpace(rssUrl))
                throw new ArgumentException("RSS URL får inte vara tom.");

            if (!rssUrl.StartsWith("http"))
                throw new ArgumentException("RSS URL måste börja med http eller https.");
        }

        public static async Task ValideraRssInnehålle(string rssUrl)
        {
            try
            {
                using (var http = new HttpClient()) 
                {
                    string xmlText = await http.GetStringAsync(rssUrl);

                    var xml = XDocument.Parse(xmlText);

                    if (xml.Root == null || xml.Root.Element("channel") == null)
                        throw new ArgumentException("RSS-flödet saknar giltigt <channel>-element.");
                }
            }
            catch (HttpRequestException)
            {
                throw new ArgumentException("Kunde inte nå RSS-länken – kontrollera internet eller adressen.");
            }
            catch (Exception)
            {
                throw new ArgumentException("RSS-länken innehåller inte giltig XML.");
            }



        }

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
//}


