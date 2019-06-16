using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSRenderer {
    class Collider {
        private readonly Entity[] world;

        public Collider(Entity[] w) { world = w; }

        public InterResult Collide(Ray ray) {
            float t = 100000;
            InterResult inter = null;
            InterResult tmp;
            foreach (Entity entity in world) {
                tmp = entity.Intersect(ray);
                if (tmp != null && tmp.t >= 0 && tmp.t < t) {
                    t = tmp.t;
                    inter = tmp;
                }
            }
            return inter;
        }

    }
}
