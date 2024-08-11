using Raylib_CsLo;

namespace TerrariaLikeCs
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            Raylib.InitWindow(1280, 720, "TerrariaLike");

            Scene scene = new MainScene();

            while (!Raylib.WindowShouldClose())
            {
                scene.update();
                scene.draw();
            }
            Raylib.CloseWindow();
            Blocks.unloadTexture();
        }
    }
}