using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSRenderer {
    class DirectionalLight : Light {
        private Vec3d direction;
        private float luminance;

        public DirectionalLight(Vec3d d, float l) {
            d.Normalize();
            direction = d;
            luminance = l;
        }

        private Ray GetRay(Vec3d ox) {
            return new Ray(ox - direction * 1e-4f, -direction);
        }

        public float Sample(InterResult inter, Collider c, Ray reflRay) {
            Vec3d x = inter.position;
            Ray ray = GetRay(x);
            InterResult shadow = c.Collide(ray);
            if (shadow == null) {
                float val = 0f;
                Vec3d normal = inter.entity.GetNormal(x);
                float tmp = normal % ray.direction;
                if (tmp > 0) val += luminance * tmp;

                tmp = reflRay.direction % ray.direction;
                if (tmp > 0) val += luminance * (float)Math.Pow(tmp, 30) * 0.3f;
                return val;
            }
            return 0;
        }
    }
}