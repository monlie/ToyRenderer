namespace CSRenderer.GUI {
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
            this.picRenderResult = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picRenderResult)).BeginInit();
            this.SuspendLayout();
            // 
            // picRenderResult
            // 
            this.picRenderResult.Location = new System.Drawing.Point(0, 0);
            this.picRenderResult.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.picRenderResult.Name = "picRenderResult";
            this.picRenderResult.Size = new System.Drawing.Size(100, 50);
            this.picRenderResult.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picRenderResult.TabIndex = 0;
            this.picRenderResult.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1255, 1015);
            this.Controls.Add(this.picRenderResult);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "ToyRenderer";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picRenderResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picRenderResult;
    }
}