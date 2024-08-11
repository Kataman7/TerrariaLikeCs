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

        public int countNeighbor(T neighbor, int x, int y)
        {
            int count = 0;

            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    if (!(i == 0 && j == 0))
                    {
                        int neighborX = x + i;
                        int neighborY = y + j;

                        if (getCell(neighborX, neighborY).Equals(neighbor))
                        {
                            count++;
                        }
                    }
                }
            }

            return count;
        }

        public GridInt createNeighborsGrid(GridEntity<T> grid, T neighbor)
        {
            GridInt neighborsGrid = new GridInt(grid.width, grid.height, grid.blockSize);

            for (int i = 0; i < grid.height; i++)
            {
                for (int j = 0; j < grid.width; j++)
                {
                    neighborsGrid.setCell(j, i, grid.countNeighbor(neighbor, j, i));
                }
            }

            return neighborsGrid;
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

        public void drawInfiniteMode(Camera2D camera)
        {
            int halfScreenW = Raylib.GetScreenWidth() / 2;
            int halfScreenH = Raylib.GetScreenHeight() / 2;

            int width = halfScreenW / blockSize + 2;
            int height = halfScreenH / blockSize + 2;

            float blockX = (camera.target.X + halfScreenW) / blockSize;
            float blockY = (camera.target.Y + halfScreenH) / blockSize;

            for (int i = (int)blockY - height; i < blockY + height; ++i)
            {
                for (int j = (int)blockX - width; j < blockX + width; ++j)
                {
                    T cell = getCell(j, i);
                    if (cell != null)
                    {
                        cell.draw();
                    }
                }
            }
        }

    }
}
