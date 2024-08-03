using Raylib_CsLo;

namespace TerrariaLikeCs
{
    public class BasicScene: Scene
    {
        private Rectangle rectangle;
        private Color color;

        public BasicScene()
        {
            rectangle = new Rectangle(Raylib.GetScreenWidth() / 2 - 100, Raylib.GetScreenHeight() / 2 - 100, 200, 200);
            color = Raylib.WHITE;
            Raylib.SetTargetFPS(60);
        }

        public void update()
        {
            color.r = (byte)((color.r + 1) % 256);
            color.g = (byte)((color.g + 2) % 256);
            color.b = (byte)((color.b + 3) % 256);
        }

        public void draw()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Raylib.RAYWHITE);

            Raylib.DrawRectangleRec(rectangle, color);

            Raylib.EndMode2D();
            Raylib.EndDrawing();
        }

    }
}
