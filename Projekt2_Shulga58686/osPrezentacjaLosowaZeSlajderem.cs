using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//dodanie przestrzeni nazw osFiguryGeometryczne
using static Projekt2_Shulga58686.osFiguryGeometryczne;
//dodanie przestrzeni nazw dla potrzeb grafiki 2D
using System.Drawing.Drawing2D;

namespace Projekt2_Shulga58686
{
    public partial class osPrezentacjaLosowaZeSlajderem : Form
    {//deklaracja zmiennej referencyjnej powierzchni graficznej
        Graphics osRysownica;
        osPunkt[] osTFG;//tablica figur geom.
        int osIndexTFG;//indeks tablicy
        ushort osIndex;
        const int osMargines = 10;//odstęp od krawędzie Rysownicy
        const int osMarginesFormularza = 20;//margines odstępu krawędzi formularza


        public osPrezentacjaLosowaZeSlajderem()
        {
            InitializeComponent();
            //lokalizacja i zwymiarowanie formularza
            this.Left = Screen.PrimaryScreen.Bounds.X + osMarginesFormularza;
            this.Top = Screen.PrimaryScreen.Bounds.Y + osMarginesFormularza;
            this.Width = (int)(Screen.PrimaryScreen.Bounds.Width * 0.85F);
            this.Height = (int)(Screen.PrimaryScreen.Bounds.Height * 0.75F);
            //ustalenie właściwości StartPosition dla lokalizacji i zwymiarowania 
            //formularza według naszych ustaleń
            this.StartPosition = FormStartPosition.Manual;
            //dodatkowe ustawienia atrybutów formularza
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            //lokalizacja i zwymiarowanie kontrolki pb
            ospbRysownica.Location = new Point(osbtnStart.Location.X + osbtnStart.Width + osMargines,
                                              ostxtN.Top);
            ospbRysownica.Width = (int)(this.Width * 0.65F);
            ospbRysownica.Height = (int)(this.Height * 0.70F);

            ospbRysownica.BackColor = Color.Beige;
            ospbRysownica.BorderStyle = BorderStyle.Fixed3D;
            //utworzenie mapy bitowej i jej "podpięcie" do kontrolki pictureBox
            ospbRysownica.Image = new Bitmap(ospbRysownica.Width, ospbRysownica.Height);
            //utworzenie egzemplarza powierzchni graficznej bitmapy
            osRysownica = Graphics.FromImage(ospbRysownica.Image);

            //lokalizacja btnPowrót
            osbtnPowrótDoGłówForm.Location = new Point(ospbRysownica.Location.X + ospbRysownica.Width + osMargines,
                                                       label1.Top);
            oslblZaznaczFigury.Location = new Point(osbtnPowrótDoGłówForm.Left, osbtnPowrótDoGłówForm.Top + 
                                                    osbtnPowrótDoGłówForm.Height + osMargines);
            oschlbFiguryGeometryczne.Location = new Point(oslblZaznaczFigury.Location.X,
                                         oslblZaznaczFigury.Top + oslblZaznaczFigury.Height + osMargines);
            osbtnWłączenieSlajdera.Location = new Point(ospbRysownica.Left, ospbRysownica.Bottom + osMargines);
            osbtnWyłączenieSlajdera.Location = new Point(osbtnWłączenieSlajdera.Left + osbtnWłączenieSlajdera.Width + osMargines,
                                                            osbtnWłączenieSlajdera.Top);
            osgbPokazFigur.Location = new Point(osbtnWyłączenieSlajdera.Left + osbtnWyłączenieSlajdera.Width + osMargines,
                                                osbtnWyłączenieSlajdera.Top);
            osgbPokazFigur.Width = 300;
            osbtnNastępna.Location = new Point(osgbPokazFigur.Left + osgbPokazFigur.Width + osMargines, osgbPokazFigur.Top);
            osbtnPoprzednia.Location = new Point(osbtnNastępna.Left, osbtnNastępna.Top + osbtnNastępna.Height + osMargines);
            oslblNumer.Location = new Point(osbtnNastępna.Left + osbtnNastępna.Width + osMargines, osbtnNastępna.Top);
            ostxtNumerFigury.Location = new Point(oslblNumer.Left, oslblNumer.Top + oslblNumer.Height + osMargines);
            osbtnResetuj.Location = new Point(oschlbFiguryGeometryczne.Left + oschlbFiguryGeometryczne.Width/2 - osbtnResetuj.Width/2, oschlbFiguryGeometryczne.Bottom + osMargines);

        }

