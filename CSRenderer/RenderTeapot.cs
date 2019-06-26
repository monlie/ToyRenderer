using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSRenderer {
    class RenderTeapot {
        public static Renderer Build() {
            Plane p1 = new Plane(new Vec3d(0f, 0f, 1f), -0.2f);
            Plane p2 = new Plane(new Vec3d(0f, 1f, 0f), -0.8f);
            Plane p3 = new Plane(new Vec3d(1f, 0f, 0f), -1.7f);

            Light dl1 = new DirectionalLight(new Vec3d(-0.6f, -1f, -1f), 30);
            Light dl2 = new DirectionalLight(new Vec3d(0.6f, 0.8f, -1f), 60);
            Light dl3 = new DirectionalLight(new Vec3d(-1f, 0f, -1f), 20f);
            Light pl1 = new Pointolite(new Vec3d(0f, -10f, 120f), 100f);
            Light pl2 = new Pointolite(new Vec3d(0f, 0f, 28f), 100f);


            Light[] light = new Light[] { dl1, dl2 };

            PerspectiveCamera camera = new PerspectiveCamera(new Vec3d(0f, -11, 6.5f),
                                                             new Vec3d(0f, 1f, 0f),
                                                             new Vec3d(0f, 0f, 1f),
                                                             120f);
            List<Entity> scenes = new List<Entity>();
            foreach (Shape shape in StlLoader.Load("Teapot.stl")) {
                scenes.Add(new Entity(shape, new Vec3d(0f, 0.5f, 1f), 0f, 0f, 0.2f, 1.3f));
            }

            Mapping m1 = new Mapping("C:\\Users\\wrvsrx\\OneDrive\\Document\\project\\graph\\ToyRenderer\\CSRenderer\\Mappings\\weathered-steel-zaragoza.jpg");
            // Mapping m2 = new Mapping("C:\\Users\\Mon\\Desktop\\BlackHole\\csrender\\CSRenderer\\CSRenderer\\Mappings\\granite-rainscreen-cladding-aveiro.jpg");
            // Mapping nm1 = new Mapping("C:\\Users\\Mon\\Desktop\\BlackHole\\csrender\\CSRenderer\\CSRenderer\\Mappings\\brick_NRM.png");
            Mapping m2 = null;
            scenes.Add(new Entity(new Plane(new Vec3d(0f, 0f, 1f), 0f, 90, 64, null), m2, 0.7f, 0.2f, 0.1f));
            scenes.Add(new Entity(new Plane(new Vec3d(0f, 0f, -1f), -30f, 90, 64, null), m2, 1f, 0f, 0f));
            scenes.Add(new Entity(new Plane(new Vec3d(0f, -1f, 0f), -12f, 25, 30, null), m1));
            scenes.Add(new Entity(new Plane(new Vec3d(1f, 0f, 0f), -15f, 25, 30, null), m1));
            scenes.Add(new Entity(new Plane(new Vec3d(-1f, 0f, 0f), -15f, 25, 30, null), m1));

            Renderer renderer = new Renderer(scenes.ToArray(), light, camera);
            return renderer;
        }
    }
}
