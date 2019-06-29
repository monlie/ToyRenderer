using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSRenderer {
    class RenderSF {
        public static Renderer Build() {
            Plane p1 = new Plane(new Vec3d(0f, 0f, 1f), -0.2f);
            Plane p2 = new Plane(new Vec3d(0f, 1f, 0f), -0.8f);
            Plane p3 = new Plane(new Vec3d(1f, 0f, 0f), -1.7f);

            Light dl1 = new DirectionalLight(new Vec3d(-1f, -1f, -1f), 50f);
            Light dl2 = new DirectionalLight(new Vec3d(1f, 1f, -1f), 30f);
            Light dl3 = new DirectionalLight(new Vec3d(-1f, 0f, -1f), 20f);
            Light pl1 = new Pointolite(new Vec3d(0f, -10f, 120f), 100f);

            Light[] light = new Light[] { dl2, dl3, pl1};

            PerspectiveCamera camera = new PerspectiveCamera(new Vec3d(50f, -40f, 75f),
                                                             new Vec3d(-1f, 1.5f, -0.4f),
                                                             new Vec3d(0f, 0f, 1f),
                                                             120f);
            List<Entity> scenes = new List<Entity>();
            foreach (Shape shape in StlLoader.Load("SF.stl")) {
                scenes.Add(new Entity(shape, new Vec3d(0f, 0.5f, 1f), 0.3f, 0f, 0.1f, 1.3f));
            }

<<<<<<< HEAD:CSRenderer/RenderSF.cs
            Mapping m1 = new Mapping("C:\\Users\\wrvsrx\\OneDrive\\Document\\project\\graph\\ToyRenderer\\CSRenderer\\Mappings\\weathered-steel-zaragoza.jpg");
            Mapping m2 = new Mapping("C:\\Users\\wrvsrx\\OneDrive\\Document\\project\\graph\\ToyRenderer\\CSRenderer\\Mappings\\granite-rainscreen-cladding-aveiro.jpg");
=======
            //Mapping m1 = new Mapping("C:\\Users\\wrvsrx\\OneDrive\\Document\\project\\graph\\ToyRenderer\\CSRenderer\\Mappings\\weathered-steel-zaragoza.jpg");
            //Mapping m2 = new Mapping("C:\\Users\\wrvsrx\\OneDrive\\Document\\project\\graph\\ToyRenderer\\CSRenderer\\Mappings\\granite-rainscreen-cladding-aveiro.jpg");
>>>>>>> kd:CSRenderer/RenderTest.cs
            // Mapping nm1 = new Mapping("C:\\Users\\Mon\\Desktop\\BlackHole\\csrender\\CSRenderer\\CSRenderer\\Mappings\\brick_NRM.png");
            Mapping m1 = null,m2=null,nm1=null;
            scenes.Add(new Entity(new Plane(new Vec3d(0f, 0f, 1f), 0f, 90, 64, null), m2, 1f, 0f, 0f));
            scenes.Add(new Entity(new Plane(new Vec3d(0f, -1f, 0f), -40f, 75, 90, null), m1));
            scenes.Add(new Entity(new Plane(new Vec3d(1f, 0f, 0f), -110f, 75, 90, null), m1));

            Renderer renderer = new Renderer(scenes.ToArray(), light, camera);
            return renderer;
        }
    }
}