        private void osbtnStart_Click(object sender, EventArgs e)
        {
            //deklaracja i utworzenie generatora liczb losowych
            Random osRnd = new Random();
            //deklaracje pomocnicze
            ushort osN;//wpisana liczba
            //zgaszenie errorProvider
            errorProvider1.Dispose();
            //sprawdzenie czy Użytkownik podał liczbę figur
            if (string.IsNullOrEmpty(ostxtN.Text))
            {
                //jest błąd:osN = 0
                errorProvider1.SetError(ostxtN, "ERROR : musisz podać liczbę figur geometrycznych");
                return;
            }
            if(!ushort.TryParse(ostxtN.Text, out osN))
            {
                errorProvider1.SetError(ostxtN, "ERROR : niepoprawnie wpisana liczba!");
                return;
            }
            if(osN == 0)
            {
                errorProvider1.SetError(ostxtN, "ERROR : liczba figur geometrycznych musi być > 0");
                return;
            }
            osIndexTFG = 0;
            osTFG = new osPunkt[osN];
            //skopiowanie numerów zaznaczonych figur 
            CheckedListBox.CheckedItemCollection osWybraneFigury = oschlbFiguryGeometryczne.CheckedItems;
            if(osWybraneFigury.Count == 0)
            {
                errorProvider1.SetError(oschlbFiguryGeometryczne, "ERROR : żadna figura geometryczna nie została zaznaczona!");
                return;
            }
            errorProvider1.Dispose();
            //wyznaczenie rozmiarów powierzchni graficznej
            int osXmax = ospbRysownica.Width;
            int osYmax = ospbRysownica.Height;
            //deklaracje zmiennych pomocniczych
            int osX, osY;
            Color osKolorLinii, osKolorWypełnienia;
            int osGrubośćLinii;
            DashStyle osStylLinii;
            int osRozmiarPunktu;
            int osWylosowabyIndex;
            int osXk, osYk;
            int osOśDuża, osOśMała;
            for (ushort osi = 0; osi < osN; osi++)
            {
                //losowanie atrybutów geometrycznych i graficznych
                //wylosowanie grubości linii
                osGrubośćLinii = osRnd.Next(1, 10);
                //wylosowanie stylu linii
                switch (osRnd.Next(0, 4))
                {
                    case 0: osStylLinii = DashStyle.Solid; break;
                    case 1: osStylLinii = DashStyle.Dot; break;
                    case 2: osStylLinii = DashStyle.DashDot; break;
                    case 3: osStylLinii = DashStyle.DashDotDot; break;
                    case 4: osStylLinii = DashStyle.Dash; break;
                    default: osStylLinii = DashStyle.Solid; break;
                }
                //wylosowanie kolorów
                osKolorLinii = Color.FromArgb(osRnd.Next(1, 255),
                                              osRnd.Next(1, 255),
                                              osRnd.Next(1, 255));
                osKolorWypełnienia = Color.FromArgb(osRnd.Next(1, 255),
                                              osRnd.Next(1, 255),
                                              osRnd.Next(1, 255));
                //wylosowanie osX i osY
                osX = osRnd.Next(osMargines, osXmax - osMargines);
                osY = osRnd.Next(osMargines, osYmax - osMargines);
                //wylosowanie w kolekcji figur wybranych
                osWylosowabyIndex = osRnd.Next(osWybraneFigury.Count);
                //rozpoznie figury wylosowanej
                switch (osWybraneFigury[osWylosowabyIndex])
                {
                    case "Punkt":
                        {
                            //utowrzenie egzemplarza punkt i dodanie do TFG
                            osTFG[osIndexTFG] = new osPunkt(osX, osY);
                            osRozmiarPunktu = 2 * osRnd.Next(3, osMargines);
                            osTFG[osIndexTFG].osUstalNoweAtrybutyGraficzne(osKolorLinii, osStylLinii, osRozmiarPunktu);
                            osTFG[osIndexTFG].osWykreśl(osRysownica);
                            osIndexTFG++;
                            break;
                        }
                    case "Linia":
                        {
                            //wylosowanie osXk i osYk
                            osXk = osRnd.Next(osMargines, osXmax - osMargines);
                            osYk = osRnd.Next(osMargines, osYmax - osMargines);
                            //utowrzenie egzemplarza punkt i dodanie do TFG
                            osTFG[osIndexTFG] = new osLinia(osX, osY, osXk, osYk);
                            osTFG[osIndexTFG].osUstalNoweAtrybutyGraficzne(osKolorLinii, osStylLinii, osGrubośćLinii);
                            osTFG[osIndexTFG].osWykreśl(osRysownica);
                            osIndexTFG++;
                            break;
                        }
                    case "Elipsa":
                        {
                            //wylosowanie osiej
                            osOśDuża = osRnd.Next(osMargines, osXmax/3);
                            osOśMała = osRnd.Next(osMargines, osYmax/3);
                            //utowrzenie egzemplarza punkt i dodanie do TFG
                            osTFG[osIndexTFG] = new osElipsa(osX, osY, osOśDuża, osOśMała);
                            osTFG[osIndexTFG].osUstalNoweAtrybutyGraficzne(osKolorLinii, osStylLinii, osGrubośćLinii);
                            osTFG[osIndexTFG].osWykreśl(osRysownica);
                            osIndexTFG++;
                            break;
                        }
                    case "Okrąg":
                        {
                            //wylosowanie promienia
                            osOśDuża = osRnd.Next(osMargines, osXmax / 3);
                            //utowrzenie egzemplarza punkt i dodanie do TFG
                            osTFG[osIndexTFG] = new osOkrąg(osX, osY, osOśDuża);
                            osTFG[osIndexTFG].osUstalNoweAtrybutyGraficzne(osKolorLinii, osStylLinii, osGrubośćLinii);
                            osTFG[osIndexTFG].osWykreśl(osRysownica);
                            osIndexTFG++;
                            break;
                        }
                    case "Prostokąt":
                        {
                            //wylosowanie stron
                            osOśDuża = osRnd.Next(osMargines, osXmax / 3);
                            osOśMała = osRnd.Next(osMargines, osYmax / 3);
                            //utowrzenie egzemplarza punkt i dodanie do TFG
                            osTFG[osIndexTFG] = new osProstokąt(osX, osY, osOśDuża, osOśMała);
                            osTFG[osIndexTFG].osUstalNoweAtrybutyGraficzne(osKolorLinii, osStylLinii, osGrubośćLinii);
                            osTFG[osIndexTFG].osWykreśl(osRysownica);
                            osIndexTFG++;
                            break;
                        }
                    case "Kwadrat":
                        {
                            //wylosowanie strony
                            osOśDuża = osRnd.Next(osMargines, osXmax / 3);
                            //utowrzenie egzemplarza punkt i dodanie do TFG
                            osTFG[osIndexTFG] = new osKwadrat(osX, osY, osOśDuża);
                            osTFG[osIndexTFG].osUstalNoweAtrybutyGraficzne(osKolorLinii, osStylLinii, osGrubośćLinii);
                            osTFG[osIndexTFG].osWykreśl(osRysownica);
                            osIndexTFG++;
                            break;
                        }
                    case "Koło jednobarwne":
                        {
                            //wylosowanie promienia
                            osOśDuża = osRnd.Next(osMargines, osXmax / 3);
                            //utowrzenie egzemplarza punkt i dodanie do TFG
                            osTFG[osIndexTFG] = new osKoło(osX, osY, osOśDuża);
                            osTFG[osIndexTFG].osUstalNoweAtrybutyGraficzneTło(osKolorWypełnienia);
                            osTFG[osIndexTFG].osWykreśl(osRysownica);
                            osIndexTFG++;
                            break;
                           
                        }
                    case "Prostokąt wypełniony":
                        {
                            //wylosowanie stron
                            osOśDuża = osRnd.Next(osMargines, osXmax / 3);
                            osOśMała = osRnd.Next(osMargines, osYmax / 3);
                            //utowrzenie egzemplarza punkt i dodanie do TFG
                            osTFG[osIndexTFG] = new osProstokątWypełniony(osX, osY, osOśDuża, osOśMała);
                            osTFG[osIndexTFG].osUstalNoweAtrybutyGraficzne(osKolorLinii, osStylLinii, osGrubośćLinii);
                            osTFG[osIndexTFG].osUstalNoweAtrybutyGraficzneTło(osKolorWypełnienia);
                            osTFG[osIndexTFG].osWykreśl(osRysownica);
                            osIndexTFG++;
                            break;
                        }
                    case "Wielokąt foremny":
                        {
                            osTFG[osIndexTFG] = new osWielokątForemny(osX, osY, osX + osRnd.Next(50, 100), osY, (ushort)(osRnd.Next(3, 12)));
                            osTFG[osIndexTFG].osUstalNoweAtrybutyGraficzne(osKolorLinii, osStylLinii, osGrubośćLinii);
                            //osTFG[osIndexTFG].osUstalNoweAtrybutyGraficzneTło(osKolorWypełnienia);
                            osTFG[osIndexTFG].osWykreśl(osRysownica);
                            osIndexTFG++;
                            break;
                        }
                    case "Wielokąt foremny wypełniony":
                        {
                            osTFG[osIndexTFG] = new osWielokątForemnyWypełniony(osX, osY, osX + osRnd.Next(50, 100), osY, (ushort)(osRnd.Next(3, 12)));
                            osTFG[osIndexTFG].osUstalNoweAtrybutyGraficzne(osKolorLinii, osStylLinii, osGrubośćLinii);
                            osTFG[osIndexTFG].osUstalNoweAtrybutyGraficzneTło(osKolorWypełnienia);
                            osTFG[osIndexTFG].osWykreśl(osRysownica);
                            osIndexTFG++;
                            break;
                        }
                    case "itp":
                        {
                            int osK1 = osRnd.Next(0, 180);
                            int osK2 = osRnd.Next(osK1 + 10, osK1 + 170);
                            int osInd = osIndexTFG % 3;
                            switch (osInd)
                            {
                                case 0:
                                    {
                                        osTFG[osIndexTFG] = new osDrawArc(osX, osY, osRnd.Next(50, 200), osRnd.Next(50, 200), osK1, osK2);
                                        break;
                                    }
                                case 1:
                                    {
                                        osTFG[osIndexTFG] = new osDrawPie(osX, osY, osRnd.Next(50, 200), osRnd.Next(50, 200), osK1, osK2);
                                        break;
                                    }
                                case 2:
                                    {
                                        osTFG[osIndexTFG] = new osFillPie(osX, osY, osRnd.Next(50, 200), osRnd.Next(50, 200), osK1, osK2);
                                        osTFG[osIndexTFG].osUstalNoweAtrybutyGraficzneTło(osKolorWypełnienia);
                                        break;
                                    }
                            }
                            osTFG[osIndexTFG].osUstalNoweAtrybutyGraficzne(osKolorLinii, osStylLinii, osGrubośćLinii);
                            osTFG[osIndexTFG].osWykreśl(osRysownica);
                            osIndexTFG++;
                            break;
                        }


                }
            }
            ospbRysownica.Refresh();
            //ustalenie aktywności kontrolek
            osbtnStart.Enabled = false;
            ostxtN.Enabled = false;
            oschlbFiguryGeometryczne.Enabled = false;
            osbtnWłączenieSlajdera.Enabled = true;
            osbtnPrzesunięcie.Enabled = true;
            osbtnPrzesunięcieIZmianaGraficzna.Enabled = true;
            osbtnZmianaGraficznychAtrybutów.Enabled = true;
            ostxtNumerFigury.Enabled= true;
            osgbPokazFigur.Enabled= true;

        }

