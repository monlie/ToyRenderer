using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSRenderer
{
    [Serializable]
    class Box
    {
        public Vec3d min;
        public Vec3d max;
        public Box()
        {
            min = new Vec3d();max = new Vec3d();
        }
        public float Intersect(Ray ray)
        {
            Plane[] p = new Plane[12];
            p[0] = new Plane(Vec3d.Front, min.x);
            p[1] = new Plane(Vec3d.Front, max.x);
            p[2] = new Plane(Vec3d.Right, min.y);
            p[3] = new Plane(Vec3d.Right, max.y);
            p[4] = new Plane(Vec3d.Up, min.z);
            p[5] = new Plane(Vec3d.Up, max.z);
            p[6] = new Plane(-Vec3d.Front, -min.x);
            p[7] = new Plane(-Vec3d.Front, -max.x);
            p[8] = new Plane(-Vec3d.Right, -min.y);
            p[9] = new Plane(-Vec3d.Right, -max.y);
            p[10] = new Plane(-Vec3d.Up, -min.z);
            p[11] = new Plane(-Vec3d.Up, -max.z);
            float[] t = new float[6];
                for(int i = 0; i < 6; ++i) {
                    float a = p[i].Intersect(ray),b=p[i+6].Intersect(ray);
                    t[i] = a<b?b:a;
                }
            Vec3d intersertpoint = ray.GetFront(t[0]);
            if (!(intersertpoint.y >= min.y-1e-6 && intersertpoint.y <= max.y +1e-6&& intersertpoint.z >= min.z - 1e-6 && intersertpoint.z <= max.z + 1e-6))
                t[0] = -1f;
            intersertpoint = ray.GetFront(t[1]);
            if (!(intersertpoint.y >= min.y - 1e-6 && intersertpoint.y <= max.y + 1e-6 && intersertpoint.z >= min.z - 1e-6 && intersertpoint.z <= max.z + 1e-6))
                t[1] = -1f;
            intersertpoint = ray.GetFront(t[2]);
            if (!(intersertpoint.x >= min.x - 1e-6 && intersertpoint.x <= max.x + 1e-6 && intersertpoint.z >= min.z- 1e-6 && intersertpoint.z <= max.z + 1e-6))
                t[2] = -1f;
            intersertpoint = ray.GetFront(t[3]);
            if (!(intersertpoint.x >= min.x - 1e-6 && intersertpoint.x <= max.x + 1e-6 && intersertpoint.z >= min.z- 1e-6 && intersertpoint.z <= max.z + 1e-6))
                t[3] = -1f;
            intersertpoint = ray.GetFront(t[4]);
            if (!(intersertpoint.x >= min.x - 1e-6 && intersertpoint.x <= max.x + 1e-6 && intersertpoint.y >= min.y- 1e-6 && intersertpoint.y <= max.y + 1e-6))
                t[4] = -1f;
            intersertpoint = ray.GetFront(t[5]);
            if (!(intersertpoint.x >= min.x - 1e-6 && intersertpoint.x <= max.x + 1e-6 && intersertpoint.y >= min.y - 1e-6 && intersertpoint.y <= max.y + 1e-6))
                t[5] = -1f;
            float tmp = float.MaxValue;
            float o=-1f;
            for(int i = 0; i < 6; i++)
            {
                if (t[i] >= 0 && tmp > t[i])
                { o= tmp = t[i]; }

            }
            return o;
        }
    }
}
