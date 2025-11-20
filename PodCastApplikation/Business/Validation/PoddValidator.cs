using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodCastApplikation.Business.Validation
{
    public static class PoddValidator
    {
        // Kollar att poddnamnet följer reglerna (2–100 tecken, ej tomt)
        public static bool ÄrGiltigtNamn(string namn)
        {
           return !string.IsNullOrWhiteSpace(namn) 
            && namn.Trim().Length >= 2
            && namn.Trim().Length <= 50;
        }

        // Kollar att rssUrl är unik bland befintliga poddar
        public static bool ÄrUnikRssUrl(string rssUrl, List<Models.Klasser.Podd> befintligaPoddar)
        {
            return !befintligaPoddar
                .Any(p => p.RssURL.Equals(rssUrl, StringComparison.OrdinalIgnoreCase));
        }

        // Kollar att poddId inte är tomt eller null
        public static bool ÄrGiltigtId(string poddId)
        {
            return !string.IsNullOrWhiteSpace(poddId);
        }

        // Kollar att kategoriId inte är tomt eller null
        public static bool ÄrGiltigKategori(string kategoriId)
        {
            return !string.IsNullOrWhiteSpace(kategoriId);
        }
    }
}