        private void osbtnPowrótDoGłówForm_Click(object sender, EventArgs e)
        {
            //odszukanie formularza głównego w kolekcji OpenForms
            foreach(Form osFormX in Application.OpenForms)
                //sprawdzenie czy "znaleziony" formularz jest form1
                if(osFormX.Name== "osPrezenter_Shulga")
                {
                    //ukryci ebieżącego formularza
                    Hide();
                    //odsłonięcie
                    osFormX.Show();
                    //wyjście z metody zdarzenia click
                    return;
                }
            //formularz główny nie został znaleziony
           
            osPrezenter_Shulga osPrezenter = new osPrezenter_Shulga();
            Hide();
            osPrezenter.Show();
        }

        private void osPrezentacjaLosowaZeSlajderem_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult osWynik=MessageBox.Show("Czy rzeczywiście chcesz zakończyć działanie programu?", 
                this.Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);
            //sprawdzenie odpowiedzi użytkownika programu
            if (osWynik != DialogResult.Yes)
                //skasowanie zdarzenia
                e.Cancel = true;
            else
                //zdarzenie cancel nie może być skasowane
                e.Cancel = false;
        }

        private void osPrezentacjaLosowaZeSlajderem_FormClosed(object sender, FormClosedEventArgs e)
        {
            //zamknięcie programu
            Application.Exit();
        }

