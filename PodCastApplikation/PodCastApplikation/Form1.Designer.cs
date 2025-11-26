namespace PodCastApplikation
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private Button btnLaggTillPodd;
        private TextBox txtTitel;
        private TextBox txtDatum;
        private TextBox txtBeskrivning;
        private ListBox lstPoddar;
        private Button btnVisaAlla;
        private Button btnUppdateraPodd;
        private Button btnSparaPrenumerera;
        private TextBox txtNyttNamn;
        private Button btnBytNamnPodd;
        private Button btnRaderaPodd;
        private Button btnVisaAvsnitt;
        private ListBox lstAvsnitt;
        private Label lblValjKategori;
        private ComboBox cmbValjKategori;
        private Label lblFiltreraKategori;
        private ComboBox cmbFiltreraKategori;
        private Button btnOppenKategoriFonster;
        private TextBox txtRssLank;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtTitel = new TextBox();
            txtDatum = new TextBox();
            txtBeskrivning = new TextBox();
            lstPoddar = new ListBox();
            lstAvsnitt = new ListBox();
            txtRssLank = new TextBox();
            btnLaggTillPodd = new Button();
            btnVisaAlla = new Button();
            btnRaderaPodd = new Button();
            btnUppdateraPodd = new Button();
            btnSparaPrenumerera = new Button();
            txtNyttNamn = new TextBox();
            btnBytNamnPodd = new Button();
            btnVisaAvsnitt = new Button();
            lblValjKategori = new Label();
            cmbValjKategori = new ComboBox();
            lblFiltreraKategori = new Label();
            cmbFiltreraKategori = new ComboBox();
            btnOppenKategoriFonster = new Button();
            SuspendLayout();
            // 
            // txtTitel
            // 
            txtTitel.Location = new Point(280, 485);
            txtTitel.Name = "txtTitel";
            txtTitel.ReadOnly = true;
            txtTitel.Size = new Size(300, 39);
            txtTitel.TabIndex = 0;
            // 
            // txtDatum
            // 
            txtDatum.Location = new Point(280, 530);
            txtDatum.Name = "txtDatum";
            txtDatum.ReadOnly = true;
            txtDatum.Size = new Size(200, 39);
            txtDatum.TabIndex = 1;
            // 
            // txtBeskrivning
            // 
            txtBeskrivning.Location = new Point(280, 575);
            txtBeskrivning.Multiline = true;
            txtBeskrivning.Name = "txtBeskrivning";
            txtBeskrivning.ReadOnly = true;
            txtBeskrivning.Size = new Size(400, 105);
            txtBeskrivning.TabIndex = 2;
            // 
            // lstPoddar
            // 
            lstPoddar.Location = new Point(12, 225);
            lstPoddar.Name = "lstPoddar";
            lstPoddar.Size = new Size(250, 228);
            lstPoddar.TabIndex = 4;
            // 
            // lstAvsnitt
            // 
            lstAvsnitt.Location = new Point(12, 512);
            lstAvsnitt.Name = "lstAvsnitt";
            lstAvsnitt.Size = new Size(250, 164);
            lstAvsnitt.TabIndex = 5;
            lstAvsnitt.SelectedIndexChanged += LstAvsnitt_SelectedIndexChanged;
            // 
            // txtRssLank
            // 
            txtRssLank.Location = new Point(12, 100);
            txtRssLank.Name = "txtRssLank";
            txtRssLank.Size = new Size(250, 39);
            txtRssLank.TabIndex = 3;
            // 
            // btnLaggTillPodd
            // 
            btnLaggTillPodd.Location = new Point(280, 128);
            btnLaggTillPodd.Name = "btnLaggTillPodd";
            btnLaggTillPodd.Size = new Size(165, 41);
            btnLaggTillPodd.TabIndex = 6;
            btnLaggTillPodd.Text = "Lägg till";
            // 
            // btnVisaAlla
            // 
            btnVisaAlla.Location = new Point(280, 175);
            btnVisaAlla.Name = "btnVisaAlla";
            btnVisaAlla.Size = new Size(171, 39);
            btnVisaAlla.TabIndex = 7;
            btnVisaAlla.Text = "Visa alla";
            btnVisaAlla.Click += btnVisaAlla_Click_1;
            // 
            // btnRaderaPodd
            // 
            btnRaderaPodd.Location = new Point(280, 221);
            btnRaderaPodd.Name = "btnRaderaPodd";
            btnRaderaPodd.Size = new Size(142, 38);
            btnRaderaPodd.TabIndex = 8;
            btnRaderaPodd.Text = "Radera";
            // 
            // btnUppdateraPodd
            // 
            btnUppdateraPodd.Location = new Point(280, 265);
            btnUppdateraPodd.Name = "btnUppdateraPodd";
            btnUppdateraPodd.Size = new Size(165, 40);
            btnUppdateraPodd.TabIndex = 9;
            btnUppdateraPodd.Text = "Uppdatera";
            // 
            // btnSparaPrenumerera
            // 
            btnSparaPrenumerera.Location = new Point(280, 311);
            btnSparaPrenumerera.Name = "btnSparaPrenumerera";
            btnSparaPrenumerera.Size = new Size(274, 43);
            btnSparaPrenumerera.TabIndex = 10;
            btnSparaPrenumerera.Text = "Spara / Prenumerera";
            // 
            // txtNyttNamn
            // 
            txtNyttNamn.Location = new Point(280, 360);
            txtNyttNamn.Name = "txtNyttNamn";
            txtNyttNamn.Size = new Size(246, 39);
            txtNyttNamn.TabIndex = 11;
            txtNyttNamn.TextChanged += txtNyttNamn_TextChanged;
            // 
            // btnBytNamnPodd
            // 
            btnBytNamnPodd.Location = new Point(280, 405);
            btnBytNamnPodd.Name = "btnBytNamnPodd";
            btnBytNamnPodd.Size = new Size(200, 48);
            btnBytNamnPodd.TabIndex = 12;
            btnBytNamnPodd.Text = "Byt namn";
            // 
            // btnVisaAvsnitt
            // 
            btnVisaAvsnitt.Location = new Point(12, 466);
            btnVisaAvsnitt.Name = "btnVisaAvsnitt";
            btnVisaAvsnitt.Size = new Size(120, 40);
            btnVisaAvsnitt.TabIndex = 13;
            btnVisaAvsnitt.Text = "Visa avsnitt";
            // 
            // lblValjKategori
            // 
            lblValjKategori.Location = new Point(12, 16);
            lblValjKategori.Name = "lblValjKategori";
            lblValjKategori.Size = new Size(200, 32);
            lblValjKategori.TabIndex = 14;
            lblValjKategori.Text = "Välj kategori";
            // 
            // cmbValjKategori
            // 
            cmbValjKategori.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbValjKategori.Location = new Point(12, 54);
            cmbValjKategori.Name = "cmbValjKategori";
            cmbValjKategori.Size = new Size(250, 40);
            cmbValjKategori.TabIndex = 15;
            // 
            // lblFiltreraKategori
            // 
            lblFiltreraKategori.Location = new Point(12, 142);
            lblFiltreraKategori.Name = "lblFiltreraKategori";
            lblFiltreraKategori.Size = new Size(100, 34);
            lblFiltreraKategori.TabIndex = 16;
            lblFiltreraKategori.Text = "Filtrera kategori";
            // 
            // cmbFiltreraKategori
            // 
            cmbFiltreraKategori.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltreraKategori.Location = new Point(12, 175);
            cmbFiltreraKategori.Name = "cmbFiltreraKategori";
            cmbFiltreraKategori.Size = new Size(250, 40);
            cmbFiltreraKategori.TabIndex = 17;
            // 
            // btnOppenKategoriFonster
            // 
            btnOppenKategoriFonster.Location = new Point(907, 12);
            btnOppenKategoriFonster.Name = "btnOppenKategoriFonster";
            btnOppenKategoriFonster.Size = new Size(250, 40);
            btnOppenKategoriFonster.TabIndex = 18;
            btnOppenKategoriFonster.Text = "Kategorier";
            // 
            // Form1
            // 
            BackColor = Color.SteelBlue;
            ClientSize = new Size(1169, 693);
            Controls.Add(txtTitel);
            Controls.Add(txtDatum);
            Controls.Add(txtBeskrivning);
            Controls.Add(txtRssLank);
            Controls.Add(lstPoddar);
            Controls.Add(lstAvsnitt);
            Controls.Add(btnLaggTillPodd);
            Controls.Add(btnVisaAlla);
            Controls.Add(btnRaderaPodd);
            Controls.Add(btnUppdateraPodd);
            Controls.Add(btnSparaPrenumerera);
            Controls.Add(txtNyttNamn);
            Controls.Add(btnBytNamnPodd);
            Controls.Add(btnVisaAvsnitt);
            Controls.Add(lblValjKategori);
            Controls.Add(cmbValjKategori);
            Controls.Add(lblFiltreraKategori);
            Controls.Add(cmbFiltreraKategori);
            Controls.Add(btnOppenKategoriFonster);
            Name = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
