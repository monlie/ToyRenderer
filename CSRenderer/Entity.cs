using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSRenderer {
    class Entity {
        public Shape shape;
        public float diffuse = 0.4f;
        public float mirror = 0.3f;
        public float specular = 0.3f;
        public Vec3d color;

        public Entity(Shape shape, float d, float m, float s) {
            this.shape = shape;
            diffuse = d;
            mirror = m;
            specular = s;
        }

        public Entity(Shape shape) {
            this.shape = shape;
        }

        public InterResult Intersect(Ray ray) {
            float t = shape.Intersect(ray);
            return t >= 0 ? new InterResult(t, ray.GetFront(t), this) : null;
        }
    }
}
