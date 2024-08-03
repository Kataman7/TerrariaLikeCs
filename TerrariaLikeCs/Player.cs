using Raylib_CsLo;
using System.Runtime.CompilerServices;

namespace TerrariaLikeCs
{
    public class Player: DynamicEntity
    {
        private int jumpCount;
        private int jumpPower;
        private int jumpMax;
        private int speed;

        public Player(int x, int y, World world) : base(x, y, 0.98f, 1.98f, 10, 1000, world)
        {
            jumpCount = 0;
            jumpPower = 600;
            jumpMax = 3;
            speed = 300;
        }
        private void moove(int direction)
        {
            hitBox.x += speed * direction * Raylib.GetFrameTime();
        }
        private void jump()
        {
            if (jumpCount < jumpMax)
            {
                velY = -jumpPower;
                jumpCount++;
            }
        }
        private void control()
        {
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
            {
                jump();
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
            {
                moove(1);
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
            {
                moove(-1);
            }
        }
        override public void update()
        {
            float previousX = hitBox.x;
            float previousY = hitBox.y;

            velY += weight * Raylib.GetFrameTime();
            hitBox.y += velY * Raylib.GetFrameTime();

            if (checkStateCollision() == States.SOLID)
            {
                if (velY > 0)
                {
                    jumpCount = 0;
                }
                velY = 0;
                hitBox.y = previousY;
            }

            control();

            if (checkStateCollision() == States.SOLID)
            {
                hitBox.x = previousX;
            }

        }
    }
}
