using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSRenderer {
    [Serializable]
    abstract class Shape{
        abstract public float Intersect(Ray ray);
        abstract public Vec3d GetNormal(Vec3d pos);
        abstract public void GetUV(Vec3d x, out float u, out float v);
        // support CSG in feature
        abstract public float SDF(Vec3d pos);
        public Box box;
    }
}
