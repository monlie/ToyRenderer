using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSRenderer {
    class Ray {
        public Vec3d position;
        public Vec3d direction;

        public Ray(Vec3d pos, Vec3d d) {
            position = pos;
            direction = d;
        }

        public Vec3d GetFront(float t) {
            return position + t * direction;
        }
    }
}
