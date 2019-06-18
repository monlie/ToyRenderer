using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSRenderer {
    interface Shape {
        float Intersect(Ray ray);
        Vec3d GetNormal(Vec3d pos);
        void GetUV(Vec3d x, out float u, out float v);
        // support CSG in feature
        float SDF(Vec3d pos);
    }
}
