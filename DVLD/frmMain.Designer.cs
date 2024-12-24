namespace DVLD
{
    partial class frmMain
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.peopleStripDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.driversStripDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.usersStripDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripDropDownButton5 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(70, 70);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.peopleStripDropDownButton,
            this.driversStripDropDownButton,
            this.usersStripDropDownButton,
            this.toolStripDropDownButton5});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1924, 77);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.DimGray;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::DVLD.Properties.Resources.license;
            this.pictureBox1.Location = new System.Drawing.Point(0, 77);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1924, 959);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.toolStripDropDownButton1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripDropDownButton1.Image = global::DVLD.Properties.Resources.Apply;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.ShowDropDownArrow = false;
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(180, 74);
            this.toolStripDropDownButton1.Text = "Applications";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(235, 26);
            this.toolStripMenuItem1.Text = "toolStripMenuItem1";
            // 
            // peopleStripDropDownButton
            // 
            this.peopleStripDropDownButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.peopleStripDropDownButton.Image = global::DVLD.Properties.Resources.People;
            this.peopleStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.peopleStripDropDownButton.Name = "peopleStripDropDownButton";
            this.peopleStripDropDownButton.ShowDropDownArrow = false;
            this.peopleStripDropDownButton.Size = new System.Drawing.Size(137, 74);
            this.peopleStripDropDownButton.Text = "People";
            this.peopleStripDropDownButton.Click += new System.EventHandler(this.peopleStripDropDownButton_Click);
            // 
            // driversStripDropDownButton
            // 
            this.driversStripDropDownButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.driversStripDropDownButton.Image = global::DVLD.Properties.Resources.Driver;
            this.driversStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.driversStripDropDownButton.Name = "driversStripDropDownButton";
            this.driversStripDropDownButton.ShowDropDownArrow = false;
            this.driversStripDropDownButton.Size = new System.Drawing.Size(138, 74);
            this.driversStripDropDownButton.Text = "Drivers";
            this.driversStripDropDownButton.Click += new System.EventHandler(this.driversStripDropDownButton_Click);
            // 
            // usersStripDropDownButton
            // 
            this.usersStripDropDownButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usersStripDropDownButton.Image = global::DVLD.Properties.Resources.Users;
            this.usersStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.usersStripDropDownButton.Name = "usersStripDropDownButton";
            this.usersStripDropDownButton.ShowDropDownArrow = false;
            this.usersStripDropDownButton.Size = new System.Drawing.Size(125, 74);
            this.usersStripDropDownButton.Text = "Users";
            this.usersStripDropDownButton.Click += new System.EventHandler(this.usersStripDropDownButton_Click);
            // 
            // toolStripDropDownButton5
            // 
            this.toolStripDropDownButton5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripDropDownButton5.Image = global::DVLD.Properties.Resources.People;
            this.toolStripDropDownButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton5.Name = "toolStripDropDownButton5";
            this.toolStripDropDownButton5.ShowDropDownArrow = false;
            this.toolStripDropDownButton5.Size = new System.Drawing.Size(213, 74);
            this.toolStripDropDownButton5.Text = "Account Settings";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1924, 1036);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.toolStrip1);
            this.DoubleBuffered = true;
            this.IsMdiContainer = true;
            this.Name = "frmMain";
            this.Text = "DVLD";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripDropDownButton peopleStripDropDownButton;
        private System.Windows.Forms.ToolStripDropDownButton driversStripDropDownButton;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton usersStripDropDownButton;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton5;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

