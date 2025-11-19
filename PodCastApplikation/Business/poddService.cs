using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Interfaces;
using Models.Klasser;

namespace PodCastApplikation.Business
{
    public class PoddService
    {
        private readonly IRssHämtare _rssHämtare;
        private readonly IPoddRepository _poddRepository;
        private readonly IKategoriRepository _kategoriRepository; 
        public PoddService(IRssHämtare rssHämtare, IPoddRepository poddRepository, IKategoriRepository kategoriRepository)
        {
            _rssHämtare = rssHämtare;
            _poddRepository = poddRepository;
            _kategoriRepository = kategoriRepository;
        }

        // Metod för att lägga till ett nytt poddflöde
        public async Task LäggTillPodd(string rssUrl)
        {
        }

        // Metod för att hämta alla poddflöden
        public async Task<List<Podd>> HämtaAllaPoddar()
        {
            return await _poddRepository.HämtaAllaPoddar();
        }

        // Metod för att hämta alla avsnitt för ett specifikt poddflöde
        public async Task<List<Avsnitt>> HämtaAvsnittFörPodd(string poddId)
        {
            return new List<Avsnitt>();
        }

        // Metod för att uppdatera poddflödets namn
        public async Task UppdateraPoddNamn(string poddId, string nyttNamn)
        {
        }

        // Metod för att uppdatera poddflödets kategori
        public async Task UppdateraPoddKategori(string poddId, string kategoriId)
        {
        }

        // Metod för att ta bort ett poddflöde
        public async Task TaBortPodd(string poddId)
        {
        }

        // Metod för att lägga till en ny kategori
        public async Task LäggTillKategori(string namn)
        {
        }

        // Metod för att uppdatera en kategoris namn
        public async Task UppdateraKategori(string kategoriId, string nyttNamn)
        {
        }

        // Metod för att ta bort en kategori
        public async Task TaBortKategori(string kategoriId)
        {
        }

        // Metod för att hämta alla kategorier
        public async Task <List<Kategori>> HämtaAllaKategorier()
        {
            return await _kategoriRepository.HämtaAllaKategorier();
        }


    }
}
