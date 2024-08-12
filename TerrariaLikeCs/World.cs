using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrariaLikeCs
{
    public class World
    {
        public GridInt grid;
        public List<DynamicEntity> entities;

        public World(int width, int height, int blockSize)
        {
            this.grid = new GridInt(width, height, blockSize);
            entities = new List<DynamicEntity>();
        }

        public World(GridInt grid)
        {
            this.grid = grid;
            entities = new List<DynamicEntity>();
        }

        public void create()
        {
            landGeneration();
            caveGeneration();
        }

        public void draw(Camera camera)
        {
            grid.drawInfiniteMode(camera.camera);
            for (int i = 0; i < entities.Count; i++)
            {
                if (entities[i].alive)
                {
                    entities[i].draw();
                }
                else
                {
                    entities.Remove(entities[i]);
                    i--;
                }
            }
        }

        public void update()
        {
            foreach (var entity in entities)
            {
                entity.update();
            }
        }

        private void landGeneration()
        {
            int[] altitude = Generator.altitudeGeneration(grid.width, 5, 0.16f, 100);

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
                        Generator.randomCellGeneration(grid, i, j, 0.5f, Blocks.STONE.id, 0, -1);
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
