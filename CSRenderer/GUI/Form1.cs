using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace CSRenderer.GUI {
    public partial class Form1 : Form {
        private int n = 256;
        private Renderer renderer;

        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            Width = n + 17;
            Height = n + 65;
            progressBar1.Width = 4 * n / 5;
            progressBar1.Location = new Point(n/2 - progressBar1.Width/2, n + 8);
            label1.Location = new Point(5, n - 20);
            label2.Location = new Point(n / 2 - label2.Width / 2, n / 2 - label2.Height / 2);
        }

        private void SaveToolBox_Click(object sender, EventArgs e) {
            SaveFileDialog sfd = new SaveFileDialog {
                Title = "请选择要保存的文件路径",
                Filter = "图片文件|*.png|所有文件|*.*"
            };
            sfd.InitialDirectory = Application.StartupPath;
            if (sfd.ShowDialog() == DialogResult.OK) {
                FileStream fs = (FileStream)sfd.OpenFile();
                picRenderResult.Image.Save(fs, System.Drawing.Imaging.ImageFormat.Png);
                fs.Close();
            }
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e) {
            Clipboard.SetImage(picRenderResult.Image);
        }

        private void Form1_Activated(object sender, EventArgs e) {
            if (!backgroundWorker1.IsBusy) {
                backgroundWorker1.RunWorkerAsync();
                Console.WriteLine("123");
                backgroundWorker2.RunWorkerAsync();
            }
        }

        private void PicRenderResult_MouseMove(object sender, MouseEventArgs e) {
            if (picRenderResult.Image != null)
            label1.Text = ((Bitmap)picRenderResult.Image).GetPixel(e.X, e.Y).ToString();
        }

        private void PicRenderResult_MouseLeave(object sender, EventArgs e) {
            label1.Text = "";
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e) {
            BackgroundWorker bgWorker = sender as BackgroundWorker;
            if (picRenderResult.Image == null) {
                renderer = RenderSF.Build();
                var image = renderer.GetImage(n, n);
                bgWorker.ReportProgress(100, image);
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            //if (renderer != null) {
            //    int value = renderer.counter / (n * n);
            //    progressBar1.Value = value;
            //}
            Console.WriteLine("rendering finished!");
            label2.Visible = false;
            progressBar1.Value = 100;
            picRenderResult.Image = (Image)e.UserState;
        }

        private void backgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e) {
            BackgroundWorker bgWorker = sender as BackgroundWorker;
            while (picRenderResult.Image == null) {
                if (renderer != null) {
                    var value = renderer.counter * 100 / (n * n);
                    bgWorker.ReportProgress(value, null);
                    Thread.Sleep(500);
                }
            }
        }
    }
}
