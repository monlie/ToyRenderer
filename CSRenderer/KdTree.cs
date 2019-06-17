using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSRenderer {
    class KdTree {
        private InterResult Intersect(Ray ray, KdTreeNode node) {
            // nothing
            if (node.Intersect(ray) < 0) return null;
            // leaf node
            if (node.isLeaf) {
                float t = 100000;
                InterResult inter = null;
                InterResult tmp;
                foreach (Entity entity in node.entities) {
                    tmp = entity.Intersect(ray);
                    if (tmp != null && tmp.t >= 0 && tmp.t < t) {
                        t = tmp.t;
                        inter = tmp;
                    }
                }
                return inter;
            }
            // subspace
            return null;
        }
    }
}
