using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver; // för MongoDB klienten
using Models.Interfaces; // Här ligger IPOddRepository
using Models.Klasser; // Här ligger klassen Podd


namespace DAL.Mongo // Namespace utifrån att projektet heter "DAL" och mappen "Mongo"

{
    // Denna klass sköter all kontakt med MongoDB för poddar
    public class  PoddRepository : IPoddRepository
    {
        private  IMongoClient _client; // fält för att spara kopplingen till MongoDB - kluster

        private  IMongoDatabase _database; // Färlt för att hålla referens till rätt databas (OruMongoDb)

        private  IMongoCollection<Podd> _poddar; // fält för collectionen ("tabellen") där alla Podd-dokument lagras

        public PoddRepository() // Konstruktorn körs när du skapar ett nytt PoddRepository objekt. Här skapas kopplingen till MongoDB och vi viljer databas + collection

        {
            var conncetionString = "mongodb+srv://OruMongoDBAdmin:mByfTKzZCnVYXgw8@orumongodb.5yfpn9e.mongodb.net/?appName=OruMongoDB"; // Anluter MongDB conncetion strängen till Projektet
      
            _client = new MongoClient(conncetionString); // Skapar en klient = kopplingen mot MOngoDb-kluster

            _database = _client.GetDatabase("OruMongoDB"); // Väljer databasen (OruMongoDb) i Atlas

            // Väljer collectionen där poddar ska sparas
            // Namnet "Poddar" kommer sysnas som collection-namn i Atlas
            _poddar = _database.GetCollection<Podd>("Poddar");

        }

        public async Task<List<Podd>> HämtaAllaPoddar()
        
        { 
            var lista = await _poddar
            .Find(Builders<Podd>.Filter.Empty)
            .ToListAsync();

            return lista;     // Hämtar alla dokument i collectionen (inget filter = allt)

        }

        public async Task<Podd> HämtaPoddMedId(string id)

        { 
            throw new NotImplementedException();
        }

        public async Task SparaPodd(Podd podd) // spara en ny podd
        {
            await _poddar.InsertOneAsync(podd);
        }

        public async Task UppdateraPodd(Podd podd) // uppdaterar befintliga poddar

        { throw new NotImplementedException();

        }

        public async Task TabortPodd(string id) // ta bort en podd gennom id
        { 
            throw new NotImplementedException();    
        }
    }

}

