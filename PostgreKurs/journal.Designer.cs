namespace PostgreKurs
{
    partial class journal
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
            this.dvgData = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dvgData)).BeginInit();
            this.SuspendLayout();
            // 
            // dvgData
            // 
            this.dvgData.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dvgData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dvgData.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dvgData.Location = new System.Drawing.Point(0, 0);
            this.dvgData.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dvgData.Name = "dvgData";
            this.dvgData.RowHeadersWidth = 51;
            this.dvgData.RowTemplate.Height = 24;
            this.dvgData.Size = new System.Drawing.Size(699, 553);
            this.dvgData.TabIndex = 10;
            // 
            // journal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(699, 553);
            this.Controls.Add(this.dvgData);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "journal";
            this.Text = "journal";
            this.Load += new System.EventHandler(this.journal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvgData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dvgData;
    }
}