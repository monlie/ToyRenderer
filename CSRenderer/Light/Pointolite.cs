using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSRenderer {
    class Pointolite : Light{
        private Vec3d position;

        public Pointolite(Vec3d pos, float l) {
            position = pos;
            luminance = l;
        }

        protected override Ray GetRay(Vec3d x) {
            Vec3d direction = position - x;
            direction.Normalize();
            return new Ray(x + direction * 1e-4f, direction);
        }

        protected override Vec3d Diffuse(InterResult inter, Ray lightRay) {
            Entity entity = inter.entity;
            Vec3d x = inter.position;
            Vec3d normal = entity.shape.GetNormal(x);
            float tmp = normal % lightRay.direction;
            if (tmp > 0) {
                Vec3d r = x - position;
                float rr = r % r;
                return entity.color * entity.diffuse * luminance * tmp / rr;
            }
            return Vec3d.Zero;
        }
    }
}
