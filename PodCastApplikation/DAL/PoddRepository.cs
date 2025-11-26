using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver; // för MongoDB klienten
using PodCastApplikation.Models.Interfaces; // Här ligger IPOddRepository
using PodCastApplikation.Models.Klasser;// Här ligger klassen Podd



namespace PodCastApplikation.DAL // Namespace utifrån att projektet heter "DAL" och mappen "Mongo"

{
    // Denna klass sköter all kontakt med MongoDB för poddar
    public class  PoddRepository : IPoddRepository
    {
        private  IMongoClient _client; // fält för att spara kopplingen till MongoDB - kluster

        private  IMongoDatabase _database; // Färlt för att hålla referens till rätt databas (OruMongoDb)

        private  IMongoCollection<Podd> _poddar; // fält för collectionen ("tabellen") där alla Podd-dokument lagras

        public PoddRepository() // Konstruktorn körs när du skapar ett nytt PoddRepository objekt. Här skapas kopplingen till MongoDB och vi viljer databas + collection

        {
            var conncetionString = "mongodb+srv://OruMongoDBAdmin2:orumongoDB@orumongodb.wtryamo.mongodb.net/OruMongoDB?retryWrites=true&w=majority";
                    // Anluter MongDB conncetion strängen till Projektet
      
            _client = new MongoClient(conncetionString); // Skapar en klient = kopplingen mot MOngoDb-kluster

            _database = _client.GetDatabase("OruMongoDB"); // Väljer databasen (OruMongoDb) i Atlas

            // Väljer collectionen där poddar ska sparas
            // Namnet "Poddar" kommer sysnas som collection-namn i Atlas
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

        public async Task<Podd> HämtaPoddMedId(string id) // Hämtar podden med hjälp av id 

        {
            var filter = Builders<Podd>.Filter.Eq(p => p.Id, id);
           
            return await _poddar.Find(filter).FirstOrDefaultAsync(); 
        }

        public async Task SparaPodd(Podd podd) // spara en ny podd
        {
            try
            {
                await _poddar.InsertOneAsync(podd);
            }
            catch (Exception ex)
            {
                throw new Exception("Fel vi försök att spara podd i databas.", ex);
            }
        }


        public async Task UppdateraPoddKategori(string poddId, string kategoriId)
        {
            try
            {
                var filter = Builders<Podd>.Filter.Eq(p => p.Id, poddId);
                var update = Builders<Podd>.Update.Set(p => p.KategoriId, kategoriId);

                await _poddar.UpdateOneAsync(filter, update);
            }
            catch (Exception ex)
            {
                throw new Exception("Fel vid uppdatering av poddens kategori.", ex);
            }
        }

        public async Task UppdateraPodd(Podd podd)
        {
            try
            {
                var filter = Builders<Podd>.Filter.Eq(p => p.Id, podd.Id);
                await _poddar.ReplaceOneAsync(filter, podd);
            }
            catch (Exception ex)
            {
                throw new Exception("Fel vid uppdatering av podd i databasen.", ex);
            }
        }

        public async Task TabortPodd(string id) // ta bort en podd gennom id
        {
            try
            {
                var filter = Builders<Podd>.Filter.Eq(p => p.Id, id);
                await _poddar.DeleteOneAsync(filter);
            }
            catch (Exception ex)
            {
                throw new Exception("Fel vid borttagning av podd i databasen.", ex);
            }
        }

    }

}

