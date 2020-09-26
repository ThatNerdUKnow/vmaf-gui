namespace vmaf_gui
{
    partial class Form1
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
            this.btnSource = new System.Windows.Forms.Button();
            this.btnCompressed = new System.Windows.Forms.Button();
            this.originalFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.compressedFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.lblSource = new System.Windows.Forms.Label();
            this.lblCompressed = new System.Windows.Forms.Label();
            this.vmafLogo = new System.Windows.Forms.PictureBox();
            this.grpFiles = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.vmafLogo)).BeginInit();
            this.grpFiles.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSource
            // 
            this.btnSource.Location = new System.Drawing.Point(6, 19);
            this.btnSource.Name = "btnSource";
            this.btnSource.Size = new System.Drawing.Size(75, 23);
            this.btnSource.TabIndex = 0;
            this.btnSource.Text = "Source";
            this.btnSource.UseVisualStyleBackColor = true;
            this.btnSource.Click += new System.EventHandler(this.btnSource_Click);
            // 
            // btnCompressed
            // 
            this.btnCompressed.Location = new System.Drawing.Point(6, 61);
            this.btnCompressed.Name = "btnCompressed";
            this.btnCompressed.Size = new System.Drawing.Size(75, 23);
            this.btnCompressed.TabIndex = 1;
            this.btnCompressed.Text = "Compressed";
            this.btnCompressed.UseVisualStyleBackColor = true;
            this.btnCompressed.Click += new System.EventHandler(this.btnCompressed_Click);
            // 
            // originalFileDialog
            // 
            this.originalFileDialog.InitialDirectory = ".";
            this.originalFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.originalFileDialog_FileOk);
            // 
            // compressedFileDialog
            // 
            this.compressedFileDialog.InitialDirectory = ".";
            this.compressedFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.compressedFileDialog_FileOk);
            // 
            // lblSource
            // 
            this.lblSource.AutoSize = true;
            this.lblSource.Location = new System.Drawing.Point(6, 45);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(99, 13);
            this.lblSource.TabIndex = 2;
            this.lblSource.Text = "No source selected";
//            this.lblSource.Click += new System.EventHandler(this.lblSource_Click);
            // 
            // lblCompressed
            // 
            this.lblCompressed.AutoSize = true;
            this.lblCompressed.Location = new System.Drawing.Point(6, 87);
            this.lblCompressed.Name = "lblCompressed";
            this.lblCompressed.Size = new System.Drawing.Size(80, 13);
            this.lblCompressed.TabIndex = 3;
            this.lblCompressed.Text = "No file selected";
//            this.lblCompressed.Click += new System.EventHandler(this.lblCompressed_Click);
            // 
            // vmafLogo
            // 
            this.vmafLogo.BackgroundImage = global::vmaf_gui.Properties.Resources.vmaf_logo;
            this.vmafLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.vmafLogo.Location = new System.Drawing.Point(34, 12);
            this.vmafLogo.Name = "vmafLogo";
            this.vmafLogo.Size = new System.Drawing.Size(160, 131);
            this.vmafLogo.TabIndex = 4;
            this.vmafLogo.TabStop = false;
            // 
            // grpFiles
            // 
            this.grpFiles.Controls.Add(this.btnSource);
            this.grpFiles.Controls.Add(this.btnCompressed);
            this.grpFiles.Controls.Add(this.lblCompressed);
            this.grpFiles.Controls.Add(this.lblSource);
            this.grpFiles.Location = new System.Drawing.Point(12, 149);
            this.grpFiles.Name = "grpFiles";
            this.grpFiles.Size = new System.Drawing.Size(191, 112);
            this.grpFiles.TabIndex = 5;
            this.grpFiles.TabStop = false;
            this.grpFiles.Text = "Select video files";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 267);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(191, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Get VMAF score";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 511);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.grpFiles);
            this.Controls.Add(this.vmafLogo);
            this.Name = "Form1";
            this.Text = "VMAF-GUI";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.vmafLogo)).EndInit();
            this.grpFiles.ResumeLayout(false);
            this.grpFiles.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSource;
        private System.Windows.Forms.Button btnCompressed;
        private System.Windows.Forms.OpenFileDialog originalFileDialog;
        private System.Windows.Forms.OpenFileDialog compressedFileDialog;
        private System.Windows.Forms.Label lblSource;
        private System.Windows.Forms.Label lblCompressed;
        private System.Windows.Forms.PictureBox vmafLogo;
        private System.Windows.Forms.GroupBox grpFiles;
        private System.Windows.Forms.Button button1;
    }
}

