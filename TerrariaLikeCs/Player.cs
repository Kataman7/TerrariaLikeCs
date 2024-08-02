using Raylib_CsLo;
using System.Runtime.CompilerServices;

namespace TerrariaLikeCs
{
    public class Player: Entity
    {
        private int jumpCount;
        private int jumpPower;
        private int jumpMax;
        private int speed;

        public Player(int x, int y, World world) : base(x, y, 1, 2, 10, 0.1f, world)
        {
            jumpCount = 0;
            jumpPower = 6;
            jumpMax = 2;
            speed = 2;
        }

        private void moove(int direction)
        {
            hitBox.x += speed * direction;
        }

        private void jump()
        {
            if (jumpCount < jumpMax)
            {
                velY = -jumpPower;
                jumpCount++;
            }
        }

        public void control()
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

        public void update()
        {
            float previousX = hitBox.x;
            float previousY = hitBox.y;

            velY += weight;
            hitBox.y += velY;

            if (checkStateCollision(world.grid) == States.SOLID)
            {
                if (velY > 0)
                {
                    jumpCount = 0;
                }
                velY = 0;
                hitBox.y = previousY;
            }

            control();

            if (checkStateCollision(world.grid) == States.SOLID)
            {
                hitBox.x = previousX;
            }

        }
    }
}
