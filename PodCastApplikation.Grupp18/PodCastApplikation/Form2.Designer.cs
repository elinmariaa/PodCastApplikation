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
            btnRaderaKategori = new Button();
            btnSortera = new Button();
            btnVisaSparade = new Button();
            SuspendLayout();
            // 
            // txtKategoriNamn
            // 
            txtKategoriNamn.Location = new Point(28, 29);
            txtKategoriNamn.Name = "txtKategoriNamn";
            txtKategoriNamn.Size = new Size(200, 31);
            txtKategoriNamn.TabIndex = 0;
            // 
            // lstKategorier
            // 
            lstKategorier.Location = new Point(28, 83);
            lstKategorier.Name = "lstKategorier";
            lstKategorier.Size = new Size(200, 204);
            lstKategorier.TabIndex = 1;
            lstKategorier.SelectedIndexChanged += lstKategorier_SelectedIndexChanged;
            // 
            // btnSkapaKategori
            // 
            btnSkapaKategori.BackColor = Color.White;
            btnSkapaKategori.Location = new Point(234, 83);
            btnSkapaKategori.Name = "btnSkapaKategori";
            btnSkapaKategori.Size = new Size(159, 38);
            btnSkapaKategori.TabIndex = 2;
            btnSkapaKategori.Text = "Skapa";
            btnSkapaKategori.UseVisualStyleBackColor = false;
            // 
            // btnRaderaKategori
            // 
            btnRaderaKategori.BackColor = Color.White;
            btnRaderaKategori.Location = new Point(234, 175);
            btnRaderaKategori.Name = "btnRaderaKategori";
            btnRaderaKategori.Size = new Size(159, 47);
            btnRaderaKategori.TabIndex = 4;
            btnRaderaKategori.Text = "Radera";
            btnRaderaKategori.UseVisualStyleBackColor = false;
            btnRaderaKategori.Click += BtnRaderaKategori_Click;
            // 
            // btnSortera
            // 
            btnSortera.BackColor = Color.White;
            btnSortera.Location = new Point(234, 127);
            btnSortera.Name = "btnSortera";
            btnSortera.Size = new Size(159, 42);
            btnSortera.TabIndex = 6;
            btnSortera.Text = "Sortera A-Ö";
            btnSortera.UseVisualStyleBackColor = false;
            // 
            // btnVisaSparade
            // 
            btnVisaSparade.BackColor = Color.White;
            btnVisaSparade.Location = new Point(234, 228);
            btnVisaSparade.Name = "btnVisaSparade";
            btnVisaSparade.Size = new Size(159, 59);
            btnVisaSparade.TabIndex = 9;
            btnVisaSparade.Text = "Visa alla kategorier";
            btnVisaSparade.UseVisualStyleBackColor = false;
            // 
            // Form2
            // 
            BackColor = Color.SteelBlue;
            ClientSize = new Size(897, 692);
            Controls.Add(txtKategoriNamn);
            Controls.Add(lstKategorier);
            Controls.Add(btnSkapaKategori);
            Controls.Add(btnRaderaKategori);
            Controls.Add(btnSortera);
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

        private Button btnRaderaKategori;

        private Button btnSortera;

        private Button btnVisaSparade;

    }

}

