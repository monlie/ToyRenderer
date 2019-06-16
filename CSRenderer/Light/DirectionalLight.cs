using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSRenderer {
    class DirectionalLight : Light {
        private Vec3d direction;

        public DirectionalLight(Vec3d d, float l) {
            d.Normalize();
            direction = d;
            luminance = l;
        }

        protected override Ray GetRay(Vec3d ox) {
            return new Ray(ox - direction * 1e-4f, -direction);
        }

        public override float Sample(InterResult inter, Collider c, Ray reflRay) {
            Vec3d x = inter.position;
            Entity entity = inter.entity;
            Ray ray = GetRay(x);
            InterResult shadow = c.Collide(ray);

            if (shadow == null) {
                float val = 0f;
                Vec3d normal = entity.shape.GetNormal(x);
                float tmp = normal % ray.direction;
                // diffuse
                if (tmp > 0) val += entity.diffuse * luminance * tmp;
                // phong specular
                val += Specular(entity.specular, ray, reflRay);
                return val;
            }
            return 0;
        }
    }
}