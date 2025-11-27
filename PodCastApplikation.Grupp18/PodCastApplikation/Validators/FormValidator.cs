using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodCastApplikation.Validators
{
    public static class FormValidator
    {
        // Metod för att validera URL
        public static bool ÄrGiltigUrl(string url)
        {
            if (string.IsNullOrEmpty(url))
                return false;

            return Uri.TryCreate(url, UriKind.Absolute, out Uri? uri)
                   && (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps);
        }

        // Metod för att validera poddflöde namn
        public static bool ÄrGiltigtPoddNamn(string namn)
        {
            return !string.IsNullOrWhiteSpace(namn)
                && namn.Trim().Length >= 2
                && namn.Length <= 50
                && namn == namn.Trim();
        }

        // Metod för att validera kategori namn
      public static bool ÄrGiltigtKategoriNamn(string namn)
        {
            return !string.IsNullOrWhiteSpace(namn)
                && namn.Trim().Length >= 2
                && namn.Length <= 50
                && namn == namn.Trim();
        }

        // Metod för att kontrollera om ett poddflöde är valt
        public static bool ÄrPoddVald(object podd)
        {
            return podd != null;
        }

        // Metod för att kontrollera om en kategori är vald
        public static bool ÄrKategoriVald(object kategori)
        {
            return kategori != null;
        }

        // Metod för att kontrollera om en kategori är vald för borttagning
        public static bool ÄrKategoriValdFörBorttagning(object kategori)
        {
            return kategori != null;
        }

        // Metod för att validera uppdateringsintervall
        public static bool ÄrGiltigtUppdateringsIntervall(string text)
        {
            return !string.IsNullOrWhiteSpace(text)
                && int.TryParse(text, out int intervall)
                && intervall >= 5
                && intervall <= 60;
        }



    }
}

