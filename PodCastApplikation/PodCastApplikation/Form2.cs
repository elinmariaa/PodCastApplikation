using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using PodCastApplikation.Business;
using PodCastApplikation.Models.Klasser;



namespace PodCastApplikation

{ 
    public partial class Form2 : Form

    {
        private readonly IPoddService _service;

        public Form2(IPoddService service)

        {

            InitializeComponent();
            _service = service;



            // Kategori-funktioner

            btnSkapaKategori.Click += BtnSkapaKategori_Click;

            btnBytKategoriNamn.Click += BtnBytKategoriNamn_Click;

            btnRaderaKategori.Click += BtnRaderaKategori_Click;

            btnSortera.Click += BtnSortera_Click;

            btnVisaSparade.Click += BtnVisaSparade_Click;

            btnIntervall.Click += BtnIntervall_Click;


            // Ladda kategorier när fönstret öppnas
            Load += async (s, e) => await LaddaKategorier();

        }
        private async Task LaddaKategorier()
        {
            lstKategorier.Items.Clear();
            var kategorier = await _service.HämtaAllaKategorier();
            foreach (var kategori in kategorier)
            {
                lstKategorier.Items.Add(kategori.Namn);
            }
        }



        // ------------------------------------------

        // KNAPPFUNKTIONER

        // ------------------------------------------



        private async void BtnSkapaKategori_Click(object sender, EventArgs e)

        {         
                try
                {
                    string namn = txtKategoriNamn.Text;
                    await _service.LäggTillKategori(namn);
                    MessageBox.Show("Kategori tillagd!");
                    await LaddaKategorier();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                 }
         }

        private async void BtnRaderaKategori_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstKategorier.SelectedItem == null)
                {
                    MessageBox.Show("Välj en kategori först.");
                    return;
                }

                var kategorier = await _service.HämtaAllaKategorier();
                var vald = kategorier[lstKategorier.SelectedIndex];

                await _service.TaBortKategori(vald.Id);
                MessageBox.Show("Kategori borttagen!");
                await LaddaKategorier();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    





        private void BtnBytKategoriNamn_Click(object sender, EventArgs e)

        {

            // Byt namn på vald kategori

        }



        private void BtnSortera_Click(object sender, EventArgs e)

        {

            // Sortera kategorier alfabetiskt

        }



        private void BtnVisaSparade_Click(object sender, EventArgs e)

        {

            // Visa sparade kategorier i lstKategorier

        }



        private void BtnIntervall_Click(object sender, EventArgs e)

        {

            // Spara valt uppdateringsintervall från cmbIntervall

        }



       



        private void lstKategorier_SelectedIndexChanged(object sender, EventArgs e)

        {



        }

    }

}