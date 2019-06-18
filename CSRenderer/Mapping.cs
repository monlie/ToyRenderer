using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;

namespace CSRenderer {
    class Mapping {
        private Vec3d[,] image;
        private int width;
        private int height;

        private static Vec3d Color2Vec3d(Color color) {
            return new Vec3d(color.R / 255f, color.G / 255f, color.B / 255f);
        }

        private static Vec3d BiInterpolation(Vec3d a, Vec3d b, Vec3d c, Vec3d d, float u, float v) {
            float x = 1 - u;
            float y = 1 - v;
            return a * x * y + b * u * y + c * u * v + d * x * v;
        }

        public Mapping(string path) {
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            Bitmap bmp = new Bitmap(fs);
            fs.Close();
            width = bmp.Width;
            height = bmp.Height;
            image = new Vec3d[height, width];
            for (int i = 0; i < width; i++) {
                for (int j = 0; j < height; j++) {
                    image[j, i] = Color2Vec3d(bmp.GetPixel(i, j));
                }
            }
        }

        public Vec3d GetColor(float u, float v) {
            u *= width - 1;
            v *= height - 1;
            int xUp, xDown, yUp, yDown;
            xUp = (int)Math.Ceiling(u);
            xDown = (int)u;
            yUp = (int)Math.Ceiling(v);
            yDown = (int)v;
            u -= xDown;
            v -= yDown;
            return BiInterpolation(image[yDown, xDown],
                                   image[yDown, xUp],
                                   image[yUp, xUp],
                                   image[yUp, xDown],
                                   u, v);
        }
    }
}
