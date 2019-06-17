using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSRenderer {
    class RenderTest {
        public static Renderer Build() {
            Plane p1 = new Plane(new Vec3d(0f, 0f, 1f), -0.2f);
            Plane p2 = new Plane(new Vec3d(0f, 1f, 0f), -0.8f);
            Plane p3 = new Plane(new Vec3d(1f, 0f, 0f), -1.7f);
            Triangle tri = new Triangle(new Vec3d(0f, -0.2f, -0.2f),
                                        new Vec3d(0f, 0.2f, -0.2f),
                                        new Vec3d(0f, 0.2f, 0.4f));
            Triangle tri1 = new Triangle(new Vec3d(0f, 0.2f, -0.2f),
                                         new Vec3d(-0.4f, 0.2f, -0.2f),
                                         new Vec3d(0f, 0.2f, 0.4f));
            Triangle tri2 = new Triangle(new Vec3d(0f, -0.2f, -0.2f),
                                         new Vec3d(0f, 0.2f, 0.4f),
                                         new Vec3d(0f, -0.2f, 0.4f));
            Ball ball1 = new Ball(new Vec3d(0f, 0f, 0f), 0.2f);
            Ball ball2 = new Ball(new Vec3d(-0.4f, 0.45f, 0f), 0.2f);
            Ball ball3 = new Ball(new Vec3d(-1.3f, -0.5f, 0f), 0.2f);
            Light dl1 = new DirectionalLight(new Vec3d(-1f, -1f, -1f), 50f);
            Light dl2 = new DirectionalLight(new Vec3d(1f, 1f, -1f), 30f);
            Light dl3 = new DirectionalLight(new Vec3d(-1f, 0f, -1f), 20f);
            Light pl1 = new Pointolite(new Vec3d(-0.4f, 1f, 2f), 60f);
            Light[] light = new Light[] { dl2, dl3 };
            Shape[] world = new Shape[] { p1, p2, p3, ball1, ball2, ball3 };
            PerspectiveCamera camera = new PerspectiveCamera(new Vec3d(50f, -40f, 75f),
                                                             new Vec3d(-1f, 1.5f, -0.4f),
                                                             new Vec3d(0f, 0f, 1f),
                                                             120f);
            List<Entity> scenes = new List<Entity>();
            foreach (Shape shape in StlLoader.Load("SF.stl")) {
                // Console.WriteLine(shape);
                scenes.Add(new Entity(shape, new Vec3d(0f, 0.5f, 1f), 0.6f, 0f, 0.4f));
            }
            scenes.Add(new Entity(new Plane(new Vec3d(0f, 0f, 1f), 0)));

            Renderer renderer = new Renderer(scenes.ToArray(), light, camera);
            return renderer;
        }
    }
}
