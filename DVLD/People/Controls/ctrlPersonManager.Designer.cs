namespace DVLD
{
    partial class ctrlPersonManager
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.llblRemove = new System.Windows.Forms.LinkLabel();
            this.llblSetImage = new System.Windows.Forms.LinkLabel();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.rtxtAddress = new System.Windows.Forms.RichTextBox();
            this.rbFemale = new System.Windows.Forms.RadioButton();
            this.rbMale = new System.Windows.Forms.RadioButton();
            this.cbxCountry = new System.Windows.Forms.ComboBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.dtpDateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtNationalNo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtThirdName = new System.Windows.Forms.TextBox();
            this.txtSecondName = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialogForImage = new System.Windows.Forms.OpenFileDialog();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(428, 359);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(109, 38);
            this.btnClose.TabIndex = 58;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(575, 359);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(109, 38);
            this.btnSave.TabIndex = 57;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // llblRemove
            // 
            this.llblRemove.AutoSize = true;
            this.llblRemove.Location = new System.Drawing.Point(805, 316);
            this.llblRemove.Name = "llblRemove";
            this.llblRemove.Size = new System.Drawing.Size(68, 20);
            this.llblRemove.TabIndex = 56;
            this.llblRemove.TabStop = true;
            this.llblRemove.Text = "Remove";
            this.llblRemove.Visible = false;
            this.llblRemove.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblRemove_LinkClicked);
            // 
            // llblSetImage
            // 
            this.llblSetImage.AutoSize = true;
            this.llblSetImage.Location = new System.Drawing.Point(706, 316);
            this.llblSetImage.Name = "llblSetImage";
            this.llblSetImage.Size = new System.Drawing.Size(83, 20);
            this.llblSetImage.TabIndex = 55;
            this.llblSetImage.TabStop = true;
            this.llblSetImage.Text = "Set Image";
            this.llblSetImage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblSetImage_LinkClicked);
            // 
            // pbImage
            // 
            this.pbImage.Image = global::DVLD.Properties.Resources.Male;
            this.pbImage.Location = new System.Drawing.Point(710, 111);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(163, 182);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImage.TabIndex = 54;
            this.pbImage.TabStop = false;
            // 
            // rtxtAddress
            // 
            this.rtxtAddress.Location = new System.Drawing.Point(149, 257);
            this.rtxtAddress.Name = "rtxtAddress";
            this.rtxtAddress.Size = new System.Drawing.Size(535, 96);
            this.rtxtAddress.TabIndex = 53;
            this.rtxtAddress.Text = "";
            // 
            // rbFemale
            // 
            this.rbFemale.AutoSize = true;
            this.rbFemale.Location = new System.Drawing.Point(232, 161);
            this.rbFemale.Name = "rbFemale";
            this.rbFemale.Size = new System.Drawing.Size(80, 24);
            this.rbFemale.TabIndex = 52;
            this.rbFemale.Text = "Female";
            this.rbFemale.UseVisualStyleBackColor = true;
            // 
            // rbMale
            // 
            this.rbMale.AutoSize = true;
            this.rbMale.Checked = true;
            this.rbMale.Location = new System.Drawing.Point(149, 161);
            this.rbMale.Name = "rbMale";
            this.rbMale.Size = new System.Drawing.Size(61, 24);
            this.rbMale.TabIndex = 51;
            this.rbMale.TabStop = true;
            this.rbMale.Text = "Male";
            this.rbMale.UseVisualStyleBackColor = true;
            this.rbMale.CheckedChanged += new System.EventHandler(this.rbMale_CheckedChanged);
            // 
            // cbxCountry
            // 
            this.cbxCountry.FormattingEnabled = true;
            this.cbxCountry.Location = new System.Drawing.Point(521, 206);
            this.cbxCountry.Name = "cbxCountry";
            this.cbxCountry.Size = new System.Drawing.Size(163, 28);
            this.cbxCountry.TabIndex = 50;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(521, 158);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(163, 26);
            this.txtPhone.TabIndex = 49;
            // 
            // dtpDateOfBirth
            // 
            this.dtpDateOfBirth.CustomFormat = "";
            this.dtpDateOfBirth.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateOfBirth.Location = new System.Drawing.Point(521, 111);
            this.dtpDateOfBirth.Name = "dtpDateOfBirth";
            this.dtpDateOfBirth.Size = new System.Drawing.Size(163, 26);
            this.dtpDateOfBirth.TabIndex = 48;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(374, 209);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(76, 20);
            this.label12.TabIndex = 47;
            this.label12.Text = "Country:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(374, 111);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(120, 20);
            this.label11.TabIndex = 46;
            this.label11.Text = "Date Of Birth:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(374, 161);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 20);
            this.label10.TabIndex = 45;
            this.label10.Text = "Phone:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(149, 209);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(163, 26);
            this.txtEmail.TabIndex = 44;
            // 
            // txtNationalNo
            // 
            this.txtNationalNo.Location = new System.Drawing.Point(149, 108);
            this.txtNationalNo.Name = "txtNationalNo";
            this.txtNationalNo.Size = new System.Drawing.Size(163, 26);
            this.txtNationalNo.TabIndex = 43;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(17, 260);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 20);
            this.label9.TabIndex = 42;
            this.label9.Text = "Address:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(17, 209);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 20);
            this.label8.TabIndex = 41;
            this.label8.Text = "Email:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(17, 161);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 20);
            this.label7.TabIndex = 40;
            this.label7.Text = "Gender:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(17, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 20);
            this.label6.TabIndex = 39;
            this.label6.Text = "National No:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(773, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 20);
            this.label5.TabIndex = 38;
            this.label5.Text = "Last";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(570, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 20);
            this.label4.TabIndex = 37;
            this.label4.Text = "Third";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(381, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 20);
            this.label3.TabIndex = 36;
            this.label3.Text = "Second";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(203, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 20);
            this.label2.TabIndex = 35;
            this.label2.Text = "First";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(710, 59);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(163, 26);
            this.txtLastName.TabIndex = 34;
            // 
            // txtThirdName
            // 
            this.txtThirdName.Location = new System.Drawing.Point(521, 59);
            this.txtThirdName.Name = "txtThirdName";
            this.txtThirdName.Size = new System.Drawing.Size(163, 26);
            this.txtThirdName.TabIndex = 33;
            // 
            // txtSecondName
            // 
            this.txtSecondName.Location = new System.Drawing.Point(331, 59);
            this.txtSecondName.Name = "txtSecondName";
            this.txtSecondName.Size = new System.Drawing.Size(163, 26);
            this.txtSecondName.TabIndex = 32;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(149, 59);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(163, 26);
            this.txtFirstName.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 20);
            this.label1.TabIndex = 30;
            this.label1.Text = "Name:";
            // 
            // openFileDialogForImage
            // 
            this.openFileDialogForImage.FileName = "openFileDialogForImage";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ctrlPersonManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.llblRemove);
            this.Controls.Add(this.llblSetImage);
            this.Controls.Add(this.pbImage);
            this.Controls.Add(this.rtxtAddress);
            this.Controls.Add(this.rbFemale);
            this.Controls.Add(this.rbMale);
            this.Controls.Add(this.cbxCountry);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.dtpDateOfBirth);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtNationalNo);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtThirdName);
            this.Controls.Add(this.txtSecondName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ctrlPersonManager";
            this.Size = new System.Drawing.Size(890, 409);
            this.Load += new System.EventHandler(this.ctrlPersonManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.LinkLabel llblRemove;
        private System.Windows.Forms.LinkLabel llblSetImage;
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.RichTextBox rtxtAddress;
        private System.Windows.Forms.RadioButton rbFemale;
        private System.Windows.Forms.RadioButton rbMale;
        private System.Windows.Forms.ComboBox cbxCountry;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.DateTimePicker dtpDateOfBirth;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtNationalNo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtThirdName;
        private System.Windows.Forms.TextBox txtSecondName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialogForImage;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
