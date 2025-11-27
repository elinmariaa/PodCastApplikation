using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodCastApplikation.Business.Validation
{
    public static class KategoriValidator
    {
        // Kollar att namnet följer reglerna (2–50 tecken, ej tomt)
        public static bool ÄrGiltigNamn(string namn)
            {
               return !string.IsNullOrWhiteSpace(namn) 
                && namn.Trim().Length >= 2
                && namn.Trim().Length <= 50;
            }

        // Kollar att namnet följer reglerna (2–50 tecken, ej tomt)
        public static bool ÄrUniktNamn(string namn, List<Models.Klasser.Kategori> befintligaKategorier)
        {
            return !befintligaKategorier
                .Any(k => k.Namn.Equals(namn, StringComparison.OrdinalIgnoreCase));
        }

        // Kollar att nytt namn inte kolliderar med andra kategorier (vid uppdatering)
        public static bool ÄrUniktVidUppdatering(
            string nyttNamn, 
            string kategoriId,
            List<Models.Klasser.Kategori> befintligaKategorier)
        {
            return !befintligaKategorier
                .Any(k => k.Namn.Equals(nyttNamn, StringComparison.OrdinalIgnoreCase)
                          && k.Id != kategoriId);
        }

        // Kollar att kategoriId inte är tomt eller null
        public static bool ÄrGiltigId(string kategoriId)
        {
            return !string.IsNullOrWhiteSpace(kategoriId);
        }

        // Kollar att ingen podd använder kategorin (vid borttagning)
        public static bool KanTaBortKategori(
            string kategoriId,
            List<Models.Klasser.Podd> allaPoddar)
        {
            return !allaPoddar
                .Any(p => p.KategoriId == kategoriId);
        }
    }
}
