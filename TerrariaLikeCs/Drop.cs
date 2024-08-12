using Raylib_CsLo;
using System.Numerics;

namespace TerrariaLikeCs
{
    public class Drop : DynamicEntity
    {
        public int quantity;
        public Block stuff;

        public Drop(int x, int y, Block stuff, World world) : base(x, y, 0.5f, 0.5f, 3, 1000, world)
        {
            this.quantity = 1;
            this.stuff = stuff;
        }

        public override void update()
        {
            base.update();
            foreach (var entity in world.entities)
            {
                if (this == entity || !entity.alive) continue;
                if (entity is Drop drop)
                {
                    if (stuff == drop.stuff)
                    {
                        if (Raylib.CheckCollisionCircleRec(new Vector2(entity.hitBox.x + entity.hitBox.width / 2, entity.hitBox.y + entity.hitBox.height / 2), world.grid.blockSize * range, hitBox))
                        {
                            if (quantity >= drop.quantity)
                            {
                                drop.alive = false;
                                quantity += drop.quantity;
                            }
                            else
                            {
                                alive = false;
                                drop.quantity += quantity;
                            }
                        }
                    }
                }
                else if (entity is Player player)
                {
                    if (Raylib.CheckCollisionRecs(player.hitBox, hitBox))
                    {
                        if (player.inventory.addItem(new Item(this), quantity))
                        {
                            alive = false;
                        }
                    }
                }
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
