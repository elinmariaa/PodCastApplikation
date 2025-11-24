using MongoDB.Driver;
using PodCastApplikation.Models.Interfaces;
using PodCastApplikation.Models.Klasser;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PodCastApplikation.DAL
{
    public class KategoriRepository : IKategoriRepository
    {
        private IMongoClient _client;
        private IMongoDatabase _database;
        private IMongoCollection<Kategori> _kategorier;

        public KategoriRepository()
        {
            var connectionString = "mongodb+srv://OruMongoDBAdmin2:orumongoDB@orumongodb.wtryamo.mongodb.net/OruMongoDB?retryWrites=true&w=majority";

            _client = new MongoClient(connectionString);
            _database = _client.GetDatabase("OruMongoDB");
            _kategorier = _database.GetCollection<Kategori>("Kategorier");
        }

        public async Task<List<Kategori>> HämtaAllaKategorier()
        {
            var lista = await _kategorier
                .Find(Builders<Kategori>.Filter.Empty)
                .ToListAsync();

            return lista;
        }

     

        public async Task UppdateraKategori(Kategori kategori)
        {
            var filter = Builders<Kategori>.Filter.Eq(k => k.Id, kategori.Id);
            await _kategorier.ReplaceOneAsync(filter, kategori);
        }

        public async Task TaBortKategori(string id)
        {
            var filter = Builders<Kategori>.Filter.Eq(k => k.Id, id);
            await _kategorier.DeleteOneAsync(filter);
        }
        public async Task SparaKategori(Kategori kategori)
        {
            await _kategorier.InsertOneAsync(kategori);
        }
    }
}
