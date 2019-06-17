using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSRenderer {
    class KdTreeNode {
        public List<Entity> entities;
        public bool isLeaf;
        public byte axis;
        public float position;

        public float Intersect(Ray ray) {
            return 0f;
        }
    }
}
