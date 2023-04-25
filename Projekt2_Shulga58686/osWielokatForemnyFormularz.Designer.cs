namespace Projekt2_Shulga58686
{
    partial class osWielokatForemnyFormularz
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
            this.label1 = new System.Windows.Forms.Label();
            this.ostxtWierzchołki = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.osbtnOK = new System.Windows.Forms.Button();
            this.osErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.osbtnPoprawność = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.osErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(457, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Podaj liczbę wierzchołków wielokąta:";
            // 
            // ostxtWierzchołki
            // 
            this.ostxtWierzchołki.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ostxtWierzchołki.Location = new System.Drawing.Point(195, 68);
            this.ostxtWierzchołki.Name = "ostxtWierzchołki";
            this.ostxtWierzchołki.Size = new System.Drawing.Size(100, 42);
            this.ostxtWierzchołki.TabIndex = 1;
            this.ostxtWierzchołki.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ostxtWierzchołki.Click += new System.EventHandler(this.ostxtWierzchołki_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(46, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(397, 52);
            this.label2.TabIndex = 2;
            this.label2.Text = "Następnie na Rysownicy podaj 2 punkty :\r\n środek wielokąta i jeden wierzchołek";
            // 
            // osbtnOK
            // 
            this.osbtnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.osbtnOK.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.osbtnOK.Location = new System.Drawing.Point(195, 195);
            this.osbtnOK.Name = "osbtnOK";
            this.osbtnOK.Size = new System.Drawing.Size(100, 62);
            this.osbtnOK.TabIndex = 3;
            this.osbtnOK.Text = "OK";
            this.osbtnOK.UseVisualStyleBackColor = true;
            this.osbtnOK.Visible = false;
            this.osbtnOK.Click += new System.EventHandler(this.osbtnOK_Click);
            // 
            // osErrorProvider
            // 
            this.osErrorProvider.ContainerControl = this;
            // 
            // osbtnPoprawność
            // 
            this.osbtnPoprawność.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.osbtnPoprawność.Location = new System.Drawing.Point(122, 189);
            this.osbtnPoprawność.Name = "osbtnPoprawność";
            this.osbtnPoprawność.Size = new System.Drawing.Size(243, 78);
            this.osbtnPoprawność.TabIndex = 4;
            this.osbtnPoprawność.Text = "Sprawdź poprawność wpisania liczby";
            this.osbtnPoprawność.UseVisualStyleBackColor = true;
            this.osbtnPoprawność.Click += new System.EventHandler(this.osbtnPoprawność_Click);
            // 
            // osWielokątForemnyFormularz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClientSize = new System.Drawing.Size(493, 269);
            this.Controls.Add(this.osbtnPoprawność);
            this.Controls.Add(this.osbtnOK);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ostxtWierzchołki);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "osWielokątForemnyFormularz";
            this.Text = "Wielokąt Foremny";
            ((System.ComponentModel.ISupportInitialize)(this.osErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ostxtWierzchołki;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button osbtnOK;
        private System.Windows.Forms.ErrorProvider osErrorProvider;
        private System.Windows.Forms.Button osbtnPoprawność;
    }
}