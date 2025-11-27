using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PodCastApplikation.Models.Klasser
{
    public class Kategori
    {
        [BsonId] // markerar att detta är primärnyckeln
        [BsonRepresentation(BsonType.ObjectId)] 
        public string Id { get; set; }
        public string Namn { get; set; }       
    }
}
