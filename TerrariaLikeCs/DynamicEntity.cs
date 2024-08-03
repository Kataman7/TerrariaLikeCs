using Raylib_CsLo;
using System.Numerics;

namespace TerrariaLikeCs
{
    public class DynamicEntity : Entity
    {
        protected float velY;
        protected int range;
        protected float weight;
        protected World world;

        public DynamicEntity(int x, int y, float width, float height, int range, float weight, World world) : base (x, y, width, height, world.grid.blockSize)
        {
            velY = 0;
            this.range = range;
            this.weight = weight;
            this.world = world;
        }

        override public void update()
        {
            float previousX = hitBox.x;
            float previousY = hitBox.y;

            velY += weight;
            hitBox.y += velY;

            if (checkStateCollision() == States.SOLID)
            {
                velY = 0;
                hitBox.y = previousY;
            }

            if (checkStateCollision() == States.SOLID)
            {
                hitBox.x = previousX;
            }
            
        }

        public States checkStateCollision()
        {
            float blockX = hitBox.x / world.grid.blockSize;
            float blockY = hitBox.y / world.grid.blockSize;

            for (int i = (int)blockY - 2; i < blockY + 2; ++i)
            {
                for (int j = (int)blockX - 2; j < blockX + 2; ++j)
                {
                    if (world.grid.getCell(j, i) != 0)
                    {
                        Rectangle blockHitBox = new Rectangle(j * world.grid.blockSize, i * world.grid.blockSize, world.grid.blockSize, world.grid.blockSize);
                        if (Raylib.CheckCollisionRecs(hitBox, blockHitBox))
                        {
                            return Blocks.list[world.grid.getCell(j, i)].state;
                        }
                    }
                }
            }

            return States.VOID;
        }

    }
}
