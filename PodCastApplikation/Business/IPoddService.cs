using Models.Klasser;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PodCastApplikation.Business
{
    public interface IPoddService
    {
        // PODDAR
        Task LäggTillPodd(string rssUrl);
        Task<List<Podd>> HämtaAllaPoddar();
        Task<List<Avsnitt>> HämtaAvsnittFörPodd(string poddId);
        Task UppdateraPoddNamn(string poddId, string nyttNamn);
        Task UppdateraPoddKategori(string poddId, string nyKategoriId);
        Task TaBortPodd(string poddId);

        // KATEGORIER
        Task LäggTillKategori(string namn);
        Task UppdateraKategori(string kategoriId, string nyttNamn);
        Task TaBortKategori(string kategoriId);
        Task<List<Kategori>> HämtaAllaKategorier();
    }
}
