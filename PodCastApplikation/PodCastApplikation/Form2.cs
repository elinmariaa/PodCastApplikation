using System;

using System.Windows.Forms;



namespace PodCastApplikation

{

    public partial class Form2 : Form

    {

        public Form2()

        {

            InitializeComponent();



            // Kategori-funktioner

            btnSkapaKategori.Click += BtnSkapaKategori_Click;

            btnBytKategoriNamn.Click += BtnBytKategoriNamn_Click;

            btnRaderaKategori.Click += BtnRaderaKategori_Click;

            btnSortera.Click += BtnSortera_Click;



            // Visa sparad data

            btnVisaSparade.Click += BtnVisaSparade_Click;



            // Uppdateringsintervall

            btnIntervall.Click += BtnIntervall_Click;

        }



        // ------------------------------------------

        // KNAPPFUNKTIONER

        // ------------------------------------------



        private void BtnSkapaKategori_Click(object sender, EventArgs e)

        {

            // Skapa ny kategori

            // txtKategoriNamn.Text → lägg in i kategori-lista/databas

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



        private void BtnRaderaKategori_Click(object sender, EventArgs e)

        {

            if (lstKategorier.SelectedItem == null)

            {

                MessageBox.Show("Välj en kategori först.");

                return;

            }



            var resultat = MessageBox.Show(

                "Är du säker på att du vill radera denna kategori?",

                "Bekräfta radering",

                MessageBoxButtons.YesNo,

                MessageBoxIcon.Warning

            );



            if (resultat == DialogResult.Yes)

            {

                // Ta bort kategorin här

                lstKategorier.Items.Remove(lstKategorier.SelectedItem);



                // Om du sparar i fil/databas ska du radera där också

                // t.ex. kategoriManager.Remove(category)

            }

        }



        private void lstKategorier_SelectedIndexChanged(object sender, EventArgs e)

        {



        }

    }

}