namespace DVLD
{
    partial class frmAddUpdatePerson
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
            this.lblAddUpdatePerson = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPersonID = new System.Windows.Forms.Label();
            this.ctrlPersonManager1 = new DVLD.ctrlPersonManager();
            this.SuspendLayout();
            // 
            // lblAddUpdatePerson
            // 
            this.lblAddUpdatePerson.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddUpdatePerson.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblAddUpdatePerson.Location = new System.Drawing.Point(4, 21);
            this.lblAddUpdatePerson.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAddUpdatePerson.Name = "lblAddUpdatePerson";
            this.lblAddUpdatePerson.Size = new System.Drawing.Size(895, 42);
            this.lblAddUpdatePerson.TabIndex = 4;
            this.lblAddUpdatePerson.Text = "Add New Person";
            this.lblAddUpdatePerson.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Person ID:";
            // 
            // lblPersonID
            // 
            this.lblPersonID.AutoSize = true;
            this.lblPersonID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPersonID.Location = new System.Drawing.Point(112, 80);
            this.lblPersonID.Name = "lblPersonID";
            this.lblPersonID.Size = new System.Drawing.Size(38, 20);
            this.lblPersonID.TabIndex = 6;
            this.lblPersonID.Text = "N/A";
            // 
            // ctrlPersonManager1
            // 
            this.ctrlPersonManager1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ctrlPersonManager1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlPersonManager1.Location = new System.Drawing.Point(9, 114);
            this.ctrlPersonManager1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrlPersonManager1.Name = "ctrlPersonManager1";
            this.ctrlPersonManager1.Size = new System.Drawing.Size(890, 409);
            this.ctrlPersonManager1.TabIndex = 7;
            this.ctrlPersonManager1.OnSavePersonComplete += new System.Action<int>(this.ctrlPersonManager1_OnSavePersonComplete);
            this.ctrlPersonManager1.OnClose += new System.Action(this.ctrlPersonManager1_OnClose);
            // 
            // frmAddUpdatePerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(906, 524);
            this.Controls.Add(this.ctrlPersonManager1);
            this.Controls.Add(this.lblPersonID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblAddUpdatePerson);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmAddUpdatePerson";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add New Person";
            this.Load += new System.EventHandler(this.frmAddUpdatePerson_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAddUpdatePerson;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPersonID;
        private ctrlPersonManager ctrlPersonManager1;
    }
}