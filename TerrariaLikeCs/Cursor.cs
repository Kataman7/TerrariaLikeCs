using Raylib_CsLo;
using System.Numerics;

namespace TerrariaLikeCs
{
    public class Cursor: Entity
    {
        private Block block;
        private int blockSize;
        private Camera camera;

        public Cursor(int blockSize, Camera camera) : base(0, 0, 1, 1, blockSize/6)
        {
            Raylib.HideCursor();
            block = Blocks.CURSOR;
            this.blockSize = blockSize;
            hitBoxColor = Raylib.WHITE;
            this.camera = camera;
        }

        public Vector2 getGridPos()
        {
            Vector2 vector = Raylib.GetScreenToWorld2D(Raylib.GetMousePosition(), camera.camera);
            return new Vector2(vector.X / blockSize, vector.Y / blockSize);
        }

        public override void draw()
        {
            base.draw();
            Vector2 pos = Raylib.GetMousePosition() / blockSize;
           // block.draw((int) pos.X, (int) pos.Y, blockSize);
        }

        override public void update()
        {
            Vector2 pos = Raylib.GetMousePosition();
            hitBox.x = pos.X;
            hitBox.y = pos.Y;
        }

    }
}
