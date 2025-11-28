using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;



namespace PodCastApplikation.Models.Klasser
{
    [BsonIgnoreExtraElements]
    public class Podd
    {
        [BsonId] 
        [BsonRepresentation(BsonType.ObjectId)]

        public string? Id { get; set; } 
        public string? OriginalTitel { get; set; }

        public string? AnvändarTitel { get; set; } 
        public string? Beskrivning { get; set; } 

        public string? RssURL { get; set; } 

        public string? KategoriId { get; set; } 

        public List<Avsnitt> Avsnitt { get; set; } = new(); 

    }
}
