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
            if (string.IsNullOrWhiteSpace(rssUrl))
                throw new ArgumentException("RSS URL får inte vara tom.");

            var allaPoddar = await _poddRepository.HämtaAllaPoddar();

            bool finnsRedan = allaPoddar
                .Any(p => p.RssURL.Equals(rssUrl, StringComparison.OrdinalIgnoreCase));


            if (finnsRedan)
                throw new InvalidOperationException("Podden finns redan i systemet.");

            var podd = await _rssHämtare.HämtaPoddFrånRssUrl(rssUrl);

            await _poddRepository.SparaPodd(podd);
        }


        // Metod för att hämta alla poddflöden
        public async Task<List<Podd>> HämtaAllaPoddar()
        {
            return await _poddRepository.HämtaAllaPoddar();
        }

        // Metod för att hämta alla avsnitt för ett specifikt poddflöde
        public async Task<List<Avsnitt>> HämtaAvsnittFörPodd(string poddId)
        {
            var podd = await _poddRepository.HämtaPoddMedId(poddId);

            if (podd == null)
            {
                throw new KeyNotFoundException("Podd med angivet ID hittades inte.");
            }
            return podd.Avsnitt;
        }

        // Metod för att uppdatera poddflödets namn
        public async Task UppdateraPoddNamn(string poddId, string nyttNamn)
        {
            if (string.IsNullOrWhiteSpace(nyttNamn) || nyttNamn.Length < 2 || nyttNamn.Length > 50)
            {
                throw new ArgumentException("Det nya namnet är ogiltigt.");
            }

            var podd = await _poddRepository.HämtaPoddMedId(poddId);

            if (podd == null)
            {
                throw new KeyNotFoundException("Podd med angivet ID hittades inte.");
            }

            podd.OriginalTitel = nyttNamn;

            await _poddRepository.UppdateraPodd(podd);
        }

        // Metod för att uppdatera poddflödets kategori
        public async Task UppdateraPoddKategori(string poddId, string nyKategoriId)
        {
            if (string.IsNullOrWhiteSpace(nyKategoriId))
            {
                throw new ArgumentException("Kategori-ID får inte vara tomt.");
            }

            var podd = await _poddRepository.HämtaPoddMedId(poddId);

            if (podd == null)
            {
                throw new InvalidOperationException("Podden kunde inte hittas.");
            }

            var kategori = (await _kategoriRepository.HämtaAllaKategorier())
                           .FirstOrDefault(k => k.Id == nyKategoriId);

            if (kategori == null)
            {
                throw new InvalidOperationException("Kategorin kunde inte hittas.");
            }

            podd.KategoriId = nyKategoriId;

            await _poddRepository.UppdateraPodd(podd);

        }

        // Metod för att ta bort ett poddflöde
        public async Task TaBortPodd(string poddId)
        {
            if (string.IsNullOrWhiteSpace(poddId))
            {
                throw new ArgumentException("Podd-ID får inte vara tomt.");
            }

            var podd = await _poddRepository.HämtaPoddMedId(poddId);

            if (podd == null)
            {
                throw new InvalidOperationException("Podden kunde inte hittas.");
            }

            await _poddRepository.TabortPodd(poddId);
        }

        // Metod för att lägga till en ny kategori
        public async Task LäggTillKategori(string namn)
        {
            if (string.IsNullOrWhiteSpace(namn) || namn.Trim().Length < 2 || namn.Trim().Length > 50)
            {
                throw new ArgumentException("Det angivna kategorinamnet är ogiltigt.");
            }

            var allaKategorier = await _kategoriRepository.HämtaAllaKategorier();

            bool finnsRedan = allaKategorier
                .Any(k => k.Namn.Equals(namn, StringComparison.OrdinalIgnoreCase));

            if (finnsRedan)
            {
                throw new InvalidOperationException("Kategorin finns redan i systemet.");
            }

            var kategori = new Kategori
            {
                Namn = namn
            };

            await _kategoriRepository.SkapaKategori(kategori);

        }

        // Metod för att uppdatera en kategoris namn
        public async Task UppdateraKategori(string kategoriId, string nyttNamn)
        {
            if (string.IsNullOrWhiteSpace(nyttNamn) || nyttNamn.Trim().Length < 2 || nyttNamn.Trim().Length > 50)
            {
                throw new ArgumentException("Det angivna kategorinamnet är ogiltigt.");
            }
            var allaKategorier = await _kategoriRepository.HämtaAllaKategorier();
           
            var kategori = allaKategorier
                .FirstOrDefault(k => k.Id == kategoriId);

            if (kategori == null)
            {
                throw new KeyNotFoundException("Kategorin med angivet ID hittades inte.");
            }
           
            bool finnsRedan = allaKategorier
                .Any(k => k.Namn.Equals(nyttNamn, StringComparison.OrdinalIgnoreCase) && k.Id != kategoriId);
           
            if (finnsRedan)
            {
                throw new InvalidOperationException("En annan kategori med samma namn finns redan i systemet.");
            }
            
            kategori.Namn = nyttNamn;
           
            await _kategoriRepository.UppdateraKategori(kategori);
        }

        // Metod för att ta bort en kategori
        public async Task TaBortKategori(string kategoriId)
        {
            if (string.IsNullOrWhiteSpace(kategoriId))
            {
                throw new ArgumentException("Kategori-ID får inte vara tomt.");
            }
            var allaKategorier = await _kategoriRepository.HämtaAllaKategorier();
            
            var kategori = allaKategorier
                .FirstOrDefault(k => k.Id == kategoriId);
            
            if (kategori == null)
            {
                throw new KeyNotFoundException("Kategorin med angivet ID hittades inte.");
            }

            var allaPoddar = await _poddRepository.HämtaAllaPoddar();
            
            bool användsAvPodd = allaPoddar
                .Any(p => p.KategoriId == kategoriId);
            if (användsAvPodd)
            {
                throw new InvalidOperationException("Kategorin kan inte tas bort eftersom den används av en eller flera poddar.");  
            }

            await _kategoriRepository.TaBortKategori(kategoriId);
        }

        // Metod för att hämta alla kategorier
        public async Task <List<Kategori>> HämtaAllaKategorier()
        {
            return await _kategoriRepository.HämtaAllaKategorier();
        }


    }
}
