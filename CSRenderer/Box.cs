using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSRenderer
{
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
            Plane[] p = new Plane[6];
            p[0] = new Plane(Vec3d.Front, min.x);
            p[1] = new Plane(Vec3d.Front, max.x);
            p[2] = new Plane(Vec3d.Right, min.y);
            p[3] = new Plane(Vec3d.Right, max.y);
            p[4] = new Plane(Vec3d.Up, min.z);
            p[5] = new Plane(Vec3d.Up, max.z);
            float[] t = new float[6];
            {
                int i = 0;
                foreach (Plane item in p)
                {
                    t[i++] = item.Intersect(ray);
                }
            }
            Vec3d intersertpoint = ray.GetFront(t[0]);
            if (!(intersertpoint.y >= min.y && intersertpoint.y <= max.y && intersertpoint.z >= min.z && intersertpoint.z <= max.z))
                t[0] = -1;
            intersertpoint = ray.GetFront(t[1]);
            if (!(intersertpoint.y >= min.y && intersertpoint.y <= max.y && intersertpoint.z >= min.z && intersertpoint.z <= max.z))
                t[1] = -1;
            intersertpoint = ray.GetFront(t[2]);
            if (!(intersertpoint.x >= min.x && intersertpoint.x <= max.x && intersertpoint.z >= min.z && intersertpoint.z <= max.z))
                t[2] = -1;
            intersertpoint = ray.GetFront(t[3]);
            if (!(intersertpoint.x >= min.x && intersertpoint.x <= max.x && intersertpoint.z >= min.z && intersertpoint.z <= max.z))
                t[3] = -1;
            intersertpoint = ray.GetFront(t[4]);
            if (!(intersertpoint.x >= min.x && intersertpoint.x <= max.x && intersertpoint.y >= min.y && intersertpoint.y <= max.y))
                t[4] = -1;
            intersertpoint = ray.GetFront(t[5]);
            if (!(intersertpoint.x >= min.x && intersertpoint.x <= max.x && intersertpoint.y >= min.y && intersertpoint.y <= max.y))
                t[5] = -1;
            float tmp = float.MaxValue;
            bool isinter = false;
            for(int i = 0; i < 6; i++)
            {
                if (t[i] >= 0 && tmp > t[i])
                { isinter = true; tmp = t[i]; }

            }
            return isinter?tmp:-1;
        }
    }
}
