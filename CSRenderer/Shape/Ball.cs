using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSRenderer {
    class Ball : Shape {
        private Vec3d center;
        private float r;

        public Ball(Vec3d c, float r) {
            center = c;
            this.r = r;
        }

        public Vec3d GetNormal(Vec3d pos) {
            return (pos - center) / r;
        }

        public float SDF(Vec3d pos) {
            return (pos - center).Norm() - r;
        }

        public float Intersect(Ray ray) {
            Vec3d d = ray.position - center;
            float a = ray.direction % ray.direction;
            float b = 2 * ray.direction % d;
            float c = d % d - r * r;
            float delta = b * b - 4 * a * c;
            if (delta >= 0) {
                delta = (float)Math.Sqrt(delta);
                float tmp = -b - delta;
                if (tmp >= 0) {
                    tmp /= 2 * a;
                    return tmp;
                }
                tmp = (-b + delta) / (2 * a);
                return tmp;
            }
            return -1f;
        }
    }
}
