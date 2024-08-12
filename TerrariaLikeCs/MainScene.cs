using Raylib_CsLo;
using static System.Formats.Asn1.AsnWriter;
namespace TerrariaLikeCs
{
    public class MainScene: Scene
    {
        private World world;
        private Cursor cursor;
        private Player player;
        private Camera camera;

        public MainScene()
        {
            world = new World(300, 500, 20);
            player = new Player(0, -30, world);
            camera = new Camera(player, 800, 1f, true);
            cursor = new Cursor(world.grid.blockSize, camera);
            Raylib.SetTargetFPS(10000);
            world.entities.Add(player);

            world.create();
        }

        public void update()
        {
            player.update(camera, cursor);
            cursor.update();
            camera.update();
            world.update();
        }

        public void draw()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Raylib.RAYWHITE);
            Raylib.BeginMode2D(camera.camera);

            player.draw();
            world.draw(camera);
            //world.grid.draw();

            Raylib.EndMode2D();
            Raylib.DrawFPS(10, 10);
            cursor.draw();
            player.inventory.draw();
            Raylib.EndDrawing();
        }
    }
}
