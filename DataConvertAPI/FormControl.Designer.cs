
namespace DataConvertAPI
{
    partial class FormControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormControl));
            this.btn_PendingInbound = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_PendingInbound
            // 
            this.btn_PendingInbound.Location = new System.Drawing.Point(12, 12);
            this.btn_PendingInbound.Name = "btn_PendingInbound";
            this.btn_PendingInbound.Size = new System.Drawing.Size(144, 27);
            this.btn_PendingInbound.TabIndex = 1;
            this.btn_PendingInbound.Text = "Pending Inbound";
            this.btn_PendingInbound.UseVisualStyleBackColor = true;
            this.btn_PendingInbound.Click += new System.EventHandler(this.btn_PendingInbound_Click);
            // 
            // FormControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 144);
            this.Controls.Add(this.btn_PendingInbound);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormControl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Control";
            this.Load += new System.EventHandler(this.FormControl_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_PendingInbound;
    }
}