        private void osbtnPrzesunięcie_Click(object sender, EventArgs e)
        {
            //wyczyszczenie rysownicy
            osRysownica.Clear(ospbRysownica.BackColor);
            Random osRnd = new Random();
            //wyznaczenie rozmiarów kontrolki
            int osXmax = ospbRysownica.Width;
            int osYmax = ospbRysownica.Height;
            //deklaracja zmiennych pomocniczych
            int osX, osY;
            //przesunięcie figur
            for(ushort osi =0; osi<osIndexTFG; osi++)
            {
                //wulosowanie nowego położenia
                osX = osRnd.Next(osMargines, osXmax - osMargines);
                osY = osRnd.Next(osMargines, osYmax - osMargines);
                //przesunięcie i-tej figury
                osTFG[osi].osPrzesuńDoNowegoXY(ospbRysownica, osRysownica, osX, osY);
            }
            //odświerzenie powierzchni graficznej
            ospbRysownica.Refresh();
        }

        private void osbtnZmianaGraficznychAtrybutów_Click(object sender, EventArgs e)
        {
            osRysownica.Clear(ospbRysownica.BackColor);
            //deklaracja i utworzenie generatora liczb losowych
            Random osRnd = new Random();
            Color osKolorLinii, osKolorWypełnienia;
            int osGrubośćLinii;
            DashStyle osStylLinii;
            
            for(ushort osi=0; osi<osIndexTFG; osi++)
            {

                //losowanie atrybutów graficznych
                //wylosowanie grubości linii
                osGrubośćLinii = osRnd.Next(1, 10);
                //wylosowanie stylu linii
                switch (osRnd.Next(0, 4))
                {
                    case 0: osStylLinii = DashStyle.Solid; break;
                    case 1: osStylLinii = DashStyle.Dot; break;
                    case 2: osStylLinii = DashStyle.DashDot; break;
                    case 3: osStylLinii = DashStyle.DashDotDot; break;
                    case 4: osStylLinii = DashStyle.Dash; break;
                    default: osStylLinii = DashStyle.Solid; break;
                }
                //wylosowanie kolorów
                osKolorLinii = Color.FromArgb(osRnd.Next(1, 255),
                                              osRnd.Next(1, 255),
                                              osRnd.Next(1, 255));
                osKolorWypełnienia = Color.FromArgb(osRnd.Next(1, 255),
                                              osRnd.Next(1, 255),
                                              osRnd.Next(1, 255));
                osTFG[osi].osUstalNoweAtrybutyGraficzne(osKolorLinii, osKolorWypełnienia, osStylLinii, osGrubośćLinii);
                osTFG[osi].osWykreśl(osRysownica);
            }
            ospbRysownica.Refresh();

        }

