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
    public partial class osKreslenieFigur_Linii : Form
    {//deklaracje pomocniczecowy;
        float osKątPoczątkowy, osKątKońcowy;
        ushort osNW;
        const ushort osMargines = 10;
        const ushort osMarginesFormularza = 20;
        //deklaracja powierzchni graficznej
        Graphics osRysownica;
        //utworzenie tymczasowej rysownicy
        Graphics osRysownicaTymczasowa;
        //deklaracja punktu po wciśnięciu myszy
        Point osPunkt;
        //deklaracja pióra
        Pen osPióro;
        //deklaracja pędzla
        SolidBrush osPędzel;
        //deklaracja pióra dlal kreślenia po powierzchni tymczasowej
        Pen osPióroTymczasowe;
        //lista ewidencji egzemplarzy kreślonych figur geometrycznych
        List<osPunkt> osLFG = new List<osPunkt>();
        
        short osIndexListy;
        short osIndexKrzBez = 0;

        Random osRand = new Random();
        public int osN = 0;

        public osKreslenieFigur_Linii()
        {
            InitializeComponent();
            //lokalizacja i zwymiarowanie formularza
            this.Location = new Point(Screen.PrimaryScreen.Bounds.X + osMarginesFormularza,
                Screen.PrimaryScreen.Bounds.Y + 2 * osMarginesFormularza);
            this.Width = (int)(Screen.PrimaryScreen.Bounds.Width * 0.85F);
            this.Height = (int)(Screen.PrimaryScreen.Bounds.Height * 0.85F);
            this.StartPosition = FormStartPosition.Manual;
            //można ustalić wartości innych atrybutów formularza
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            //lokalizacja i zwymiarowanie kontrolki pictureBox
            ospbRysownica.Location = new Point(Left + osMarginesFormularza, Top + osMarginesFormularza);
            ospbRysownica.Width = (int)(this.Width * 0.7F);
            ospbRysownica.Height = (int)(this.Height * 0.6F);
            ospbRysownica.BackColor = Color.Beige;
            ospbRysownica.BorderStyle = BorderStyle.FixedSingle;

            //utowrzenie mapy bitowej i podpięcie jej do kontrolki PictureBox
            ospbRysownica.Image = new Bitmap(ospbRysownica.Width, ospbRysownica.Height);
            //lokalizacja GroupBox1
            osgbFigury_Linie.Location = new Point(ospbRysownica.Left + ospbRysownica.Width + osMargines, ospbRysownica.Top);
            //lokalizacja GroupBox2
            osgbAtrybutyGraficzne.Location = new Point(osgbFigury_Linie.Left, osgbFigury_Linie.Top+ osgbFigury_Linie.Height + osMargines);
            //lokalizacja btnPowrót
            osbtnPowrótZKreśl.Location = new Point(osgbFigury_Linie.Left, osgbFigury_Linie.Top - osMargines - osbtnPowrótZKreśl.Height);
            osbtnCofnij.Location = new Point(osbtnPrzesuń.Left + osbtnPrzesuń.Width + osMargines, osbtnPrzesuń.Top);
            osbtnWykreśl.Location = new Point(osbtnCofnij.Left + osbtnCofnij.Width + osMargines, osbtnCofnij.Top);

            //utworzenie egzemplarza powierzchni graficznej na bitmapie
            osRysownica = Graphics.FromImage(ospbRysownica.Image);
            //utworzenie egzemplarza tymczasowej pow graf
            osRysownicaTymczasowa = ospbRysownica.CreateGraphics();

            //utowrzenie egzemplarza pióra głównego 
            osPunkt = Point.Empty;
            osPióro = new Pen(Color.Black, 3F);
            osPióro.DashStyle= DashStyle.Solid;
            osPióro.StartCap = LineCap.Round;
            osPióro.EndCap= LineCap.Round;
            //utworzenie niebieskiego pióra dla wizualizacji rozciągnięcia
            osPióroTymczasowe = new Pen(Color.Blue, 1);
            //utworzenie egzemplarza pędzla
            osPędzel = new SolidBrush(Color.Green);
            
         }

        private void ospbRysownica_MouseDown(object sender, MouseEventArgs e)
        {
            //wyświetlenie aktualnego położenia myszy
            oslblX.Text = e.Location.X.ToString();
            oslblY.Text = e.Location.Y.ToString();
            

            if(e.Button== MouseButtons.Left)
            {
                //zapamiętanie współrzędnych punktu
                osPunkt = e.Location;
                //obsługa kontrolki dla kreślenia linii myszą
                if (osrdbLiniaCiągła.Checked)
                {//kontrolka została zapalona
                    if (osLFG.Count == 0)
                        osZmianaAktywności(true);
                    //dodanie do LFG egzemplarza linii kreslonej myszą
                    osLFG.Add(new osLiniaKreślonaMyszą (osPunkt));
                    osLFG[osLFG.Count - 1].osUstalNoweAtrybutyGraficzne(osPióro);
                    
                }
            }
            

        }

        private void ospbRysownica_MouseUp(object sender, MouseEventArgs e)
        {
            //wyświetlenie aktualnego położenia myszy
            oslblX.Text = e.Location.X.ToString();
            oslblY.Text = e.Location.Y.ToString();
            //deklaracja zmiennych pomocniczych i wyznaczanie parametrów prostokątu,
            //w których będzie wyświetlana figura
            int osLewyGórnyNarożnikX = (osPunkt.X > e.Location.X) ? e.Location.X : e.Location.Y;
            int osLewyGórnyNarożnikY = (osPunkt.Y > e.Location.Y) ? e.Location.Y : e.Location.Y;
            int osSzerokość = Math.Abs(osPunkt.X - e.Location.X);
            int osWysokość = Math.Abs(osPunkt.Y - e.Location.Y);
            //rozpoznanie czy zdarzenie MouseUp dotyczy lewego przycisku myszy
            if (e.Button == MouseButtons.Left)
            {
                if(osLFG.Count == 0)
                {
                    /*osbtnPrzesuń.Enabled = true;
                    osbtnWłąćPokazFigur.Enabled = true;
                    osbtnCofnij.Enabled = true;
                    ostxtIndeks.Enabled = true;
                    osgbPokazFigur.Enabled = true;*/
                    osZmianaAktywności(true);
                }
                if (osrdbPunkt.Checked)
                {
                    osLFG.Add(new osPunkt(osPunkt.X, osPunkt.Y));
                    //ustalenie geom i graf atrybutów punktu
                    osLFG[osLFG.Count - 1].osUstalNoweAtrybutyGraficzne(osPióro);
                    //wykreslenie punktu
                    osLFG[osLFG.Count - 1].osWykreśl(osRysownica);
                }
                if (osrdbLinia.Checked)
                {
                    osLFG.Add(new osLinia(osPunkt.X, osPunkt.Y, e.Location.X, e.Location.Y));
                    osLFG[osLFG.Count - 1].osUstalNoweAtrybutyGraficzne(osPióro);
                    osLFG[osLFG.Count - 1].osWykreśl(osRysownica);
                }
                if (osrdbElipsa.Checked)
                {

                    osLFG.Add(new osElipsa(osLewyGórnyNarożnikX, osLewyGórnyNarożnikY, osSzerokość, osWysokość));
                    osLFG[osLFG.Count - 1].osUstalNoweAtrybutyGraficzne(osPióro);
                    osLFG[osLFG.Count - 1].osWykreśl(osRysownica);
                    //osLewyGórnyNarożnikX - osSzerokość/2, osLewyGórnyNarożnikY - osWysokość/2, osSzerokość, osWysokość
                }
                if (osrdbElipsaWypełniona.Checked)
                {
                    osLFG.Add(new osElipsaWypełniona(osLewyGórnyNarożnikX, osLewyGórnyNarożnikY, osSzerokość, osWysokość));
                    osLFG[osLFG.Count - 1].osUstalNoweAtrybutyGraficzneTło(osPędzel.Color);
                    osLFG[osLFG.Count - 1].osWykreśl(osRysownica);
                }
                if (osrdbOkrąg.Checked)
                {
                    osLFG.Add(new osOkrąg(osLewyGórnyNarożnikX, osLewyGórnyNarożnikY, osSzerokość));
                    osLFG[osLFG.Count - 1].osUstalNoweAtrybutyGraficzne(osPióro);
                    osLFG[osLFG.Count - 1].osWykreśl(osRysownica);
                }

                if (osrdbKoło.Checked)
                {
                    osLFG.Add(new osKoło(osLewyGórnyNarożnikX, osLewyGórnyNarożnikY, osSzerokość));
                    osLFG[osLFG.Count - 1].osUstalNoweAtrybutyGraficzneTło(osPędzel.Color);
                    osLFG[osLFG.Count - 1].osWykreśl(osRysownica);
                }
                if (osrdbLiniaCiągła.Checked)
                {
                    //dodanie do linii kreślonej myszą punktu ostatniego
                    ((osLiniaKreślonaMyszą)osLFG[osLFG.Count - 1]).osDodajNowyPunktKreślonejLinii(e.Location);
                    //osRysownica.DrawLine(osPióro, osPunkt, e.Location);
                    osLFG[osLFG.Count - 1].osWykreśl(osRysownica);
                }
                if (osrdbProstokąt.Checked)
                {
                    osLFG.Add(new osProstokąt(osLewyGórnyNarożnikX, osLewyGórnyNarożnikY, osSzerokość, osWysokość));
                    osLFG[osLFG.Count - 1].osUstalNoweAtrybutyGraficzne(osPióro);
                    osLFG[osLFG.Count - 1].osWykreśl(osRysownica);
                }
                if (osrdbProstokątWyp.Checked)
                {
                    osLFG.Add(new osProstokątWypełniony(osLewyGórnyNarożnikX, osLewyGórnyNarożnikY, osSzerokość, osWysokość));
                    osLFG[osLFG.Count - 1].osUstalNoweAtrybutyGraficzne(osPióro, osPędzel);
                    osLFG[osLFG.Count - 1].osWykreśl(osRysownica);
                }
                if (osrdbKwadrat.Checked)
                {
                    osLFG.Add(new osKwadrat(osLewyGórnyNarożnikX, osLewyGórnyNarożnikY, osSzerokość));
                    osLFG[osLFG.Count - 1].osUstalNoweAtrybutyGraficzne(osPióro);
                    osLFG[osLFG.Count - 1].osWykreśl(osRysownica);


                }
                if (osrdbKrzywaBeziera.Checked)
                {
                    if (osIndexKrzBez == 0)
                    {
                        osLFG.Add(new osKrzywaBeziera(e.Location.X, e.Location.Y));
                        osLFG[osLFG.Count - 1].osUstalNoweAtrybutyGraficzne(osPióro);
                        ((osKrzywaBeziera)osLFG[osLFG.Count - 1]).osDodajPunkt(0, e.Location, osRysownica);
                        osIndexKrzBez++;
                        osZmianaAktywności(false);
                    }
                    else if (osIndexKrzBez == 1 || osIndexKrzBez == 2)
                    {
                        ((osKrzywaBeziera)osLFG[osLFG.Count - 1]).osDodajPunkt(osIndexKrzBez, e.Location, osRysownica);
                        osIndexKrzBez++;
                    }

                    else
                    if (osIndexKrzBez == 3)
                    {
                        ((osKrzywaBeziera)osLFG[osLFG.Count - 1]).osDodajPunkt(osIndexKrzBez, e.Location, osRysownica);
                        osLFG[osLFG.Count - 1].osWykreśl(osRysownica);
                        osIndexKrzBez = 0;
                        osZmianaAktywności(true);
                    }


                }
                if (osrdbWielokąt.Checked)
                {
                    if (osIndexKrzBez == 0)
                    {
                        osLFG.Add(new osWielokąt(e.Location.X, e.Location.Y));
                        osLFG[osLFG.Count - 1].osUstalNoweAtrybutyGraficzne(osPióro);
                        ((osWielokąt)osLFG[osLFG.Count - 1]).osDodajPunkt(e.Location, osRysownica);
                        osIndexKrzBez++;
                        osZmianaAktywności(false);
                    }
                    else
                    {
                        if (osIndexKrzBez == 2)
                            osbtnWykreśl.Enabled = true;
                        ((osWielokąt)osLFG[osLFG.Count - 1]).osDodajPunkt(e.Location, osRysownica);
                        osIndexKrzBez++;
                    }
                }
                if (osrdbWielokątWypełniony.Checked)
                {
                    if (osIndexKrzBez == 0)
                    {
                        osLFG.Add(new osWielokątWypełniony(e.Location.X, e.Location.Y));
                        osLFG[osLFG.Count - 1].osUstalNoweAtrybutyGraficzne(osPióro, osPędzel);
                        ((osWielokątWypełniony)osLFG[osLFG.Count - 1]).osDodajPunkt(e.Location, osRysownica);
                        osIndexKrzBez++;
                        osZmianaAktywności(false);
                    }
                    else
                    {
                        if (osIndexKrzBez == 2)
                            osbtnWykreśl.Enabled = true;
                        ((osWielokątWypełniony)osLFG[osLFG.Count - 1]).osDodajPunkt(e.Location, osRysownica);
                        osIndexKrzBez++;
                    }
                }
                if (osrdbKrzywaKardynalna.Checked)
                {
                    if (osIndexKrzBez == 0)
                    {
                        osLFG.Add(new osKrzywaKardynalna(e.Location.X, e.Location.Y));
                        osLFG[osLFG.Count - 1].osUstalNoweAtrybutyGraficzne(osPióro);
                        ((osKrzywaKardynalna)osLFG[osLFG.Count - 1]).osDodajPunkt(e.Location, osRysownica);
                        osIndexKrzBez++;
                        osZmianaAktywności(false);
                    }
                    else
                    {
                        if (osIndexKrzBez == 1)
                            osbtnWykreśl.Enabled = true;
                        ((osKrzywaKardynalna)osLFG[osLFG.Count - 1]).osDodajPunkt(e.Location, osRysownica);
                        osIndexKrzBez++;
                    }


                }
                if (osrdbDrawClosedCurve.Checked)
                {
                    if (osIndexKrzBez == 0)
                    {
                        osLFG.Add(new osDrawClosedCurve(e.Location.X, e.Location.Y));
                        osLFG[osLFG.Count - 1].osUstalNoweAtrybutyGraficzne(osPióro);
                        ((osDrawClosedCurve)osLFG[osLFG.Count - 1]).osDodajPunkt(e.Location, osRysownica);
                        osIndexKrzBez++;
                        osZmianaAktywności(false);
                    }
                    else
                    {
                        if (osIndexKrzBez == 2)
                            osbtnWykreśl.Enabled = true;
                        ((osDrawClosedCurve)osLFG[osLFG.Count - 1]).osDodajPunkt(e.Location, osRysownica);
                        osIndexKrzBez++;
                    }


                }
                if (osrdbFillClosedCurve.Checked)
                {
                    if (osIndexKrzBez == 0)
                    {
                        osLFG.Add(new osFillClosedCurve(e.Location.X, e.Location.Y));
                        osLFG[osLFG.Count - 1].osUstalNoweAtrybutyGraficzne(osPióro, osPędzel);
                        ((osFillClosedCurve)osLFG[osLFG.Count - 1]).osDodajPunkt(e.Location, osRysownica);
                        osIndexKrzBez++;
                        osZmianaAktywności(false);
                    }
                    else
                    {
                        if (osIndexKrzBez == 2)
                            osbtnWykreśl.Enabled = true;
                        ((osFillClosedCurve)osLFG[osLFG.Count - 1]).osDodajPunkt(e.Location, osRysownica);
                        osIndexKrzBez++;
                    }


                }
                if (osrdbWielokątForemny.Checked)
                {
                    if (osIndexKrzBez == 0)
                    {
                        osLFG.Add(new osWielokątForemny(e.Location, osNW));
                        osLFG[osLFG.Count - 1].osUstalNoweAtrybutyGraficzne(osPióro);
                        ((osWielokątForemny)osLFG[osLFG.Count - 1]).osDodajPunktPC(e.Location, osRysownica);
                        osIndexKrzBez++;
                        osZmianaAktywności(false);
                    }
                    else
                    {
                        ((osWielokątForemny)osLFG[osLFG.Count - 1]).osDodajPunktP0(e.Location);
                        osLFG[osLFG.Count - 1].osWykreśl(osRysownica);
                        osIndexKrzBez = 0;
                        osZmianaAktywności(true);
                    }
                    /*osLFG.Add(new osWielokątForemny(e.Location.X, e.Location.Y, e.Location.X + 50, e.Location.Y, 7));
                    osLFG[osLFG.Count - 1].osUstalNoweAtrybutyGraficzne(osPióro);
                    osLFG[osLFG.Count - 1].osWykreśl(osRysownica);*/

                }
                if (osrdbWielokątForemnyWypełniony.Checked)
                {
                    if (osIndexKrzBez == 0)
                    {
                        osLFG.Add(new osWielokątForemnyWypełniony(e.Location, osNW));
                        osLFG[osLFG.Count - 1].osUstalNoweAtrybutyGraficzne(osPióro, osPędzel);
                        ((osWielokątForemnyWypełniony)osLFG[osLFG.Count - 1]).osDodajPunktPC(e.Location, osRysownica);
                        osIndexKrzBez++;
                        osZmianaAktywności(false);
                    }
                    else
                    {
                        ((osWielokątForemnyWypełniony)osLFG[osLFG.Count - 1]).osDodajPunktP0(e.Location);
                        osLFG[osLFG.Count - 1].osWykreśl(osRysownica);
                        osIndexKrzBez = 0;
                        osZmianaAktywności(true);
                    }
                }
                if (osrdbDrawArc.Checked)
                {
                    osLFG.Add(new osDrawArc(osLewyGórnyNarożnikX, osLewyGórnyNarożnikY, osSzerokość, osWysokość, osKątPoczątkowy, osKątKońcowy));
                    osLFG[osLFG.Count - 1].osUstalNoweAtrybutyGraficzne(osPióro);
                    osLFG[osLFG.Count - 1].osWykreśl(osRysownica);
                    /*if (osIndexKrzBez == 0)
                    {
                        osLFG.Add(new osDrawArc(e.Location));
                        osLFG[osLFG.Count - 1].osUstalNoweAtrybutyGraficzne(osPióro);
                        ((osDrawArc)osLFG[osLFG.Count - 1]).osDodajPunkt(e.Location, 0, osRysownica);
                        osIndexKrzBez++;
                    }else
                    if (osIndexKrzBez == 1)
                    {
                        ((osDrawArc)osLFG[osLFG.Count - 1]).osDodajPunkt(e.Location, 1, osRysownica);
                        ((osDrawArc)osLFG[osLFG.Count - 1]).osDodajPunktIWypisz(e.Location, 1, osRysownica, ostxtIndeks);
                        osIndexKrzBez++;
                    }
                    else
                    {
                        ((osDrawArc)osLFG[osLFG.Count - 1]).osDodajPunkt(e.Location, 2, osRysownica);
                        osLFG[osLFG.Count - 1].osWykreśl(osRysownica);
                        osIndexKrzBez = 0;
                    }*/
                }
                if (osrdbDrawPie.Checked)
                {
                    osLFG.Add(new osDrawPie(osLewyGórnyNarożnikX, osLewyGórnyNarożnikY, osSzerokość, osWysokość, osKątPoczątkowy, osKątKońcowy));
                    osLFG[osLFG.Count - 1].osUstalNoweAtrybutyGraficzne(osPióro);
                    osLFG[osLFG.Count - 1].osWykreśl(osRysownica);

                }
                if (osrdbFillPie.Checked)
                {
                    osLFG.Add(new osFillPie(osLewyGórnyNarożnikX, osLewyGórnyNarożnikY, osSzerokość, osWysokość, osKątPoczątkowy, osKątKońcowy));
                    osLFG[osLFG.Count - 1].osUstalNoweAtrybutyGraficzne(osPióro, osPędzel);
                    osLFG[osLFG.Count - 1].osWykreśl(osRysownica);

                }
            }

            ospbRysownica.Refresh();

        }
        public void osZmianaAktywności(bool osZnaczenie)
        {
            osgbFigury_Linie.Enabled = osZnaczenie;
            osbtnPrzesuń.Enabled = osZnaczenie;
            osbtnWłąćPokazFigur.Enabled = osZnaczenie;
            osbtnCofnij.Enabled = osZnaczenie;
            osgbAtrybutyGraficzne.Enabled = osZnaczenie;
            osgbPokazFigur.Enabled= osZnaczenie;
            ostxtIndeks.Enabled = osZnaczenie;
        }

        private void osbtnPowrótZKreśl_Click(object sender, EventArgs e)
        {
            //odszukanie formularza głównego w kolekcji OpenForms
            foreach (Form osFormX in Application.OpenForms)
                //sprawdzenie czy "znaleziony" formularz jest form1
                if (osFormX.Name == "osPrezenter_Shulga")
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

        private void ospbRysownica_MouseMove(object sender, MouseEventArgs e)
        {
            //wyświetlenie aktualnego położenia myszy
            oslblX.Text = e.Location.X.ToString();
            oslblY.Text = e.Location.Y.ToString();
            if(e.Button == MouseButtons.Left)
            {
                //wyświetlenie aktualnego położenia myszy
                oslblX.Text = e.Location.X.ToString();
                oslblY.Text = e.Location.Y.ToString();
                //deklaracja zmiennych pomocniczych i wyznaczanie parametrów prostokątu,
                //w których będzie wyświetlana figura
                int osLewyGórnyNarożnikX = (osPunkt.X > e.Location.X) ? e.Location.X : e.Location.Y;
                int osLewyGórnyNarożnikY = (osPunkt.Y > e.Location.Y) ? e.Location.Y : e.Location.Y;
                int osSzerokość = Math.Abs(osPunkt.X - e.Location.X);
                int osWysokość = Math.Abs(osPunkt.Y - e.Location.Y);
                if (osrdbPunkt.Checked)
                    ;//punktu nie rozciągamy
                if (osrdbLinia.Checked)
                    //kreślenie linii na powierzchni tymczasowej
                    osRysownicaTymczasowa.DrawLine(osPióroTymczasowe, osPunkt.X, osPunkt.Y, e.Location.X, e.Location.Y);
                if (osrdbElipsa.Checked)
                    osRysownicaTymczasowa.DrawEllipse(osPióroTymczasowe, new Rectangle(osLewyGórnyNarożnikX, osLewyGórnyNarożnikY, osSzerokość, osWysokość));
                if (osrdbElipsaWypełniona.Checked)
                    osRysownicaTymczasowa.DrawEllipse(osPióroTymczasowe, new Rectangle(osLewyGórnyNarożnikX, osLewyGórnyNarożnikY, osSzerokość, osWysokość));
                if (osrdbOkrąg.Checked)
                    osRysownicaTymczasowa.DrawEllipse(osPióroTymczasowe, new Rectangle(osLewyGórnyNarożnikX, osLewyGórnyNarożnikY, osSzerokość, osSzerokość));
                if (osrdbKoło.Checked)
                    osRysownicaTymczasowa.DrawEllipse(osPióroTymczasowe, new Rectangle(osLewyGórnyNarożnikX, osLewyGórnyNarożnikY, osSzerokość, osSzerokość));

                if (osrdbLiniaCiągła.Checked)
                {
                    ((osLiniaKreślonaMyszą)osLFG[osLFG.Count-1]).osDodajNowyPunktKreślonejLiniiZaWspółrzędnymi(e.Location.X, e.Location.Y);
                     osLFG[osLFG.Count - 1].osWykreśl(osRysownica);
                }
                if (osrdbProstokąt.Checked)
                    osRysownicaTymczasowa.DrawRectangle(osPióroTymczasowe, new Rectangle(osLewyGórnyNarożnikX, osLewyGórnyNarożnikY, osSzerokość, osWysokość));
                if (osrdbProstokątWyp.Checked)
                    osRysownicaTymczasowa.DrawRectangle(osPióroTymczasowe, new Rectangle(osLewyGórnyNarożnikX, osLewyGórnyNarożnikY, osSzerokość, osWysokość));
                if (osrdbKwadrat.Checked)
                    osRysownicaTymczasowa.DrawRectangle(osPióroTymczasowe, new Rectangle(osLewyGórnyNarożnikX, osLewyGórnyNarożnikY, osSzerokość, osSzerokość));
                if (osrdbDrawArc.Checked || osrdbDrawPie.Checked || osrdbFillPie.Checked)
                    osRysownicaTymczasowa.DrawEllipse(osPióroTymczasowe, new Rectangle(osLewyGórnyNarożnikX, osLewyGórnyNarożnikY, osSzerokość, osWysokość));
                //if (osrdbDrawPie.Checked)
                    //osRysownicaTymczasowa.DrawEllipse(osPióroTymczasowe, new Rectangle(osLewyGórnyNarożnikX, osLewyGórnyNarożnikY, osSzerokość, osWysokość));


                ospbRysownica.Refresh();
            }
        }

        private void osKreślenieFigur_Linii_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult osWynik = MessageBox.Show("Czy rzeczywiście chcesz zakończyć działanie programu?",
                this.Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);
            //sprawdzenie odpowiedzi użytkownika programu
            if (osWynik != DialogResult.Yes)
                //skasowanie zdarzenia
                e.Cancel = true;
            else
                //zdarzenie cancel nie może być skasowane
                e.Cancel = false;
        }

        private void osKreślenieFigur_Linii_FormClosed(object sender, FormClosedEventArgs e)
        {
            //zamknięcie programu
            Application.Exit();
        }

        private void osbtnKolorlinii_Click(object sender, EventArgs e)
        {
            ColorDialog osKolorDialog = new ColorDialog();
            osKolorDialog.ShowDialog();
            if(osKolorDialog.ShowDialog() == DialogResult.OK)
            {
                ostxtKolorLinii.BackColor = osKolorDialog.Color;
                osPióro.Color = osKolorDialog.Color;
                //osKolorDialog.Dispose();
            }
            osKolorDialog.Dispose();
        }

        private void osKreślenieFigur_Linii_Load(object sender, EventArgs e)
        {

        }

        private void osbtnPrzesuń_Click(object sender, EventArgs e)
        {
            //wyczyszczenie kontrolki Rysownica
            osRysownica.Clear(ospbRysownica.BackColor);
            //wyznaczenie rozmiarów Rysownicy
            int osXmax = ospbRysownica.Width;
            int osYmax = ospbRysownica.Height;
            //deklaracja zmiennych na przechowanie losowanych współrzędnych
            int osX, osY;
            //deklaracja i utworzenie egzemplarza liczb losowych
            Random osRnd = new Random();
            
            //dla każdego elementa (referencja do egzamplarza figury geometrycznej)
            for (int osi=0; osi<osLFG.Count; osi++)
            {
                osX = osRnd.Next(osMargines, osXmax - osMargines);
                osY = osRnd.Next(osMargines, osYmax - osMargines);
                if (osLFG[osi].GetType().Name == "osLiniaKreślonaMyszą" || osLFG[osi].GetType().Name == "osKrzywaBeziera")
                {
                    osLFG[osi].osUaktualnijXY(osX, osY);
                    osLFG[osi].osWykreśl(osRysownica);
                }
                else    
                osLFG[osi].osPrzesuńDoNowegoXY(ospbRysownica, osRysownica, osX, osY);
            }
            //osRysownica.DrawArc(osPióro, 100, 100, 50, 50, 0, 90);
            //osRysownica.DrawPie(osPióro, 100, 100, 50, 50, 0, 90);
            ospbRysownica.Refresh();

        }

        private void osbtnCofnij_Click(object sender, EventArgs e)
        {
            //sprawdzenie czy w liście są umieszczone figury
            /*if(osLFG.Count <= 0)
            {
                errorProvider1.SetError(osbtnCofnij, "ERROR : lista figur " +
                    "geometrycznych jest pusta  i operacja COFNIJ nie może być zrealizowana");
                return;
            }*/
            //osLFG[osLFG.Count - 1].osWymaż(ospbRysownica, osRysownica);
            //usunięcie ostatniego elementu liczby osLFG
            osLFG.RemoveAt(osLFG.Count - 1);
            osRysownica.Clear(ospbRysownica.BackColor);
            for (ushort osi = 0; osi < osLFG.Count; osi++)
                osLFG[osi].osWykreśl(osRysownica);
            ospbRysownica.Refresh();
            if(osLFG.Count == 0)
            {
                osbtnCofnij.Enabled = false;
                osbtnPrzesuń.Enabled = false;
                osbtnWłąćPokazFigur.Enabled = false;
            }
            /* //usunięcie ostatniego elementu liczby osLFG
            osLFG.RemoveAt(osLFG.Count - 1);
            //ponowne odrysowanie figur na Rysownice
            osRysownica.Clear(ospbRysownica.BackColor);
            //dla każdego elementa (referencja do egzamplarza figury geometrycznej)
            for (int osi = 0; osi < osLFG.Count; osi++)
            {
                
                osLFG[osi].osWykreśl(osRysownica);
            }
            ospbRysownica.Refresh();*/
        }

        private void osbtnKolorWypełnienia_Click(object sender, EventArgs e)
        {
            ColorDialog osKolorDialog = new ColorDialog();
            osKolorDialog.ShowDialog();
            if (osKolorDialog.ShowDialog() == DialogResult.OK)
            {
                ostxtKolorWypełnienia.BackColor = osKolorDialog.Color;
                osPędzel.Color = osKolorDialog.Color;
            }
            //osKolorDialog.Dispose();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ostbGrubośćLinii_Scroll(object sender, EventArgs e)
        {
            //zmiana grubości pióra
            osPióro.Width = ostbGrubośćLinii.Value;
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:  osPióro.DashStyle = DashStyle.Solid;
                    break;
                case 1: osPióro.DashStyle = DashStyle.Dot;
                    break;
                case 2: osPióro.DashStyle = DashStyle.Dash;
                    break;
                case 3: osPióro.DashStyle = DashStyle.DashDot;
                    break;
                case 4: osPióro.DashStyle = DashStyle.DashDotDot;
                    break;
                default: osPióro.DashStyle = DashStyle.Solid;
                    break;

            }
            
        }

        private void osbtnWłąćPokazFigur_Click(object sender, EventArgs e)
        {
            if (ostxtIndeks.Text == "")
            {
                osIndexListy = 0;
                
            }
            else
                if (!short.TryParse(ostxtIndeks.Text, out osIndexListy))
            {
                errorProvider1.SetError(ostxtIndeks, "ERROR : w zapisie indeksa figury wystąpił niedozwolony znak");
                return;
            }
            else
                if (osIndexListy < 0 || osIndexListy >= osLFG.Count)
            {
                errorProvider1.SetError(ostxtIndeks, "ERROR : indeks figury powinien być w zakresie [0, " + (osLFG.Count - 1).ToString() + "]!");
                return;
            }
            ostxtIndeks.Enabled = false;
            errorProvider1.Dispose();
            osRysownica.Clear(Color.Beige);
            osLFG[0].osWykreśl(osRysownica);
            ospbRysownica.Refresh();
            osgbFigury_Linie.Enabled = false;
            osgbAtrybutyGraficzne.Enabled = false;
            osbtnCofnij.Enabled = false;
            osbtnPrzesuń.Enabled = false;
            
            ostxtIndeks.Text = osIndexListy.ToString();
            osbtnWłąćPokazFigur.Enabled = false;
            osgbPokazFigur.Enabled = false;
            osbtnWyłącz.Enabled = true;
            if (osrdbAutomatyczny.Checked)
            {
                osTimer1.Start();
            }
            else
            {
                osbtnNastępna.Enabled = true;
                osbtnPoprzednia.Enabled = true;
            }
            
                
            

        }

        private void osbtnNastępna_Click(object sender, EventArgs e)
        {
            osZwiększenieIndeksa(ref osIndexListy, osLFG.Count);
            osPokazFigury(osIndexListy);
        }

        private void osbtnPoprzednia_Click(object sender, EventArgs e)
        {
            if (osIndexListy > 0)
                osIndexListy--;
            else
                osIndexListy = (short)(osLFG.Count - 1);
            osPokazFigury(osIndexListy);
        }

        private void osbtnWyłącz_Click(object sender, EventArgs e)
        {
            osTimer1.Stop();
            ostxtIndeks.Clear();
            osRysownica.Clear(Color.Beige);
            for (int osi = 0; osi < osLFG.Count; osi++)
                osLFG[osi].osWykreśl(osRysownica);
            ospbRysownica.Refresh();
            osbtnWłąćPokazFigur.Enabled = true;
            osgbPokazFigur.Enabled = true;
            osbtnPoprzednia.Enabled = false;
            osbtnNastępna.Enabled = false;
            osbtnWyłącz.Enabled = false;
            ostxtIndeks.Enabled = true;
            osgbAtrybutyGraficzne.Enabled = true;
            osgbFigury_Linie.Enabled = true;
            osbtnPrzesuń.Enabled = true;
            osbtnCofnij.Enabled = true;
        }

        private void osTimer1_Tick(object sender, EventArgs e)
        {
            osbtnNastępna_Click(sender, e);
        }

        public void osZwiększenieIndeksa(ref short osIndeks, int osListaCount)
        {
            if (osIndeks < osListaCount - 1)
                osIndeks++;
            else
                osIndeks = 0;
            
        }
        public void osPokazFigury(short osIndeks)
        {
            osRysownica.Clear(Color.Beige);
            osLFG[osIndeks].osWykreśl(osRysownica);
            ospbRysownica.Refresh();
            ostxtIndeks.Text = osIndeks.ToString();
            
            
        }

        private void osbtnWykreśl_Click(object sender, EventArgs e)
        {
            osbtnWykreśl.Enabled = false;
            osIndexKrzBez = 0;
            osLFG[osLFG.Count - 1].osWykreśl(osRysownica);
            ospbRysownica.Refresh();
            osZmianaAktywności(true);
        }

        
        private void osrdbKrzywaKardynalna_CheckedChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("Wykreślenie Krzywej Kardynalnej wymaga zaznaczenia kilku (minimum 2) punktów na Rysownicy i naciśnięcia przycisku 'Wykreśl'", "Krzywa Kardynalna", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void osrdbKrzywaKardynalna_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Wykreślenie Krzywej Kardynalnej wymaga zaznaczenia kilku (minimum 2) punktów na Rysownicy i naciśnięcia przycisku 'Wykreśl'", "Krzywa Kardynalna", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void osrdbDrawClosedCurve_CheckedChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("Wykreślenie figury DrawClosedCurve wymaga zaznaczenia kilku(minimum 3) punktów na Rysownicy i naciśnięcia przycisku 'Wykreśl'", "DrawClosedCurve", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void osrdbDrawClosedCurve_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Wykreślenie figury DrawClosedCurve wymaga zaznaczenia kilku(minimum 3) punktów na Rysownicy i naciśnięcia przycisku 'Wykreśl'", "DrawClosedCurve", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void osrdbFillClosedCurve_CheckedChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("Wykreślenie figury FillClosedCurve wymaga zaznaczenia kilku(minimum 3) punktów na Rysownicy i naciśnięcia przycisku 'Wykreśl'", "FillClosedCurve", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void osrdbFillClosedCurve_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Wykreślenie figury FillClosedCurve wymaga zaznaczenia kilku(minimum 3) punktów na Rysownicy i naciśnięcia przycisku 'Wykreśl'", "FillClosedCurve", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void osrdbWielokątForemny_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void osrdbKrzywaBeziera_CheckedChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("Wykreślenie Krzywej Beziera wymaga zaznaczenia (kliknięciem) 4 punktów na Rysownicy", "Krzywa Beziera", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        private void osrdbKrzywaBeziera_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Wykreślenie Krzywej Beziera wymaga zaznaczenia (kliknięciem) 4 punktów na Rysownicy", "Krzywa Beziera", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void osrdbWielokątForemny_Click(object sender, EventArgs e)
        {
            osWielokatForemnyFormularz osOkno = new osWielokatForemnyFormularz();
            osOkno.ShowDialog();
            if(osOkno.ShowDialog() == DialogResult.OK)
            {
                osNW = osOkno.osRezultat();
                osOkno.Close();
            }
            /*osOkno.Show();
            if (osOkno.osOK)
                osNW = osOkno.osRezultat();
            osOkno.Close();*/
            
        }

        private void osrdbWielokątForemnyWypełniony_Click(object sender, EventArgs e)
        {
            osWielokatForemnyFormularz osOkno = new osWielokatForemnyFormularz();
            osOkno.ShowDialog();
            if (osOkno.ShowDialog() == DialogResult.OK)
            {
                osNW = osOkno.osRezultat();
                osOkno.Close();
            }
        }

        private void osrdbDrawPie_Click(object sender, EventArgs e)
        {
            osDrawArcFormularz osOkno = new osDrawArcFormularz("DrawPie");
            osOkno.ShowDialog();
            if (osOkno.ShowDialog() == DialogResult.OK)
            {
                osKątPoczątkowy = osOkno.osRezultatP();
                osKątKońcowy = osOkno.osRezultatK();
                osOkno.Close();
            }
        }

        private void osrdbFillPie_Click(object sender, EventArgs e)
        {
            osDrawArcFormularz osOkno = new osDrawArcFormularz("FillPie");
            osOkno.ShowDialog();
            if (osOkno.ShowDialog() == DialogResult.OK)
            {
                osKątPoczątkowy = osOkno.osRezultatP();
                osKątKońcowy = osOkno.osRezultatK();
                osOkno.Close();
            }
        }

        private void osrdbWielokąt_CheckedChanged(object sender, EventArgs e)
        {
            if(osrdbWielokąt.Checked)
            MessageBox.Show("Wykreślenie wielokąta dowolnego wymaga zaznaczenia kilku(minimum 3) punktów na Rysownicy", "Wielokąt dowolny", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void osrdbWielokątWypełniony_CheckedChanged(object sender, EventArgs e)
        {
            if(osrdbWielokątWypełniony.Checked)
            MessageBox.Show("Wykreślenie wielokąta dowolnego wypełnionego wymaga zaznaczenia kilku(minimum 3) punktów na Rysownicy", "Wielokąt dowolny wypełniony", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void osrdbDrawArc_Click(object sender, EventArgs e)
        {
            osDrawArcFormularz osOkno = new osDrawArcFormularz("DrawArc");
            osOkno.ShowDialog();
            if (osOkno.ShowDialog() == DialogResult.OK)
            {
                //osOkno.osKąty(out osKątPoczątkowy, out osKątKońcowy);
                //ososOkno.osRezultatK();
                osKątPoczątkowy = osOkno.osRezultatP();
                osKątKońcowy = osOkno.osRezultatK();
                //ostxtIndeks.Text = "KP"+osKątPoczątkowy.ToString();
                //ostxtKolorLinii.Text = "KK" + osKątKońcowy.ToString();
                osOkno.Close();
            }
        }
    }
}
