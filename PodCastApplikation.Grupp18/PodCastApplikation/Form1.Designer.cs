namespace PodCastApplikation
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        
        private Button btnForhandsgranska; //NY
        private TextBox txtTitel;
        private TextBox txtDatum;
        private TextBox txtBeskrivning;
       
        
       
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
        private ListBox lstSparadePoddar;
        
        private TextBox txtPreviewTitel;
        private TextBox txtPreviewBeskrivning;

        
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
            lstAvsnitt = new ListBox();
            txtRssLank = new TextBox();
            btnForhandsgranska = new Button();
            btnRaderaPodd = new Button();
            btnSparaPrenumerera = new Button();
            txtNyttNamn = new TextBox();
            btnBytNamnPodd = new Button();
            btnVisaAvsnitt = new Button();
            lblValjKategori = new Label();
            cmbValjKategori = new ComboBox();
            lblFiltreraKategori = new Label();
            cmbFiltreraKategori = new ComboBox();
            btnOppenKategoriFonster = new Button();
            lstSparadePoddar = new ListBox();
            label1 = new Label();
            label2 = new Label();
            txtPreviewTitel = new TextBox();
            txtPreviewBeskrivning = new TextBox();
            SuspendLayout();
            // 
            // txtTitel
            // 
            txtTitel.Location = new Point(1378, 147);
            txtTitel.Name = "txtTitel";
            txtTitel.PlaceholderText = "Titel avsnitt";
            txtTitel.ReadOnly = true;
            txtTitel.Size = new Size(299, 31);
            txtTitel.TabIndex = 0;
            // 
            // txtDatum
            // 
            txtDatum.Location = new Point(1378, 184);
            txtDatum.Name = "txtDatum";
            txtDatum.PlaceholderText = "Datum för avsnitt";
            txtDatum.ReadOnly = true;
            txtDatum.Size = new Size(299, 31);
            txtDatum.TabIndex = 1;
            // 
            // txtBeskrivning
            // 
            txtBeskrivning.ForeColor = SystemColors.InactiveCaption;
            txtBeskrivning.Location = new Point(1378, 221);
            txtBeskrivning.Multiline = true;
            txtBeskrivning.Name = "txtBeskrivning";
            txtBeskrivning.PlaceholderText = "Beskrivning av avsnitt...";
            txtBeskrivning.ReadOnly = true;
            txtBeskrivning.Size = new Size(299, 305);
            txtBeskrivning.TabIndex = 2;
            // 
            // lstAvsnitt
            // 
            lstAvsnitt.Location = new Point(1048, 147);
            lstAvsnitt.Name = "lstAvsnitt";
            lstAvsnitt.Size = new Size(325, 379);
            lstAvsnitt.TabIndex = 5;
            lstAvsnitt.SelectedIndexChanged += LstAvsnitt_SelectedIndexChanged;
            // 
            // txtRssLank
            // 
            txtRssLank.ForeColor = SystemColors.WindowText;
            txtRssLank.Location = new Point(14, 59);
            txtRssLank.Name = "txtRssLank";
            txtRssLank.PlaceholderText = "Skriv in RSS-länk här....";
            txtRssLank.Size = new Size(397, 31);
            txtRssLank.TabIndex = 3;
            // 
            // btnForhandsgranska
            // 
            btnForhandsgranska.BackColor = Color.Transparent;
            btnForhandsgranska.Font = new Font("Segoe UI", 9F);
            btnForhandsgranska.Location = new Point(12, 98);
            btnForhandsgranska.Name = "btnForhandsgranska";
            btnForhandsgranska.Size = new Size(246, 43);
            btnForhandsgranska.TabIndex = 19;
            btnForhandsgranska.Text = "Förhandsgranska";
            btnForhandsgranska.UseVisualStyleBackColor = false;
            // 
            // btnRaderaPodd
            // 
            btnRaderaPodd.BackColor = Color.Transparent;
            btnRaderaPodd.Location = new Point(1300, 92);
            btnRaderaPodd.Name = "btnRaderaPodd";
            btnRaderaPodd.Size = new Size(246, 43);
            btnRaderaPodd.TabIndex = 8;
            btnRaderaPodd.Text = "Radera podd";
            btnRaderaPodd.UseVisualStyleBackColor = false;
            // 
            // btnSparaPrenumerera
            // 
            btnSparaPrenumerera.BackColor = Color.Transparent;
            btnSparaPrenumerera.Location = new Point(11, 560);
            btnSparaPrenumerera.Name = "btnSparaPrenumerera";
            btnSparaPrenumerera.Size = new Size(246, 43);
            btnSparaPrenumerera.TabIndex = 10;
            btnSparaPrenumerera.Text = "Spara podd";
            btnSparaPrenumerera.UseVisualStyleBackColor = false;
            // 
            // txtNyttNamn
            // 
            txtNyttNamn.Location = new Point(11, 448);
            txtNyttNamn.Name = "txtNyttNamn";
            txtNyttNamn.PlaceholderText = "Byt namn (valfritt)";
            txtNyttNamn.Size = new Size(251, 31);
            txtNyttNamn.TabIndex = 11;
            // 
            // btnBytNamnPodd
            // 
            btnBytNamnPodd.BackColor = Color.Transparent;
            btnBytNamnPodd.Location = new Point(11, 498);
            btnBytNamnPodd.Name = "btnBytNamnPodd";
            btnBytNamnPodd.Size = new Size(246, 43);
            btnBytNamnPodd.TabIndex = 12;
            btnBytNamnPodd.Text = "Byt namn";
            btnBytNamnPodd.UseVisualStyleBackColor = false;
            // 
            // btnVisaAvsnitt
            // 
            btnVisaAvsnitt.BackColor = Color.Transparent;
            btnVisaAvsnitt.Location = new Point(1048, 92);
            btnVisaAvsnitt.Name = "btnVisaAvsnitt";
            btnVisaAvsnitt.Size = new Size(246, 43);
            btnVisaAvsnitt.TabIndex = 13;
            btnVisaAvsnitt.Text = "Visa avsnitt";
            btnVisaAvsnitt.UseVisualStyleBackColor = false;
            // 
            // lblValjKategori
            // 
            lblValjKategori.Location = new Point(11, 364);
            lblValjKategori.Name = "lblValjKategori";
            lblValjKategori.Size = new Size(200, 32);
            lblValjKategori.TabIndex = 14;
            lblValjKategori.Text = "Välj kategori";
            // 
            // cmbValjKategori
            // 
            cmbValjKategori.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbValjKategori.Items.AddRange(new object[] { "Alla poddar" });
            cmbValjKategori.Location = new Point(12, 399);
            cmbValjKategori.Name = "cmbValjKategori";
            cmbValjKategori.Size = new Size(250, 33);
            cmbValjKategori.TabIndex = 15;
            // 
            // lblFiltreraKategori
            // 
            lblFiltreraKategori.Location = new Point(829, 62);
            lblFiltreraKategori.Name = "lblFiltreraKategori";
            lblFiltreraKategori.Size = new Size(100, 34);
            lblFiltreraKategori.TabIndex = 16;
            lblFiltreraKategori.Text = "Filtrera kategori";
            // 
            // cmbFiltreraKategori
            // 
            cmbFiltreraKategori.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltreraKategori.Location = new Point(830, 98);
            cmbFiltreraKategori.Name = "cmbFiltreraKategori";
            cmbFiltreraKategori.Size = new Size(212, 33);
            cmbFiltreraKategori.TabIndex = 17;
            // 
            // btnOppenKategoriFonster
            // 
            btnOppenKategoriFonster.BackColor = Color.Transparent;
            btnOppenKategoriFonster.Cursor = Cursors.IBeam;
            btnOppenKategoriFonster.Location = new Point(1431, 572);
            btnOppenKategoriFonster.Name = "btnOppenKategoriFonster";
            btnOppenKategoriFonster.Size = new Size(246, 43);
            btnOppenKategoriFonster.TabIndex = 18;
            btnOppenKategoriFonster.Text = "Hantera Kategorier";
            btnOppenKategoriFonster.UseVisualStyleBackColor = false;
            // 
            // lstSparadePoddar
            // 
            lstSparadePoddar.Location = new Point(830, 147);
            lstSparadePoddar.Name = "lstSparadePoddar";
            lstSparadePoddar.Size = new Size(212, 379);
            lstSparadePoddar.TabIndex = 20;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(14, 9);
            label1.Name = "label1";
            label1.Size = new Size(417, 38);
            label1.TabIndex = 21;
            label1.Text = "Förhandsgranska podd med RSS";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F);
            label2.Location = new Point(826, 9);
            label2.Name = "label2";
            label2.Size = new Size(213, 38);
            label2.TabIndex = 22;
            label2.Text = "Sparade poddar";
            // 
            // txtPreviewTitel
            // 
            txtPreviewTitel.BackColor = Color.White;
            txtPreviewTitel.Location = new Point(11, 147);
            txtPreviewTitel.Name = "txtPreviewTitel";
            txtPreviewTitel.PlaceholderText = "PoddTitel";
            txtPreviewTitel.ReadOnly = true;
            txtPreviewTitel.Size = new Size(400, 31);
            txtPreviewTitel.TabIndex = 1;
            // 
            // txtPreviewBeskrivning
            // 
            txtPreviewBeskrivning.BackColor = Color.White;
            txtPreviewBeskrivning.Location = new Point(11, 184);
            txtPreviewBeskrivning.Multiline = true;
            txtPreviewBeskrivning.Name = "txtPreviewBeskrivning";
            txtPreviewBeskrivning.PlaceholderText = "Beskrivning av podden...";
            txtPreviewBeskrivning.ReadOnly = true;
            txtPreviewBeskrivning.Size = new Size(400, 177);
            txtPreviewBeskrivning.TabIndex = 2;
            // 
            // Form1
            // 
            BackColor = Color.SteelBlue;
            ClientSize = new Size(1734, 715);
            Controls.Add(txtPreviewTitel);
            Controls.Add(txtPreviewBeskrivning);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtTitel);
            Controls.Add(txtDatum);
            Controls.Add(txtBeskrivning);
            Controls.Add(txtRssLank);
            Controls.Add(lstAvsnitt);
            Controls.Add(btnForhandsgranska);
            Controls.Add(btnRaderaPodd);
            Controls.Add(btnSparaPrenumerera);
            Controls.Add(txtNyttNamn);
            Controls.Add(btnBytNamnPodd);
            Controls.Add(btnVisaAvsnitt);
            Controls.Add(lblValjKategori);
            Controls.Add(cmbValjKategori);
            Controls.Add(lblFiltreraKategori);
            Controls.Add(cmbFiltreraKategori);
            Controls.Add(btnOppenKategoriFonster);
            Controls.Add(lstSparadePoddar);
            Name = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }
        private Label label1;
        private Label label2;
    }
}
