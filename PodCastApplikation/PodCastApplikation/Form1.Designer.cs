namespace PodCastApplikation

{

    using System.Drawing;

    using System.Windows.Forms;



    partial class Form1

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
            btnLaggTillPodd = new Button();
            txtTitel = new Button();
            lstPoddar = new ListBox();
            btnVisaAlla = new Button();
            btnUppdateraPodd = new Button();
            btnSparaPrenumerera = new Button();
            txtNyttNamn = new TextBox();
            btnBytNamnPodd = new Button();
            btnRaderaPodd = new Button();
            btnVisaAvsnitt = new Button();
            lstAvsnitt = new ListBox();
            lblValjKategori = new Label();
            cmbValjKategori = new ComboBox();
            lblFiltreraKategori = new Label();
            cmbFiltreraKategori = new ComboBox();
            btnOppenKategoriFonster = new Button();
            txtRssLank = new TextBox();
            SuspendLayout();
            // 
            // btnLaggTillPodd
            // 
            btnLaggTillPodd.BackColor = Color.White;
            btnLaggTillPodd.Location = new Point(280, 128);
            btnLaggTillPodd.Name = "btnLaggTillPodd";
            btnLaggTillPodd.Size = new Size(165, 41);
            btnLaggTillPodd.TabIndex = 1;
            btnLaggTillPodd.Text = "Lägg till";
            btnLaggTillPodd.UseVisualStyleBackColor = false;
            // 
            // txtTitel
            // 
            txtTitel.Location = new Point(0, 0);
            txtTitel.Name = "txtTitel";
            txtTitel.Size = new Size(75, 23);
            txtTitel.TabIndex = 0;
            // 
            // lstPoddar
            // 
            lstPoddar.BackColor = SystemColors.InactiveCaption;
            lstPoddar.Location = new Point(12, 225);
            lstPoddar.Name = "lstPoddar";
            lstPoddar.Size = new Size(250, 228);
            lstPoddar.TabIndex = 2;
            // 
            // btnVisaAlla
            // 
            btnVisaAlla.BackColor = Color.White;
            btnVisaAlla.Location = new Point(280, 175);
            btnVisaAlla.Name = "btnVisaAlla";
            btnVisaAlla.Size = new Size(171, 39);
            btnVisaAlla.TabIndex = 3;
            btnVisaAlla.Text = "Visa alla";
            btnVisaAlla.UseVisualStyleBackColor = false;
            btnVisaAlla.Click += btnVisaAlla_Click_1;
            // 
            // btnUppdateraPodd
            // 
            btnUppdateraPodd.BackColor = Color.White;
            btnUppdateraPodd.Location = new Point(280, 265);
            btnUppdateraPodd.Name = "btnUppdateraPodd";
            btnUppdateraPodd.Size = new Size(165, 40);
            btnUppdateraPodd.TabIndex = 4;
            btnUppdateraPodd.Text = "Uppdatera";
            btnUppdateraPodd.UseVisualStyleBackColor = false;
            // 
            // btnSparaPrenumerera
            // 
            btnSparaPrenumerera.BackColor = Color.White;
            btnSparaPrenumerera.Location = new Point(280, 311);
            btnSparaPrenumerera.Name = "btnSparaPrenumerera";
            btnSparaPrenumerera.Size = new Size(274, 43);
            btnSparaPrenumerera.TabIndex = 5;
            btnSparaPrenumerera.Text = "Spara / Prenumerera";
            btnSparaPrenumerera.UseVisualStyleBackColor = false;
            // 
            // txtNyttNamn
            // 
            txtNyttNamn.Location = new Point(280, 360);
            txtNyttNamn.Name = "txtNyttNamn";
            txtNyttNamn.Size = new Size(246, 39);
            txtNyttNamn.TabIndex = 6;
            txtNyttNamn.TextChanged += txtNyttNamn_TextChanged;
            // 
            // btnBytNamnPodd
            // 
            btnBytNamnPodd.BackColor = Color.White;
            btnBytNamnPodd.Location = new Point(280, 405);
            btnBytNamnPodd.Name = "btnBytNamnPodd";
            btnBytNamnPodd.Size = new Size(200, 48);
            btnBytNamnPodd.TabIndex = 7;
            btnBytNamnPodd.Text = "Byt namn";
            btnBytNamnPodd.UseVisualStyleBackColor = false;
            // 
            // btnRaderaPodd
            // 
            btnRaderaPodd.BackColor = Color.White;
            btnRaderaPodd.ForeColor = Color.Red;
            btnRaderaPodd.Location = new Point(280, 221);
            btnRaderaPodd.Name = "btnRaderaPodd";
            btnRaderaPodd.Size = new Size(142, 38);
            btnRaderaPodd.TabIndex = 8;
            btnRaderaPodd.Text = "Radera";
            btnRaderaPodd.UseVisualStyleBackColor = false;
            // 
            // btnVisaAvsnitt
            // 
            btnVisaAvsnitt.BackColor = Color.White;
            btnVisaAvsnitt.Location = new Point(12, 466);
            btnVisaAvsnitt.Name = "btnVisaAvsnitt";
            btnVisaAvsnitt.Size = new Size(120, 40);
            btnVisaAvsnitt.TabIndex = 13;
            btnVisaAvsnitt.Text = "Visa avsnitt";
            btnVisaAvsnitt.UseVisualStyleBackColor = false;
            // 
            // lstAvsnitt
            // 
            lstAvsnitt.BackColor = SystemColors.InactiveCaption;
            lstAvsnitt.Location = new Point(12, 512);
            lstAvsnitt.Name = "lstAvsnitt";
            lstAvsnitt.Size = new Size(250, 164);
            lstAvsnitt.TabIndex = 14;
            lstAvsnitt.SelectedIndexChanged += lstAvsnitt_SelectedIndexChanged_1;
            // 
            // lblValjKategori
            // 
            lblValjKategori.Location = new Point(12, 16);
            lblValjKategori.Name = "lblValjKategori";
            lblValjKategori.Size = new Size(234, 42);
            lblValjKategori.TabIndex = 9;
            lblValjKategori.Text = "Välj kategori";
            // 
            // cmbValjKategori
            // 
            cmbValjKategori.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbValjKategori.Location = new Point(12, 54);
            cmbValjKategori.Name = "cmbValjKategori";
            cmbValjKategori.Size = new Size(250, 40);
            cmbValjKategori.TabIndex = 10;
            cmbValjKategori.SelectedIndexChanged += cmbValjKategori_SelectedIndexChanged;
            // 
            // lblFiltreraKategori
            // 
            lblFiltreraKategori.Location = new Point(12, 140);
            lblFiltreraKategori.Name = "lblFiltreraKategori";
            lblFiltreraKategori.Size = new Size(200, 32);
            lblFiltreraKategori.TabIndex = 11;
            lblFiltreraKategori.Text = "Filtrera kategori";
            // 
            // cmbFiltreraKategori
            // 
            cmbFiltreraKategori.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltreraKategori.Location = new Point(12, 175);
            cmbFiltreraKategori.Name = "cmbFiltreraKategori";
            cmbFiltreraKategori.Size = new Size(250, 40);
            cmbFiltreraKategori.TabIndex = 12;
            // 
            // btnOppenKategoriFonster
            // 
            btnOppenKategoriFonster.BackColor = Color.White;
            btnOppenKategoriFonster.Location = new Point(907, 12);
            btnOppenKategoriFonster.Name = "btnOppenKategoriFonster";
            btnOppenKategoriFonster.Size = new Size(250, 40);
            btnOppenKategoriFonster.TabIndex = 21;
            btnOppenKategoriFonster.Text = "Kategorier";
            btnOppenKategoriFonster.UseVisualStyleBackColor = false;
            // 
            // txtRssLank
            // 
            txtRssLank.Location = new Point(12, 100);
            txtRssLank.Name = "txtRssLank";
            txtRssLank.Size = new Size(250, 39);
            txtRssLank.TabIndex = 0;
            txtRssLank.TextChanged += txtRssLank_TextChanged;
            // 
            // Form1
            // 
            BackColor = Color.SteelBlue;
            ClientSize = new Size(1169, 693);
            Controls.Add(txtTitel);
            Controls.Add(txtRssLank);
            Controls.Add(btnLaggTillPodd);
            Controls.Add(lstPoddar);
            Controls.Add(btnVisaAlla);
            Controls.Add(btnUppdateraPodd);
            Controls.Add(btnSparaPrenumerera);
            Controls.Add(txtNyttNamn);
            Controls.Add(btnBytNamnPodd);
            Controls.Add(btnRaderaPodd);
            Controls.Add(cmbValjKategori);
            Controls.Add(lblFiltreraKategori);
            Controls.Add(cmbFiltreraKategori);
            Controls.Add(btnVisaAvsnitt);
            Controls.Add(lstAvsnitt);
            Controls.Add(btnOppenKategoriFonster);
            Controls.Add(lblValjKategori);
            Name = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();

        }



        #endregion

        private Button btnLaggTillPodd;

        private Button txtTitel;

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

    }

}

