﻿namespace CSRenderer.GUI {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.picRenderResult = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SaveToolBox = new System.Windows.Forms.ToolStripMenuItem();
            this.CopyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label2 = new System.Windows.Forms.Label();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.picRenderResult)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // picRenderResult
            // 
            this.picRenderResult.ContextMenuStrip = this.contextMenuStrip1;
            this.picRenderResult.Location = new System.Drawing.Point(0, 0);
            this.picRenderResult.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.picRenderResult.Name = "picRenderResult";
            this.picRenderResult.Size = new System.Drawing.Size(100, 50);
            this.picRenderResult.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picRenderResult.TabIndex = 0;
            this.picRenderResult.TabStop = false;
            this.picRenderResult.MouseLeave += new System.EventHandler(this.PicRenderResult_MouseLeave);
            this.picRenderResult.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PicRenderResult_MouseMove);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveToolBox,
            this.CopyToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(137, 76);
            // 
            // SaveToolBox
            // 
            this.SaveToolBox.Name = "SaveToolBox";
            this.SaveToolBox.Size = new System.Drawing.Size(136, 36);
            this.SaveToolBox.Text = "保存";
            this.SaveToolBox.Click += new System.EventHandler(this.SaveToolBox_Click);
            // 
            // CopyToolStripMenuItem
            // 
            this.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem";
            this.CopyToolStripMenuItem.Size = new System.Drawing.Size(136, 36);
            this.CopyToolStripMenuItem.Text = "复制";
            this.CopyToolStripMenuItem.Click += new System.EventHandler(this.CopyToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(12, 453);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 31);
            this.label1.TabIndex = 1;
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.SystemColors.Control;
            this.progressBar1.Location = new System.Drawing.Point(156, 410);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(200, 15);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 2;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 16.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(119, 195);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(250, 57);
            this.label2.TabIndex = 3;
            this.label2.Text = "Rendering";
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.WorkerReportsProgress = true;
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            this.backgroundWorker2.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker2_ProgressChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 479);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picRenderResult);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "ToyRenderer";
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picRenderResult)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picRenderResult;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem SaveToolBox;
        private System.Windows.Forms.ToolStripMenuItem CopyToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label2;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
    }
}