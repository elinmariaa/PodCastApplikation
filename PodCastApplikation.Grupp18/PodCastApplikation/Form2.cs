using System;
using System.Collections.Generic;
using System.Linq;
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

            Shown += (s, e) => this.ActiveControl = null;

            txtKategoriNamn.Text = "Nytt namn";
            txtKategoriNamn.ForeColor = Color.Gray;

            txtKategoriNamn.GotFocus += (s, e) =>
            {
                if (txtKategoriNamn.Text == "Nytt namn")
                {
                    txtKategoriNamn.Text = "";
                    txtKategoriNamn.ForeColor = Color.Black;
                }
            };



            txtKategoriNamn.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtKategoriNamn.Text))
                {
                    txtKategoriNamn.Text = "Nytt namn";
                    txtKategoriNamn.ForeColor = Color.Gray;
                }
            };

            // Kategori-funktioner
            btnSkapaKategori.Click += BtnSkapaKategori_Click;
            
            btnRaderaKategori.Click += BtnRaderaKategori_Click;
            btnSortera.Click += BtnSortera_Click;
            btnVisaSparade.Click += BtnVisaSparade_Click;

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

        private async void BtnSkapaKategori_Click(object sender, EventArgs e)
        {
            try
            {
                string namn = txtKategoriNamn.Text;

               
                if (string.IsNullOrWhiteSpace(namn) || namn == "Nytt namn")
                {
                    MessageBox.Show("Ange ett giltigt kategorinamn innan du sparar.");
                    return;
                }

                // 🔹 2. Kontrollera om kategorin redan finns (case-insensitive)
                var befintliga = await _service.HämtaAllaKategorier();
                bool finnsRedan = befintliga.Any(k =>
                    k.Namn.Equals(namn, StringComparison.OrdinalIgnoreCase));

                if (finnsRedan)
                {
                    MessageBox.Show($"Kategorin '{namn}' finns redan.");
                    return;
                }

                // 🔹 3. Spara kategorin
                await _service.LäggTillKategori(namn);
                MessageBox.Show($"Kategorin '{namn}' har lagts till!");

                txtKategoriNamn.Text = "Nytt namn";
                txtKategoriNamn.ForeColor = Color.Gray;

                await LaddaKategorier();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fel: {ex.Message}");
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

                // Bekräftelse-meddelande
                var dialog = MessageBox.Show(
                    "Är du säker på att du vill radera kategorin?",
                    "Bekräfta radering",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (dialog != DialogResult.Yes)
                {
                    return; // Avbryt om användaren inte trycker "Ja"
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

       

        private async void BtnSortera_Click(object sender, EventArgs e)
        {
            try
            {
                lstKategorier.Items.Clear();

                var kategorier = await _service.HämtaAllaKategorier();
                var sorterade = kategorier.OrderBy(k => k.Namn).ToList();

                foreach (var kategori in sorterade)
                {
                    lstKategorier.Items.Add(kategori.Namn);
                }

                MessageBox.Show("Kategorier sorterade!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fel: " + ex.Message);
            }
        }

        private async void BtnVisaSparade_Click(object sender, EventArgs e)
        {
            try
            {
                lstKategorier.Items.Clear();
                var kategorier = await _service.HämtaAllaKategorier();

                foreach (var kategori in kategorier)
                {
                    lstKategorier.Items.Add(kategori.Namn);
                }

                MessageBox.Show("Sparade kategorier visas nu!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fel: " + ex.Message);
            }
        }

        private void lstKategorier_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtKategoriNamn.Text = lstKategorier.SelectedItem?.ToString() ?? string.Empty;
        }

        private void txtKategoriNamn_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
