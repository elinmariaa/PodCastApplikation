using Models.Klasser;
using System.Threading.Tasks;

namespace Models.Interfaces
{
    public interface IRssHämtare
    {
        Task<Podd> HämtaPoddFrånRssUrl(string rssUrl);
    }
}
