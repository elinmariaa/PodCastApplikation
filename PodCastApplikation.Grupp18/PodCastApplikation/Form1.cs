using PodCastApplikation.Business;
using PodCastApplikation.Business.Validation;
using PodCastApplikation.Models.Klasser;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PodCastApplikation
{
    public partial class Form1 : Form
    {
        private readonly IPoddService _service;
        private List<Avsnitt> _aktuellaAvsnitt = new();
        private List<Podd> _visadePoddar = new();
        private Podd _senastFörhandsgranskadPodd; //så den förhandsgranskade inte försvinner 


        public Form1(IPoddService service)
        {
            InitializeComponent();
            _service = service;

            // Event wiring
            //btnLaggTillPodd.Click += BtnLaggTillPodd_Click;
            btnForhandsgranska.Click += BtnForhandsgranska_Click;

          
            btnRaderaPodd.Click += BtnRaderaPodd_Click;
            btnSparaPrenumerera.Click += BtnSparaPodd_Click;
            btnBytNamnPodd.Click += BtnBytNamnPodd_Click;
            btnVisaAvsnitt.Click += BtnVisaAvsnitt_Click;
            lstAvsnitt.SelectedIndexChanged += LstAvsnitt_SelectedIndexChanged;
            btnOppenKategoriFonster.Click += BtnOppenKategoriFonster_Click;
            cmbFiltreraKategori.SelectedIndexChanged += CmbFiltreraKategori_SelectedIndexChanged;
        }


        private async void BtnSparaPodd_Click(object sender, EventArgs e)
        {
            try
            {

                if (_senastFörhandsgranskadPodd == null)
                {
                    MessageBox.Show("Förhandsgranska en podd innan du sparar den.");
                    return;
                }

                // 2️⃣ Hämta vald kategori (som faktiskt är ett objekt)
                var valdKategori = cmbValjKategori.SelectedItem as Kategori;

                // 3️⃣ Om ingen kategori är vald, använd eller skapa 'AllaPoddar'
                if (valdKategori == null)
                {
                    var allaKategorier = await _service.HämtaAllaKategorier();
                    valdKategori = allaKategorier
                        .FirstOrDefault(k => k.Namn.Equals("AllaPoddar", StringComparison.OrdinalIgnoreCase));


                    if (valdKategori == null)
                    {
                        await _service.LäggTillKategori("AllaPoddar");
                        allaKategorier = await _service.HämtaAllaKategorier();
                        valdKategori = allaKategorier.First(k => k.Namn.Equals("AllaPoddar", StringComparison.OrdinalIgnoreCase));
                    }
                }


                var nyPodd = await _service.LäggTillPoddMedKategori
                    (_senastFörhandsgranskadPodd.RssURL, valdKategori.Id);

                MessageBox.Show($"Podd '{nyPodd.OriginalTitel}' sparad i kategorin '{valdKategori.Namn}'.");

                txtPreviewTitel.Text = "";
                txtPreviewBeskrivning.Text = "";
                txtRssLank.Text = "";
                _senastFörhandsgranskadPodd = null;
                await LaddaAllaPoddar();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fel vid sparande: {ex.Message}");
            }
        }

        private async void BtnForhandsgranska_Click(object sender, EventArgs e)
        {
            try
            {
                string rssUrl = txtRssLank.Text?.Trim();
                if (string.IsNullOrWhiteSpace(rssUrl))
                {
                    MessageBox.Show("Skriv in RSs-länk i rutan ");
                }

                RssValidator.ValideraRssUrl(rssUrl);
                await RssValidator.ValideraRssInnehålle(rssUrl);

                // Hämta podden men spara den inte ännu
                var poddPreview = await _service.FörhandsgranskaPodd(rssUrl);

                if (poddPreview == null)
                {
                    MessageBox.Show("Kunde inte läsa in podden. Kontrollera RSS-länken.");
                    return;
                }

                _senastFörhandsgranskadPodd = poddPreview;


                //  Visa titel & beskrivning i förhandsgranskningsrutorna
                txtPreviewTitel.Text = poddPreview.OriginalTitel ?? "Okänd titel";
                txtPreviewBeskrivning.Text = poddPreview.Beskrivning ?? "Ingen beskrivning tillgänglig.";

                MessageBox.Show($"Förhandsgranskning klar: '{poddPreview.OriginalTitel}'");

            
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kunde inte läsa in RSS-länk: {ex.Message}");
            }
        }



        //private async void BtnVisaAlla_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        await LaddaAllaPoddar();
                
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Fel: {ex.Message}");
        //    }
        //}

        private async Task LaddaAllaPoddar()
        {
            var poddar = await _service.HämtaAllaPoddar();
            _visadePoddar = poddar;

            lstSparadePoddar.Items.Clear();
            

            foreach (var podd in poddar)
            {

                lstSparadePoddar.Items.Add(podd.OriginalTitel);
            }
        }

        private async void BtnRaderaPodd_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstSparadePoddar.SelectedIndex < 0)
                {
                    MessageBox.Show("Välj en podd att radera.");
                    return;
                }

                var valdPodd = _visadePoddar[lstSparadePoddar.SelectedIndex];

                var result = MessageBox.Show
                    ($"Vill du verklilgen ta bort podden '{valdPodd.OriginalTitel}'?",
                    "Bekräfta borttagning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result != DialogResult.Yes)
                {
                    return; //avbryt om användaren klickar nej 
                }
                Console.WriteLine($"Försöker ta bort podd med ID: '{valdPodd.Id}' och titel: {valdPodd.OriginalTitel}");


                await _service.TaBortPodd(valdPodd.Id);

                _visadePoddar.Remove(valdPodd);
                lstSparadePoddar.Items.RemoveAt(lstSparadePoddar.SelectedIndex);
                lstAvsnitt.Items.Clear(); 

               

                MessageBox.Show("Podd raderad.");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fel vid radering: {ex.Message}");
            }
        }

      

        private async void BtnBytNamnPodd_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstSparadePoddar.SelectedIndex < 0)
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

                var valdPodd = _visadePoddar[lstSparadePoddar.SelectedIndex];

                var confirm = MessageBox.Show($"Vill du byta namn på '{valdPodd.OriginalTitel}' till '{nyttNamn}'?",
            "Bekräfta namnbyte",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

                if (confirm != DialogResult.Yes)
                    return;

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
            if (lstSparadePoddar.SelectedItem == null)
            {
                MessageBox.Show("Välj en podd för att visa avsnitt.");
                return;
            }

            var valdPodd = _visadePoddar[lstSparadePoddar.SelectedIndex];

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
            txtBeskrivning.Text = string.IsNullOrWhiteSpace(avsnitt.Beskrivning) ? "Ingen beskrivning tillgänglig." : avsnitt.Beskrivning;
        }

        private async Task LaddaKategorier()
        {
            try
            {
                var kategorier = await _service.HämtaAllaKategorier();

                kategorier = kategorier.OrderByDescending(k => k.Namn.Equals("AllaPoddar", StringComparison
                    .OrdinalIgnoreCase)).ThenBy(k => k.Namn).ToList();

                cmbValjKategori.Items.Clear();
                cmbFiltreraKategori.Items.Clear();

                //visar vilket fält som ska visas i rullistan
                cmbValjKategori.DisplayMember = "Namn";
                cmbFiltreraKategori.DisplayMember = "Namn";



                foreach (var kategori in kategorier)
                {
                    cmbValjKategori.Items.Add(kategori);
                    cmbFiltreraKategori.Items.Add(kategori);
                }

                if (cmbValjKategori.Items.Count > 0)
                    cmbValjKategori.SelectedIndex = 0;

                if (cmbFiltreraKategori.Items.Count > 0)
                    cmbFiltreraKategori.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fel vid laddning av kategorier: {ex.Message}");
            }


        }

        private async Task KontrolleraStandardKategori()
        {
            try
            {
                var kategorier = await _service.HämtaAllaKategorier();

                // Finns "AllaPoddar" redan?
                var finns = kategorier.Any(k =>
                    k.Namn.Equals("AllaPoddar", StringComparison.OrdinalIgnoreCase));

                if (!finns)
                {
                    await _service.LäggTillKategori("AllaPoddar");
                    await LaddaKategorier();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kunde inte kontrollera eller skapa standardkategori: {ex.Message}");
            }
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
                var valdKategori = cmbFiltreraKategori.SelectedItem as Kategori;
                if (valdKategori == null)
                    return;


                // Hämta alla poddar
                var allaPoddar = await _service.HämtaAllaPoddar();

                // 3️⃣ Filtrera
                if (valdKategori.Namn.Equals("AllaPoddar", StringComparison.OrdinalIgnoreCase))
                {
                    _visadePoddar = allaPoddar; // Visa alla
                }
                else
                {
                    _visadePoddar = allaPoddar
                        .Where(p => p.KategoriId == valdKategori.Id)
                        .ToList();
                }

                lstSparadePoddar.Items.Clear();

                if (_visadePoddar.Count == 0)
                {
                    MessageBox.Show("Inga poddar i denna kategori");
                    return;
                }

                foreach (var podd in _visadePoddar)
                {
                    lstSparadePoddar.Items.Add(podd.OriginalTitel);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fel vid filtrering: {ex.Message}");
            }
        }





        private async void Form1_Load(object sender, EventArgs e)
        {
            await KontrolleraStandardKategori();
            await LaddaKategorier();
            await LaddaAllaPoddar();
           
        }

      

        private async void LstSparadePoddar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstSparadePoddar.SelectedIndex < 0)
                return;

            var allaPoddar = await _service.HämtaAllaPoddar();
            var valdPodd = allaPoddar[lstSparadePoddar.SelectedIndex];

            _aktuellaAvsnitt = await _service.HämtaAvsnittFörPodd(valdPodd.Id);
            lstAvsnitt.Items.Clear();

            foreach (var avsnitt in _aktuellaAvsnitt)
            {
                lstAvsnitt.Items.Add(avsnitt.Titel);
            }
        }

        
    }

}       