        private void osbtnPrzesunięcieIZmianaGraficzna_Click(object sender, EventArgs e)
        {
            //wyczyszczenie rysownicy
            osRysownica.Clear(ospbRysownica.BackColor);
            Random osRnd = new Random();
            //wyznaczenie rozmiarów kontrolki
            int osXmax = ospbRysownica.Width;
            int osYmax = ospbRysownica.Height;
            //deklaracja zmiennych pomocniczych
            int osX, osY;
            Color osKolorLinii, osKolorWypełnienia;
            int osGrubośćLinii;
            DashStyle osStylLinii;
            //przesunięcie figur
            for (ushort osi = 0; osi < osIndexTFG; osi++)
            {
                //losowanie atrybutów graficznych
                //wylosowanie grubości linii
                osGrubośćLinii = osRnd.Next(1, 10);
                //wylosowanie stylu linii
                switch (osRnd.Next(0, 4))
                {
                    case 0: osStylLinii = DashStyle.Solid; break;
                    case 1: osStylLinii = DashStyle.Dot; break;
                    case 2: osStylLinii = DashStyle.DashDot; break;
                    case 3: osStylLinii = DashStyle.DashDotDot; break;
                    case 4: osStylLinii = DashStyle.Dash; break;
                    default: osStylLinii = DashStyle.Solid; break;
                }
                //wylosowanie kolorów
                osKolorLinii = Color.FromArgb(osRnd.Next(1, 255),
                                              osRnd.Next(1, 255),
                                              osRnd.Next(1, 255));
                osKolorWypełnienia = Color.FromArgb(osRnd.Next(1, 255),
                                              osRnd.Next(1, 255),
                                              osRnd.Next(1, 255));
                osTFG[osi].osUstalNoweAtrybutyGraficzne(osKolorLinii, osKolorWypełnienia, osStylLinii, osGrubośćLinii);

                //wylosowanie nowego położenia
                osX = osRnd.Next(osMargines, osXmax - osMargines);
                osY = osRnd.Next(osMargines, osYmax - osMargines);
                //przesunięcie i-tej figury
                osTFG[osi].osPrzesuńDoNowegoXY(ospbRysownica, osRysownica, osX, osY);
            }
            //odświerzenie powierzchni graficznej
            ospbRysownica.Refresh();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //wymazanie osRysownicy
            osRysownica.Clear(ospbRysownica.BackColor);
            //wyznaczenie rozmiarów rysownicy
            int osXmax = ospbRysownica.Width;
            int osYmax = ospbRysownica.Height;
            //wykreślenie pośrodku rysownicy figury geometrycznej
            osTFG[(int)osTimer.Tag].osPrzesuńDoNowegoXY(ospbRysownica, osRysownica, osXmax / 2, osYmax / 2);
            ostxtNumerFigury.Text = osTimer.Tag.ToString();
            //wyznaczednie timer.Tag dla następnego wykreślenia
            osTimer.Tag = ((int)osTimer.Tag + 1) % osIndexTFG;
            ospbRysownica.Refresh();
        }

