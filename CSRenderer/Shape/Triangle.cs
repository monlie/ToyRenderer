using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSRenderer {
    class Triangle : Shape {
        private Vec3d v1;
        private Vec3d v2;
        private Vec3d v3;
        private Vec3d e1;
        private Vec3d e2;
        private Vec3d normal;

        public Triangle(Vec3d v1, Vec3d v2, Vec3d v3) {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
            e1 = v2 - v1;
            e2 = v3 - v1;
            normal = e1.Cross(e2);
            normal.Normalize();
        }

        public Vec3d GetNormal(Vec3d pos) {
            return normal;
        }

        public float SDF(Vec3d pos) {
            return 0f;
        }

        public float Intersect(Ray ray) {
            Vec3d r = ray.direction.Cross(e2);
            Vec3d s = ray.position - v1;
            float a = e1 % r;
            float f = 1 / a;
            Vec3d q = s.Cross(e1);
            float u = s % r;
            if (a > 1e-6f) {
                if (u < 0 || u > a) return -1f;
                float v = ray.direction % q;
                if (v < 0 || u + v > a) return -1f;
                float t = f * (e2 % q);
                return t;
            }
            return -1f;
        }
    }
}
