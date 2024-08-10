using Raylib_CsLo;

namespace TerrariaLikeCs
{
    public class Gui : Entity
    {
        public Cursor cursor;

        public Gui(int x, int y, int width, int height, int size, Cursor cursor) : base(x, y, width, height, size)
        {
            this.cursor = cursor;
        }

        override public void update()
        {
            if (Raylib.CheckCollisionRecs(hitBox, cursor.hitBox))
            {
                hoverEvent();
                if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT))
                {
                    clicEvent();
                }
            }
            else
            {
                passifEvent();
            }
        }

        virtual public void clicEvent() { }

        virtual public void hoverEvent() { }

        virtual public void passifEvent() { }
    }
}
