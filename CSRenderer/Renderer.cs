using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace CSRenderer {
    class Renderer {
        private Collider collider;
        private Light[] lights;
        private PerspectiveCamera camera;
        private bool calcReflection = true;

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

        public Renderer(Entity[] world, Light[] l, PerspectiveCamera c) {
            collider = new Collider(world);
            lights = l;
            camera = c;
        }

        private Vec3d Trace(Ray ray, int times) {
            Vec3d color = Vec3d.Zero;
            InterResult inter = collider.Collide(ray);

            if (inter != null) {
                Ray reflRay = ray.Reflect(inter);
                Entity entity = inter.entity;
                Vec3d entityColor = entity.shape.GetType() != typeof(Plane) ? entity.color : entity.GetColor(inter.position);

                // reflection
                if (inter.entity.mirror > 1e-4 && calcReflection && times < 5) {
                    color += entityColor * inter.entity.mirror * Trace(reflRay, times + 1);
                }

                // diffuse reflection
                foreach (Light l in lights) { color += l.Sample(inter, collider, entityColor, reflRay); }
            }
            return color;
        }

        private float[,,] Render(int rx, int ry) {
            Ray ray;
            Vec3d color;
            float[,,] photo = new float[ry, rx, 3];
            for (int i = 0; i < rx; i++) {
                for (int j = 0; j < ry; j++) {
                    ray = camera.SightLine(i / (float)rx, j / (float)ry);
                    color = Trace(ray, 0);
                    photo[j, i, 0] = color.x;
                    photo[j, i, 1] = color.y;
                    photo[j, i, 2] = color.z;
                }
            }
            return photo;
        }

        private float[,,] ParaRender(int rx, int ry) {
            float[,,] photo = new float[ry, rx, 3];
            Parallel.For(0, rx * ry, idx => {
                int i = idx % rx;
                int j = idx / rx;
                Ray ray = camera.SightLine(i / (float)rx, j / (float)ry);
                Vec3d color = Trace(ray, 0);
                photo[j, i, 0] = color.x;  // Red
                photo[j, i, 1] = color.y;  // Green
                photo[j, i, 2] = color.z;  // Blue
            });
            return photo;
        }

        public Image GetImage(int rx, int ry) {
            int r, g, b;
            float[,,] img = ParaRender(rx, ry);
            float max = matMax(img, rx);
            Bitmap btm = new Bitmap(rx, ry);
            for (int i = 1; i < rx; i++) {
                for (int j = 1; j < ry; j++) {
                    r = Convert.ToInt32(255f * img[j, i, 0] / max);
                    g = Convert.ToInt32(255f * img[j, i, 1] / max);
                    b = Convert.ToInt32(255f * img[j, i, 2] / max);
                    btm.SetPixel(i, ry - j - 1, Color.FromArgb(r, g, b));
                }
            }
            return btm;
        }
    }
}
