using System;
using System.Net.Http;
using System.Threading.Tasks;
using PodCastApplikation.Models.Interfaces;
using PodCastApplikation.Models;
using PodCastApplikation.Models.Klasser;




namespace PodCastApplikation.DAL
{
    public class RssHämtare : IRssHämtare
    {
        public async Task<Podd> HämtaPoddFrånRssUrl(string rssUrl)
        {
            
            if (string.IsNullOrWhiteSpace(rssUrl) || !rssUrl.StartsWith("http"))
            {

                throw new Exception("Rss-adressen är ogiltig");
            }



            try
            {
               
                using var http = new HttpClient(); 

                
                string xmlText = await http.GetStringAsync(rssUrl);

                var podd = RssLäsare.TolkaRss(xmlText, rssUrl);
                return podd;
            }
            catch 
            {

                throw new Exception("Kunde inte hämta RSS-flödet från internet.");
            }

            
        }
    }
}
