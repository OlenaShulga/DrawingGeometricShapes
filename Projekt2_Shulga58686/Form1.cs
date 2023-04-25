using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt2_Shulga58686
{
    public partial class osPrezenter_Shulga : Form
    {
        public osPrezenter_Shulga()
        {
            InitializeComponent();
        }

        private void osbtnPrezentacjaZeSlajderem_Click(object sender, EventArgs e)
        {
            foreach (Form osFormX in Application.OpenForms)
                //sprawdzenie czy "znaleziony" formularz jest form1
                if (osFormX.Name == "osPrezentacjaLosowaZeSlajderem")
                {
                    //ukryci ebieżącego formularza
                    Hide();
                    //odsłonięcie
                    osFormX.Show();
                    //wyjście z metody zdarzenia click
                    return;
                }
            //formularz główny nie został znaleziony
            
            osPrezentacjaLosowaZeSlajderem osPrezZeSl = new osPrezentacjaLosowaZeSlajderem();
            Hide();
            osPrezZeSl.Show();
        }

        private void osbtnKreślenieFigur_Click(object sender, EventArgs e)
        {
            foreach (Form osFormX in Application.OpenForms)
                //sprawdzenie czy "znaleziony" formularz jest form1
                if (osFormX.Name == "osKreślenieFigur_Linii")
                {
                    //ukryci ebieżącego formularza
                    Hide();
                    //odsłonięcie
                    osFormX.Show();
                    //wyjście z metody zdarzenia click
                    return;
                }
            //formularz główny nie został znaleziony

            osKreslenieFigur_Linii osPrezZeSl = new osKreslenieFigur_Linii();
            Hide();
            osPrezZeSl.Show();
        }
    }
}
