using Raylib_CsLo;

namespace TerrariaLikeCs
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            Raylib.InitWindow(1280, 720, "TerrariaLike");
            Raylib.SetTargetFPS(60);

            World word = new World(1000, 50, 40);
            word.create();

            Player e = new Player(5, 5, word);

            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Raylib.RAYWHITE);

                e.update();

                word.grid.draw();
                Raylib.DrawRectangleRec(e.hitBox, Raylib.BLACK);

                Raylib.DrawFPS(10, 10);

                Raylib.EndDrawing();
            }
            Raylib.CloseWindow();
            Blocks.unloadTexture();
        }
    }
}