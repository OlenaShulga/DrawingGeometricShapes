using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Projekt2_Shulga58686
{
    class osFiguryGeometryczne
    {
        public class osPunkt
        {
            //deklaracje
            const int osDomyślnyRozmiarPunktu = 10;
            protected int osX, osY;
            protected Color osKolor;
            //deklaracja atrybutów współnych dla klas pochodnych
            protected DashStyle osStylLinii;
            protected int osGrubośćLinii;
            protected bool osWidoczny;
            protected Color osKolorTła;
            protected bool osWidocznePunkty;
            protected Font osFont = new Font("Times New Roman", 13, FontStyle.Regular);

            //deklaracja konstruktora
            public osPunkt(int osx, int osy)
            {
                osX = osx; osY = osy;
                //domyśln eokreślenie koloru
                osKolor = Color.Black;
                //domyślne utawienie wartości atrybutów dla klas pochodnych 
                osStylLinii = DashStyle.Solid;
                osGrubośćLinii = 1;

            }
            //osPunkt P = new osPunkt(100, 200);

            //drugi konstruktor
            public osPunkt(int osx, int osy, Color osKolor) : this(osx, osy)
            {
                this.osKolor = osKolor;
            }

            //deklaracja zmiennych prywatnych
            public virtual void osUaktualnijXY(int osX, int osY)
            {
                this.osX = osX; this.osY = osY;
            }
            //przeciążenie metody
            public void osUaktualnijXY(Point osNowalokalizacja)
            {
                osX = osNowalokalizacja.X;
                osY = osNowalokalizacja.Y;
            }

            public virtual void osPrzesuńDoNowegoXY(PictureBox ospbRysownica, Graphics osRysownica, int osX, int osY)
            {
                this.osX = osX;
                this.osY = osY;
                this.osWykreśl(osRysownica);
            }
            //deklaracja metod publicznych
            public void osUstalNoweAtrybutyGraficzne(Color osKolor, DashStyle osStyllinii, int osGrubośćLinii)
            {
                this.osKolor = osKolor;
                this.osStylLinii = osStyllinii;
                this.osGrubośćLinii = osGrubośćLinii;
            }
            public void osUstalNoweAtrybutyGraficzne(Color osKolor, Color osKolorTła, DashStyle osStyllinii, int osGrubośćLinii)
            {
                this.osKolor = osKolor;
                this.osKolorTła = osKolorTła;
                this.osStylLinii = osStyllinii;
                this.osGrubośćLinii = osGrubośćLinii;
            }

            public void osUstalNoweAtrybutyGraficzne(Pen osPióro)
            {
                this.osKolor = osPióro.Color;
                this.osStylLinii = osPióro.DashStyle;
                this.osGrubośćLinii = (int)osPióro.Width;
            }
            public void osUstalNoweAtrybutyGraficzne(Pen osPióro, SolidBrush osPędzel)
            {
                this.osKolor = osPióro.Color;
                this.osStylLinii = osPióro.DashStyle;
                this.osGrubośćLinii = (int)osPióro.Width;
                this.osKolorTła = osPędzel.Color;
            }

            public void osUstalNoweAtrybutyGraficzneTło(Color osKolorTła)
            {
                this.osKolorTła = osKolorTła;
            }

            //deklaracje metod wirtualnych, które moga być nadpisywane w klasach pochodnych
            public virtual void osWykreśl(Graphics osRysownica)
            {
                //deklaracje pędzla
                SolidBrush osPędzel = new SolidBrush(osKolor);
                osRysownica.FillEllipse(osPędzel, osX - osGrubośćLinii, osY - osGrubośćLinii, 2 * osGrubośćLinii, 2 * osGrubośćLinii);
                osWidoczny = true;
                //zwolonienie pędzla
                osPędzel.Dispose();

            }

            public virtual void osWymaż(Control osKontrolka, Graphics osRysownica)
            {
                if (osWidoczny)
                { //deklaracja pędzla
                    SolidBrush osPędzel = new SolidBrush(osKontrolka.BackColor);
                    //wymazanie punktu
                    osRysownica.FillEllipse(osPędzel, osX - osDomyślnyRozmiarPunktu / 2, osY - osDomyślnyRozmiarPunktu / 2,
                        osDomyślnyRozmiarPunktu, osDomyślnyRozmiarPunktu);
                }
            }


            //...

        }//od klasy Punkt
        //osLinia LiniaPozioma = new osLinia(20, 50, 200, 300);
        public class osLinia : osPunkt
        {
            int osXk, osYk;
            //deklaracja konstruktora
            public osLinia(int osXp, int osYp, int osXk, int osYk) : base(osXp, osYp)
            {
                //przechowani ewspółrzędnych końca linii
                this.osXk = osXk;
                this.osYk = osYk;
                //int aa = osX;
            }

            public osLinia(int osXp, int osYp, int osXk, int osYk, Color osKolor,
                int osGrubośćLinii, DashStyle osStylLinii) : base(osXp, osYp, osKolor)
            {
                //przechowanie pozostałych atrybutów
                base.osGrubośćLinii = osGrubośćLinii;
                base.osStylLinii = osStylLinii;

            }

            //deklaracje metod klasy Linia
            //nadpisanie metod wirtualnych
            public override void osWykreśl(Graphics osRysownica)
            {
                //wykreślenie pojedynczej linii
                Pen osPióro = new Pen(osKolor, osGrubośćLinii);
                //ustalenie stylu linii dla pióra
                osPióro.DashStyle = osStylLinii;
                //wykresleni elinii
                osRysownica.DrawLine(osPióro, osX, osY, osXk, osYk);
                osWidoczny = true;
                //zwolnienie pióra
                osPióro.Dispose();
            }
            public override void osWymaż(Control osKontrolka, Graphics osRysownica)
            {
                if (osWidoczny)
                {//wykreślenie pojedynczej linii
                    Pen osPióro = new Pen(osKontrolka.BackColor, osGrubośćLinii);
                    //ustalenie stylu linii dla pióra
                    osPióro.DashStyle = osStylLinii;
                    //wykresleni elinii
                    osRysownica.DrawLine(osPióro, osX, osY, osXk, osYk);
                    osWidoczny = false;
                    //zwolnienie pióra
                    osPióro.Dispose();
                }
            }


        }//od klasy Linia
        //deklaracja klasy Elipsa
        public class osElipsa : osPunkt
        {
            protected int osOśDuża, osOśMała;
            //deklaracja konstruktora
            public osElipsa(int osX, int osY, int osOśDuża, int osOśMała) : base(osX, osY)
            {
                this.osOśDuża = osOśDuża;
                this.osOśMała = osOśMała;
            }
            //deklaracja pozostałych konstruktorów

            //nadpisanie metod wirtualnych z klasy Punkt
            public override void osWykreśl(Graphics osRysownica)
            {
                //wykreślenie pojedynczej linii
                Pen osPióro = new Pen(osKolor, osGrubośćLinii);
                //ustalenie stylu linii dla pióra
                osPióro.DashStyle = osStylLinii;
                //wykresleni elinii
                osRysownica.DrawEllipse(osPióro, osX, osY, osOśDuża, osOśMała);
                osWidoczny = true;
                //zwolnienie pióra
                osPióro.Dispose();
            }

            public override void osWymaż(Control osKontrolka, Graphics osRysownica)
            {
                if (osWidoczny)
                {//wykreślenie pojedynczej linii
                    Pen osPióro = new Pen(osKontrolka.BackColor, osGrubośćLinii);
                    //ustalenie stylu linii dla pióra
                    osPióro.DashStyle = osStylLinii;
                    //wykresleni elinii
                    osRysownica.DrawLine(osPióro, osX, osY, osOśDuża, osOśMała);
                    osWidoczny = false;
                    //zwolnienie pióra
                    osPióro.Dispose();
                }
            }
        }
        public class osElipsaWypełniona : osElipsa
        {

            //deklaracja konstruktora
            public osElipsaWypełniona(int osX, int osY, int osOśDuża, int osOśMała) : base(osX, osY, osOśDuża, osOśMała)
            {

            }
            //nadpisanie metod wirtualnych z klasy Punkt
            public override void osWykreśl(Graphics osRysownica)
            {
                //wykreślenie pojedynczej linii
                SolidBrush osPędzel = new SolidBrush(osKolorTła);
                //wykreslenie elipsy
                osRysownica.FillEllipse(osPędzel, osX, osY, osOśDuża, osOśMała);
                osWidoczny = true;
                //zwolnienie pióra
                osPędzel.Dispose();
            }

            public override void osWymaż(Control osKontrolka, Graphics osRysownica)
            {
                if (osWidoczny)
                {//wykreślenie pojedynczej linii
                    SolidBrush osPędzel = new SolidBrush(osKontrolka.BackColor);
                    //wykreslenie elipsy
                    osRysownica.FillEllipse(osPędzel, osX, osY, osOśDuża, osOśMała);
                    osWidoczny = true;
                    //zwolnienie pióra
                    osPędzel.Dispose();
                }
            }
        }
        //deklaracja klasy Okrąg
        public class osOkrąg : osElipsa
        {
            protected int osPromień;
            //deklaracja konstruktora
            public osOkrąg(int osX, int osY, int osPromień) : base(osX, osY, 2 * osPromień, 2 * osPromień)
            {
                this.osPromień = osPromień;
            }
            //pozostałe konstruktory
            //...
            //napisanie metod
            public override void osWykreśl(Graphics osRysownica)
            {
                //wykreślenie pojedynczej linii
                Pen osPióro = new Pen(osKolor, osGrubośćLinii);
                //ustalenie stylu linii dla pióra
                osPióro.DashStyle = osStylLinii;
                //wykresleni elinii
                osRysownica.DrawEllipse(osPióro, osX, osY, osPromień, osPromień);
                osWidoczny = true;
                //zwolnienie pióra
                osPióro.Dispose();
            }

            public override void osWymaż(Control osKontrolka, Graphics osRysownica)
            {
                if (osWidoczny)
                {//wykreślenie pojedynczej linii
                    Pen osPióro = new Pen(osKontrolka.BackColor, osGrubośćLinii);
                    //ustalenie stylu linii dla pióra
                    osPióro.DashStyle = osStylLinii;
                    //wykreslenie linii
                    osRysownica.DrawLine(osPióro, osX, osY, osPromień, osPromień);
                    osWidoczny = false;
                    //zwolnienie pióra
                    osPióro.Dispose();
                }
            }
        }//od klasy Okrąg

        public class osKoło : osOkrąg
        {
            public osKoło(int osX, int osY, int osPromień) : base(osX, osY, osPromień)
            {
                //this.osKolorTła = osKolorTła; 
            }

            public override void osWykreśl(Graphics osRysownica)
            {
                //wykreślenie pojedynczej linii
                SolidBrush osPędzel = new SolidBrush(osKolorTła);
                //ustalenie stylu linii dla pióra

                //wykreślenie koła
                osRysownica.FillEllipse(osPędzel, osX, osY, osPromień, osPromień);
                osWidoczny = true;
                //zwolnienie pióra
                osPędzel.Dispose();
            }

            public override void osWymaż(Control osKontrolka, Graphics osRysownica)
            {
                if (osWidoczny)
                {//wykreślenie pojedynczej linii
                    SolidBrush osPędzel = new SolidBrush(osKontrolka.BackColor);
                    //ustalenie stylu linii dla pióra

                    //wykreslenie linii
                    osRysownica.FillEllipse(osPędzel, osX, osY, osPromień, osPromień);
                    osWidoczny = false;
                    //zwolnienie pióra
                    osPędzel.Dispose();
                }
            }
        }



        //pozostałe deklaracje klas dla klas regularnych: prostokąt
        //...
        //deklaracja clasy dla linii kreślonej myszą
        public class osLiniaKreślonaMyszą : osPunkt
        {
            //deklaracja listy punktów linii ciągłej
            List<Point> oslistaPunktów = new List<Point>();
            //deklaracja konstruktorów klasy LiniaKres
            public osLiniaKreślonaMyszą(Point osPoczątekLinii) : base(osPoczątekLinii.X, osPoczątekLinii.Y)
            {
                //dodaniedo listy punktów współrzędnych początku linii
                oslistaPunktów.Add(osPoczątekLinii);
            }
            //deklaracje metod

            public void osDodajNowyPunktKreślonejLinii(Point osNowyPunkt)
            {
                oslistaPunktów.Add(osNowyPunkt);
            }

            public void osDodajNowyPunktKreślonejLiniiZaWspółrzędnymi(int osX, int osY)
            {
                Point osNew = new Point(osX, osY);
                oslistaPunktów.Add(osNew);
            }



            //deklaracja metod nadpisujących metody wirtualne klasy osPunkt
            public override void osUaktualnijXY(int osX, int osY)
            {
                if (oslistaPunktów.Count < 1)
                    //lista jest pusta
                    return;
                //realizacja operacji utsaw xy wymaga zmiany położenia wszystkich punktów wykreślonej linii
                //deklaracja zmiennych pomocniczych
                int osPrzyrostX = oslistaPunktów[0].X - osX;
                int osPrzyrostY = oslistaPunktów[0].Y - osY;
                //zmiana położenia wszystkich punktów linii kreślonej myszą
                for (int osi = 0; osi < oslistaPunktów.Count; osi++)
                    oslistaPunktów[osi] = new Point(oslistaPunktów[osi].X - osPrzyrostX,
                        oslistaPunktów[osi].Y - osPrzyrostY);


            }
            public virtual void osPrzesuńDoNowegoXY(PictureBox ospbRysownica, Graphics osRysownica, int osX, int osY)
            {
                if (oslistaPunktów.Count < 1)
                    //lista jest pusta
                    return;
                //realizacja operacji utsaw xy wymaga zmiany położenia wszystkich punktów wykreślonej linii
                //deklaracja zmiennych pomocniczych
                int osPrzyrostX = oslistaPunktów[0].X - osX;
                int osPrzyrostY = oslistaPunktów[0].Y - osY;
                //zmiana położenia wszystkich punktów linii kreślonej myszą
                for (int osi = 0; osi < oslistaPunktów.Count; osi++)
                    oslistaPunktów[osi] = new Point(oslistaPunktów[osi].X - osPrzyrostX,
                        oslistaPunktów[osi].Y - osPrzyrostY);
                this.osWykreśl(osRysownica);


            }
            public override void osWykreśl(Graphics osRysownica)
            {
                //deklaracja pomoocniczej tablicy dla wpisania wszystkich współrzędnych
                Point[] osTablicaPunktów = new Point[oslistaPunktów.Count];

                //przepisanie współrzędnych wszystkich punktów 
                for (int osi = 0; osi < oslistaPunktów.Count; osi++)
                    osTablicaPunktów[osi] = oslistaPunktów[osi];
                //wykreślenie linii
                Pen osPióro = new Pen(osKolor, osGrubośćLinii);
                //ustalenie stylu linii dla pióra
                osPióro.DashStyle = osStylLinii;
                osRysownica.DrawLines(osPióro, osTablicaPunktów);

                osWidoczny = true;
                //zwolnienie pióra
                osPióro.Dispose();
            }
            public override void osWymaż(Control osKontrolka, Graphics osRysownica)
            {
                //deklaracja pomoocniczej tablicy dla wpisania wszystkich współrzędnych
                Point[] osTablicaPunktów = new Point[oslistaPunktów.Count];

                //przepisanie współrzędnych wszystkich punktów 
                for (int osi = 0; osi < oslistaPunktów.Count; osi++)
                    osTablicaPunktów[osi] = oslistaPunktów[osi];
                //wykreślenie linii
                Pen osPióroGumka = new Pen(osKontrolka.BackColor, osGrubośćLinii);
                //ustalenie stylu linii dla pióra
                osPióroGumka.DashStyle = osStylLinii;
                osRysownica.DrawLines(osPióroGumka, osTablicaPunktów);

                osWidoczny = true;
                //zwolnienie pióra
                osPióroGumka.Dispose();
            }
        }//od klasy osLiniaKreślonaMyszą

        public class osProstokąt : osPunkt
        {
            protected int osWysokość, osSzerokość;
            public osProstokąt(int osX, int osY, int osSzerokość, int osWysokość) : base(osX, osY)
            {
                this.osSzerokość = osSzerokość;
                this.osWysokość = osWysokość;
            }

            //nadpisanie metod wirtualnych z klasy Punkt
            public override void osWykreśl(Graphics osRysownica)
            {
                //wykreślenie pojedynczej linii
                Pen osPióro = new Pen(osKolor, osGrubośćLinii);
                //ustalenie stylu linii dla pióra
                osPióro.DashStyle = osStylLinii;
                //wykreslenie prostokąta
                osRysownica.DrawRectangle(osPióro, osX, osY, osSzerokość, osWysokość);
                osWidoczny = true;
                //zwolnienie pióra
                osPióro.Dispose();
            }

            public override void osWymaż(Control osKontrolka, Graphics osRysownica)
            {
                if (osWidoczny)
                {//wykreślenie pojedynczej linii
                    Pen osPióro = new Pen(osKontrolka.BackColor, osGrubośćLinii);
                    //ustalenie stylu linii dla pióra
                    osPióro.DashStyle = osStylLinii;
                    //wykreslenie prostokąta
                    osRysownica.DrawRectangle(osPióro, osX, osY, osSzerokość, osWysokość);
                    osWidoczny = false;
                    //zwolnienie pióra
                    osPióro.Dispose();
                }
            }
        }

        public class osProstokątWypełniony : osProstokąt
        {
            //deklaracja konstruktora
            public osProstokątWypełniony(int osX, int osY, int osSzerokość, int osWysokość) : 
                base(osX, osY, osSzerokość, osWysokość)
            {

            }
            //nadpisanie metod wirtualnych z klasy Punkt
            public override void osWykreśl(Graphics osRysownica)
            {
                SolidBrush osPędzel = new SolidBrush(osKolorTła);
                //wykreslenie prostokąta wypełnionego
                osRysownica.FillRectangle(osPędzel, osX, osY, osSzerokość, osWysokość);
                osWidoczny = true;
                //zwolnienie pióra
                osPędzel.Dispose();
                //wykreślenie linii po granicę prostokąta
                Pen osPióro = new Pen(osKolor, osGrubośćLinii);
                //ustalenie stylu linii dla pióra
                osPióro.DashStyle = osStylLinii;
                //wykreslenie prostokąta
                osRysownica.DrawRectangle(osPióro, osX, osY, osSzerokość, osWysokość);
                osWidoczny = true;
                //zwolnienie pióra
                osPióro.Dispose();
            }
            public override void osWymaż(Control osKontrolka, Graphics osRysownica)
            {
                if (osWidoczny)
                {//wykreślenie pojedynczej linii
                    SolidBrush osPędzel = new SolidBrush(osKolorTła);

                    //wykreslenie prostokąta
                    osRysownica.FillRectangle(osPędzel, osX, osY, osSzerokość, osWysokość);
                    osWidoczny = false;
                    //zwolnienie pióra
                    osPędzel.Dispose();
                }
            }

        }
        public class osKwadrat : osProstokąt
        {
            public osKwadrat(int osX, int osY, int osSzerokość) : base(osX, osY, osSzerokość, osSzerokość)
            {

            }
            //nadpisanie metod wirtualnych z klasy Punkt
            public override void osWykreśl(Graphics osRysownica)
            {
                //wykreślenie pojedynczej linii
                Pen osPióro = new Pen(osKolor, osGrubośćLinii);
                //ustalenie stylu linii dla pióra
                osPióro.DashStyle = osStylLinii;
                //wykreslenie prostokąta
                osRysownica.DrawRectangle(osPióro, osX, osY, osSzerokość, osSzerokość);
                osWidoczny = true;
                //zwolnienie pióra
                osPióro.Dispose();
            }

            public override void osWymaż(Control osKontrolka, Graphics osRysownica)
            {
                if (osWidoczny)
                {//wykreślenie pojedynczej linii
                    Pen osPióro = new Pen(osKontrolka.BackColor, osGrubośćLinii);
                    //ustalenie stylu linii dla pióra
                    osPióro.DashStyle = osStylLinii;
                    //wykreslenie prostokąta
                    osRysownica.DrawRectangle(osPióro, osX, osY, osSzerokość, osSzerokość);
                    osWidoczny = false;
                    //zwolnienie pióra
                    osPióro.Dispose();
                }

            }
        }

        public class osKrzywaBeziera : osPunkt
        {
            protected Point[] osTP = new Point[4];
            protected string[] osNazwyPunktów = { "P0", "P1", "P2", "P3" };


            public osKrzywaBeziera(int osX1, int osY1) : base(osX1, osY1)
            {

            }

            public override void osWykreśl(Graphics osRysownica)
            {
                //wykreślenie pojedynczej linii
                Pen osPióro = new Pen(osKolor, osGrubośćLinii);
                //ustalenie stylu linii dla pióra
                osPióro.DashStyle = osStylLinii;
                osRysownica.DrawBezier(osPióro, osTP[0], osTP[1], osTP[2], osTP[3]);
                /*if (!osWidocznePunkty)
                {*/
                    //wykreślenie 4 punktów
                    SolidBrush osPędzel = new SolidBrush(osKolor);
                    for (ushort osi = 0; osi < 4; osi++)
                    {
                        osRysownica.FillEllipse(osPędzel, osTP[osi].X - 5, osTP[osi].Y - 5, 10, 10);
                        osRysownica.DrawString(osNazwyPunktów[osi], osFont, osPędzel, osTP[osi].X + 5, osTP[osi].Y + 5);
                    }
                //}
            }
            public override void osWymaż(Control osKontrolka, Graphics osRysownica)
            {
                //wykreślenie pojedynczej linii
                Pen osPióro = new Pen(osKolor, osGrubośćLinii);
                //ustalenie stylu linii dla pióra
                osPióro.DashStyle = osStylLinii;
                osRysownica.DrawBezier(osPióro, osTP[0], osTP[1], osTP[2], osTP[3]);
            }

            public void osDodajPunkt(short osIndex, Point osPunkt, Graphics osRysownica)
            {
                osWidocznePunkty = true;
                osTP[osIndex] = osPunkt;
                //wykreślenie pojedynczej linii
                SolidBrush osPędzel = new SolidBrush(osKolor);
                osRysownica.FillEllipse(osPędzel, osPunkt.X - 5, osPunkt.Y - 5, 10, 10);
                osRysownica.DrawString(osNazwyPunktów[osIndex], osFont, osPędzel, osPunkt.X + 5, osPunkt.Y + 5);

            }

            public override void osUaktualnijXY(int osX, int osY)
            {
                //realizacja operacji utsaw xy wymaga zmiany położenia wszystkich punktów wykreślonej linii
                //deklaracja zmiennych pomocniczych
                int osPrzyrostX = osTP[0].X - osX;
                int osPrzyrostY = osTP[0].Y - osY;
                //zmiana położenia wszystkich punktów
                for (ushort osi = 0; osi < 4; osi++)
                    osTP[osi] = new Point(osTP[osi].X - osPrzyrostX, osTP[osi].Y - osPrzyrostY);
                osWidocznePunkty = false;

            }
            public override void osPrzesuńDoNowegoXY(PictureBox ospbRysownica, Graphics osRysownica, int osX, int osY)
            {
                //realizacja operacji utsaw xy wymaga zmiany położenia wszystkich punktów wykreślonej linii
                //deklaracja zmiennych pomocniczych
                int osPrzyrostX = osTP[0].X - osX;
                int osPrzyrostY = osTP[0].Y - osY;
                //zmiana położenia wszystkich punktów
                for (ushort osi = 0; osi < 4; osi++)
                    osTP[osi] = new Point(osTP[osi].X - osPrzyrostX, osTP[osi].Y - osPrzyrostY);
                osWidocznePunkty = false;
                this.osWykreśl(osRysownica);

            }

        }
        public class osWielokąt : osPunkt
        {
            protected List<Point> osLP = new List<Point>();
            protected string osPodpis = "P";
            //deklaracja konstruktora
            public osWielokąt(int osX, int osY) : base(osX, osY)
            {

            }

            public override void osWykreśl(Graphics osRysownica)
            {
                Point[] osTP = new Point[osLP.Count];
                for (int osi = 0; osi < osLP.Count; osi++)
                    osTP[osi] = osLP[osi];
                //deklaracja pióra
                Pen osPióro = new Pen(osKolor, osGrubośćLinii);
                osPióro.DashStyle = osStylLinii;
                //wykreślenie wielokąta
                osRysownica.DrawPolygon(osPióro, osTP);
                //zwolnienie pióra
                osPióro.Dispose();
                 //wykreślenie punktów
                 SolidBrush osPędzel = new SolidBrush(osKolor);
                    for (ushort osi = 0; osi < osTP.Length; osi++)
                    {
                        osRysownica.FillEllipse(osPędzel, osTP[osi].X - 5, osTP[osi].Y - 5, 10, 10);
                        osRysownica.DrawString(osPodpis + osi, osFont, osPędzel, osTP[osi].X + 5, osTP[osi].Y + 5);
                    }
            }
            public void osDodajPunkt(Point osPunkt, Graphics osRysownica)
            {
                osWidocznePunkty = true;
                osLP.Add(osPunkt);
                //wykreślenie punkta
                SolidBrush osPędzel = new SolidBrush(osKolor);

                osRysownica.FillEllipse(osPędzel, osPunkt.X - 5, osPunkt.Y - 5, 10, 10);
                osRysownica.DrawString(osPodpis + (osLP.Count - 1), osFont, osPędzel, osPunkt.X + 5, osPunkt.Y + 5);
                //zwolnienie pędzla
                osPędzel.Dispose();

            }
            
            public override void osPrzesuńDoNowegoXY(PictureBox ospbRysownica, Graphics osRysownica, int osX, int osY)
            {
                // realizacja operacji utsaw xy wymaga zmiany położenia wszystkich punktów wielokąta
                //deklaracja zmiennych pomocniczych
                int osPrzyrostX = osLP[0].X - osX;
                int osPrzyrostY = osLP[0].Y - osY;
                //zmiana położenia wszystkich punktów
                for (ushort osi = 0; osi < osLP.Count; osi++)
                    osLP[osi] = new Point(osLP[osi].X - osPrzyrostX, osLP[osi].Y - osPrzyrostY);
                osWidocznePunkty = false;
                this.osWykreśl(osRysownica);
            }

        }
        public class osWielokątWypełniony : osWielokąt
        {
            public osWielokątWypełniony(int osX, int osY) : base(osX, osY)
            {

            }
            public override void osWykreśl(Graphics osRysownica)
            {
                Point[] osTP = new Point[osLP.Count];
                for (int osi = 0; osi < osLP.Count; osi++)
                    osTP[osi] = osLP[osi];
                //wykreślenie wielokąta
                SolidBrush osPędzel = new SolidBrush(osKolorTła);
                osRysownica.FillPolygon(osPędzel, osTP);
                //zwolnienie pędzla
                osPędzel.Dispose();
                //deklaracja pióra
                Pen osPióro = new Pen(osKolor, osGrubośćLinii);
                osPióro.DashStyle = osStylLinii;
                //wykreślenie wielokąta
                osRysownica.DrawPolygon(osPióro, osTP);
                //zwolnienie pióra
                osPióro.Dispose();
                //wykreślenie punktów
                SolidBrush osPędzel1 = new SolidBrush(osKolor);
                for (ushort osi = 0; osi < osTP.Length; osi++)
                {
                    osRysownica.FillEllipse(osPędzel1, osTP[osi].X - 5, osTP[osi].Y - 5, 10, 10);
                    osRysownica.DrawString(osPodpis + osi, osFont, osPędzel1, osTP[osi].X + 5, osTP[osi].Y + 5);
                }
                
            }

        }
        public class osKrzywaKardynalna : osWielokąt
        {
            //deklaracja konstruktora
            public osKrzywaKardynalna(int osX, int osY) : base(osX, osY)
            {

            }
            //nadpisanie metod wirtualnych
            public override void osWykreśl(Graphics osRysownica)
            {
                Point[] osTP = new Point[osLP.Count];
                for (int osi = 0; osi < osLP.Count; osi++)
                    osTP[osi] = osLP[osi];
                //deklaracja pióra
                Pen osPióro = new Pen(osKolor, osGrubośćLinii);
                osPióro.DashStyle = osStylLinii;
                //wykreślenie wielokąta
                osRysownica.DrawCurve(osPióro, osTP);
                //zwolnienie pióra
                osPióro.Dispose();
                //wykreślenie punktów
                SolidBrush osPędzel = new SolidBrush(osKolor);
                for (ushort osi = 0; osi < osTP.Length; osi++)
                  {
                    osRysownica.FillEllipse(osPędzel, osTP[osi].X - 5, osTP[osi].Y - 5, 10, 10);
                    osRysownica.DrawString(osPodpis + osi, osFont, osPędzel, osTP[osi].X + 5, osTP[osi].Y + 5);
                  }
            }
        }
        public class osDrawClosedCurve : osWielokąt
        {
            //deklaracja konstruktora
            public osDrawClosedCurve(int osX, int osY) : base(osX, osY)
            {

            }
            //nadpisanie metod wirtualnych
            public override void osWykreśl(Graphics osRysownica)
            {
                Point[] osTP = new Point[osLP.Count];
                for (int osi = 0; osi < osLP.Count; osi++)
                    osTP[osi] = osLP[osi];
                //deklaracja pióra
                Pen osPióro = new Pen(osKolor, osGrubośćLinii);
                osPióro.DashStyle = osStylLinii;
                //wykreślenie wielokąta
                osRysownica.DrawClosedCurve(osPióro, osTP);
                //zwolnienie pióra
                osPióro.Dispose();
                //wykreślenie punktów
                SolidBrush osPędzel = new SolidBrush(osKolor);
                for (ushort osi = 0; osi < osTP.Length; osi++)
                 {
                    osRysownica.FillEllipse(osPędzel, osTP[osi].X - 5, osTP[osi].Y - 5, 10, 10);
                    osRysownica.DrawString(osPodpis + osi, osFont, osPędzel, osTP[osi].X + 5, osTP[osi].Y + 5);
                 }
            }
        }
        public class osFillClosedCurve : osDrawClosedCurve
        {
            //deklaracja konstruktora
            public osFillClosedCurve(int osX, int osY): base(osX, osY)
            {

            }
            //nadpisanie metod wirtualnych
            public override void osWykreśl(Graphics osRysownica)
            {
                Point[] osTP = new Point[osLP.Count];
                for (int osi = 0; osi < osLP.Count; osi++)
                    osTP[osi] = osLP[osi];
                //deklaracja pędzla
                SolidBrush osPędzel = new SolidBrush(osKolorTła);
                //wykreślenie 
                osRysownica.FillClosedCurve(osPędzel, osTP);
                //zwolnienie pędzla
                osPędzel.Dispose();
                //deklaracja pióra
                Pen osPióro = new Pen(osKolor, osGrubośćLinii);
                osPióro.DashStyle = osStylLinii;
                //wykreślenie wielokąta
                osRysownica.DrawClosedCurve(osPióro, osTP);
                //zwolnienie pióra
                osPióro.Dispose();
                //wykreślenie punktów
                SolidBrush osPędzel1 = new SolidBrush(osKolor);
                for (ushort osi = 0; osi < osTP.Length; osi++)
                 {
                   osRysownica.FillEllipse(osPędzel1, osTP[osi].X - 5, osTP[osi].Y - 5, 10, 10);
                   osRysownica.DrawString(osPodpis + osi, osFont, osPędzel1, osTP[osi].X + 5, osTP[osi].Y + 5);
                 }
            }
        }
        public class osWielokątForemny : osWielokąt
        {
            protected Point osPc;
            protected ushort osN;
            protected Point[] osTP;
            //deklaracje konstruktorów
            public osWielokątForemny(Point osCenter, ushort osN) : base(osCenter.X, osCenter.Y)
            {
                this.osN = osN;
                osTP = new Point[osN];
                osPc = osCenter;
            } 
            public osWielokątForemny(int osXc, int osYc, int osX, int osY, ushort osN): base(osXc, osYc)
            {
                osPc.X = osXc;
                osPc.Y = osYc;
                /*this.osP0.X = osX;
                this.osP0.Y = osY;*/
                this.osN = osN;
                osTP = new Point[osN];
                osTP[0] = new Point(osX, osY);
            }
            //nadpisanie metod wirtualnych
            public override void osWykreśl(Graphics osRysownica)
            {
                double osR = Math.Sqrt((osTP[0].X - osPc.X) * (osTP[0].X - osPc.X) + (osTP[0].Y - osPc.Y) * (osTP[0].Y - osPc.Y));
                double osAlfa = 2 * Math.PI / osN;
                //kąt
                double osXd = osPc.X + osR, osYd = osPc.Y;
                double osL = Math.Sqrt((osTP[0].X - osXd) * (osTP[0].X - osXd) + (osTP[0].Y - osYd) * (osTP[0].Y - osYd));
                double osBeta = 2 * Math.Asin(osL / 2 / osR);
                //wykreślenie punktów i wielokąta
                SolidBrush osPędzel = new SolidBrush(osKolor);
                osRysownica.FillEllipse(osPędzel, osPc.X - 5, osPc.Y - 5, 10, 10);
                osRysownica.DrawString("S", osFont, osPędzel, osPc.X + 5, osPc.Y + 5);
                
                for (int osi = 0; osi < osN; osi++)
                {
                    double osFi = osi * osAlfa;
                    osTP[osi] = new Point((int)(osPc.X - osR * Math.Cos(osFi + osBeta - Math.PI) ), 
                                    osPc.Y - (int)(osR * Math.Sin(osFi + osBeta - Math.PI)));
                    //wykreślenie punkta
                    osRysownica.FillEllipse(osPędzel, osTP[osi].X - 5, osTP[osi].Y - 5, 10, 10);
                    osRysownica.DrawString(osPodpis + osi, osFont, osPędzel, osTP[osi].X + 5, osTP[osi].Y + 5);
                }
                osPędzel.Dispose();
                //wykreślenie wielokąta
                Pen osPióro = new Pen(osKolor, osGrubośćLinii);
                osPióro.DashStyle = osStylLinii;
                osRysownica.DrawPolygon(osPióro, osTP);
                osPióro.Dispose();
            }
            public void osDodajPunktPC(Point osPunkt, Graphics osRysownica)
            {
                osWidocznePunkty = true;
                //wykreślenie punkta
                SolidBrush osPędzel = new SolidBrush(osKolor);
                osRysownica.FillEllipse(osPędzel, osPunkt.X - 5, osPunkt.Y - 5, 10, 10);
                osRysownica.DrawString("S", osFont, osPędzel, osPunkt.X + 5, osPunkt.Y + 5);
                //zwolnienie pędzla
                osPędzel.Dispose();

            }
            public void osDodajPunktP0(Point osPunkt)
            {
                osTP[0]=osPunkt;
            }
            public override void osPrzesuńDoNowegoXY(PictureBox ospbRysownica, Graphics osRysownica, int osX, int osY)
            {
                // realizacja operacji utsaw xy wymaga zmiany położenia wszystkich punktów wielokąta
                //deklaracja zmiennych pomocniczych
                int osPrzyrostX = osPc.X - osX;
                int osPrzyrostY = osPc.Y - osY;
                //zmiana położenia wszystkich punktów
                osPc.X = osX;
                osPc.Y = osY;
                for (ushort osi = 0; osi < osN; osi++)
                    osTP[osi] = new Point(osTP[osi].X - osPrzyrostX, osTP[osi].Y - osPrzyrostY);
                osWidocznePunkty = false;
                this.osWykreśl(osRysownica);
                
            }
        }
        public class osWielokątForemnyWypełniony : osWielokątForemny
        {
            //deklaracje konstruktorów
            public osWielokątForemnyWypełniony(Point osCenter, ushort osN) : base(osCenter, osN)
            {

            }
            public osWielokątForemnyWypełniony(int osXc, int osYc, int osX, int osY, ushort osN) : base(osXc, osYc, osX, osY, osN)
            {
                osPc.X = osXc;
                osPc.Y = osYc;
                this.osN = osN;
                osTP = new Point[osN];
                osTP[0] = new Point(osX, osY);
            }
            //nadpisanie metod wirtualnych
            public override void osWykreśl(Graphics osRysownica)
            {
                double osR = Math.Sqrt((osTP[0].X - osPc.X) * (osTP[0].X - osPc.X) + (osTP[0].Y - osPc.Y) * (osTP[0].Y - osPc.Y));
                double osAlfa = 2 * Math.PI / osN;
                //kąt
                double osXd = osPc.X + osR, osYd = osPc.Y;
                double osL = Math.Sqrt((osTP[0].X - osXd) * (osTP[0].X - osXd) + (osTP[0].Y - osYd) * (osTP[0].Y - osYd));
                double osBeta = 2 * Math.Asin(osL / 2 / osR);
                
                for (int osi = 0; osi < osN; osi++)
                {
                    double osFi = osi * osAlfa;
                    osTP[osi] = new Point((int)(osPc.X - osR * Math.Cos(osFi + osBeta - Math.PI)), 
                        osPc.Y - (int)(osR * Math.Sin(osFi + osBeta - Math.PI)));
                }
                //deklaracja nowego pędzla
                SolidBrush osPędzel1 = new SolidBrush(osKolorTła);
                //wykreślenie wielokąta
                osRysownica.FillPolygon(osPędzel1, osTP);
                //zwolnienie pędzla
                Pen osPióro = new Pen(osKolor, osGrubośćLinii);
                osPióro.DashStyle = osStylLinii;
                osRysownica.DrawPolygon(osPióro, osTP);
                osPióro.Dispose();
                //wykreślenie punktów
                SolidBrush osPędzel = new SolidBrush(osKolor);
                osRysownica.FillEllipse(osPędzel, osPc.X - 5, osPc.Y - 5, 10, 10);
                osRysownica.DrawString("S", osFont, osPędzel, osPc.X + 5, osPc.Y + 5);
                for (int osi = 0; osi < osN; osi++)
                {
                    //wykreślenie punkta
                    osRysownica.FillEllipse(osPędzel, osTP[osi].X - 5, osTP[osi].Y - 5, 10, 10);
                    osRysownica.DrawString(osPodpis + osi, osFont, osPędzel, osTP[osi].X + 5, osTP[osi].Y + 5);
                }
                //zwolnienie pędzla
                osPędzel.Dispose();
            }
        }
        public class osDrawArc : osPunkt
        {
            //deklaracja zmiennych
            protected int osSzerokość, osWysokość;
            protected float osKątPoczątkowy, osKątKońcowy;
            //deklaracja konstruktora
            public osDrawArc(int osX, int osY, int osSzerokość, int osWysokość, float osKątP, float osKątK): base(osX, osY)
            {
                this.osSzerokość = osSzerokość;
                this.osWysokość = osWysokość;
                this.osKątPoczątkowy = osKątP;
                this.osKątKońcowy = osKątK;
            }
            //nadpisanie metod wirtualnych
            public override void osWykreśl(Graphics osRysownica)
            {
                //deklaracja pióra
                Pen osPióro = new Pen(osKolor, osGrubośćLinii);
                osPióro.DashStyle = osStylLinii;
                osRysownica.DrawArc(osPióro, osX, osY, osSzerokość, osWysokość, osKątPoczątkowy, osKątKońcowy);
                //zwolnienie pióra
                osPióro.Dispose();
            }
        }
        public class osDrawPie : osDrawArc
        {
            //deklaracja konstruktora
            public osDrawPie(int osX, int osY, int osSzerokość, int osWysokość, float osKątP, float osKątK) : 
                base(osX, osY, osSzerokość, osWysokość, osKątP, osKątK)
            {
                
            }
            //nadpisanie metod wirtualnych
            public override void osWykreśl(Graphics osRysownica)
            {
                //deklaracja pióra
                Pen osPióro = new Pen(osKolor, osGrubośćLinii);
                osPióro.DashStyle = osStylLinii;
                osRysownica.DrawPie(osPióro, osX, osY, osSzerokość, osWysokość, osKątPoczątkowy, osKątKońcowy);
                //zwolnienie pióra
                osPióro.Dispose();
            }
        }
        public class osFillPie : osDrawPie
        {
            //deklaracja konstruktora
            public osFillPie(int osX, int osY, int osSzerokość, int osWysokość, float osKątP, float osKątK) : 
                base(osX, osY, osSzerokość, osWysokość, osKątP, osKątK)
            {

            }
            //nadpisanie metod wirtualnych
            public override void osWykreśl(Graphics osRysownica)
            {
                //deklaracja pędzla
                SolidBrush osPędzel = new SolidBrush(osKolorTła);
                osRysownica.FillPie(osPędzel, osX, osY, osSzerokość, osWysokość, osKątPoczątkowy, osKątKońcowy);
                //zwolnienie pędzla
                osPędzel.Dispose();
                //deklaracja pióra
                Pen osPióro = new Pen(osKolor, osGrubośćLinii);
                osPióro.DashStyle = osStylLinii;
                osRysownica.DrawPie(osPióro, osX, osY, osSzerokość, osWysokość, osKątPoczątkowy, osKątKońcowy);
                //zwolnienie pióra
                osPióro.Dispose();
            }
        }
    }
}
