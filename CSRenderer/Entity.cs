using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSRenderer {
    class Entity {
        public Shape shape;
        public float diffuse = 0.3f;
        public float mirror = 0.5f;
        public float specular = 0.2f;
        public Vec3d color = new Vec3d(1f, 1f, 1f);

        public Entity(Shape shape, Vec3d color, float d, float m, float s) {
            this.shape = shape;
            this.color = color;
            diffuse = d;
            mirror = m;
            specular = s;
        }

        public Entity(Shape shape) {
            this.shape = shape;
        }

        public Entity(Shape shape, Vec3d color) {
            this.shape = shape;
            this.color = color;
        }

        public InterResult Intersect(Ray ray) {
            float t = shape.Intersect(ray);
            return t >= 0 ? new InterResult(t, ray.GetFront(t), this) : null;
        }
    }
}
