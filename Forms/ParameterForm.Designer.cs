
namespace ApplicationParameterTest
{
    partial class ParameterForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnRefresh = new System.Windows.Forms.Button();
            this.tcApplicationParam = new System.Windows.Forms.TabControl();
            this.SuspendLayout();
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnRefresh.Location = new System.Drawing.Point(44, 37);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 25);
            this.btnRefresh.TabIndex = 20;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // tcApplicationParam
            // 
            this.tcApplicationParam.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tcApplicationParam.Location = new System.Drawing.Point(44, 77);
            this.tcApplicationParam.Multiline = true;
            this.tcApplicationParam.Name = "tcApplicationParam";
            this.tcApplicationParam.Padding = new System.Drawing.Point(10, 6);
            this.tcApplicationParam.SelectedIndex = 0;
            this.tcApplicationParam.Size = new System.Drawing.Size(1855, 800);
            this.tcApplicationParam.TabIndex = 2;
            this.tcApplicationParam.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tcApplicationParam_DrawItem);
            // 
            // ParameterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 937);
            this.Controls.Add(this.tcApplicationParam);
            this.Controls.Add(this.btnRefresh);
            this.Name = "ParameterForm";
            this.Text = "Applikationsparametrar";
            this.Load += new System.EventHandler(this.AppParamForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TabControl tcApplicationParam;
    }
}

