using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSRenderer {
    [Serializable]
    class Vec3d {
        public static Vec3d Zero = new Vec3d(0f, 0f, 0f);
        public static Vec3d One = new Vec3d(1f, 1f, 1f);
        public static Vec3d Up = new Vec3d(0f, 0f, 1f);
        public static Vec3d Right = new Vec3d(0f, 1f, 0f);
        public static Vec3d Front = new Vec3d(1f, 0f, 0f);

        public float x;
        public float y;
        public float z;

        public Vec3d(float x=0f, float y=0f, float z=0f) {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        // quick inverse square root
        private static unsafe float Qrsqrt(float val) {
            float valhalf = 0.5f * val;
            int i = *(int*)&val;
            i = 0x5f3759df - (i >> 1); // HACK
            val = *(float*)&i;
            val = val * (1.5f - valhalf * val * val);
            val = val * (1.5f - valhalf * val * val);
            return val;
        }

        public static Vec3d operator +(Vec3d v1, Vec3d v2) {
            return new Vec3d(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
        }

        public static Vec3d operator -(Vec3d v1, Vec3d v2) {
            return new Vec3d(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
        }

        public static Vec3d operator -(Vec3d v) {
            return new Vec3d(-v.x, -v.y, -v.z);
        }

        public static Vec3d operator *(Vec3d v1, Vec3d v2) {
            return new Vec3d(v1.x * v2.x, v1.y * v2.y, v1.z * v2.z);
        }

        // right number multiplication
        public static Vec3d operator *(Vec3d v, float k) {
            return new Vec3d(k * v.x, k * v.y, k *v.z);
        }

        // left number multiplication
        public static Vec3d operator *(float k, Vec3d v) {
            return new Vec3d(k * v.x, k * v.y, k * v.z);
        }

        public static Vec3d operator /(Vec3d v, float k) {
            return new Vec3d(v.x / k, v.y / k, v.z / k);
        }

        // v1 dot v2
        public static float operator %(Vec3d v1, Vec3d v2) {
            return v1.x * v2.x + v1.y * v2.y + v1.z * v2.z;
        }

        // v1 cross v2
        public Vec3d Cross(Vec3d v) {
            return new Vec3d(y * v.z - z * v.y, 
                             z * v.x - x * v.z,
                             x * v.y - y * v.x);
        }

        public void Normalize() {
            float rnorm = Qrsqrt(x * x + y * y + z * z);
            x = x * rnorm;
            y = y * rnorm;
            z = z * rnorm;
        }

        public float Norm() {
            float tmp = this % this;
            return tmp * Qrsqrt(tmp);
        }

        public override string ToString() {
            return string.Format("[{0:F}, {1:F}, {2:F}]", x, y, z);
        }
    }
}
