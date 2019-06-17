using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CSRenderer {
    class Renderer {
        private Collider collider;
        private Light[] lights;
        private PerspectiveCamera camera;

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

                // reflection
                if (inter.entity.mirror > 1e-4 && times < 5) {
                    color += inter.entity.mirror * Trace(reflRay, times + 1);
                }

                // diffuse reflection
                foreach (Light l in lights) { color += l.Sample(inter, collider, reflRay); }
            }
            return color;
        }

        public float[,,] Render(int rx, int ry) {
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

        public float[,,] ParaRender(int rx, int ry) {
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

        public void SavePicture(int rx, int ry) {
            float[,,] photo = ParaRender(rx, ry);
            StreamWriter sw = new StreamWriter("pic.moe", false);
            sw.WriteLine(string.Format("{0} {1}", rx, ry));
            for (int j = 0; j < ry; j++) {
                for (int i = 0; i < rx; i++) {
                    sw.Write("{0:F2} ", photo[j, i, 0]);
                }
                sw.WriteLine();
            }
            sw.Close();
        }
    }
}
