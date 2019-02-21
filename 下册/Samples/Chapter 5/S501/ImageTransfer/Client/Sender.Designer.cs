namespace Client
{
    partial class Sender
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.buttonSend = new System.Windows.Forms.Button();
            this.checkBoxReliableSession = new System.Windows.Forms.CheckBox();
            this.checkBoxOrdered = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(524, 520);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(524, 520);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // buttonOpen
            // 
            this.buttonOpen.Location = new System.Drawing.Point(12, 546);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(75, 23);
            this.buttonOpen.TabIndex = 1;
            this.buttonOpen.Text = "Browse";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // buttonSend
            // 
            this.buttonSend.Enabled = false;
            this.buttonSend.Location = new System.Drawing.Point(93, 546);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(75, 23);
            this.buttonSend.TabIndex = 2;
            this.buttonSend.Text = "Send";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // checkBoxReliableSession
            // 
            this.checkBoxReliableSession.AutoSize = true;
            this.checkBoxReliableSession.Location = new System.Drawing.Point(301, 546);
            this.checkBoxReliableSession.Name = "checkBoxReliableSession";
            this.checkBoxReliableSession.Size = new System.Drawing.Size(104, 17);
            this.checkBoxReliableSession.TabIndex = 3;
            this.checkBoxReliableSession.Text = "Reliable Session";
            this.checkBoxReliableSession.UseVisualStyleBackColor = true;
            this.checkBoxReliableSession.CheckedChanged += new System.EventHandler(this.checkBoxReliableSession_CheckedChanged);
            // 
            // checkBoxOrdered
            // 
            this.checkBoxOrdered.AutoSize = true;
            this.checkBoxOrdered.Location = new System.Drawing.Point(408, 546);
            this.checkBoxOrdered.Name = "checkBoxOrdered";
            this.checkBoxOrdered.Size = new System.Drawing.Size(105, 17);
            this.checkBoxOrdered.TabIndex = 4;
            this.checkBoxOrdered.Text = "Ordered Delivery";
            this.checkBoxOrdered.UseVisualStyleBackColor = true;
            this.checkBoxOrdered.CheckedChanged += new System.EventHandler(this.checkBoxOrdered_CheckedChanged);
            // 
            // Sender
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 582);
            this.Controls.Add(this.checkBoxOrdered);
            this.Controls.Add(this.checkBoxReliableSession);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.buttonOpen);
            this.Controls.Add(this.panel1);
            this.Name = "Sender";
            this.Text = "Sender";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.CheckBox checkBoxReliableSession;
        private System.Windows.Forms.CheckBox checkBoxOrdered;
    }
}

