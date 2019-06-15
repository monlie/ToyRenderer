using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSRenderer {
    class Plane : Shape {
        public Vec3d pos;
        public Vec3d normal;

        public Plane(Vec3d n, float l) {
            n.Normalize();
            pos = l * n;
            normal = n;
        }

        public Vec3d GetNormal(Vec3d pos) {
            return normal;
        }

        public float SDF(Vec3d x) {
            return (x - pos) % normal;
        }

        public InterResult Intersect(Ray ray) {
            float tmp = ray.direction % normal;
            if (tmp < 0) {
                float t = ((pos - ray.position) % normal) / tmp;
                if (t >= 0) return new InterResult(t, ray.GetFront(t), this);
            }
            return null;
        }
    }
}
