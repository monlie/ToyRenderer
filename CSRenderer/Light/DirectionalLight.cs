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

        protected override Vec3d Diffuse(InterResult inter, Ray lightRay) {
            Entity entity= inter.entity;
            Vec3d x = inter.position;
            Vec3d normal = entity.shape.GetNormal(x);
            float tmp = normal % lightRay.direction;
            if (tmp > 0) return entity.color * entity.diffuse * luminance * tmp;
            return Vec3d.Zero;
        }
    }
}