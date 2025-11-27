using PodCastApplikation.Models.Klasser;
using System.Threading.Tasks;

namespace PodCastApplikation.Models.Interfaces
{
    public interface IRssHämtare
    {
        Task<Podd> HämtaPoddFrånRssUrl(string rssUrl);
    }
}
