namespace Restaurant
{
    partial class Categorie
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtNumeCategorie = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAfiseazaCategorii = new System.Windows.Forms.Button();
            this.btnActualizeaza = new System.Windows.Forms.Button();
            this.btnSterge = new System.Windows.Forms.Button();
            this.btnSalvare = new System.Windows.Forms.Button();
            this.btnNou = new System.Windows.Forms.Button();
            this.txtId = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.txtNumeCategorie);
            this.groupBox1.Location = new System.Drawing.Point(26, 24);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(396, 85);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nume categorie";
            // 
            // txtNumeCategorie
            // 
            this.txtNumeCategorie.Location = new System.Drawing.Point(45, 36);
            this.txtNumeCategorie.Name = "txtNumeCategorie";
            this.txtNumeCategorie.Size = new System.Drawing.Size(314, 24);
            this.txtNumeCategorie.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnAfiseazaCategorii);
            this.panel1.Controls.Add(this.btnActualizeaza);
            this.panel1.Controls.Add(this.btnSterge);
            this.panel1.Controls.Add(this.btnSalvare);
            this.panel1.Controls.Add(this.btnNou);
            this.panel1.Location = new System.Drawing.Point(12, 123);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(423, 62);
            this.panel1.TabIndex = 1;
            // 
            // btnAfiseazaCategorii
            // 
            this.btnAfiseazaCategorii.Location = new System.Drawing.Point(318, 9);
            this.btnAfiseazaCategorii.Name = "btnAfiseazaCategorii";
            this.btnAfiseazaCategorii.Size = new System.Drawing.Size(100, 43);
            this.btnAfiseazaCategorii.TabIndex = 4;
            this.btnAfiseazaCategorii.Text = "Afiseaza categorii";
            this.btnAfiseazaCategorii.UseVisualStyleBackColor = true;
            this.btnAfiseazaCategorii.Click += new System.EventHandler(this.btnAfiseazaCategorii_Click);
            // 
            // btnActualizeaza
            // 
            this.btnActualizeaza.Enabled = false;
            this.btnActualizeaza.Location = new System.Drawing.Point(225, 14);
            this.btnActualizeaza.Name = "btnActualizeaza";
            this.btnActualizeaza.Size = new System.Drawing.Size(92, 32);
            this.btnActualizeaza.TabIndex = 3;
            this.btnActualizeaza.Text = "Actualizeaza";
            this.btnActualizeaza.UseVisualStyleBackColor = true;
            this.btnActualizeaza.Click += new System.EventHandler(this.btnActualizeaza_Click);
            // 
            // btnSterge
            // 
            this.btnSterge.Enabled = false;
            this.btnSterge.Location = new System.Drawing.Point(151, 14);
            this.btnSterge.Name = "btnSterge";
            this.btnSterge.Size = new System.Drawing.Size(68, 32);
            this.btnSterge.TabIndex = 2;
            this.btnSterge.Text = "Sterge";
            this.btnSterge.UseVisualStyleBackColor = true;
            this.btnSterge.Click += new System.EventHandler(this.btnSterge_Click);
            // 
            // btnSalvare
            // 
            this.btnSalvare.Location = new System.Drawing.Point(77, 14);
            this.btnSalvare.Name = "btnSalvare";
            this.btnSalvare.Size = new System.Drawing.Size(68, 32);
            this.btnSalvare.TabIndex = 1;
            this.btnSalvare.Text = "Salveaza";
            this.btnSalvare.UseVisualStyleBackColor = true;
            this.btnSalvare.Click += new System.EventHandler(this.btnSalvare_Click);
            // 
            // btnNou
            // 
            this.btnNou.Location = new System.Drawing.Point(3, 14);
            this.btnNou.Name = "btnNou";
            this.btnNou.Size = new System.Drawing.Size(68, 32);
            this.btnNou.TabIndex = 0;
            this.btnNou.Text = "Nou";
            this.btnNou.UseVisualStyleBackColor = true;
            this.btnNou.Click += new System.EventHandler(this.btnNou_Click);
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(303, 2);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(143, 24);
            this.txtId.TabIndex = 5;
            this.txtId.Visible = false;
            // 
            // Categorie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BackgroundImage = global::Restaurant.Properties.Resources._0088181331020_Color_Sky_Blue_SW_60X601;
            this.ClientSize = new System.Drawing.Size(447, 210);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Categorie";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Categorii";
            this.Load += new System.EventHandler(this.Categorie_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.TextBox txtNumeCategorie;
        public System.Windows.Forms.Button btnAfiseazaCategorii;
        public System.Windows.Forms.Button btnActualizeaza;
        public System.Windows.Forms.Button btnSterge;
        public System.Windows.Forms.Button btnSalvare;
        public System.Windows.Forms.Button btnNou;
        public System.Windows.Forms.TextBox txtId;
    }
}