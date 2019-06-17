using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSRenderer {
    abstract class Light {
        protected float luminance;

        abstract protected Ray GetRay(Vec3d pos);
        abstract public Vec3d Sample(InterResult inter, Collider c, Ray reflRay);

        protected Vec3d Specular(float s, Vec3d color, Ray lightRay, Ray reflRay) {
            float tmp = reflRay.direction % lightRay.direction;
            if (tmp > 0) return color * s * luminance * (float)Math.Pow(tmp, 30) * 0.3f;
            return Vec3d.Zero;
        }
    }
}
