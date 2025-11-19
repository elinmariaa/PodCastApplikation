using System;
using System.Threading.Tasks;
using Models.Interfaces;
using Models.Klasser;
using Models.Undantag;
using System.Net.Http;
using System.Xml.Linq;

namespace DAL
{
    public class RssHämtare : IRssHämtare
    {
        public async Task<Podd> HämtaPoddFrånRssUrl(string rssUrl)
        {
            // Kollar att länken inte är tom att den ser ut som en riktig webbadress
            if (string.IsNullOrWhiteSpace(rssUrl) || !rssUrl.StartsWith("http" )) 
            {
                //Stannar programmet och säger att länken är ogiltig
                throw new InvalidRssUrl("Rss-adressen är ogiltig"); 
            }

            //Här kommer texten från RSS-filen hamna
            string xmlText;

            try
            {
                // skapar en httpklient-objekt som vi döper till "http" som kan hämta saker från internet
                using var http = new HttpClient(); //using i koden gör att metoden stängs av utan att behöva skriva close

                //Hämtar hela RSS-filen som text från webben (detta kan ta tid --> därför async)
                xmlText = await http.GetStringAsync(rssUrl); 
            }
            catch
            {
                //Om något går fel vid hämtningen slänger vi ett eget fel
                throw new RssHämtningMisslyckades("Kunde inte hämta RSS-flödet från internet.");
            }

            //här konverterar vi RSS-texten till ett XML-objekt
            XDocument xml;

            try
            {
                //Försöker omvandla texten vi hämtat till ett XML-dokument
                xml = XDocument.Parse(xmlText);
            }

            catch
            {
                //Om texten inte gick att läsa som XML, så är RSS:en trasig
                throw new RssHämtningMisslyckades("Rss-flödet innehåller ogiltig XML");
            }

            //Nu när vi har XML-dokumentet i variabeln xml, ska vi leta efter channeldelen i dokumentet
            var channel = xml.Root?.Element("channel");

            if (channel==null)
            {
                //Om channel saknas är RSS-flödet defekt.
                throw new RssHämtningMisslyckades("Kunde inte hitta 'channel' i RSS-flödet");

            }

            //Hämtar poddens titel (kan vara null om RSS-flödet saknar title)

            string? titel = channel.Element("title")?.Value;

            //Hämtar poddens beskrivning (kan också vara null)
            string? beskrivning = channel.Element("description")?.Value;


            //Hittar alla avsnitt (<item>)  och skapar Avsnitt-objekt
            var items = channel.Elements("item");

            //skapar en tom lista där vi ska lägga alla avsnitt
            var avsnittLista = new List<Avsnitt>();

            foreach (var item in items) // Gå igenom varje <item> i RSS, en i taget och kalla den för item

            {
                var avsnitt = new Avsnitt // skapar ett nytt avsnitt i c#
                {
                    Titel = item.Element("title")?.Value,//"Hämta texten som står i <title> inne i <item>

                    Beskrivning = item.Element("description")?.Value,

                    PubliceringsDatum = DateTime.TryParse(item.Element("pubDate")?.Value, out var d)
                    ? d : null //En kort if sats - om TryParse lyckas = publiceringsdatum = d // Misslyckas = pubDate = null
                };

                avsnittLista.Add(avsnitt); // läägg till avsnittet i listan
            }

            //Skapar en podd med all information från RSS-flödet
            var podd = new Podd
            {
                OriginalTitel = titel,
                Beskrivning = beskrivning,
                RssURL = rssUrl,
                Avsnitt = avsnittLista
            };

            return podd; //Returnerar podden till businesslagret


        }
    }
}
