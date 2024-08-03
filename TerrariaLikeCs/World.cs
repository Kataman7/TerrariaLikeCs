using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrariaLikeCs
{
    public class World
    {
        public Grid grid { get; }

        public World(int width, int height, int blockSize)
        {
            this.grid = new Grid(width, height, blockSize);
        }

        public World(Grid grid)
        {
            this.grid = grid;
        }

        public void create()
        {
            landGeneration();
            caveGeneration();
        }

        private void landGeneration()
        {
            int[] altitude = Generator.altitudeGeneration(grid.width, 5, 0.16f, 50);

            for (int i = 0; i < grid.width; i++)
            {
                for (int j = 0; j < grid.height; j++)
                {
                    if (j == altitude[i])
                    {
                        grid.setCell(i, j, Blocks.DIRT_GRASS.id);

                    }
                    else if (j > altitude[i] && j < altitude[i] + 3)
                    {
                        grid.setCell(i, j, Blocks.DIRT.id);
                    }
                    else if (j >= altitude[i] + 3 && j < altitude[i] + 6)
                    {
                        grid.setCell(i, j, Blocks.STONE.id);
                    }
                    else if (j >= altitude[i] + 6)
                    {
                        Generator.randomCellGeneration(grid, i, j, 0.45f, Blocks.STONE.id, 0, -1);
                    }
                }
            }
        }

        private void caveGeneration()
        {
            for (int i = 0; i < 10; i++)
            {
                Generator.nextCaveGeneration(grid, Blocks.STONE.id, 0);
            }
        }
    }
}
