using Raylib_CsLo;

namespace TerrariaLikeCs
{
    public class Entity
    {
        public Rectangle hitBox;
        public Color hitBoxColor { get; set; }

        public Entity(int x, int y, float width, float height, int size )
        {
            hitBox = new Rectangle(x, y, width * size, height *size);
            hitBoxColor = Raylib.GRAY;
        }
        public virtual void draw()
        {
            Raylib.DrawRectangleRec(hitBox, hitBoxColor);
        }

        public virtual void update()
        {
            // ne fait rien par défaut
        }
    }
}
