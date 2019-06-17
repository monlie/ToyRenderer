using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSRenderer {
    abstract class Light {
        protected float luminance;

        abstract protected Ray GetRay(Vec3d pos);
        abstract protected Vec3d Diffuse(InterResult inter, Ray lightRay);

        protected Vec3d Specular(Entity entity, Ray lightRay, Ray reflRay) {
            float tmp = reflRay.direction % lightRay.direction;
            if (tmp > 0) return entity.color * entity.specular * luminance * (float)Math.Pow(tmp, 30) * 0.3f;
            return Vec3d.Zero;
        }

        public Vec3d Sample(InterResult inter, Collider c, Ray reflRay) {
            Vec3d x = inter.position;
            Entity entity = inter.entity;
            Ray ray = GetRay(x);
            InterResult shadow = c.Collide(ray);
            Vec3d val = Vec3d.Zero;

            // infinite plane cannot hid the light
            if (shadow == null || shadow.entity.shape.GetType() == typeof(Plane)) {
                // diffuse
                Vec3d normal = entity.shape.GetNormal(x);
                val += Diffuse(inter, ray);
                // phong specular
                val += Specular(entity, ray, reflRay);
                return val;
            }
            return val;
        }
    }
}
