using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver; 
using PodCastApplikation.Models.Interfaces; 
using PodCastApplikation.Models.Klasser;



namespace PodCastApplikation.DAL 

{
    // Denna klass sköter all kontakt med MongoDB för poddar
    public class  PoddRepository : IPoddRepository
    {
        private  IMongoClient _client; 

        private  IMongoDatabase _database; 

        private  IMongoCollection<Podd> _poddar; 
        
        public PoddRepository() 

        {
            var conncetionString = "mongodb+srv://OruMongoDBAdmin2:orumongoDB@orumongodb.wtryamo.mongodb.net/OruMongoDB?retryWrites=true&w=majority";
                    
      
            _client = new MongoClient(conncetionString); 

            _database = _client.GetDatabase("opponering"); 

     
            _poddar = _database.GetCollection<Podd>("Poddar");

        }

        public async Task<List<Podd>> HämtaAllaPoddar()
        
        { 
            try
            {
               return await _poddar.Find(Builders<Podd>.Filter.Empty).ToListAsync();
            }
            catch(Exception ex)
            {
                throw new Exception("fel vid hämtning av poddar från databas. ", ex);
            }
            

        }

        public async Task<Podd> HämtaPoddMedId(string id) 

        {
            var filter = Builders<Podd>.Filter.Eq(p => p.Id, id);
           
            return await _poddar.Find(filter).FirstOrDefaultAsync(); 
        }

        public async Task SparaPodd(Podd podd) 
        {
            using var session = await _client.StartSessionAsync();
            session.StartTransaction();

            try
            {
                await _poddar.InsertOneAsync(session, podd);
                await session.CommitTransactionAsync();
            }
            catch (Exception ex)
            {
                await session.AbortTransactionAsync();
                throw new Exception("Fel vi försök att spara podd i databas.", ex);
            }
        }


        public async Task UppdateraPoddKategori(string poddId, string kategoriId)
        {
            using var session = await _client.StartSessionAsync();
            session.StartTransaction();

            try
            {
                var filter = Builders<Podd>.Filter.Eq(p => p.Id, poddId); 
                var update = Builders<Podd>.Update.Set(p => p.KategoriId, kategoriId);

                await _poddar.UpdateOneAsync(session, filter, update);
                await session.CommitTransactionAsync(); 
            }
            catch (Exception ex)
            {
                await session.AbortTransactionAsync();
                throw new Exception("Fel vid uppdatering av poddens kategori.", ex);
            }
        }

        public async Task UppdateraPodd(Podd podd)
        {
            using var session = await _client.StartSessionAsync();
            session.StartTransaction();

            try
            {
                var filter = Builders<Podd>.Filter.Eq(p => p.Id, podd.Id);

                await _poddar.ReplaceOneAsync(session, filter, podd);
                await session.CommitTransactionAsync();
            }
            catch (Exception ex)
            {
                await session.AbortTransactionAsync();
                throw new Exception("Fel vid uppdatering av podd i databasen.", ex);
            }
        }

        public async Task TabortPodd(string id) 
        {
            using var session = await _client.StartSessionAsync();
            session.StartTransaction();

            try
            {
                var filter = Builders<Podd>.Filter.Eq(p => p.Id, id);

                await _poddar.DeleteOneAsync(session, filter);
                await session.CommitTransactionAsync();

            }
            catch (Exception ex)
            {
                await session.AbortTransactionAsync();
                throw new Exception("Fel vid borttagning av podd i databasen.", ex);
            }
        }

    }

}

