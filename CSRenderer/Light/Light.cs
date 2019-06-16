using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSRenderer {
    abstract class Light {
        protected float luminance;

        abstract protected Ray GetRay(Vec3d pos);
        abstract public float Sample(InterResult inter, Collider c, Ray reflRay);

        protected float Specular(float s, Ray lightRay, Ray reflRay) {
            float tmp = reflRay.direction % lightRay.direction;
            if (tmp > 0) return s * luminance * (float)Math.Pow(tmp, 30) * 0.3f;
            return 0f;
        }
    }
}
