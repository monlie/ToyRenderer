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

namespace CSRenderer.GUI {
    public partial class Form1 : Form {
        private int n = 256;

        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            Width = n + 17;
            Height = n + 39;
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
            if (picRenderResult.Image == null) {
                Renderer renderer = RenderTest.Build();
                picRenderResult.Image = renderer.GetImage(n, n);
            }
        }

        private void PicRenderResult_MouseMove(object sender, MouseEventArgs e) {
            label1.Text = ((Bitmap)picRenderResult.Image).GetPixel(e.X, e.Y).ToString();
        }

        private void PicRenderResult_MouseLeave(object sender, EventArgs e) {
            label1.Text = "";
        }
    }
}
