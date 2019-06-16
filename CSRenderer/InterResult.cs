using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSRenderer {
    class InterResult {
        public static InterResult None = new InterResult(0, null, null);
        public readonly float t;
        public readonly Vec3d position;
        public readonly Entity entity;

        public InterResult(float t, Vec3d p, Entity e) {
            this.t = t;
            position = p;
            entity = e;
        }
    }
}