using Raylib_CsLo;
using System.Numerics;

namespace TerrariaLikeCs
{
    public class Drop : DynamicEntity
    {
        public int quantity;
        public Block stuff;

        public Drop(int x, int y, Block stuff, World world) : base(x, y, 0.5f, 0.5f, 4, 500, world)
        {
            this.quantity = 1;
            this.stuff = stuff;
        }

        private void dropCollision(Drop dropA, Drop dropB)
        {
            dropA.alive = false;
            dropB.quantity += dropA.quantity;
            dropB.velY = -50;
        }

        public override void update()
        {
            base.update();
            Drop max = null;
            foreach (var entity in world.entities)
            {
                if (this == entity || !entity.alive) continue;
                if (entity is Drop drop)
                {
                    if (stuff == drop.stuff)
                    {
                        if (Raylib.CheckCollisionCircleRec(new Vector2(entity.hitBox.x + entity.hitBox.width / 2, entity.hitBox.y + entity.hitBox.height / 2), world.grid.blockSize * range, hitBox))
                        {
                            if (max == null || drop.quantity > max.quantity) max = drop;
                        }
                        if (Raylib.CheckCollisionRecs(hitBox, drop.hitBox))
                        {
                            if (quantity >= drop.quantity) dropCollision(drop, this);
                            else dropCollision(this, drop);
                        }
                    }
                }
                else if (entity is Player player)
                {
                    if (Raylib.CheckCollisionRecs(player.hitBox, hitBox))
                    {
                        if (player.inventory.addItem(new Item(this), quantity)) alive = false;
                    }
                }
            }
            if (max != null)
            {
                velX += (max.hitBox.x - hitBox.x) * 1000 * Raylib.GetFrameTime();
                velY += (max.hitBox.y - hitBox.y) * Raylib.GetFrameTime();
            }
        }

        public override void draw()
        {
            // Raylib.DrawCircle((int)hitBox.x, (int)hitBox.y, range * world.grid.blockSize, Raylib.BLUE);
            Rectangle sourceRec = new Rectangle(0, 0, stuff.texture.width, stuff.texture.height);
            Raylib.DrawTexturePro(stuff.texture, sourceRec, hitBox, new Vector2(0, 0), 0, Raylib.WHITE);
        }
    }
}