        private void osbtnWłączenieSlajdera_Click(object sender, EventArgs e)
        {
            if (ostxtNumerFigury.Text == "")
            {
                osIndex = 0;

            }
            else
               if (!ushort.TryParse(ostxtNumerFigury.Text, out osIndex))
            {
                errorProvider1.SetError(ostxtNumerFigury, "ERROR : w zapisie indeksa figury wystąpił niedozwolony znak");
                return;
            }
            else
               if (osIndex < 0 || osIndex >= osIndexTFG)
            {
                errorProvider1.SetError(ostxtNumerFigury, "ERROR : indeks figury powinien być w zakresie [0, " + (osIndexTFG - 1).ToString() + "]!");
                return;
            }
            errorProvider1.Dispose();
            osRysownica.Clear(ospbRysownica.BackColor);
            
            
            //uaktywnienie przycisków
            osbtnWłączenieSlajdera.Enabled = false;
            osbtnWyłączenieSlajdera.Enabled = true;
            ostxtNumerFigury.Enabled = false;
            osgbPokazFigur.Enabled = false;
            osbtnZmianaGraficznychAtrybutów.Enabled= false;
            osbtnPrzesunięcieIZmianaGraficzna.Enabled= false;
            osbtnPrzesunięcie.Enabled= false;
            if (osrdbAutomatyczny.Checked)
            {
                osTimer.Tag = (int)osIndex;
                osTimer.Start();
            }
            else
            {
                osbtnNastępna.Enabled = true;
                osbtnPoprzednia.Enabled = true;
                //wyznaczenie rozmiarów rysownicy
                int osXmax = ospbRysownica.Width;
                int osYmax = ospbRysownica.Height;
                //wykreślenie pośrodku rysownicy figury geometrycznej
                osTFG[osIndex].osPrzesuńDoNowegoXY(ospbRysownica, osRysownica, osXmax / 2, osYmax / 2);
                ostxtNumerFigury.Text = osIndex.ToString();
                //wyznaczednie osIndex dla następnego wykreślenia
                //osIndex = (ushort)((osIndex + 1) % osIndexTFG);
                
            }
            ospbRysownica.Refresh();


        }

