namespace kredikartiBasvuru
{
    partial class MainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.ApplicationList = new System.Windows.Forms.Button();
            this.CustomerScreen = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ApplicationList
            // 
            this.ApplicationList.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ApplicationList.BackgroundImage")));
            this.ApplicationList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ApplicationList.FlatAppearance.BorderColor = System.Drawing.Color.Aqua;
            this.ApplicationList.FlatAppearance.BorderSize = 2;
            this.ApplicationList.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ApplicationList.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ApplicationList.ImageKey = "(none)";
            this.ApplicationList.Location = new System.Drawing.Point(18, 198);
            this.ApplicationList.Name = "ApplicationList";
            this.ApplicationList.Size = new System.Drawing.Size(243, 35);
            this.ApplicationList.TabIndex = 1;
            this.ApplicationList.TabStop = false;
            this.ApplicationList.Text = "Müşteri Ekranı";
            this.ApplicationList.UseVisualStyleBackColor = true;
            this.ApplicationList.Click += new System.EventHandler(this.ApplicationList_Click);
            // 
            // CustomerScreen
            // 
            this.CustomerScreen.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CustomerScreen.BackgroundImage")));
            this.CustomerScreen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CustomerScreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.CustomerScreen.Location = new System.Drawing.Point(18, 260);
            this.CustomerScreen.Name = "CustomerScreen";
            this.CustomerScreen.Size = new System.Drawing.Size(243, 33);
            this.CustomerScreen.TabIndex = 1;
            this.CustomerScreen.TabStop = false;
            this.CustomerScreen.Text = "Başvuru Ekranı";
            this.CustomerScreen.UseVisualStyleBackColor = true;
            this.CustomerScreen.Click += new System.EventHandler(this.CustomerScreen_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(434, 130);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(191, 163);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(644, 105);
            this.label1.TabIndex = 3;
            this.label1.Text = "Müşteri Kaydı Oluşturmak İçin Başvuru Ekranına Gidiniz.\r\n\r\nKayıtlı Müşteriyi Kont" +
    "rol Etmek İçin Müşteri Ekranına Gidiniz.\r\n";
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(653, 332);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.CustomerScreen);
            this.Controls.Add(this.ApplicationList);
            this.MaximizeBox = false;
            this.Name = "MainMenu";
            this.Text = "MainMenu";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ApplicationList;
        private System.Windows.Forms.Button CustomerScreen;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
    }
}