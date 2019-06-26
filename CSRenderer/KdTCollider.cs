using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSRenderer
{
    class KdTCollider:Collider
    {
        private KdTreeNode tree;
        private List<Entity> worldwithoutplane=new List<Entity>();
        private List<Entity> plane=new List<Entity>();
        public KdTCollider(Entity[] w):base(w) { 
            
            foreach(Entity item in w)
            {
                if (item.shape.GetType() == typeof(Plane))
                {
                    plane.Add(item);
                }
                else
                {
                    worldwithoutplane.Add(item);
                }

            }
            tree = new KdTreeNode(worldwithoutplane);
        }
        public InterResult Collide(Ray ray, KdTreeNode intree = null)
        {
            if (intree == null) intree = tree;
            InterResult inter = null;
            float t = float.MaxValue;
            {
                InterResult tmp;
                foreach (Entity entity in plane)
                {
                    tmp = entity.Intersect(ray);
                    if (tmp != null && tmp.t >= 0 && tmp.t < t)
                    {
                        t = tmp.t;
                        inter = tmp;
                    }
                }
            }
            float intertmp = intree.box.Intersect(ray);
            if (intertmp >= 0)
            {
                if (intree.isLeaf)
                {

                    InterResult tmp;
                    foreach (Entity entity in intree.entities)
                    {
                        tmp = entity.Intersect(ray);
                        if (tmp != null && tmp.t >= 0 && tmp.t < t)
                        {
                            t = tmp.t;
                            inter = tmp;
                        }
                    }
                }
                else
                {
                    InterResult linter = Collide(ray, intree.left), rinter = Collide(ray, intree.right);
                    InterResult tmp = linter;
                    if (tmp != null && tmp.t >= 0 && tmp.t < t)
                    {
                        t = tmp.t;
                        inter = tmp;
                    }
                    tmp = rinter;
                    if (tmp != null && tmp.t >= 0 && tmp.t < t)
                    {
                        t = tmp.t;
                        inter = tmp;
                    }
                }

            }
            return inter;
        }

    }
}
