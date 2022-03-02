
namespace ApplicationParameterTest
{
    partial class EditParameterList
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
            this.txtParameterId = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txtCreatedBy = new System.Windows.Forms.TextBox();
            this.txtStringValue = new System.Windows.Forms.TextBox();
            this.txtParameterNameSwe = new System.Windows.Forms.TextBox();
            this.label = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label101 = new System.Windows.Forms.Label();
            this.btnBroweseDocument = new System.Windows.Forms.Button();
            this.semicolonList = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddToList = new System.Windows.Forms.Button();
            this.btnRemoveFromList = new System.Windows.Forms.Button();
            this.txtAddToList = new System.Windows.Forms.TextBox();
            this.comboBoxCategory = new System.Windows.Forms.ComboBox();
            this.txtUpdatedTime = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtboxUpdatedBy = new System.Windows.Forms.TextBox();
            this.richTextBoxnote = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtboxnumValue = new System.Windows.Forms.TextBox();
            this.lbdocumentList = new System.Windows.Forms.Label();
            this.btnRemoveDocument = new System.Windows.Forms.Button();
            this.btnSaveImage = new System.Windows.Forms.Button();
            this.btnRemoveImage = new System.Windows.Forms.Button();
            this.linkLabelDoc = new System.Windows.Forms.LinkLabel();
            this.btnSaveDoc = new System.Windows.Forms.Button();
            this.linkLabelImage = new System.Windows.Forms.LinkLabel();
            this.btnBrowseImage = new System.Windows.Forms.Button();
            this.lbList = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // txtParameterId
            // 
            this.txtParameterId.Location = new System.Drawing.Point(16, 226);
            this.txtParameterId.Name = "txtParameterId";
            this.txtParameterId.ReadOnly = true;
            this.txtParameterId.Size = new System.Drawing.Size(78, 23);
            this.txtParameterId.TabIndex = 31;
            this.txtParameterId.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(207, 536);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(97, 23);
            this.btnCancel.TabIndex = 28;
            this.btnCancel.Text = "Avbryt";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(101, 536);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 23);
            this.btnUpdate.TabIndex = 27;
            this.btnUpdate.Text = "Spara";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txtCreatedBy
            // 
            this.txtCreatedBy.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCreatedBy.Location = new System.Drawing.Point(103, 588);
            this.txtCreatedBy.Name = "txtCreatedBy";
            this.txtCreatedBy.ReadOnly = true;
            this.txtCreatedBy.Size = new System.Drawing.Size(158, 16);
            this.txtCreatedBy.TabIndex = 25;
            // 
            // txtStringValue
            // 
            this.txtStringValue.Location = new System.Drawing.Point(16, 197);
            this.txtStringValue.Name = "txtStringValue";
            this.txtStringValue.ReadOnly = true;
            this.txtStringValue.Size = new System.Drawing.Size(78, 23);
            this.txtStringValue.TabIndex = 23;
            this.txtStringValue.Visible = false;
            // 
            // txtParameterNameSwe
            // 
            this.txtParameterNameSwe.Location = new System.Drawing.Point(101, 19);
            this.txtParameterNameSwe.Name = "txtParameterNameSwe";
            this.txtParameterNameSwe.Size = new System.Drawing.Size(203, 23);
            this.txtParameterNameSwe.TabIndex = 22;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(43, 51);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(51, 15);
            this.label.TabIndex = 21;
            this.label.Text = "Kategori";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 588);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 15);
            this.label4.TabIndex = 20;
            this.label4.Text = "Skapad av";
            // 
            // label101
            // 
            this.label101.AutoSize = true;
            this.label101.Location = new System.Drawing.Point(65, 22);
            this.label101.Name = "label101";
            this.label101.Size = new System.Drawing.Size(29, 15);
            this.label101.TabIndex = 17;
            this.label101.Text = "Titel";
            // 
            // btnBroweseDocument
            // 
            this.btnBroweseDocument.Location = new System.Drawing.Point(9, 459);
            this.btnBroweseDocument.Name = "btnBroweseDocument";
            this.btnBroweseDocument.Size = new System.Drawing.Size(30, 30);
            this.btnBroweseDocument.TabIndex = 34;
            this.btnBroweseDocument.UseVisualStyleBackColor = true;
            this.btnBroweseDocument.Click += new System.EventHandler(this.BrowseDocument);
            // 
            // semicolonList
            // 
            this.semicolonList.FormattingEnabled = true;
            this.semicolonList.ItemHeight = 15;
            this.semicolonList.Location = new System.Drawing.Point(101, 168);
            this.semicolonList.Name = "semicolonList";
            this.semicolonList.Size = new System.Drawing.Size(203, 109);
            this.semicolonList.TabIndex = 38;
            this.semicolonList.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 15);
            this.label2.TabIndex = 39;
            this.label2.Text = "Värde";
            // 
            // btnAddToList
            // 
            this.btnAddToList.Location = new System.Drawing.Point(126, 106);
            this.btnAddToList.Name = "btnAddToList";
            this.btnAddToList.Size = new System.Drawing.Size(75, 56);
            this.btnAddToList.TabIndex = 40;
            this.btnAddToList.UseVisualStyleBackColor = true;
            this.btnAddToList.Click += new System.EventHandler(this.btnAddToList_Click);
            // 
            // btnRemoveFromList
            // 
            this.btnRemoveFromList.Location = new System.Drawing.Point(207, 106);
            this.btnRemoveFromList.Name = "btnRemoveFromList";
            this.btnRemoveFromList.Size = new System.Drawing.Size(75, 56);
            this.btnRemoveFromList.TabIndex = 41;
            this.btnRemoveFromList.UseVisualStyleBackColor = true;
            this.btnRemoveFromList.Click += new System.EventHandler(this.btnRemoveFromList_Click);
            // 
            // txtAddToList
            // 
            this.txtAddToList.Location = new System.Drawing.Point(101, 77);
            this.txtAddToList.Name = "txtAddToList";
            this.txtAddToList.Size = new System.Drawing.Size(203, 23);
            this.txtAddToList.TabIndex = 42;
            // 
            // comboBoxCategory
            // 
            this.comboBoxCategory.FormattingEnabled = true;
            this.comboBoxCategory.Location = new System.Drawing.Point(101, 48);
            this.comboBoxCategory.Name = "comboBoxCategory";
            this.comboBoxCategory.Size = new System.Drawing.Size(203, 23);
            this.comboBoxCategory.TabIndex = 43;
            // 
            // txtUpdatedTime
            // 
            this.txtUpdatedTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUpdatedTime.Location = new System.Drawing.Point(103, 566);
            this.txtUpdatedTime.Name = "txtUpdatedTime";
            this.txtUpdatedTime.ReadOnly = true;
            this.txtUpdatedTime.Size = new System.Drawing.Size(140, 16);
            this.txtUpdatedTime.TabIndex = 46;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 565);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 15);
            this.label5.TabIndex = 45;
            this.label5.Text = "Uppdaterad";
            // 
            // txtboxUpdatedBy
            // 
            this.txtboxUpdatedBy.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtboxUpdatedBy.Location = new System.Drawing.Point(249, 565);
            this.txtboxUpdatedBy.Name = "txtboxUpdatedBy";
            this.txtboxUpdatedBy.ReadOnly = true;
            this.txtboxUpdatedBy.Size = new System.Drawing.Size(120, 16);
            this.txtboxUpdatedBy.TabIndex = 47;
            // 
            // richTextBoxnote
            // 
            this.richTextBoxnote.Location = new System.Drawing.Point(101, 283);
            this.richTextBoxnote.Name = "richTextBoxnote";
            this.richTextBoxnote.Size = new System.Drawing.Size(203, 150);
            this.richTextBoxnote.TabIndex = 48;
            this.richTextBoxnote.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 281);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 15);
            this.label6.TabIndex = 49;
            this.label6.Text = "Beskrivning";
            // 
            // txtboxnumValue
            // 
            this.txtboxnumValue.Location = new System.Drawing.Point(16, 255);
            this.txtboxnumValue.Name = "txtboxnumValue";
            this.txtboxnumValue.ReadOnly = true;
            this.txtboxnumValue.Size = new System.Drawing.Size(78, 23);
            this.txtboxnumValue.TabIndex = 51;
            this.txtboxnumValue.Visible = false;
            // 
            // lbdocumentList
            // 
            this.lbdocumentList.AutoSize = true;
            this.lbdocumentList.Location = new System.Drawing.Point(31, 436);
            this.lbdocumentList.Name = "lbdocumentList";
            this.lbdocumentList.Size = new System.Drawing.Size(63, 15);
            this.lbdocumentList.TabIndex = 54;
            this.lbdocumentList.Text = "Dokument";
            // 
            // btnRemoveDocument
            // 
            this.btnRemoveDocument.Location = new System.Drawing.Point(71, 459);
            this.btnRemoveDocument.Name = "btnRemoveDocument";
            this.btnRemoveDocument.Size = new System.Drawing.Size(30, 30);
            this.btnRemoveDocument.TabIndex = 127;
            this.btnRemoveDocument.UseVisualStyleBackColor = true;
            this.btnRemoveDocument.Click += new System.EventHandler(this.btnRemoveDocument_Click);
            // 
            // btnSaveImage
            // 
            this.btnSaveImage.Location = new System.Drawing.Point(40, 495);
            this.btnSaveImage.Name = "btnSaveImage";
            this.btnSaveImage.Size = new System.Drawing.Size(30, 30);
            this.btnSaveImage.TabIndex = 122;
            this.btnSaveImage.UseVisualStyleBackColor = true;
            this.btnSaveImage.Click += new System.EventHandler(this.btnSaveImage_Click);
            // 
            // btnRemoveImage
            // 
            this.btnRemoveImage.Location = new System.Drawing.Point(71, 495);
            this.btnRemoveImage.Name = "btnRemoveImage";
            this.btnRemoveImage.Size = new System.Drawing.Size(30, 30);
            this.btnRemoveImage.TabIndex = 123;
            this.btnRemoveImage.UseVisualStyleBackColor = true;
            this.btnRemoveImage.Click += new System.EventHandler(this.btnRemoveImage_Click);
            // 
            // linkLabelDoc
            // 
            this.linkLabelDoc.AutoSize = true;
            this.linkLabelDoc.Location = new System.Drawing.Point(101, 464);
            this.linkLabelDoc.Name = "linkLabelDoc";
            this.linkLabelDoc.Size = new System.Drawing.Size(63, 15);
            this.linkLabelDoc.TabIndex = 125;
            this.linkLabelDoc.TabStop = true;
            this.linkLabelDoc.Text = "Dokument";
            this.linkLabelDoc.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelDoc_LinkClicked);
            // 
            // btnSaveDoc
            // 
            this.btnSaveDoc.Location = new System.Drawing.Point(40, 459);
            this.btnSaveDoc.Name = "btnSaveDoc";
            this.btnSaveDoc.Size = new System.Drawing.Size(30, 30);
            this.btnSaveDoc.TabIndex = 124;
            this.btnSaveDoc.UseVisualStyleBackColor = true;
            this.btnSaveDoc.Click += new System.EventHandler(this.btnSaveDoc_Click);
            // 
            // linkLabelImage
            // 
            this.linkLabelImage.AutoSize = true;
            this.linkLabelImage.Location = new System.Drawing.Point(101, 500);
            this.linkLabelImage.Name = "linkLabelImage";
            this.linkLabelImage.Size = new System.Drawing.Size(63, 15);
            this.linkLabelImage.TabIndex = 126;
            this.linkLabelImage.TabStop = true;
            this.linkLabelImage.Text = "Dokument";
            this.linkLabelImage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelImage_LinkClicked);
            // 
            // btnBrowseImage
            // 
            this.btnBrowseImage.Location = new System.Drawing.Point(9, 495);
            this.btnBrowseImage.Name = "btnBrowseImage";
            this.btnBrowseImage.Size = new System.Drawing.Size(30, 30);
            this.btnBrowseImage.TabIndex = 128;
            this.btnBrowseImage.UseVisualStyleBackColor = true;
            this.btnBrowseImage.Click += new System.EventHandler(this.BrowseImage);
            // 
            // lbList
            // 
            this.lbList.AutoSize = true;
            this.lbList.Location = new System.Drawing.Point(63, 168);
            this.lbList.Name = "lbList";
            this.lbList.Size = new System.Drawing.Size(31, 15);
            this.lbList.TabIndex = 129;
            this.lbList.Text = "Lista";
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(310, 283);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(22, 15);
            this.pictureBox.TabIndex = 130;
            this.pictureBox.TabStop = false;
            // 
            // EditParameterList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 632);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.lbList);
            this.Controls.Add(this.btnBrowseImage);
            this.Controls.Add(this.btnRemoveDocument);
            this.Controls.Add(this.linkLabelImage);
            this.Controls.Add(this.lbdocumentList);
            this.Controls.Add(this.btnSaveDoc);
            this.Controls.Add(this.linkLabelDoc);
            this.Controls.Add(this.txtboxnumValue);
            this.Controls.Add(this.btnRemoveImage);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnSaveImage);
            this.Controls.Add(this.richTextBoxnote);
            this.Controls.Add(this.txtboxUpdatedBy);
            this.Controls.Add(this.txtUpdatedTime);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBoxCategory);
            this.Controls.Add(this.txtAddToList);
            this.Controls.Add(this.btnRemoveFromList);
            this.Controls.Add(this.btnAddToList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.semicolonList);
            this.Controls.Add(this.btnBroweseDocument);
            this.Controls.Add(this.txtParameterId);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.txtCreatedBy);
            this.Controls.Add(this.txtStringValue);
            this.Controls.Add(this.txtParameterNameSwe);
            this.Controls.Add(this.label);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label101);
            this.Name = "EditParameterList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Lista";
            this.Load += new System.EventHandler(this.CharSemicolonForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txtParameterId;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnUpdate;
        public System.Windows.Forms.TextBox txtCreatedBy;
        public System.Windows.Forms.TextBox txtStringValue;
        public System.Windows.Forms.TextBox txtParameterNameSwe;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label101;
        private System.Windows.Forms.Button btnBroweseDocument;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddToList;
        private System.Windows.Forms.Button btnRemoveFromList;
        private System.Windows.Forms.TextBox txtAddToList;
        public System.Windows.Forms.ListBox semicolonList;
        public System.Windows.Forms.ComboBox comboBoxCategory;
        public System.Windows.Forms.TextBox txtUpdatedTime;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtboxUpdatedBy;
        public System.Windows.Forms.RichTextBox richTextBoxnote;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txtboxnumValue;
        private System.Windows.Forms.Label lbdocumentList;
        private System.Windows.Forms.Button btnRemoveDocument;
        private System.Windows.Forms.Button btnSaveImage;
        private System.Windows.Forms.Button btnRemoveImage;
        private System.Windows.Forms.Button btnSaveDoc;
        public System.Windows.Forms.LinkLabel linkLabelDoc;
        public System.Windows.Forms.LinkLabel linkLabelImage;
        private System.Windows.Forms.Button btnBrowseImage;
        private System.Windows.Forms.Label lbList;
        public System.Windows.Forms.PictureBox pictureBox;
    }
}