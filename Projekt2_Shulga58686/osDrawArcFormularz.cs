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
    public partial class osDrawArcFormularz : Form
    {
        //deklaracje zmiennych
        float osKątP, osKątK;
        //bool osPoprawne = true;
        public osDrawArcFormularz(string osNagłówek)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = osNagłówek;
            this.Width= 450;
            this.Height = 300;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            //this.MaximizeSize = false;
            //this.MinimizeSize = false;

            oslblNagłówek.Text = "Żeby wykreślić figurę " + osNagłówek + ",\n podaj wartości kątów:";
            osbtnPoprawność.Width = 243;
            osbtnPoprawność.Height = 78;


        }

        private void osbtnPoprawność_Click(object sender, EventArgs e)
        {
            if (!float.TryParse(ostxtPoczątkowy.Text, out osKątP))
            {
                osErrorProvider.SetError(ostxtPoczątkowy, "ERROR : niepoprawnie podana liczba");
                return;
            }
            else
            if (!float.TryParse(ostxtKońcowy.Text, out osKątK))
            {
                osErrorProvider.SetError(ostxtKońcowy, "ERROR : niepoprawnie podana liczba");
                return;
            }
            else
            if((osKątK >= 360) || (osKątK <= -360) || (osKątK == 0))
            {
                osErrorProvider.SetError(ostxtKońcowy, "ERROR : kąt wykreślenia powinien być w zakresie (-360; 0) U (0; 360)!");
                return;
            }
            else
            {
                osbtnOK.Visible = true;
                osbtnPoprawność.Visible = false;
                ostxtPoczątkowy.Enabled = false;
                ostxtKońcowy.Enabled = false;
            }
        }
        public void osKąty(out float osP, out float osK)
        {
             osP = osKątP;
             osK = osKątK;
        }
        public float osRezultatP()
        {
            return osKątP;
        }

        private void osbtnOK_Click(object sender, EventArgs e)
        {
            //osKątP = ostxtPoczątkowy.Text;
        }

        private void ostxtPoczątkowy_TextChanged(object sender, EventArgs e)
        {
            osErrorProvider.Dispose();
        }

        private void ostxtKońcowy_TextChanged(object sender, EventArgs e)
        {
            osErrorProvider.Dispose();
        }

        public float osRezultatK()
        {
            return osKątK;
        }
    }
}