        private void osbtnWyłączenieSlajdera_Click(object sender, EventArgs e)
        {
            osTimer.Stop();
            osbtnPrzesunięcie_Click(sender, e);
            /*osRysownica.Clear(ospbRysownica.BackColor);
            for (ushort osi = 0; osi < osIndexTFG; osi++)
                osTFG[osi].osWykreśl(osRysownica);
            ospbRysownica.Refresh();*/
            ostxtNumerFigury.Text = "";
            ostxtNumerFigury.Enabled = true;
            osbtnWyłączenieSlajdera.Enabled = false;
            osbtnWłączenieSlajdera.Enabled = true;
            osgbPokazFigur.Enabled = true;
            osbtnZmianaGraficznychAtrybutów.Enabled = true; 
            osbtnPrzesunięcieIZmianaGraficzna.Enabled = true;
            osbtnPrzesunięcie.Enabled = true;
            osbtnNastępna.Enabled = false;
            osbtnPoprzednia.Enabled=false;

        }

        private void ostxtN_TextChanged(object sender, EventArgs e)
        {
            osbtnStart.Enabled = true;
            errorProvider1.Dispose();
        }

        private void osbtnNastępna_Click(object sender, EventArgs e)
        {

            //wyznaczednie osIndex dla następnego wykreślenia
            osIndex = (ushort)((osIndex + 1) % osIndexTFG);
            //wymazanie osRysownicy
            osRysownica.Clear(ospbRysownica.BackColor);
            //wyznaczenie rozmiarów rysownicy
            int osXmax = ospbRysownica.Width;
            int osYmax = ospbRysownica.Height;
            //wykreślenie pośrodku rysownicy figury geometrycznej
            osTFG[osIndex].osPrzesuńDoNowegoXY(ospbRysownica, osRysownica, osXmax / 2, osYmax / 2);
            ostxtNumerFigury.Text = osIndex.ToString();
            
            ospbRysownica.Refresh();
        }

        private void osbtnPoprzednia_Click(object sender, EventArgs e)
        {
            //wymazanie osRysownicy
            osRysownica.Clear(ospbRysownica.BackColor);
            //wyznaczednie osIndex dla następnego wykreślenia
            if (osIndex == 0)
                osIndex = (ushort)(osIndexTFG - 1);
            else
                osIndex--;
            //wyznaczenie rozmiarów rysownicy
            int osXmax = ospbRysownica.Width;
            int osYmax = ospbRysownica.Height;
            //wykreślenie pośrodku rysownicy figury geometrycznej
            osTFG[osIndex].osPrzesuńDoNowegoXY(ospbRysownica, osRysownica, osXmax / 2, osYmax / 2);
            ostxtNumerFigury.Text = osIndex.ToString();
            
            //osIndex = (ushort)((osIndex - 1) % osIndexTFG);
            ospbRysownica.Refresh();
        }

        private void osbtnResetuj_Click(object sender, EventArgs e)
        {
            osTFG = null;
            osRysownica.Clear(ospbRysownica.BackColor);
            ospbRysownica.Refresh();
            //oschlbFiguryGeometryczne.SelectedItem = null;
            //oschlbFiguryGeometryczne.
            foreach (int osi in oschlbFiguryGeometryczne.CheckedIndices)
                oschlbFiguryGeometryczne.SetItemCheckState(osi, CheckState.Unchecked);
            oschlbFiguryGeometryczne.Enabled = true;
            ostxtN.Text = "";
            ostxtN.Enabled = true;
            osbtnStart.Enabled = false;
            osbtnPrzesunięcie.Enabled = false;
            osbtnPrzesunięcieIZmianaGraficzna.Enabled = false;
            osbtnZmianaGraficznychAtrybutów.Enabled = false;
            osbtnWłączenieSlajdera.Enabled = false;
            osgbPokazFigur.Enabled = false;
            ostxtNumerFigury.Enabled = false;
           //
           //foreach(Control Kontrolka in osKreślenieFigur_Linii.ControlCollection.)
        }
    }
}
