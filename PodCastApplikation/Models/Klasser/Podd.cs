using System;
using System.Collections.Generic;

namespace Models.Klasser
{
    public class Podd
    {
        public string? Id { get; set; } // get/set tillåter läsning/skrivning
        public string? OriginalTitel { get; set; } // Titel från RSS-flödet

        public string? AnvändarTitel { get; set; } //Titel som användaren döpt podden till
        public string? Beskrivning { get; set; } //Poddens beskrvning från RSS

        public string? RssURL { get; set; } //RSS-adressen anv'ndaren skriver in

        public string? KategoriId { get; set; } // Vilken kategori podden tillhör

        public List<Avsnitt> Avsnitt { get; set; } = new(); //varje gång en Podd skapas, så skapas automatiskt en tom lista. 

    }
}
