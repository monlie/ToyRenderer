using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSRenderer.GUI {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private static float matMax(float[,,] mat, int scale) {
            float max = 0f;
            for (int i = 1; i < scale; i++) {
                for (int j = 1; j < scale; j++) {
                    for (int k = 1; k < 3; k++) {
                        if (mat[j, i, k] > max) max = mat[j, i, k];
                    }
                }
            }
            return max;
        }

        private void Form1_Load(object sender, EventArgs e) {
            Renderer renderer = RenderTest.Build();
            int n = 512;
            int r, g, b;
            float[,,] img = renderer.ParaRender(n, n);
            float max = matMax(img, n);
            Bitmap btm = new Bitmap(n, n);
            for (int i = 1; i < n; i++) {
                for (int j = 1; j < n; j++) {
                    r = Convert.ToInt32(255f * img[j, i, 0] / max);
                    g = Convert.ToInt32(255f * img[j, i, 1] / max);
                    b = Convert.ToInt32(255f * img[j, i, 2] / max);
                    btm.SetPixel(i, n - j - 1, Color.FromArgb(r, g, b));
                }
            }
            picRenderResult.Image = btm;
            Width = picRenderResult.Width + 17;
            Height = picRenderResult.Height + 39;
        }
    }
}
