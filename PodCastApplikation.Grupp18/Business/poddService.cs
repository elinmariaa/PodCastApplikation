using MongoDB.Driver;
using PodCastApplikation.Business;
using PodCastApplikation.Models.Interfaces;
using PodCastApplikation.Models.Klasser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;


namespace PodCastApplikation.Business.Validation;

// Validator för poddar
public class PoddService : IPoddService
{
    private readonly IRssHämtare _rssHämtare;
    private readonly IPoddRepository _poddRepository;
    private readonly IKategoriRepository _kategoriRepository;

// konstruktor
    public PoddService(IRssHämtare rssHämtare, IPoddRepository poddRepository, IKategoriRepository kategoriRepository)
    {
        _rssHämtare = rssHämtare;
        _poddRepository = poddRepository;
        _kategoriRepository = kategoriRepository;
   
    }

    
    public async Task LäggTillPodd(string rssUrl)
    {
        try
        {
            RssValidator.ValideraRssUrl(rssUrl);
            await RssValidator.ValideraRssInnehålle(rssUrl);

            var allaPoddar = await _poddRepository.HämtaAllaPoddar();
            if (!PoddValidator.ÄrUnikRssUrl(rssUrl, allaPoddar))
                throw new InvalidOperationException("Podden finns redan i systemet.");

            var podd = await _rssHämtare.HämtaPoddFrånRssUrl(rssUrl);
            await _poddRepository.SparaPodd(podd);
        }
        catch (InvalidOperationException)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new Exception("Kunde inte lägga till podd. Kontrollera att RSS-länken är korrekt.", ex);
        }

    }

    public async Task<Podd> FörhandsgranskaPodd(string rssUrl)
    {
        RssValidator.ValideraRssUrl(rssUrl);
        await RssValidator.ValideraRssInnehålle(rssUrl);
        return await _rssHämtare.HämtaPoddFrånRssUrl(rssUrl);
    }

    public async Task<Podd> LäggTillPoddMedKategori(string rssUrl, string kategoriId)
    {
        try
        {

            RssValidator.ValideraRssUrl(rssUrl);
            await RssValidator.ValideraRssInnehålle(rssUrl);

            var allaPoddar = await _poddRepository.HämtaAllaPoddar();
            if (!PoddValidator.ÄrUnikRssUrl(rssUrl, allaPoddar))
                throw new InvalidOperationException("Podden finns redan i systemet.");

            var podd = await _rssHämtare.HämtaPoddFrånRssUrl(rssUrl);
            podd.KategoriId = kategoriId;

            await _poddRepository.SparaPodd(podd);

            return podd;
        }
        catch (Exception ex)
        {
            throw new Exception("Kunde inte lägga till podd. Kontrollera att RSS-länken och kategorin är korrekta.", ex);
        }
    }



    public async Task<List<Podd>> HämtaAllaPoddar()
    {
        var allaPoddar = await _poddRepository.HämtaAllaPoddar();
        return allaPoddar;
                                                           
    }

    
    public async Task<List<Avsnitt>> HämtaAvsnittFörPodd(string poddId)
    {
        var podd = await _poddRepository.HämtaPoddMedId(poddId);

        if (podd == null)
        {
            throw new KeyNotFoundException("Podd med angivet ID hittades inte.");
        }
        return podd.Avsnitt;
    }

    
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

        podd.AnvändarTitel = nyttNamn.Trim();

        await _poddRepository.UppdateraPodd(podd);
    }

    
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

    
    public async Task LäggTillKategori(string namn)
    {
        try
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

        await _kategoriRepository.SparaKategori(kategori);
    }
        catch (Exception ex)
          {
            throw new Exception("Fel i PoddService.LäggTillKategori: kunde inte spara kategori.", ex);
           }
    }

   
 

    
    public async Task TaBortKategori(string kategoriId)
    {
        try
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
        catch (Exception ex)
        {
            throw new Exception("Fel i PoddService.TaBortKategori.", ex);
        }
    }

    
    public async Task <List<Kategori>> HämtaAllaKategorier()
    {
        return await _kategoriRepository.HämtaAllaKategorier();
    }


}
