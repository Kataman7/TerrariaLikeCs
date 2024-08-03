using Raylib_CsLo;
using System.Numerics;

namespace TerrariaLikeCs
{
    public class Cursor: Entity
    {
        public Cursor() : base(0, 0, 4, 4, 3)
        {
            Raylib.HideCursor();
        }

        new public void update()
        {
            Vector2 pos = Raylib.GetMousePosition();
            hitBox.x = pos.X;
            hitBox.y = pos.Y;
        }

    }
}
