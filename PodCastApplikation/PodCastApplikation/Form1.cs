using System;

using System.Windows.Forms;
using PodCastApplikation.Business;
using PodCastApplikation.Models.Klasser;
using System.Threading.Tasks;
using PodCastApplikation.Business.Validation;



namespace PodCastApplikation

{

    public partial class Form1 : Form
    {
        private readonly IPoddService _service;
        public Form1()

        {
            InitializeComponent();
        }


        public Form1(IPoddService service)
        {
            InitializeComponent();
            _service = service;



            // Poddfunktions-knappar

            btnLaggTillPodd.Click += BtnLaggTillPodd_Click;

            btnVisaAlla.Click += BtnVisaAlla_Click;

            btnRaderaPodd.Click += BtnRaderaPodd_Click;

            btnUppdateraPodd.Click += BtnUppdateraPodd_Click;

            btnSparaPrenumerera.Click += BtnSparaPrenumerera_Click;

            btnBytNamnPodd.Click += BtnBytNamnPodd_Click;



            // Avsnitt

            btnVisaAvsnitt.Click += BtnVisaAvsnitt_Click;

            lstAvsnitt.SelectedIndexChanged += LstAvsnitt_SelectedIndexChanged;



            // Kategorifönster

            btnOppenKategoriFonster.Click += BtnOppenKategoriFonster_Click;



            // Filtrering

            cmbFiltreraKategori.SelectedIndexChanged += CmbFiltreraKategori_SelectedIndexChanged;

        }



        // -------------------------------

        // PODDAR / RSS

        // -------------------------------



        private async void BtnLaggTillPodd_Click(object sender, EventArgs e)

        {

            try
            {
                string rssUrl = txtRssLank.Text; //UI hämtar text från rutan

                await _service.LäggTillPodd(rssUrl); //UI pratar med business lagret

                MessageBox.Show("Podd tillagd");

                await LaddaAllaPoddar();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            // Hämta RSS → Visa i listbox → (Ej spara än)

        }



        private async void BtnVisaAlla_Click(object sender, EventArgs e)

        {

            try
            {
                var poddar = await _service.HämtaAllaPoddar();

                lstPoddar.Items.Clear(); //rensar gamla värden

                foreach (var podd in poddar)
                {
                    lstPoddar.Items.Add(podd.OriginalTitel); //visar titel på alla poddar
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fel: {ex.Message}");
            }

        }



        private void BtnRaderaPodd_Click(object sender, EventArgs e)

        {

            // Ta bort markerad podd och dess sparade avsnitt

        }



        private void BtnUppdateraPodd_Click(object sender, EventArgs e)

        {

            // Uppdatera valt RSS-flöde

        }



        private void BtnSparaPrenumerera_Click(object sender, EventArgs e)

        {

            // Spara podden + vald kategori

            // cmbValjKategori.SelectedItem används här

        }



        private void BtnBytNamnPodd_Click(object sender, EventArgs e)

        {

            // Byt namn på vald podd

        }

        private async Task LaddaAllaPoddar()
        {
            var poddar = await _service.HämtaAllaPoddar();

            lstPoddar.Items.Clear();
            foreach (var podd in poddar)
            {
                lstPoddar.Items.Add(podd.OriginalTitel);
            }
        }




        // -------------------------------

        // AVSNITT

        // -------------------------------



        private void BtnVisaAvsnitt_Click(object sender, EventArgs e)

        {

            // Visa avsnitten för vald podd i lstAvsnitt

        }



        private void LstAvsnitt_SelectedIndexChanged(object sender, EventArgs e)

        {

            // När användaren klickar på ett avsnitt → Fyll detaljer

            // txtTitel.Text = ...

            // txtDatum.Text = ...

            // txtBeskrivning.Text = ...

        }



        // -------------------------------

        // FILTRERING (kategori → poddar)

        // -------------------------------



        private void CmbFiltreraKategori_SelectedIndexChanged(object sender, EventArgs e)

        {

            // Filtrera lstPoddar baserat på vald kategori

        }



        // -------------------------------

        // KATEGORIFÖNSTER

        // -------------------------------



        private void BtnOppenKategoriFonster_Click(object sender, EventArgs e)

        {

            Form2 kategoriFonster = new Form2();

            kategoriFonster.Show();

        }



        private void lblBeskrivning_Click(object sender, EventArgs e)

        {


        }



        private void txtRssLank_TextChanged(object sender, EventArgs e)

        {



        }



        private void txtNyttNamn_TextChanged(object sender, EventArgs e)

        {



        }



        private void txtTitel_TextChanged(object sender, EventArgs e)

        {



        }



        private void cmbValjKategori_SelectedIndexChanged(object sender, EventArgs e)

        {



        }


    }

}

