using Raylib_CsLo;

namespace TerrariaLikeCs
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            Raylib.InitWindow(1280, 720, "TerrariaLike");

            CurrentScene.scene = new MenuScene();

            while (!Raylib.WindowShouldClose())
            {
                CurrentScene.scene.update();
                CurrentScene.scene.draw();
            }
            Raylib.CloseWindow();
            Blocks.unloadTexture();
        }
    }
}