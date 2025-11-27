using System;
using System.Collections.Generic;
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
        private List<Podd> _visadePoddar = new();

       
        public Form1(IPoddService service)
        {
            InitializeComponent();
            _service = service;

            // Event wiring
            btnLaggTillPodd.Click += BtnLaggTillPodd_Click;
            btnVisaAlla.Click += BtnVisaAlla_Click;
            btnRaderaPodd.Click += BtnRaderaPodd_Click;
            btnSparaPrenumerera.Click += BtnSparaPrenumerera_Click;
            btnBytNamnPodd.Click += BtnBytNamnPodd_Click;
            btnVisaAvsnitt.Click += BtnVisaAvsnitt_Click;
            lstAvsnitt.SelectedIndexChanged += LstAvsnitt_SelectedIndexChanged;
            btnOppenKategoriFonster.Click += BtnOppenKategoriFonster_Click;
            cmbFiltreraKategori.SelectedIndexChanged += CmbFiltreraKategori_SelectedIndexChanged;
        

        // PODDAR
        private async void BtnLaggTillPodd_Click(object sender, EventArgs e)
        {
            try
            {
                string rssUrl = txtRssLank.Text;
                await _service.LäggTillPodd(rssUrl);
                MessageBox.Show("Podd tillagd");
                await LaddaAllaPoddar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void BtnVisaAlla_Click(object sender, EventArgs e)
        {
            try
            {
                await LaddaAllaPoddar();
                MessageBox.Show("Visar alla poddar");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fel: {ex.Message}");
            }
        }

        private async Task LaddaAllaPoddar()
        {
            var poddar = await _service.HämtaAllaPoddar();
            _visadePoddar = poddar;
            lstPoddar.Items.Clear();

            foreach (var podd in poddar)
            {
                lstPoddar.Items.Add(podd.OriginalTitel);
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

                var valdPodd = _visadePoddar[lstPoddar.SelectedIndex];

                await _service.TaBortPodd(valdPodd.Id);

                MessageBox.Show("Podd raderad.");
                await LaddaAllaPoddar();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fel vid radering: {ex.Message}");
            }
        }

        private async void BtnSparaPrenumerera_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstPoddar.SelectedItem == null)
                {
                    MessageBox.Show("Välj en podd.");
                    return;
                }

                if (cmbValjKategori.SelectedItem == null)
                {
                    MessageBox.Show("Välj kategori.");
                    return;
                }

                var poddar = await _service.HämtaAllaPoddar();
                var valdPodd = poddar[lstPoddar.SelectedIndex];

                var kategorier = await _service.HämtaAllaKategorier();
                var valdKategori = kategorier[cmbValjKategori.SelectedIndex];

                await _service.UppdateraPoddKategori(valdPodd.Id, valdKategori.Id);

                MessageBox.Show($"Podd '{valdPodd.OriginalTitel}' sparad med kategori '{valdKategori.Namn}'");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fel vid sparande: {ex.Message}");
            }
        }

        private async void BtnBytNamnPodd_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstPoddar.SelectedItem == null)
                {
                    MessageBox.Show("Välj en podd.");
                    return;
                }

                string nyttNamn = txtNyttNamn.Text;
                if (string.IsNullOrWhiteSpace(nyttNamn))
                {
                    MessageBox.Show("Ange ett giltigt namn.");
                    return;
                }

                var valdPodd = _visadePoddar[lstPoddar.SelectedIndex];
                await _service.UppdateraPoddNamn(valdPodd.Id, nyttNamn);

                MessageBox.Show("Namn ändrat.");
                await LaddaAllaPoddar();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fel vid namnbyte: {ex.Message}");
            }
        }

        // AVSNITT
        private async void BtnVisaAvsnitt_Click(object sender, EventArgs e)
        {
            if (lstPoddar.SelectedItem == null)
            {
                MessageBox.Show("Välj en podd för att visa avsnitt.");
                return;
            }

            var valdPodd = _visadePoddar[lstPoddar.SelectedIndex];

            _aktuellaAvsnitt = await _service.HämtaAvsnittFörPodd(valdPodd.Id);
            lstAvsnitt.Items.Clear();

            foreach (var avsnitt in _aktuellaAvsnitt)
            {
                lstAvsnitt.Items.Add(avsnitt.Titel);
            }
        }

        private void LstAvsnitt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstAvsnitt.SelectedIndex < 0 || lstAvsnitt.SelectedIndex >= _aktuellaAvsnitt.Count)
                return;

            var avsnitt = _aktuellaAvsnitt[lstAvsnitt.SelectedIndex];

            txtTitel.Text = avsnitt.Titel;
            txtDatum.Text = avsnitt.PubliceringsDatum?.ToString("yyyy-MM-dd") ?? "Okänt datum";
            txtBeskrivning.Text = avsnitt.Beskrivning;
        }

        private async Task LaddaKategorier()
        {
            var kategorier = await _service.HämtaAllaKategorier();

            cmbValjKategori.Items.Clear();
            cmbFiltreraKategori.Items.Clear();

            foreach (var kategori in kategorier)
            {
                cmbValjKategori.Items.Add(kategori.Namn);
                cmbFiltreraKategori.Items.Add(kategori.Namn);
            }

            if (cmbValjKategori.Items.Count > 0)
                cmbValjKategori.SelectedIndex = 0;

            if (cmbFiltreraKategori.Items.Count > 0)
                cmbFiltreraKategori.SelectedIndex = 0;
        }

        // Kategorifönster
        private async void BtnOppenKategoriFonster_Click(object sender, EventArgs e)
        {
            using var f = new Form2(_service);
            f.ShowDialog();

            // Ladda om kategorier efter stängning
            await LaddaKategorier();
        }

        private async void CmbFiltreraKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Hämta alla poddar
                var poddar = await _service.HämtaAllaPoddar();

                // Hämta alla kategorier
                var kategorier = await _service.HämtaAllaKategorier();

                if (cmbFiltreraKategori.SelectedIndex < 0)
                    return;

                var valdKategori = kategorier[cmbFiltreraKategori.SelectedIndex];

                // Filtrera poddar efter kategori-id
                _visadePoddar = poddar
                    .Where(p => p.KategoriId == valdKategori.Id)
                    .ToList();

                // Rensa listboxen
                lstPoddar.Items.Clear();

                // Visa endast matchande poddar
                foreach (var p in _visadePoddar)
                {
                    lstPoddar.Items.Add(p.OriginalTitel);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fel vid filtrering: {ex.Message}");
            }
        }


        private async void Form1_Load(object sender, EventArgs e)
        {
            await LaddaKategorier();
            await LaddaAllaPoddar();
        }

        private void btnVisaAlla_Click_1(object sender, EventArgs e)
        {

        }

        private void btnVisaAvsnitt_Click_1(object sender, EventArgs e)
        {

        }

        private void txtNyttNamn_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnVisaAvsnitt_Click_2(object sender, EventArgs e)
        {

        }

        private void btnBytNamnPodd_Click_1(object sender, EventArgs e)
        {

        }

        private void lstPoddar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

}
