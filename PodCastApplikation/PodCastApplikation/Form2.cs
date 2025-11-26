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

            // Fix: se placeholder innan textbox får fokus
            Shown += (s, e) => this.ActiveControl = null;

            // Placeholder
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
            btnBytKategoriNamn.Click += BtnBytKategoriNamn_Click;
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

                if (namn == "Ny kategori")
                {
                    MessageBox.Show("Ange ett kategori-namn.");
                    return;
                }

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

        private async void BtnBytKategoriNamn_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstKategorier.SelectedItem == null)
                {
                    MessageBox.Show("Välj en kategori först.");
                    return;
                }

                string nyttNamn = txtKategoriNamn.Text.Trim();
                if (string.IsNullOrWhiteSpace(nyttNamn) || nyttNamn.Length < 2 || nyttNamn.Length > 50)
                {
                    MessageBox.Show("Ange ett giltigt kategorinamn (2-50 tecken).");
                    return;
                }

                var kategorier = await _service.HämtaAllaKategorier();
                var valdKategori = kategorier[lstKategorier.SelectedIndex];

                await _service.UppdateraKategori(valdKategori.Id, nyttNamn);

                MessageBox.Show("Kategorin har uppdaterats!");
                await LaddaKategorier();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fel: " + ex.Message);
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
