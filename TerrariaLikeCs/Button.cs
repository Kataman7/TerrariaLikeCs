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
        private Font font = new Font();
        private int padding;

        private Action onClic = null;

        public Button(int x, int y, String text, Cursor cursor) : base(x, y, text.Length / 2, 2, 1, cursor)
        {
            this.text = text;
            this.hoveredColor = Raylib.DARKGRAY;
            this.fontColor = Raylib.WHITE;
            this.fontSize = 1;
            this.backgroundColor = Raylib.BLACK;
            this.padding = 0;
        }

        public void setAction(Action action)
        {
            this.onClic = action;
        }

        public void setFontSize(int size)
        {
            fontSize = size;
        }

        public void setBackgroundColor(Color color)
        {
            backgroundColor = color;
        }

        public void setHoveredBackgroundColor(Color color)
        {
            hoveredColor = color;
        }

        public void setFontColor(Color color)
        {
            fontColor = color;
        }

        public void setWidth(int width)
        {
            hitBox.width = width;
        }

        public void setHeight(int height)
        {
            hitBox.height = height;
        }

        public void setPadding(int padding)
        {
            this.padding=padding;
            this.hitBox.width += padding;
            this.hitBox.height += padding;
        }

        public override void draw()
        {
            base.draw();
            Raylib.DrawText(text, hitBox.x+padding, hitBox.y+padding, fontSize, fontColor);
        }

        override public void clicEvent()
        {
            onClic?.Invoke();
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
