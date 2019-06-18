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

        private void Form1_Load(object sender, EventArgs e) {
            Renderer renderer = RenderTest.Build();
            int n = 512;
            picRenderResult.Image = renderer.GetImage(n, n);
            Width = picRenderResult.Width + 17;
            Height = picRenderResult.Height + 39;
        }
    }
}
