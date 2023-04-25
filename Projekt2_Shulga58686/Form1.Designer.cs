
namespace Projekt2_Shulga58686
{
    partial class osPrezenter_Shulga
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
            this.osbtnPrezentacjaZeSlajderem = new System.Windows.Forms.Button();
            this.osbtnKreślenieFigur = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // osbtnPrezentacjaZeSlajderem
            // 
            this.osbtnPrezentacjaZeSlajderem.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.osbtnPrezentacjaZeSlajderem.Location = new System.Drawing.Point(75, 229);
            this.osbtnPrezentacjaZeSlajderem.Name = "osbtnPrezentacjaZeSlajderem";
            this.osbtnPrezentacjaZeSlajderem.Size = new System.Drawing.Size(371, 142);
            this.osbtnPrezentacjaZeSlajderem.TabIndex = 0;
            this.osbtnPrezentacjaZeSlajderem.Text = "Prezentacja figur geometrycznych ze\r\nslajderem";
            this.osbtnPrezentacjaZeSlajderem.UseVisualStyleBackColor = true;
            this.osbtnPrezentacjaZeSlajderem.Click += new System.EventHandler(this.osbtnPrezentacjaZeSlajderem_Click);
            // 
            // osbtnKreślenieFigur
            // 
            this.osbtnKreślenieFigur.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.osbtnKreślenieFigur.Location = new System.Drawing.Point(553, 229);
            this.osbtnKreślenieFigur.Name = "osbtnKreślenieFigur";
            this.osbtnKreślenieFigur.Size = new System.Drawing.Size(356, 142);
            this.osbtnKreślenieFigur.TabIndex = 1;
            this.osbtnKreślenieFigur.Text = "Kreślenie figur i linii geometrycznych\r\nprzy użyciu myszy";
            this.osbtnKreślenieFigur.UseVisualStyleBackColor = true;
            this.osbtnKreślenieFigur.Click += new System.EventHandler(this.osbtnKreślenieFigur_Click);
            // 
            // osPrezenter_Shulga
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.ClientSize = new System.Drawing.Size(991, 627);
            this.Controls.Add(this.osbtnKreślenieFigur);
            this.Controls.Add(this.osbtnPrezentacjaZeSlajderem);
            this.Name = "osPrezenter_Shulga";
            this.Text = "Prezenter";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button osbtnPrezentacjaZeSlajderem;
        private System.Windows.Forms.Button osbtnKreślenieFigur;
    }
}

