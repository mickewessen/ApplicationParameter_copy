
namespace ApplicationParameterTest
{
    partial class EditParameterBool
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
            this.btnSaveImage = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.richTextBoxnote = new System.Windows.Forms.RichTextBox();
            this.txtboxUpdatedBy = new System.Windows.Forms.TextBox();
            this.txtUpdatedTime = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxCategory = new System.Windows.Forms.ComboBox();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.btnUpload = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtParameterId = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txtCreatedBy = new System.Windows.Forms.TextBox();
            this.label = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label101 = new System.Windows.Forms.Label();
            this.checkboxBool = new ApplicationParameterTest.Models.CustomCheckBoxModel();
            this.btnRemovePicture = new System.Windows.Forms.Button();
            this.txtStringValue = new System.Windows.Forms.TextBox();
            this.txtParameterNameSwe = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.btnSaveDoc = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSaveImage
            // 
            this.btnSaveImage.Location = new System.Drawing.Point(444, 253);
            this.btnSaveImage.Name = "btnSaveImage";
            this.btnSaveImage.Size = new System.Drawing.Size(75, 23);
            this.btnSaveImage.TabIndex = 83;
            this.btnSaveImage.Text = "Spara bild";
            this.btnSaveImage.UseVisualStyleBackColor = true;
            this.btnSaveImage.Click += new System.EventHandler(this.btnSaveImage_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 141);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 15);
            this.label6.TabIndex = 80;
            this.label6.Text = "Beskrivning";
            // 
            // richTextBoxnote
            // 
            this.richTextBoxnote.Location = new System.Drawing.Point(101, 138);
            this.richTextBoxnote.Name = "richTextBoxnote";
            this.richTextBoxnote.Size = new System.Drawing.Size(250, 150);
            this.richTextBoxnote.TabIndex = 79;
            this.richTextBoxnote.Text = "";
            // 
            // txtboxUpdatedBy
            // 
            this.txtboxUpdatedBy.BackColor = System.Drawing.SystemColors.Control;
            this.txtboxUpdatedBy.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtboxUpdatedBy.Location = new System.Drawing.Point(278, 344);
            this.txtboxUpdatedBy.Name = "txtboxUpdatedBy";
            this.txtboxUpdatedBy.ReadOnly = true;
            this.txtboxUpdatedBy.Size = new System.Drawing.Size(158, 16);
            this.txtboxUpdatedBy.TabIndex = 78;
            // 
            // txtUpdatedTime
            // 
            this.txtUpdatedTime.BackColor = System.Drawing.SystemColors.Control;
            this.txtUpdatedTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUpdatedTime.Location = new System.Drawing.Point(109, 344);
            this.txtUpdatedTime.Name = "txtUpdatedTime";
            this.txtUpdatedTime.ReadOnly = true;
            this.txtUpdatedTime.Size = new System.Drawing.Size(158, 16);
            this.txtUpdatedTime.TabIndex = 77;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 344);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 15);
            this.label5.TabIndex = 76;
            this.label5.Text = "Uppdaterad";
            // 
            // comboBoxCategory
            // 
            this.comboBoxCategory.FormattingEnabled = true;
            this.comboBoxCategory.Location = new System.Drawing.Point(101, 109);
            this.comboBoxCategory.Name = "comboBoxCategory";
            this.comboBoxCategory.Size = new System.Drawing.Size(158, 23);
            this.comboBoxCategory.TabIndex = 75;
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(606, 253);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(19, 23);
            this.txtFileName.TabIndex = 69;
            this.txtFileName.Visible = false;
            // 
            // pictureBox
            // 
            this.pictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox.Location = new System.Drawing.Point(363, 13);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(249, 224);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 68;
            this.pictureBox.TabStop = false;
            this.pictureBox.Click += new System.EventHandler(this.pictureBox_Click);
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(363, 253);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(75, 23);
            this.btnUpload.TabIndex = 67;
            this.btnUpload.Text = "Bläddra";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(203, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 15);
            this.label1.TabIndex = 66;
            this.label1.Text = "På";
            // 
            // txtParameterId
            // 
            this.txtParameterId.BackColor = System.Drawing.SystemColors.Control;
            this.txtParameterId.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtParameterId.Location = new System.Drawing.Point(101, 13);
            this.txtParameterId.Name = "txtParameterId";
            this.txtParameterId.ReadOnly = true;
            this.txtParameterId.Size = new System.Drawing.Size(250, 16);
            this.txtParameterId.TabIndex = 65;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(30, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 15);
            this.label7.TabIndex = 64;
            this.label7.Text = "Id";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(203, 307);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 23);
            this.btnCancel.TabIndex = 63;
            this.btnCancel.Text = "Avbryt";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(97, 307);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 23);
            this.btnUpdate.TabIndex = 62;
            this.btnUpdate.Text = "Spara";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txtCreatedBy
            // 
            this.txtCreatedBy.BackColor = System.Drawing.SystemColors.Control;
            this.txtCreatedBy.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCreatedBy.Location = new System.Drawing.Point(109, 366);
            this.txtCreatedBy.Name = "txtCreatedBy";
            this.txtCreatedBy.ReadOnly = true;
            this.txtCreatedBy.Size = new System.Drawing.Size(158, 16);
            this.txtCreatedBy.TabIndex = 60;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(30, 112);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(51, 15);
            this.label.TabIndex = 57;
            this.label.Text = "Kategori";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 366);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 15);
            this.label4.TabIndex = 56;
            this.label4.Text = "Skapad av";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(70, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 15);
            this.label3.TabIndex = 55;
            this.label3.Text = "Av";
            // 
            // label101
            // 
            this.label101.AutoSize = true;
            this.label101.Location = new System.Drawing.Point(30, 42);
            this.label101.Name = "label101";
            this.label101.Size = new System.Drawing.Size(29, 15);
            this.label101.TabIndex = 53;
            this.label101.Text = "Titel";
            // 
            // checkboxBool
            // 
            this.checkboxBool.AutoSize = true;
            this.checkboxBool.Location = new System.Drawing.Point(97, 70);
            this.checkboxBool.Name = "checkboxBool";
            this.checkboxBool.Padding = new System.Windows.Forms.Padding(6);
            this.checkboxBool.Size = new System.Drawing.Size(89, 31);
            this.checkboxBool.TabIndex = 84;
            this.checkboxBool.Text = "checkBox";
            this.checkboxBool.UseVisualStyleBackColor = true;
            // 
            // btnRemovePicture
            // 
            this.btnRemovePicture.Location = new System.Drawing.Point(525, 253);
            this.btnRemovePicture.Name = "btnRemovePicture";
            this.btnRemovePicture.Size = new System.Drawing.Size(75, 23);
            this.btnRemovePicture.TabIndex = 85;
            this.btnRemovePicture.Text = "Ta bort bild";
            this.btnRemovePicture.UseVisualStyleBackColor = true;
            this.btnRemovePicture.Click += new System.EventHandler(this.btnRemovePicture_Click);
            // 
            // txtStringValue
            // 
            this.txtStringValue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtStringValue.Location = new System.Drawing.Point(512, 344);
            this.txtStringValue.Name = "txtStringValue";
            this.txtStringValue.ReadOnly = true;
            this.txtStringValue.Size = new System.Drawing.Size(100, 16);
            this.txtStringValue.TabIndex = 86;
            this.txtStringValue.Visible = false;
            // 
            // txtParameterNameSwe
            // 
            this.txtParameterNameSwe.Location = new System.Drawing.Point(101, 38);
            this.txtParameterNameSwe.Name = "txtParameterNameSwe";
            this.txtParameterNameSwe.Size = new System.Drawing.Size(250, 23);
            this.txtParameterNameSwe.TabIndex = 87;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(363, 290);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 15);
            this.label2.TabIndex = 88;
            this.label2.Text = "Dokument:";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(363, 311);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(0, 15);
            this.linkLabel1.TabIndex = 89;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // btnSaveDoc
            // 
            this.btnSaveDoc.Location = new System.Drawing.Point(499, 336);
            this.btnSaveDoc.Name = "btnSaveDoc";
            this.btnSaveDoc.Size = new System.Drawing.Size(113, 23);
            this.btnSaveDoc.TabIndex = 90;
            this.btnSaveDoc.Text = "Spara dokument";
            this.btnSaveDoc.UseVisualStyleBackColor = true;
            this.btnSaveDoc.Click += new System.EventHandler(this.btnSaveDoc_Click);
            // 
            // EditParameterBool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(642, 399);
            this.Controls.Add(this.btnSaveDoc);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtParameterNameSwe);
            this.Controls.Add(this.txtStringValue);
            this.Controls.Add(this.btnRemovePicture);
            this.Controls.Add(this.checkboxBool);
            this.Controls.Add(this.btnSaveImage);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.richTextBoxnote);
            this.Controls.Add(this.txtboxUpdatedBy);
            this.Controls.Add(this.txtUpdatedTime);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBoxCategory);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtParameterId);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.txtCreatedBy);
            this.Controls.Add(this.label);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label101);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "EditParameterBool";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit ApplicationParameter";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSaveImage;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.RichTextBox richTextBoxnote;
        public System.Windows.Forms.TextBox txtboxUpdatedBy;
        public System.Windows.Forms.TextBox txtUpdatedTime;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.ComboBox comboBoxCategory;
        public System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtParameterId;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnUpdate;
        public System.Windows.Forms.TextBox txtCreatedBy;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label101;
        public Models.CustomCheckBoxModel checkboxBool;
        private System.Windows.Forms.Button btnRemovePicture;
        public System.Windows.Forms.TextBox txtFileName;
        public System.Windows.Forms.TextBox txtStringValue;
        public System.Windows.Forms.TextBox txtParameterNameSwe;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSaveDoc;
        public System.Windows.Forms.LinkLabel linkLabel1;
    }
}