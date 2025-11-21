namespace PodCastApplikation

{

    partial class Form2

    {

        private System.ComponentModel.IContainer components = null;



        protected override void Dispose(bool disposing)

        {

            if (disposing && (components != null))

            {

                components.Dispose();

            }

            base.Dispose(disposing);

        }



        #region Windows Form Designer generated code



        private void InitializeComponent()

        { 
            txtKategoriNamn = new TextBox();
            lstKategorier = new ListBox();
            btnSkapaKategori = new Button();
            btnBytKategoriNamn = new Button();
            btnRaderaKategori = new Button();
            btnSortera = new Button();
            cmbIntervall = new ComboBox();
            btnIntervall = new Button();
            btnVisaSparade = new Button();
            SuspendLayout();

            // 

            // txtKategoriNamn

            // 

            txtKategoriNamn.Location = new Point(28, 29);

            txtKategoriNamn.Name = "txtKategoriNamn";

            txtKategoriNamn.Size = new Size(200, 39);

            txtKategoriNamn.TabIndex = 0;

            // 

            // lstKategorier

            // 

            lstKategorier.Location = new Point(28, 83);

            lstKategorier.Name = "lstKategorier";

            lstKategorier.Size = new Size(200, 228);

            lstKategorier.TabIndex = 1;

            lstKategorier.SelectedIndexChanged += lstKategorier_SelectedIndexChanged;

            // 

            // btnSkapaKategori

            // 

            btnSkapaKategori.BackColor = Color.White;

            btnSkapaKategori.Location = new Point(234, 78);

            btnSkapaKategori.Name = "btnSkapaKategori";

            btnSkapaKategori.Size = new Size(111, 38);

            btnSkapaKategori.TabIndex = 2;

            btnSkapaKategori.Text = "Skapa";

            btnSkapaKategori.UseVisualStyleBackColor = false;

            // 

            // btnBytKategoriNamn

            // 

            btnBytKategoriNamn.BackColor = Color.White;

            btnBytKategoriNamn.Location = new Point(234, 122);

            btnBytKategoriNamn.Name = "btnBytKategoriNamn";

            btnBytKategoriNamn.Size = new Size(111, 39);

            btnBytKategoriNamn.TabIndex = 3;

            btnBytKategoriNamn.Text = "Byt";

            btnBytKategoriNamn.UseVisualStyleBackColor = false;

            // 

            // btnRaderaKategori

            // 

            btnRaderaKategori.BackColor = Color.White;

            btnRaderaKategori.Location = new Point(234, 215);

            btnRaderaKategori.Name = "btnRaderaKategori";

            btnRaderaKategori.Size = new Size(111, 47);

            btnRaderaKategori.TabIndex = 4;

            btnRaderaKategori.Text = "Radera";

            btnRaderaKategori.UseVisualStyleBackColor = false;

            btnRaderaKategori.Click += BtnRaderaKategori_Click;

            // 

            // btnSortera

            // 

            btnSortera.BackColor = Color.White;

            btnSortera.Location = new Point(234, 167);

            btnSortera.Name = "btnSortera";

            btnSortera.Size = new Size(111, 42);

            btnSortera.TabIndex = 6;

            btnSortera.Text = "Sortera";

            btnSortera.UseVisualStyleBackColor = false;

            // 

            // cmbIntervall

            // 

            cmbIntervall.Location = new Point(28, 321);

            cmbIntervall.Name = "cmbIntervall";

            cmbIntervall.Size = new Size(120, 40);

            cmbIntervall.TabIndex = 7;

            // 

            // btnIntervall

            // 

            btnIntervall.BackColor = Color.White;

            btnIntervall.Location = new Point(154, 321);

            btnIntervall.Name = "btnIntervall";

            btnIntervall.Size = new Size(143, 40);

            btnIntervall.TabIndex = 8;

            btnIntervall.Text = "Spara";

            btnIntervall.UseVisualStyleBackColor = false;

            // 

            // btnVisaSparade

            // 

            btnVisaSparade.BackColor = Color.White;

            btnVisaSparade.Location = new Point(28, 380);

            btnVisaSparade.Name = "btnVisaSparade";

            btnVisaSparade.Size = new Size(210, 40);

            btnVisaSparade.TabIndex = 9;

            btnVisaSparade.Text = "Visa sparade data";

            btnVisaSparade.UseVisualStyleBackColor = false;

            // 

            // Form2

            // 

            BackColor = Color.SteelBlue;

            ClientSize = new Size(897, 692);

            Controls.Add(txtKategoriNamn);

            Controls.Add(lstKategorier);

            Controls.Add(btnSkapaKategori);

            Controls.Add(btnBytKategoriNamn);

            Controls.Add(btnRaderaKategori);

            Controls.Add(btnSortera);

            Controls.Add(cmbIntervall);

            Controls.Add(btnIntervall);

            Controls.Add(btnVisaSparade);

            Name = "Form2";

            Text = "Kategori";

            ResumeLayout(false);

            PerformLayout();

        }



        #endregion



        private TextBox txtKategoriNamn;

        private ListBox lstKategorier;

        private Button btnSkapaKategori;

        private Button btnBytKategoriNamn;

        private Button btnRaderaKategori;

        private Button btnSortera;

        private ComboBox cmbIntervall;

        private Button btnIntervall;

        private Button btnVisaSparade;

    }

}

