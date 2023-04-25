using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using static Projekt2_Shulga58686.osKreślenieFigur_Linii;

namespace Projekt2_Shulga58686
{
    public partial class osWielokatForemnyFormularz : Form
    {
        ushort osN;
        
        public osWielokatForemnyFormularz()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Width = 400;
            this.Height = 270;
            osbtnPoprawność.Width = 210;
            osbtnPoprawność.Height = 55;
            //this.Location = new Point(Screen.PrimaryScreen.Bounds.X/2, Screen.PrimaryScreen.Bounds.Y/2);

        }
        
        private void osbtnOK_Click(object sender, EventArgs e)
        {
        }
        public ushort osRezultat()
        {
            return osN;
        }

        private void ostxtWierzchołki_Click(object sender, EventArgs e)
        {
            //zgaszenie ErrorProvider
            osErrorProvider.Dispose();
        }

        private void osbtnPoprawność_Click(object sender, EventArgs e)
        {
            if (!ushort.TryParse(ostxtWierzchołki.Text, out osN))
            {
                osErrorProvider.SetError(ostxtWierzchołki, "ERROR : w podanej liczbie wystąpił niedozwolony znak");
                //osbtnOK.DialogResult = DialogResult.No;
                return;
            }
            else
            {
                if (osN < 3)
                {
                    osErrorProvider.SetError(ostxtWierzchołki, "ERROR : liczba wierzchowłków powinna być >= 3");
                    //osbtnOK.DialogResult = DialogResult.No;
                    return;
                }
                
                osbtnOK.Visible = true;
                osbtnPoprawność.Visible = false;
                ostxtWierzchołki.Enabled = false;
            }
        }
    }
}
