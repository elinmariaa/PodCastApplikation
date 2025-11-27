using PodCastApplikation.Business;
using PodCastApplikation.Business.Validation;
using PodCastApplikation.DAL;


namespace PodCastApplikation
{
    internal static class Program
    {
        
        [STAThread]
        static async Task Main()
        {
            var repo = new KategoriRepository();
            var alla = await repo.HämtaAllaKategorier();
            Console.WriteLine($"Antal kategorier: {alla.Count}");

            ApplicationConfiguration.Initialize();

            var rssHämtare = new RssHämtare();
            var poddRepository = new PoddRepository();
            var kategoriRepository = new KategoriRepository();

            var poddService = new PoddService(rssHämtare, poddRepository, kategoriRepository);

           
            Application.Run(new Form1(poddService));


       
            
           
        }
    }
}