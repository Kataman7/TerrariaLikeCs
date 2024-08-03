using Raylib_CsLo;
namespace TerrariaLikeCs
{
    public class Button: Gui
    { 
        private String text;
        private Color backgroundColor;
        private Color hoveredColor;
        private Color fontColor;
        private int fontSize;
        public Button(int x, int y, int size, String text, Cursor cursor, Color backgroundColor, Color hoveredColor, Color fontColor) : base(x, y, 5, 2, size, cursor)
        {
            this.text = text;
            this.hoveredColor = hoveredColor;
            this.fontColor = fontColor;
            this.fontSize = size;
            this.backgroundColor = backgroundColor;
        }

        public override void draw()
        {
            base.draw();
            Raylib.DrawText(text, hitBox.x, hitBox.y, fontSize, fontColor);
        }

        override public void clicEvent()
        {

        }

        override public void hoverEvent()
        {
            base.hitBoxColor = hoveredColor;
        }

        public override void passifEvent()
        {
            base.hitBoxColor = Raylib.BLACK;
        }
    }
}
