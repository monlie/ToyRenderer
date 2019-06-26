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

        private float max(float n1, float n2, float n3)
        {
            float o = 0;
            o = (n1 < n2) ? n2 : n1;
            o = (o < n3) ? n3 : o;
            return o;
        }
        private float min(float n1, float n2, float n3)
        {
            float o = 0;
            o = (n1 > n2) ? n2 : n1;
            o = (o > n3) ? n3 : o;
            return o;
        }

        public Triangle(Vec3d v1, Vec3d v2, Vec3d v3) {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
            e1 = v2 - v1;
            e2 = v3 - v1;
            normal = e1.Cross(e2);
            normal.Normalize();
            box = new Box();
            box.min.x = min(v1.x, v2.x, v3.x);
            box.min.y = min(v1.y, v2.y, v3.y);
            box.min.z = min(v1.z, v2.z, v3.z);
            box.max.x = max(v1.x, v2.x, v3.x);
            box.max.y = max(v1.y, v2.y, v3.y);
            box.max.z = max(v1.z, v2.z, v3.z);
        }

        public override Vec3d GetNormal(Vec3d pos) {
            return normal;
        }

        public override float SDF(Vec3d pos) {
            return 0f;
        }

        public override float Intersect(Ray ray) {
            Vec3d r = ray.direction.Cross(e2);
            Vec3d s = ray.position - v1;
            float a = e1 % r;
            float f = 1 / a;
            Vec3d q = s.Cross(e1);
            float u = s % r;
            if (a > 1e-5f) {
                if (u < 0 || u > a) return -1f;
                float v = ray.direction % q;
                if (v < 0 || u + v > a) return -1f;
                float t = f * (e2 % q);
                return t;
            }
            if (a < 1e-5f) {
                if (u > 0 || u < a) return -1f;
                float v = ray.direction % q;
                if (v > 0 || u + v < a) return -1f;
                float t = f * (e2 % q);
                return t;
            }
            return -1f;
        }

        public override string ToString() {
            return v1.ToString() + v2.ToString() + v3.ToString();
        }

        public override void GetUV(Vec3d x, out float u, out float v) {
            u = 0f;
            v = 0f;
        }
    }
}
