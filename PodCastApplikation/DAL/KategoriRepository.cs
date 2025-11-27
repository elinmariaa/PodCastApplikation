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
            using var session = await _client.StartSessionAsync();
            session.StartTransaction();
            try
            {
                var filter = Builders<Kategori>.Filter.Eq(k => k.Id, kategori.Id);

                await _kategorier.ReplaceOneAsync(filter, kategori);
                await session.CommitTransactionAsync();
            }
            catch (Exception ex)
            {
                await session.AbortTransactionAsync();
                throw new Exception("Ett fel uppstod vid uppdateringen av kategorin.", ex);
            }

        }

        public async Task TaBortKategori(string id)
        {
            using var session = await _client.StartSessionAsync();
            session.StartTransaction();
            try
            {
                var filter = Builders<Kategori>.Filter.Eq(k => k.Id, id);

                await _kategorier.DeleteOneAsync(filter);
                await session.CommitTransactionAsync();
            }
            catch (Exception ex)
            {
                await session.AbortTransactionAsync();
                throw new Exception("Ett fel uppstod vid borttagningen av kategorin.", ex);
            }
        }
        public async Task SparaKategori(Kategori kategori)
        {
            using var session = await _client.StartSessionAsync();
            session.StartTransaction();
            try
            {
                await _kategorier.InsertOneAsync(session, kategori);
                await session.CommitTransactionAsync();
            }
            catch (Exception ex)
            {
                await session.AbortTransactionAsync();
                throw new Exception("Ett fel uppstod vid sparandet av kategorin.", ex);
            }

        }
    }
}
