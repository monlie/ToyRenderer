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
            Vec3d pos = GetFront(inter.t + 1e-3f);

            Vec3d normal = inter.entity.shape.GetNormal(pos);
            Vec3d tmp = direction - normal % direction * normal;
            tmp = 2 * tmp - direction;
            tmp.Normalize();
            return new Ray(pos, tmp);
        }

        public Ray Refract(InterResult inter, out bool isBack) {
            Vec3d pos = GetFront(inter.t + 1e-3f);
            Vec3d normal = inter.entity.shape.GetNormal(inter.position);
            float rate = inter.entity.refraction;
            float tmp = direction % normal;
            isBack = true;
            // out to inner
            if (tmp < 0) {
                isBack = false;
                rate = 1 / rate;
                tmp = -tmp;
                normal = -normal;
            }
            float squarecos = 1 - rate * rate * (1 - tmp * tmp);
            if (squarecos <= 0) return null;
            Vec3d d = rate * direction - (rate * tmp - (float)Math.Sqrt(squarecos)) * normal;
            return new Ray(pos, d);
        }
    }
}
