using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSRenderer {
    class Program {
        [STAThread]
        static void Main(string[] args) {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GUI.Form1());
            //Box box=new Box();
            //box.min = Vec3d.Zero;
            //box.max = Vec3d.One;
            //Ray ray = new Ray(new Vec3d(-0.5f, 0.5f, 0.5f), Vec3d.Front);
            //Console.WriteLine("{0}", box.Intersect(ray));


        }
    }
}
