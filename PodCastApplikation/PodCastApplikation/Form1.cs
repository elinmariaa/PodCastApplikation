using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using PodCastApplikation.Business;
using PodCastApplikation.Models.Klasser;



namespace PodCastApplikation

{

    public partial class Form1 : Form
    {
        private readonly IPoddService _service;

        private List<Avsnitt> _aktuellaAvsnitt = new();
        public Form1(IPoddService service)
        {
            InitializeComponent();
            _service = service;



            // Poddfunktions-knappar

            btnLaggTillPodd.Click += BtnLaggTillPodd_Click;

            btnVisaAlla.Click += BtnVisaAlla_Click;

            btnRaderaPodd.Click += BtnRaderaPodd_Click;

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



        private async void BtnRaderaPodd_Click(object sender, EventArgs e)

        {
            try
            {
                if (lstPoddar.SelectedItem == null)
                {
                    MessageBox.Show("Välj en podd att radera.");
                    return;
                }

                var poddar = await _service.HämtaAllaPoddar();
                var valdPodd = poddar[lstPoddar.SelectedIndex];

                await _service.TaBortPodd(valdPodd.Id);

                MessageBox.Show("Podd raderad.");
                await LaddaAllaPoddar();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fel vid radering: " + ex.Message);
            }

        }






        private async void BtnSparaPrenumerera_Click(object sender, EventArgs e)

        {
            try
            {
                if (lstPoddar.SelectedItem == null)
                {
                    MessageBox.Show("Välj en podd att spara.");
                    return;
                }

                if (cmbValjKategori.SelectedItem == null)
                {
                    MessageBox.Show("Välj en kategori för podden.");
                    return;
                }

                var poddar = await _service.HämtaAllaPoddar();
                var valdPodd = poddar[lstPoddar.SelectedIndex];

                var kategorier = await _service.HämtaAllaKategorier();
                var valdKategori = kategorier[cmbValjKategori.SelectedIndex];

                await _service.UppdateraPoddKategori(valdPodd.Id, valdKategori.Id);

                MessageBox.Show($"Podd '{valdPodd.OriginalTitel}' har sparats med kategori '{valdKategori.Namn}'!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fel vid sparande: " + ex.Message);
            }

        }



        private async void BtnBytNamnPodd_Click(object sender, EventArgs e)

        {
            try
            {
                if (lstPoddar.SelectedItem == null)
                {
                    MessageBox.Show("Välj en podd att byta namn på.");
                    return;
                }
                string nyttNamn = txtNyttNamn.Text;
                if (string.IsNullOrWhiteSpace(nyttNamn))
                {
                    MessageBox.Show("Ange ett giltigt nytt namn.");
                    return;
                }

                await _service.UppdateraPoddNamn(
                    (await _service.HämtaAllaPoddar())[lstPoddar.SelectedIndex].Id,
                    nyttNamn
                );
                MessageBox.Show("Poddens namn har uppdaterats.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fel vid namnbyte: " + ex.Message);
            }

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



        private async void BtnVisaAvsnitt_Click(object sender, EventArgs e)

        {
            try
            {
                if (lstPoddar.SelectedItem == null)
                {
                    MessageBox.Show("Välj en podd för att visa dess avsnitt.");
                    return;
                }

                var poddar = await _service.HämtaAllaPoddar();
                var valdPodd = poddar[lstPoddar.SelectedIndex];
                var avsnittLista = await _service.HämtaAvsnittFörPodd(valdPodd.Id);

                _aktuellaAvsnitt = avsnittLista;

                lstAvsnitt.Items.Clear();

                foreach (var avsnitt in avsnittLista)
                {
                    lstAvsnitt.Items.Add(avsnitt.Titel);
                }

                if (avsnittLista.Count == 0)
                {
                    MessageBox.Show("Inga avsnitt hittades för den valda podden.");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Fel vid hämtning av avsnitt: " + ex.Message);
            }

        }



        private void LstAvsnitt_SelectedIndexChanged(object sender, EventArgs e)

        {
            if (lstAvsnitt.SelectedItem == null || _aktuellaAvsnitt == null)
            {
                return;
            }

            var avsnitt = _aktuellaAvsnitt[lstAvsnitt.SelectedIndex];

            txtTitel.Text = avsnitt.Titel;
            txtDatum.Text = avsnitt.PubliceringsDatum?.ToString("yyyy-MM-dd") ?? "Okänt datum";
            txtBeskrivning.Text = avsnitt.Beskrivning;
        }


        // FILTRERING (kategori → poddar)



        private void CmbFiltreraKategori_SelectedIndexChanged(object sender, EventArgs e)

        {

            // Filtrera lstPoddar baserat på vald kategori

        }


        // KATEGORIFÖNSTER



        private void BtnOppenKategoriFonster_Click(object sender, EventArgs e)

        {

            using (Form2 kategoriFonster = new Form2(_service)) // Skickar in din PoddService-instans
            {
                kategoriFonster.ShowDialog();
            }

        }

        private void txtRssLank_TextChanged(object sender, EventArgs e)

        {

        }



        private void txtNyttNamn_TextChanged(object sender, EventArgs e)

        {

        }

        private void cmbValjKategori_SelectedIndexChanged(object sender, EventArgs e)

        {

        }

        private async Task Form1_Load(object sender, EventArgs e)
        {
           
        }

        private async void btnVisaAlla_Click_1(object sender, EventArgs e)
        {
            try
            {
                var poddar = await _service.HämtaAllaPoddar();

                lstPoddar.Items.Clear();

                foreach (var podd in poddar)
                {
                    lstPoddar.Items.Add(podd.OriginalTitel);
                }

                MessageBox.Show("Visar alla poddar!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fel: " + ex.Message);
            }
        }

        private void lstAvsnitt_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (lstAvsnitt.SelectedItem == null || _aktuellaAvsnitt == null)
            {
                return;
            }

            var avsnitt = _aktuellaAvsnitt[lstAvsnitt.SelectedIndex];

            txtTitel.Text = avsnitt.Titel;
            txtDatum.Text = avsnitt.PubliceringsDatum?.ToString("yyyy-MM-dd") ?? "Okänt datum";
            txtBeskrivning.Text = avsnitt.Beskrivning;
        }
    }

}

