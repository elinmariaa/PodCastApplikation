using PodCastApplikation.Business;
using PodCastApplikation.Business.Validation;
using PodCastApplikation.DAL;


namespace PodCastApplikation
{
    internal static class Program
    {
        
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var rssHämtare = new RssHämtare();
            var poddRepository = new PoddRepository();
            var kategoriRepository = new KategoriRepository();

            var poddService = new PoddService(rssHämtare, poddRepository, kategoriRepository);

           
            Application.Run(new Form1(poddService));


       
            
           
        }
    }
}