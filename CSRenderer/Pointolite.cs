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
            return new Ray(x + direction * 1e-6f, direction);
        }

        public float Sample(InterResult inter, Collider c) {
            Vec3d x = inter.position;
            Ray ray = GetRay(x);
            InterResult shadow = c.Collide(ray);
            if (shadow == null || shadow.t > 4) {
                Vec3d normal = inter.entity.GetNormal(x);
                float tmp = normal % ray.direction;
                if (tmp > 0) {
                    Vec3d r = x - position;
                    float rr = r % r;
                    return luminance * tmp / rr;
                }
            }
            return 0;
        }
    }
}
