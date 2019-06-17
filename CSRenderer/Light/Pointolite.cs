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

        public override Vec3d Sample(InterResult inter, Collider c, Ray reflRay) {
            Vec3d x = inter.position;
            Entity entity = inter.entity;
            Ray ray = GetRay(x);
            InterResult shadow = c.Collide(ray);

            if (shadow == null || shadow.t > 4) {
                Vec3d val = Vec3d.Zero;
                Vec3d normal = entity.shape.GetNormal(x);
                float tmp = normal % ray.direction;
                // diffuse
                if (tmp > 0) {
                    Vec3d r = x - position;
                    float rr = r % r;
                    val += entity.color * entity.diffuse * luminance * tmp / rr;
                }
                // phong specular
                val += Specular(entity.specular, entity.color, ray, reflRay);
                return val;
            }
            return Vec3d.Zero;
        }
    }
}
