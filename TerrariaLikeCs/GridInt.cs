using Raylib_CsLo;

namespace TerrariaLikeCs
{
    public class GridInt: Grid<int>
    {
        public int width { get; }
        public int height { get; }
        public int blockSize { get; }
        private int[] list;


        public GridInt(int width, int height, int blockSize)
        {
            this.width = width;
            this.height = height;
            this.blockSize = blockSize;
            list = new int[width * height];
        }

        public GridInt(GridInt grid) : this(grid.width, grid.height, grid.blockSize)
        {
        }

        public int getCell(int x, int y)
        {
            x = ((x % width) + width) % width;
            y = ((y % height) + height) % height;
            return list[y * width + x];
        }

        public void setCell(int x, int y, int value)
        {
            x = ((x % width) + width) % width;
            y = ((y % height) + height) % height;
            list[y * width + x] = value;
        }

        public int countNeighbor(int neighbor, int x, int y)
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

                        if (getCell(neighborX, neighborY) == neighbor)
                        {
                            count++;
                        }
                    }
                }
            }

            return count;
        }

        public static GridInt createNeighborsGrid(GridInt grid, int neighbor)
        {
            GridInt neighborsGrid = new GridInt(grid);

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
                    if (getCell(j, i) != 0)
                    {
                        Blocks.list[getCell(j, i)].draw(j, i, blockSize);
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
                    if (getCell(j, i) != 0)
                    {
                        Blocks.list[getCell(j, i)].draw(j, i, blockSize);
                    }

                }
            }
        }

    }
}
