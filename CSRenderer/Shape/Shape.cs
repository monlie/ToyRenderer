using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSRenderer {
    interface Shape {
        float Intersect(Ray ray);
        Vec3d GetNormal(Vec3d pos);
        float SDF(Vec3d pos);
    }
}
