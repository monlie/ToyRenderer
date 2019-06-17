using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CSRenderer {
    class StlLoader {

        private static Vec3d LoadVec(BinaryReader bw) {
            return new Vec3d(bw.ReadSingle(), bw.ReadSingle(), bw.ReadSingle());
        }

        public static Shape[] Load(string path) {
            path = "C:\\Users\\Mon\\Desktop\\BlackHole\\csrender\\CSRenderer\\CSRenderer\\Models\\" + path;
            BinaryReader bw = new BinaryReader(new FileStream(path, FileMode.Open));
            List<Triangle> result = new List<Triangle>();
            Vec3d normal;
            Triangle tri;

            bw.ReadBytes(80);
            uint n = bw.ReadUInt32();
            for (int i = 0; i < n; i++) {
                normal = LoadVec(bw);
                tri = new Triangle(LoadVec(bw), LoadVec(bw), LoadVec(bw));
                result.Add(tri);
                bw.ReadBytes(2);
            }
            bw.Close();

            Console.WriteLine(n);

            return result.ToArray();
        }

        static void Main1(string[] args) {
            Load("Teapot.stl");
            Console.ReadKey();
        }
    }
}