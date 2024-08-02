using Raylib_CsLo;
using System.Numerics;

namespace TerrariaLikeCs
{
    public class Entity
    {

        public Rectangle hitBox;
        protected float velY;
        protected int range;
        protected float weight;
        protected World world;


        public Entity(int x, int y, float width, float height, int range, float weight, World world)
        {
            hitBox = new Rectangle(x, y, width * world.grid.blockSize, height * world.grid.blockSize);
            velY = 0;
            this.range = range;
            this.weight = weight;
            this.weight = weight;
            this.world = world;
        }

        public void update()
        {
            float previousX = hitBox.x;
            float previousY = hitBox.y;

            velY += weight;
            hitBox.y += velY;

            if (checkStateCollision(world.grid) == States.SOLID)
            {
                velY = 0;
                hitBox.y = previousY;
            }

            if (checkStateCollision(world.grid) == States.SOLID)
            {
                hitBox.x = previousX;
            }
            
        }

        public States checkStateCollision(Grid grid)
        {
            float blockX = hitBox.x / grid.blockSize;
            float blockY = hitBox.y / grid.blockSize;

            for (int i = (int)blockY - 2; i < blockY + 2; ++i)
            {
                for (int j = (int)blockX - 2; j < blockX + 2; ++j)
                {
                    if (grid.getCell(j, i) != 0)
                    {
                        Rectangle blockHitBox = new Rectangle(j * grid.blockSize, i * grid.blockSize, grid.blockSize, grid.blockSize);
                        if (Raylib.CheckCollisionRecs(hitBox, blockHitBox))
                        {
                            return Blocks.list[grid.getCell(j, i)].state;
                        }
                    }
                }
            }

            return States.VOID;
        }

    }
}
