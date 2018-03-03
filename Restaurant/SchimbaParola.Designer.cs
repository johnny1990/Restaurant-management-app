namespace Restaurant
{
    partial class SchimbaParola
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SchimbaParola));
            this.txtNumeUtilizator = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.btnSchimbaParola = new System.Windows.Forms.Button();
            this.Label3 = new System.Windows.Forms.Label();
            this.txtConfirmaParola = new System.Windows.Forms.TextBox();
            this.txtParolaNoua = new System.Windows.Forms.TextBox();
            this.txtParolaVeche = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtNumeUtilizator
            // 
            this.txtNumeUtilizator.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtNumeUtilizator.Location = new System.Drawing.Point(172, 35);
            this.txtNumeUtilizator.Name = "txtNumeUtilizator";
            this.txtNumeUtilizator.Size = new System.Drawing.Size(119, 20);
            this.txtNumeUtilizator.TabIndex = 9;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.BackColor = System.Drawing.Color.Transparent;
            this.Label4.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.ForeColor = System.Drawing.Color.Black;
            this.Label4.Location = new System.Drawing.Point(33, 38);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(93, 17);
            this.Label4.TabIndex = 17;
            this.Label4.Text = "Nume utilizator";
            // 
            // btnSchimbaParola
            // 
            this.btnSchimbaParola.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSchimbaParola.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSchimbaParola.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSchimbaParola.Location = new System.Drawing.Point(103, 223);
            this.btnSchimbaParola.Name = "btnSchimbaParola";
            this.btnSchimbaParola.Size = new System.Drawing.Size(115, 38);
            this.btnSchimbaParola.TabIndex = 15;
            this.btnSchimbaParola.Text = "Schimba parola";
            this.btnSchimbaParola.UseVisualStyleBackColor = false;
            this.btnSchimbaParola.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.BackColor = System.Drawing.Color.Transparent;
            this.Label3.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.ForeColor = System.Drawing.Color.Black;
            this.Label3.Location = new System.Drawing.Point(33, 163);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(97, 17);
            this.Label3.TabIndex = 16;
            this.Label3.Text = "Confirma parola";
            // 
            // txtConfirmaParola
            // 
            this.txtConfirmaParola.Location = new System.Drawing.Point(172, 160);
            this.txtConfirmaParola.Name = "txtConfirmaParola";
            this.txtConfirmaParola.PasswordChar = '*';
            this.txtConfirmaParola.Size = new System.Drawing.Size(119, 20);
            this.txtConfirmaParola.TabIndex = 14;
            // 
            // txtParolaNoua
            // 
            this.txtParolaNoua.Location = new System.Drawing.Point(172, 117);
            this.txtParolaNoua.Name = "txtParolaNoua";
            this.txtParolaNoua.PasswordChar = '*';
            this.txtParolaNoua.Size = new System.Drawing.Size(119, 20);
            this.txtParolaNoua.TabIndex = 13;
            // 
            // txtParolaVeche
            // 
            this.txtParolaVeche.Location = new System.Drawing.Point(172, 75);
            this.txtParolaVeche.Name = "txtParolaVeche";
            this.txtParolaVeche.PasswordChar = '*';
            this.txtParolaVeche.Size = new System.Drawing.Size(119, 20);
            this.txtParolaVeche.TabIndex = 11;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.BackColor = System.Drawing.Color.Transparent;
            this.Label2.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(33, 120);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(73, 17);
            this.Label2.TabIndex = 12;
            this.Label2.Text = "Parola noua";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(33, 78);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(77, 17);
            this.Label1.TabIndex = 10;
            this.Label1.Text = "Parola veche";
            // 
            // SchimbaParola
            // 
            this.AcceptButton = this.btnSchimbaParola;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BackgroundImage = global::Restaurant.Properties.Resources._0088181331020_Color_Sky_Blue_SW_60X601;
            this.ClientSize = new System.Drawing.Size(322, 284);
            this.Controls.Add(this.txtNumeUtilizator);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.btnSchimbaParola);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.txtConfirmaParola);
            this.Controls.Add(this.txtParolaNoua);
            this.Controls.Add(this.txtParolaVeche);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SchimbaParola";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SchimbaParola_FormClosing);
            this.Load += new System.EventHandler(this.frmChangePassword_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox txtNumeUtilizator;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Button btnSchimbaParola;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox txtConfirmaParola;
        internal System.Windows.Forms.TextBox txtParolaNoua;
        internal System.Windows.Forms.TextBox txtParolaVeche;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
    }
}