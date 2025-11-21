using MongoDB.Driver;
using Models.Interfaces;
using Models.Klasser;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Mongo
{
    public class KategoriRepository : IKategoriRepository
    {
        private IMongoClient _client;
        private IMongoDatabase _database;
        private IMongoCollection<Kategori> _kategorier;

        public KategoriRepository()
        {
            var connectionString = "mongodb+srv://OruMongoDBAdmin:mByfTKzZCnVYXgw8@orumongodb.5yfpn9e.mongodb.net/?appName=OruMongoDB";

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

        public async Task SkapaKategori(Kategori kategori)
        {
            await _kategorier.InsertOneAsync(kategori);
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
    }
}
