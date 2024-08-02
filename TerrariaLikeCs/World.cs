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
            altitudeGeneration();
            caveGeneration();
        }

        private void altitudeGeneration()
        {
            int[] altitude = Generator.altitudeGeneration(grid.width, 5, 0.3f, 10);

            for (int i = 0; i < grid.height; i++)
            {
                for (int j = 0; j < grid.width; j++)
                {
                    if (i == altitude[j])
                    {
                        grid.setCell(j, i, Blocks.DIRT_GRASS.id);
                    }
                    else if (i > altitude[j] && i < altitude[j] + 3)
                    {
                        grid.setCell(j, i, Blocks.DIRT.id);
                    }
                    else if (i >= altitude[j] + 3 && i < altitude[j] + 6)
                    {
                        grid.setCell(j, i, Blocks.STONE.id);
                    }
                    else if (i >= altitude[j] + 6)
                    {
                        Generator.randomCellGeneration(grid, j, i, 0.5f, Blocks.STONE.id, 0, -1);
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
