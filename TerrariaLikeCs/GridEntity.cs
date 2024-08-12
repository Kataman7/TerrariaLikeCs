using Raylib_CsLo;

namespace TerrariaLikeCs
{
    public class GridEntity<T> : Grid<T> where T : Entity
    {
        public int width { get; }
        public int height { get; }
        public int blockSize { get; }
        private T[] list;


        public GridEntity(int width, int height, int blockSize)
        {
            this.width = width;
            this.height = height;
            this.blockSize = blockSize;
            list = new T[width * height];
        }

        public T getCell(int x, int y)
        {
            x = ((x % width) + width) % width;
            y = ((y % height) + height) % height;
            return list[y * width + x];
        }


        public void setCell(int x, int y, T value)
        {
            x = ((x % width) + width) % width;
            y = ((y % height) + height) % height;
            list[y * width + x] = value;
        }

        public void draw()
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    T cell = getCell(i, j);
                    if (cell != null)
                    {
                        cell.draw();
                    }
                }
            }
        }
    }
}
