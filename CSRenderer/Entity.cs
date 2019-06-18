using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSRenderer {
    class Entity {
        public Shape shape;
        public float diffuse = 0.9f;
        public float mirror = 0f;
        public float specular = 0.1f;
        public Vec3d color = new Vec3d(1f, 1f, 1f);
        public Mapping mapping = null;

        public Entity(Shape shape, Vec3d color, float d, float m, float s) {
            this.shape = shape;
            this.color = color;
            diffuse = d;
            mirror = m;
            specular = s;
        }

        public Entity(Shape shape, Mapping map, float d, float m, float s) {
            this.shape = shape;
            mapping = map;
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

        public Entity(Shape shape, Mapping m) {
            this.shape = shape;
            mapping = m;
        }

        public InterResult Intersect(Ray ray) {
            float t = shape.Intersect(ray);
            return t >= 0 ? new InterResult(t, ray.GetFront(t), this) : null;
        }

        public Vec3d GetColor(Vec3d x) {
            if (mapping == null) return color;
            shape.GetUV(x, out float u, out float v);
            return mapping.GetColor(u, 1-v);
        }
    }
}
