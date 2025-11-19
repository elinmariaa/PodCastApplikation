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
        public static bool IsValidUrl(string url)
        {
            if (string.IsNullOrEmpty(url))
                return false;

            return Uri.TryCreate(url, UriKind.Absolute, out Uri? validatedUri)
                   && (validatedUri.Scheme == Uri.UriSchemeHttp || validatedUri.Scheme == Uri.UriSchemeHttps);
        }

        // Metod för att validera poddflöde namn
        public static bool IsValidFeedName(string name)
        {
            return !string.IsNullOrWhiteSpace(name)
                && name.Trim().Length >= 2
                && name.Length <= 50
                && name == name.Trim();
        }

        // Metod för att validera kategori namn
        public static bool IsValidCategoryName(string name)
        {
            return !string.IsNullOrWhiteSpace(name)
                && name.Trim().Length >= 2
                && name.Length <= 50
                && name == name.Trim();
        }

        // Metod för att kontrollera om ett poddflöde är valt
        public static bool IsValidFeed(object feed)
        {
            return feed != null;
        }

        // Metod för att kontrollera om en kategori är vald
        public static bool IsCategorySelected(object category)
        {
            return category != null;
        }

        // Metod för att kontrollera om en kategori är vald för borttagning
        public static bool IsCategorySelectedForDeletion(object category)
        {
            return category != null;
        }

        // Metod för att validera uppdateringsintervall
        public static bool IsValidUpdateInterval(string text)
        {
            return !string.IsNullOrWhiteSpace(text)
                && int.TryParse(text, out int interval)
                && interval >= 5
                && interval <= 60;
        }



    }
}

