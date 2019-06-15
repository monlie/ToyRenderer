using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSRenderer {
    class PerspectiveCamera {
        private static float Pi = 3.141592f;
        private Vec3d viewPoint;
        private Vec3d front;
        private Vec3d right;
        private Vec3d up;
        private float fovScale;
        
        public PerspectiveCamera(Vec3d vp, Vec3d f, Vec3d refUp, float fov) {
            viewPoint = vp;
            f.Normalize();
            front = f;
            right = f.Cross(refUp);
            right.Normalize();
            up = right.Cross(f);
            fovScale = (float)Math.Tan(fov * Pi * 0.5f / 180) * 2;
        }

        public Ray SightLine(float x, float y) {
            Vec3d v = (x - 0.5f) * right * fovScale;
            Vec3d u = (y - 0.5f) * up * fovScale;
            Vec3d direction = v + u + front;
            direction.Normalize();
            return new Ray(viewPoint, direction);
        }
    }
}
