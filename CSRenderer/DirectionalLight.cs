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
            return new Ray(ox - direction * 1e-6f, -direction);
        }

        public float Sample(InterResult inter, Collider c) {
            Vec3d x = inter.position;
            Ray ray = GetRay(x);
            InterResult shadow = c.Collide(ray);
            if (shadow == null) {
                Vec3d normal = inter.entity.GetNormal(x);
                float tmp = normal % ray.direction;
                if (tmp > 0) return luminance * tmp;
            }
            return 0;
        }
    }
}