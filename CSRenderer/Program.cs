using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSRenderer {
    class Program {

        public static void ExecCmd() {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardInput = true;
            process.Start();

            process.StandardInput.WriteLine("python C:\\Users\\Mon\\Desktop\\BlackHole\\csrender\\CSRenderer\\CSRenderer\\bin\\Debug\\display.py");
            process.StandardInput.AutoFlush = true;
            process.StandardInput.WriteLine("exit");

            process.WaitForExit();
        }

        static void Main(string[] args) {

            //Renderer renderer = RenderTest.Build();
            //int n = 128;
            //renderer.SavePicture(n, n);
            //ExecCmd();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GUI.Form1());
        }
    }
}
