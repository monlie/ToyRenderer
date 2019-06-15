using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSRenderer {
    class Pointolite : Light{
        private Vec3d position;
        private float luminance;

        public Pointolite(Vec3d pos, float l) {
            position = pos;
            luminance = l;
        }

        private Ray GetRay(Vec3d x) {
            Vec3d direction = position - x;
            direction.Normalize();
            return new Ray(x + direction * 1e-4f, direction);
        }

        public float Sample(InterResult inter, Collider c, Ray reflRay) {
            Vec3d x = inter.position;
            Ray ray = GetRay(x);
            InterResult shadow = c.Collide(ray);
            if (shadow == null || shadow.t > 4) {
                float val = 0f;
                Vec3d normal = inter.entity.GetNormal(x);
                float tmp = normal % ray.direction;
                if (tmp > 0) {
                    Vec3d r = x - position;
                    float rr = r % r;
                    val += luminance * tmp / rr;
                }
                tmp = reflRay.direction % ray.direction;
                if (tmp > 0) val += luminance * (float)Math.Pow(tmp, 20) * 0.3f;
                return val;
            }
            return 0;
        }
    }
}
