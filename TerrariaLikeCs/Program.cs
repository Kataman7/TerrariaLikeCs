using Raylib_CsLo;

namespace TerrariaLikeCs
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            Raylib.InitWindow(1280, 720, "TerrariaLike");

            CurrentScene.scene = new MenuScene();
            Scene scene = CurrentScene.scene;

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