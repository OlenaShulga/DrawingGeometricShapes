
namespace Projekt2_Shulga58686
{
    partial class osPrezentacjaLosowaZeSlajderem
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ospbRysownica = new System.Windows.Forms.PictureBox();
            this.osbtnPowrótDoGłówForm = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ostxtN = new System.Windows.Forms.TextBox();
            this.osbtnStart = new System.Windows.Forms.Button();
            this.oschlbFiguryGeometryczne = new System.Windows.Forms.CheckedListBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.osbtnPrzesunięcie = new System.Windows.Forms.Button();
            this.osbtnZmianaGraficznychAtrybutów = new System.Windows.Forms.Button();
            this.osbtnPrzesunięcieIZmianaGraficzna = new System.Windows.Forms.Button();
            this.osbtnWłączenieSlajdera = new System.Windows.Forms.Button();
            this.osbtnWyłączenieSlajdera = new System.Windows.Forms.Button();
            this.osgbPokazFigur = new System.Windows.Forms.GroupBox();
            this.osrdbManualny = new System.Windows.Forms.RadioButton();
            this.osrdbAutomatyczny = new System.Windows.Forms.RadioButton();
            this.osbtnNastępna = new System.Windows.Forms.Button();
            this.osbtnPoprzednia = new System.Windows.Forms.Button();
            this.oslblNumer = new System.Windows.Forms.Label();
            this.ostxtNumerFigury = new System.Windows.Forms.TextBox();
            this.osTimer = new System.Windows.Forms.Timer(this.components);
            this.oslblZaznaczFigury = new System.Windows.Forms.Label();
            this.osbtnResetuj = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ospbRysownica)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.osgbPokazFigur.SuspendLayout();
            this.SuspendLayout();
            // 
            // ospbRysownica
            // 
            this.ospbRysownica.Location = new System.Drawing.Point(244, 111);
            this.ospbRysownica.Name = "ospbRysownica";
            this.ospbRysownica.Size = new System.Drawing.Size(434, 486);
            this.ospbRysownica.TabIndex = 0;
            this.ospbRysownica.TabStop = false;
            // 
            // osbtnPowrótDoGłówForm
            // 
            this.osbtnPowrótDoGłówForm.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.osbtnPowrótDoGłówForm.Location = new System.Drawing.Point(695, 30);
            this.osbtnPowrótDoGłówForm.Name = "osbtnPowrótDoGłówForm";
            this.osbtnPowrótDoGłówForm.Size = new System.Drawing.Size(325, 65);
            this.osbtnPowrótDoGłówForm.TabIndex = 1;
            this.osbtnPowrótDoGłówForm.Text = "Powrót do głównego formularza";
            this.osbtnPowrótDoGłówForm.UseVisualStyleBackColor = true;
            this.osbtnPowrótDoGłówForm.Click += new System.EventHandler(this.osbtnPowrótDoGłówForm_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(25, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 42);
            this.label1.TabIndex = 2;
            this.label1.Text = "Podaj liczbę figur \r\ngeometrycznych";
            // 
            // ostxtN
            // 
            this.ostxtN.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ostxtN.Location = new System.Drawing.Point(12, 63);
            this.ostxtN.Name = "ostxtN";
            this.ostxtN.Size = new System.Drawing.Size(174, 28);
            this.ostxtN.TabIndex = 3;
            this.ostxtN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ostxtN.TextChanged += new System.EventHandler(this.ostxtN_TextChanged);
            // 
            // osbtnStart
            // 
            this.osbtnStart.Enabled = false;
            this.osbtnStart.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.osbtnStart.Location = new System.Drawing.Point(10, 107);
            this.osbtnStart.Name = "osbtnStart";
            this.osbtnStart.Size = new System.Drawing.Size(176, 93);
            this.osbtnStart.TabIndex = 4;
            this.osbtnStart.Text = "Start(rozpoczęcie prezentacji)";
            this.osbtnStart.UseVisualStyleBackColor = true;
            this.osbtnStart.Click += new System.EventHandler(this.osbtnStart_Click);
            // 
            // oschlbFiguryGeometryczne
            // 
            this.oschlbFiguryGeometryczne.FormattingEnabled = true;
            this.oschlbFiguryGeometryczne.Items.AddRange(new object[] {
            "Punkt",
            "Linia",
            "Elipsa",
            "Okrąg",
            "Prostokąt",
            "Kwadrat",
            "Koło jednobarwne",
            "Prostokąt wypełniony",
            "Wielokąt foremny",
            "Wielokąt foremny wypełniony",
            "itp"});
            this.oschlbFiguryGeometryczne.Location = new System.Drawing.Point(709, 189);
            this.oschlbFiguryGeometryczne.Name = "oschlbFiguryGeometryczne";
            this.oschlbFiguryGeometryczne.Size = new System.Drawing.Size(253, 259);
            this.oschlbFiguryGeometryczne.TabIndex = 5;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // osbtnPrzesunięcie
            // 
            this.osbtnPrzesunięcie.Enabled = false;
            this.osbtnPrzesunięcie.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.osbtnPrzesunięcie.Location = new System.Drawing.Point(10, 206);
            this.osbtnPrzesunięcie.Name = "osbtnPrzesunięcie";
            this.osbtnPrzesunięcie.Size = new System.Drawing.Size(176, 93);
            this.osbtnPrzesunięcie.TabIndex = 6;
            this.osbtnPrzesunięcie.Text = "Przesunięcie do nowego miejsca";
            this.osbtnPrzesunięcie.UseVisualStyleBackColor = true;
            this.osbtnPrzesunięcie.Click += new System.EventHandler(this.osbtnPrzesunięcie_Click);
            // 
            // osbtnZmianaGraficznychAtrybutów
            // 
            this.osbtnZmianaGraficznychAtrybutów.Enabled = false;
            this.osbtnZmianaGraficznychAtrybutów.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.osbtnZmianaGraficznychAtrybutów.Location = new System.Drawing.Point(12, 305);
            this.osbtnZmianaGraficznychAtrybutów.Name = "osbtnZmianaGraficznychAtrybutów";
            this.osbtnZmianaGraficznychAtrybutów.Size = new System.Drawing.Size(176, 112);
            this.osbtnZmianaGraficznychAtrybutów.TabIndex = 7;
            this.osbtnZmianaGraficznychAtrybutów.Text = "Zmiana (losowa) atrybutów graficznych figur geometrycznych";
            this.osbtnZmianaGraficznychAtrybutów.UseVisualStyleBackColor = true;
            this.osbtnZmianaGraficznychAtrybutów.Click += new System.EventHandler(this.osbtnZmianaGraficznychAtrybutów_Click);
            // 
            // osbtnPrzesunięcieIZmianaGraficzna
            // 
            this.osbtnPrzesunięcieIZmianaGraficzna.Enabled = false;
            this.osbtnPrzesunięcieIZmianaGraficzna.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.osbtnPrzesunięcieIZmianaGraficzna.Location = new System.Drawing.Point(12, 423);
            this.osbtnPrzesunięcieIZmianaGraficzna.Name = "osbtnPrzesunięcieIZmianaGraficzna";
            this.osbtnPrzesunięcieIZmianaGraficzna.Size = new System.Drawing.Size(176, 112);
            this.osbtnPrzesunięcieIZmianaGraficzna.TabIndex = 8;
            this.osbtnPrzesunięcieIZmianaGraficzna.Text = "Przesunięcie do nowej lokalizacji i zmiana atrybutów graficznych figur geometrycz" +
    "nych";
            this.osbtnPrzesunięcieIZmianaGraficzna.UseVisualStyleBackColor = true;
            this.osbtnPrzesunięcieIZmianaGraficzna.Click += new System.EventHandler(this.osbtnPrzesunięcieIZmianaGraficzna_Click);
            // 
            // osbtnWłączenieSlajdera
            // 
            this.osbtnWłączenieSlajdera.Enabled = false;
            this.osbtnWłączenieSlajdera.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.osbtnWłączenieSlajdera.Location = new System.Drawing.Point(12, 541);
            this.osbtnWłączenieSlajdera.Name = "osbtnWłączenieSlajdera";
            this.osbtnWłączenieSlajdera.Size = new System.Drawing.Size(176, 85);
            this.osbtnWłączenieSlajdera.TabIndex = 9;
            this.osbtnWłączenieSlajdera.Text = "Włączenie slajdera figur geometrycznych";
            this.osbtnWłączenieSlajdera.UseVisualStyleBackColor = true;
            this.osbtnWłączenieSlajdera.Click += new System.EventHandler(this.osbtnWłączenieSlajdera_Click);
            // 
            // osbtnWyłączenieSlajdera
            // 
            this.osbtnWyłączenieSlajdera.Enabled = false;
            this.osbtnWyłączenieSlajdera.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.osbtnWyłączenieSlajdera.Location = new System.Drawing.Point(194, 540);
            this.osbtnWyłączenieSlajdera.Name = "osbtnWyłączenieSlajdera";
            this.osbtnWyłączenieSlajdera.Size = new System.Drawing.Size(176, 86);
            this.osbtnWyłączenieSlajdera.TabIndex = 10;
            this.osbtnWyłączenieSlajdera.Text = "Wyłączenie slajdera figur geometrycznych";
            this.osbtnWyłączenieSlajdera.UseVisualStyleBackColor = true;
            this.osbtnWyłączenieSlajdera.Click += new System.EventHandler(this.osbtnWyłączenieSlajdera_Click);
            // 
            // osgbPokazFigur
            // 
            this.osgbPokazFigur.Controls.Add(this.osrdbManualny);
            this.osgbPokazFigur.Controls.Add(this.osrdbAutomatyczny);
            this.osgbPokazFigur.Enabled = false;
            this.osgbPokazFigur.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.osgbPokazFigur.Location = new System.Drawing.Point(376, 540);
            this.osgbPokazFigur.Name = "osgbPokazFigur";
            this.osgbPokazFigur.Size = new System.Drawing.Size(334, 100);
            this.osgbPokazFigur.TabIndex = 11;
            this.osgbPokazFigur.TabStop = false;
            this.osgbPokazFigur.Text = "Pokaz figur";
            // 
            // osrdbManualny
            // 
            this.osrdbManualny.AutoSize = true;
            this.osrdbManualny.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.osrdbManualny.Location = new System.Drawing.Point(25, 57);
            this.osrdbManualny.Name = "osrdbManualny";
            this.osrdbManualny.Size = new System.Drawing.Size(301, 24);
            this.osrdbManualny.TabIndex = 1;
            this.osrdbManualny.TabStop = true;
            this.osrdbManualny.Text = "Manualny (sterowany przyciśkiem)";
            this.osrdbManualny.UseVisualStyleBackColor = true;
            // 
            // osrdbAutomatyczny
            // 
            this.osrdbAutomatyczny.AutoSize = true;
            this.osrdbAutomatyczny.Checked = true;
            this.osrdbAutomatyczny.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.osrdbAutomatyczny.Location = new System.Drawing.Point(25, 31);
            this.osrdbAutomatyczny.Name = "osrdbAutomatyczny";
            this.osrdbAutomatyczny.Size = new System.Drawing.Size(307, 24);
            this.osrdbAutomatyczny.TabIndex = 0;
            this.osrdbAutomatyczny.TabStop = true;
            this.osrdbAutomatyczny.Text = "Automatyczny (sterowany zegarem)";
            this.osrdbAutomatyczny.UseVisualStyleBackColor = true;
            // 
            // osbtnNastępna
            // 
            this.osbtnNastępna.Enabled = false;
            this.osbtnNastępna.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.osbtnNastępna.Location = new System.Drawing.Point(734, 536);
            this.osbtnNastępna.Name = "osbtnNastępna";
            this.osbtnNastępna.Size = new System.Drawing.Size(141, 49);
            this.osbtnNastępna.TabIndex = 12;
            this.osbtnNastępna.Text = "Następna";
            this.osbtnNastępna.UseVisualStyleBackColor = true;
            this.osbtnNastępna.Click += new System.EventHandler(this.osbtnNastępna_Click);
            // 
            // osbtnPoprzednia
            // 
            this.osbtnPoprzednia.Enabled = false;
            this.osbtnPoprzednia.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.osbtnPoprzednia.Location = new System.Drawing.Point(734, 591);
            this.osbtnPoprzednia.Name = "osbtnPoprzednia";
            this.osbtnPoprzednia.Size = new System.Drawing.Size(141, 49);
            this.osbtnPoprzednia.TabIndex = 13;
            this.osbtnPoprzednia.Text = "Poprzednia";
            this.osbtnPoprzednia.UseVisualStyleBackColor = true;
            this.osbtnPoprzednia.Click += new System.EventHandler(this.osbtnPoprzednia_Click);
            // 
            // oslblNumer
            // 
            this.oslblNumer.AutoSize = true;
            this.oslblNumer.Font = new System.Drawing.Font("Times New Roman", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.oslblNumer.Location = new System.Drawing.Point(907, 571);
            this.oslblNumer.Name = "oslblNumer";
            this.oslblNumer.Size = new System.Drawing.Size(113, 21);
            this.oslblNumer.TabIndex = 14;
            this.oslblNumer.Text = "Numer figury";
            // 
            // ostxtNumerFigury
            // 
            this.ostxtNumerFigury.Enabled = false;
            this.ostxtNumerFigury.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ostxtNumerFigury.Location = new System.Drawing.Point(903, 603);
            this.ostxtNumerFigury.Name = "ostxtNumerFigury";
            this.ostxtNumerFigury.Size = new System.Drawing.Size(100, 28);
            this.ostxtNumerFigury.TabIndex = 15;
            this.ostxtNumerFigury.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // osTimer
            // 
            this.osTimer.Interval = 1000;
            this.osTimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // oslblZaznaczFigury
            // 
            this.oslblZaznaczFigury.AutoSize = true;
            this.oslblZaznaczFigury.Font = new System.Drawing.Font("Times New Roman", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.oslblZaznaczFigury.Location = new System.Drawing.Point(705, 111);
            this.oslblZaznaczFigury.Name = "oslblZaznaczFigury";
            this.oslblZaznaczFigury.Size = new System.Drawing.Size(264, 63);
            this.oslblZaznaczFigury.TabIndex = 16;
            this.oslblZaznaczFigury.Text = "Zaznacz figury geometryczne,\r\nktóre mają być losowane i \r\nwyświetlane na planszy " +
    "graficznej";
            // 
            // osbtnResetuj
            // 
            this.osbtnResetuj.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.osbtnResetuj.Location = new System.Drawing.Point(709, 465);
            this.osbtnResetuj.Name = "osbtnResetuj";
            this.osbtnResetuj.Size = new System.Drawing.Size(141, 49);
            this.osbtnResetuj.TabIndex = 17;
            this.osbtnResetuj.Text = "Resetuj";
            this.osbtnResetuj.UseVisualStyleBackColor = true;
            this.osbtnResetuj.Click += new System.EventHandler(this.osbtnResetuj_Click);
            // 
            // osPrezentacjaLosowaZeSlajderem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(1032, 772);
            this.Controls.Add(this.osbtnResetuj);
            this.Controls.Add(this.ostxtNumerFigury);
            this.Controls.Add(this.osbtnWłączenieSlajdera);
            this.Controls.Add(this.oslblNumer);
            this.Controls.Add(this.osgbPokazFigur);
            this.Controls.Add(this.osbtnPoprzednia);
            this.Controls.Add(this.osbtnNastępna);
            this.Controls.Add(this.osbtnWyłączenieSlajdera);
            this.Controls.Add(this.oslblZaznaczFigury);
            this.Controls.Add(this.osbtnPrzesunięcieIZmianaGraficzna);
            this.Controls.Add(this.osbtnZmianaGraficznychAtrybutów);
            this.Controls.Add(this.osbtnPrzesunięcie);
            this.Controls.Add(this.oschlbFiguryGeometryczne);
            this.Controls.Add(this.osbtnStart);
            this.Controls.Add(this.ostxtN);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.osbtnPowrótDoGłówForm);
            this.Controls.Add(this.ospbRysownica);
            this.Name = "osPrezentacjaLosowaZeSlajderem";
            this.Text = "Prezentacja graficzna figur geometrycznych";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.osPrezentacjaLosowaZeSlajderem_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.osPrezentacjaLosowaZeSlajderem_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.ospbRysownica)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.osgbPokazFigur.ResumeLayout(false);
            this.osgbPokazFigur.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ospbRysownica;
        private System.Windows.Forms.Button osbtnPowrótDoGłówForm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ostxtN;
        private System.Windows.Forms.Button osbtnStart;
        private System.Windows.Forms.CheckedListBox oschlbFiguryGeometryczne;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button osbtnPrzesunięcie;
        private System.Windows.Forms.Button osbtnZmianaGraficznychAtrybutów;
        private System.Windows.Forms.Button osbtnPrzesunięcieIZmianaGraficzna;
        private System.Windows.Forms.Button osbtnNastępna;
        private System.Windows.Forms.GroupBox osgbPokazFigur;
        private System.Windows.Forms.RadioButton osrdbManualny;
        private System.Windows.Forms.RadioButton osrdbAutomatyczny;
        private System.Windows.Forms.Button osbtnWyłączenieSlajdera;
        private System.Windows.Forms.Button osbtnWłączenieSlajdera;
        private System.Windows.Forms.TextBox ostxtNumerFigury;
        private System.Windows.Forms.Label oslblNumer;
        private System.Windows.Forms.Button osbtnPoprzednia;
        private System.Windows.Forms.Timer osTimer;
        private System.Windows.Forms.Label oslblZaznaczFigury;
        private System.Windows.Forms.Button osbtnResetuj;
    }
}