using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSRenderer {
    class Plane : Shape {
        public Vec3d pos;
        public Vec3d normal;
        private Vec3d uVec;
        private Vec3d vVec;
        private int width = 50;
        private int height = 50;
        private Mapping normalMapping = null;

        public Plane(Vec3d n, float l) {
            n.Normalize();
            pos = l * n;
            normal = n;

            Vec3d tmp = Vec3d.Up.Cross(normal);
            if (tmp.Norm() < 1e-3) {
                uVec = Vec3d.Right.Cross(normal);
                uVec.Normalize();
            }
            else {
                tmp.Normalize();
                uVec = tmp;
                
            }
            vVec = normal.Cross(uVec);
        }

        public Plane(Vec3d n, float l, int w, int h, Mapping mapping) {
            n.Normalize();
            pos = l * n;
            normal = n;
            normalMapping = mapping;

            Vec3d tmp = Vec3d.Up.Cross(normal);
            if (tmp.Norm() < 1e-3) {
                uVec = Vec3d.Right.Cross(normal);
                uVec.Normalize();
            }
            else {
                tmp.Normalize();
                uVec = tmp;

            }
            vVec = normal.Cross(uVec);

            width = w;
            height = h;
        }

        public Vec3d GetNormal(Vec3d pos) {
            if (normalMapping == null) return normal;
            GetUV(pos, out float u, out float v);
            Vec3d n = normalMapping.GetColor(u, 1-v) - 0.5f * Vec3d.One;
            n = n.x * uVec + n.y * vVec + n.z * normal;
            return 2 * n;
        }

        public float SDF(Vec3d x) {
            return (x - pos) % normal;
        }

        public float Intersect(Ray ray) {
            float tmp = ray.direction % normal;
            if (tmp < 0) {
                float t = ((pos - ray.position) % normal) / tmp;
                if (t >= 0) return t;
            }
            return -1f;
        }

        public void GetUV(Vec3d x, out float u, out float v) {
            x = x - pos;
            u = x % uVec;
            v = x % vVec;
            u /= width;
            v /= height;
            u -= (float)Math.Floor(u);
            v -= (float)Math.Floor(v);
        }
    }
}
