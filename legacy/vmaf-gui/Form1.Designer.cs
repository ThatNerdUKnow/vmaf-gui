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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.prgProgress = new System.Windows.Forms.ProgressBar();
            this.lblProgress = new System.Windows.Forms.Label();
            this.cmbModel = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
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
            // 
            // lblCompressed
            // 
            this.lblCompressed.AutoSize = true;
            this.lblCompressed.Location = new System.Drawing.Point(6, 87);
            this.lblCompressed.Name = "lblCompressed";
            this.lblCompressed.Size = new System.Drawing.Size(80, 13);
            this.lblCompressed.TabIndex = 3;
            this.lblCompressed.Text = "No file selected";
            // 
            // vmafLogo
            // 
            this.vmafLogo.BackgroundImage = global::vmaf_gui.Properties.Resources.vmaf_logo;
            this.vmafLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.vmafLogo.Location = new System.Drawing.Point(72, 12);
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
            this.grpFiles.Size = new System.Drawing.Size(272, 112);
            this.grpFiles.TabIndex = 5;
            this.grpFiles.TabStop = false;
            this.grpFiles.Text = "Select video files";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 301);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(272, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Get VMAF score";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // prgProgress
            // 
            this.prgProgress.Location = new System.Drawing.Point(12, 331);
            this.prgProgress.Maximum = 4;
            this.prgProgress.Name = "prgProgress";
            this.prgProgress.Size = new System.Drawing.Size(272, 23);
            this.prgProgress.Step = 1;
            this.prgProgress.TabIndex = 11;
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(12, 403);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(0, 13);
            this.lblProgress.TabIndex = 12;
            // 
            // cmbModel
            // 
            this.cmbModel.FormattingEnabled = true;
            this.cmbModel.Location = new System.Drawing.Point(95, 267);
            this.cmbModel.Name = "cmbModel";
            this.cmbModel.Size = new System.Drawing.Size(189, 21);
            this.cmbModel.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 270);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "VMAF Model:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(305, 420);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbModel);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.prgProgress);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.grpFiles);
            this.Controls.Add(this.vmafLogo);
            this.MaximumSize = new System.Drawing.Size(321, 459);
            this.MinimumSize = new System.Drawing.Size(321, 459);
            this.Name = "Form1";
            this.Text = "VMAF-GUI";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.vmafLogo)).EndInit();
            this.grpFiles.ResumeLayout(false);
            this.grpFiles.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ProgressBar prgProgress;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.ComboBox cmbModel;
        private System.Windows.Forms.Label label1;
    }
}

