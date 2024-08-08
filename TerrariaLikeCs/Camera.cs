using Raylib_CsLo;
using System.Numerics;

namespace TerrariaLikeCs
{
    public class Camera
    {
        public Camera2D camera;
        private int speed;
        public Entity target;
        public bool followTarget;


        public Camera(Entity target, int speed, float zoom, bool followTarget)
        {
            camera = new Camera2D();
            camera.zoom = zoom;
            this.speed = speed;
            this.followTarget = followTarget;
            this.target = target;
        }

        public void update()
        {
            
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
            {
                followTarget = !followTarget;
            }
            
            if (followTarget)
            {
                camera.target.X = target.hitBox.x - Raylib.GetScreenWidth() / 2;
                camera.target.Y = target.hitBox.y - Raylib.GetScreenHeight() / 2;
            }
            else
            {
                float deltaTime = Raylib.GetFrameTime();

                if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
                {
                    camera.target.X -= speed * deltaTime;
                }
                if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
                {
                    camera.target.X += speed * deltaTime;
                }
                if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
                {
                    camera.target.Y -= speed * deltaTime;
                }
                if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
                {
                    camera.target.Y += speed * deltaTime;
                }
            }
        }
    }
}
