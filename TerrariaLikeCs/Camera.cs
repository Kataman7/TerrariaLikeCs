using Raylib_CsLo;
using System.Numerics;

namespace TerrariaLikeCs
{
    public class Camera
    {
        public Camera2D camera;
        private int speed;
        public Player player;
        public bool followPlayer;


        public Camera(Player player, int speed, float zoom, bool followPlayer)
        {
            camera = new Camera2D();
            camera.zoom = zoom;
            this.speed = speed;
            this.followPlayer = followPlayer;
            this.player = player;
        }

        public void update()
        {
            
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
            {
                followPlayer = !followPlayer;
            }
            
            if (followPlayer)
            {
                camera.target.X = player.hitBox.x - Raylib.GetScreenWidth() / 2;
                camera.target.Y = player.hitBox.y - Raylib.GetScreenHeight() / 2;
            }
            else
            {
                if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
                {
                    camera.target.X -= speed;
                }
                if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
                {
                    camera.target.X += speed;
                }
                if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
                {
                    camera.target.Y -= speed;
                }
                if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
                {
                    camera.target.Y += speed;
                }
            }
        }
    }
}
