namespace Artech.WcfServices.Service
{
    partial class MonitorForm
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
            this.listBoxExecutionProgress = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listBoxExecutionProgress
            // 
            this.listBoxExecutionProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxExecutionProgress.FormattingEnabled = true;
            this.listBoxExecutionProgress.Location = new System.Drawing.Point(0, 0);
            this.listBoxExecutionProgress.Name = "listBoxExecutionProgress";
            this.listBoxExecutionProgress.Size = new System.Drawing.Size(584, 262);
            this.listBoxExecutionProgress.TabIndex = 1;
            // 
            // MonitorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 262);
            this.Controls.Add(this.listBoxExecutionProgress);
            this.Name = "MonitorForm";
            this.Text = "MonitorForm";
            this.Load += new System.EventHandler(this.MonitorForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxExecutionProgress;
    }
}