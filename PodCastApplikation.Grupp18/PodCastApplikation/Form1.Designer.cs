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
            txtTitel.Location = new Point(482, 467);
            txtTitel.Name = "txtTitel";
            txtTitel.PlaceholderText = "Titel avsnitt";
            txtTitel.ReadOnly = true;
            txtTitel.Size = new Size(300, 31);
            txtTitel.TabIndex = 0;
            // 
            // txtDatum
            // 
            txtDatum.Location = new Point(482, 504);
            txtDatum.Name = "txtDatum";
            txtDatum.PlaceholderText = "Datum för avsnitt";
            txtDatum.ReadOnly = true;
            txtDatum.Size = new Size(200, 31);
            txtDatum.TabIndex = 1;
            // 
            // txtBeskrivning
            // 
            txtBeskrivning.ForeColor = SystemColors.InactiveCaption;
            txtBeskrivning.Location = new Point(482, 541);
            txtBeskrivning.Multiline = true;
            txtBeskrivning.Name = "txtBeskrivning";
            txtBeskrivning.PlaceholderText = "Beskrivning av avsnitt...";
            txtBeskrivning.ReadOnly = true;
            txtBeskrivning.Size = new Size(553, 130);
            txtBeskrivning.TabIndex = 2;
            // 
            // lstPoddar
            // 
            lstPoddar.Location = new Point(12, 174);
            lstPoddar.Name = "lstPoddar";
            lstPoddar.Size = new Size(250, 204);
            lstPoddar.TabIndex = 4;
            // 
            // lstAvsnitt
            // 
            lstAvsnitt.Location = new Point(12, 467);
            lstAvsnitt.Name = "lstAvsnitt";
            lstAvsnitt.Size = new Size(464, 204);
            lstAvsnitt.TabIndex = 5;
            lstAvsnitt.SelectedIndexChanged += LstAvsnitt_SelectedIndexChanged;
            // 
            // txtRssLank
            // 
            txtRssLank.ForeColor = SystemColors.WindowText;
            txtRssLank.Location = new Point(12, 50);
            txtRssLank.Name = "txtRssLank";
            txtRssLank.PlaceholderText = "Skriv in RSS-länk här....";
            txtRssLank.Size = new Size(250, 31);
            txtRssLank.TabIndex = 3;
            // 
            // btnLaggTillPodd
            // 
            btnLaggTillPodd.Location = new Point(524, 45);
            btnLaggTillPodd.Name = "btnLaggTillPodd";
            btnLaggTillPodd.Size = new Size(246, 41);
            btnLaggTillPodd.TabIndex = 6;
            btnLaggTillPodd.Text = "Lägg till";
            // 
            // btnVisaAlla
            // 
            btnVisaAlla.Location = new Point(285, 176);
            btnVisaAlla.Name = "btnVisaAlla";
            btnVisaAlla.Size = new Size(246, 39);
            btnVisaAlla.TabIndex = 7;
            btnVisaAlla.Text = "Visa alla poddar";
            // 
            // btnRaderaPodd
            // 
            btnRaderaPodd.Location = new Point(537, 177);
            btnRaderaPodd.Name = "btnRaderaPodd";
            btnRaderaPodd.Size = new Size(246, 38);
            btnRaderaPodd.TabIndex = 8;
            btnRaderaPodd.Text = "Radera podd";
            // 
            // btnUppdateraPodd
            // 
            btnUppdateraPodd.Location = new Point(789, 174);
            btnUppdateraPodd.Name = "btnUppdateraPodd";
            btnUppdateraPodd.Size = new Size(246, 40);
            btnUppdateraPodd.TabIndex = 9;
            btnUppdateraPodd.Text = "Uppdatera";
            // 
            // btnSparaPrenumerera
            // 
            btnSparaPrenumerera.Location = new Point(789, 220);
            btnSparaPrenumerera.Name = "btnSparaPrenumerera";
            btnSparaPrenumerera.Size = new Size(246, 43);
            btnSparaPrenumerera.TabIndex = 10;
            btnSparaPrenumerera.Text = "Spara / Prenumerera";
            // 
            // txtNyttNamn
            // 
            txtNyttNamn.Location = new Point(285, 282);
            txtNyttNamn.Name = "txtNyttNamn";
            txtNyttNamn.Size = new Size(246, 31);
            txtNyttNamn.TabIndex = 11;
            // 
            // btnBytNamnPodd
            // 
            btnBytNamnPodd.Location = new Point(285, 319);
            btnBytNamnPodd.Name = "btnBytNamnPodd";
            btnBytNamnPodd.Size = new Size(246, 48);
            btnBytNamnPodd.TabIndex = 12;
            btnBytNamnPodd.Text = "Byt namn";
            // 
            // btnVisaAvsnitt
            // 
            btnVisaAvsnitt.Location = new Point(12, 403);
            btnVisaAvsnitt.Name = "btnVisaAvsnitt";
            btnVisaAvsnitt.Size = new Size(250, 40);
            btnVisaAvsnitt.TabIndex = 13;
            btnVisaAvsnitt.Text = "Visa avsnitt";
            // 
            // lblValjKategori
            // 
            lblValjKategori.Location = new Point(268, 20);
            lblValjKategori.Name = "lblValjKategori";
            lblValjKategori.Size = new Size(200, 32);
            lblValjKategori.TabIndex = 14;
            lblValjKategori.Text = "Välj kategori";
            // 
            // cmbValjKategori
            // 
            cmbValjKategori.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbValjKategori.Items.AddRange(new object[] { "Alla poddar" });
            cmbValjKategori.Location = new Point(268, 48);
            cmbValjKategori.Name = "cmbValjKategori";
            cmbValjKategori.Size = new Size(250, 33);
            cmbValjKategori.TabIndex = 15;
            // 
            // lblFiltreraKategori
            // 
            lblFiltreraKategori.Location = new Point(12, 89);
            lblFiltreraKategori.Name = "lblFiltreraKategori";
            lblFiltreraKategori.Size = new Size(100, 34);
            lblFiltreraKategori.TabIndex = 16;
            lblFiltreraKategori.Text = "Filtrera kategori";
            // 
            // cmbFiltreraKategori
            // 
            cmbFiltreraKategori.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltreraKategori.Location = new Point(12, 123);
            cmbFiltreraKategori.Name = "cmbFiltreraKategori";
            cmbFiltreraKategori.Size = new Size(250, 33);
            cmbFiltreraKategori.TabIndex = 17;
            // 
            // btnOppenKategoriFonster
            // 
            btnOppenKategoriFonster.Location = new Point(1068, 46);
            btnOppenKategoriFonster.Name = "btnOppenKategoriFonster";
            btnOppenKategoriFonster.Size = new Size(250, 40);
            btnOppenKategoriFonster.TabIndex = 18;
            btnOppenKategoriFonster.Text = "Kategorier";
            // 
            // Form1
            // 
            BackColor = Color.SteelBlue;
            ClientSize = new Size(1356, 715);
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
