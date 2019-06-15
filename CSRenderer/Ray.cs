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

        public Ray Reflect(InterResult inter) {
            Vec3d pos = inter.position;

            Vec3d normal = inter.entity.GetNormal(pos);
            Vec3d tmp = direction - normal % direction * normal;
            tmp = 2 * tmp - direction;
            tmp.Normalize();
            return new Ray(pos, tmp);
        }
    }
}
