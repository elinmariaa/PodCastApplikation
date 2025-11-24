using System;
using System.Collections.Generic;
using System.Xml.Linq;
using PodCastApplikation.Models;
using PodCastApplikation.Models.Klasser;

namespace PodCastApplikation.DAL
{
    public static class RssLäsare
    {
        public static Podd TolkaRss(string xmlText, string rssUrl)
        {
            XDocument xml;  //Försök att tolka XML-texten

            try
            {
                xml = XDocument.Parse(xmlText);
            }
            catch
            {
                throw new Exception("Rss-flödet innehåller ogiltigt XML");
            }


            var channel = xml.Root?.Element("channel"); //LEta efter channel
            if (channel == null)
                throw new Exception("Kunde inte hitta 'channel' i RSS-flödet");

            
            string? titel = channel.Element("title")?.Value; //Hämta poddens grundinfo
            string? beskrivning = channel.Element("description")?.Value;

            var items = channel.Elements("item"); // Hämta alla avsnitt
            var avsnittLista = new List<Avsnitt>();

            foreach (var item in items)
            {
                var avsnitt = new Avsnitt
                {
                    Titel = item.Element("title")?.Value,
                    Beskrivning = item.Element("description")?.Value,
                    PubliceringsDatum = DateTime.TryParse(item.Element("pubDate")?.Value, out var d)
                        ? d : null
                };

                avsnittLista.Add(avsnitt);
            }

              var podd = new Podd
            {
                OriginalTitel = titel,
                Beskrivning = beskrivning,
                RssURL = rssUrl,
                Avsnitt = avsnittLista
            };

            return podd;
        
        }
    }
}
