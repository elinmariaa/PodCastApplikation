using PodCastApplikation.Models.Klasser;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PodCastApplikation.Models.Interfaces
{
    public interface IKategoriRepository
    {
        Task<List<Kategori>> HämtaAllaKategorier();
      
        Task UppdateraKategori(Kategori kategori);
        Task TaBortKategori(string id);
        Task SparaKategori(Kategori kategori);

    }
}
