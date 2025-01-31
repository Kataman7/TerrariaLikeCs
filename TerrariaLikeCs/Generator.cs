﻿namespace TerrariaLikeCs
{
    public class ConwayRule
    {

        public int min;
        public int max;
        public int birth;

        public ConwayRule(int min, int max, int birth)
        {
            this.min = min;
            this.max = max;
            this.birth = birth;
        }

        public static ConwayRule conway = new ConwayRule(2, 3, 3);
    }


    public class Generator
    {

        public static Random random = new Random();

        public static void randomCellGeneration(GridInt grid, int x, int y, float chanceToLive, int livingValue, int deadValue, int conditionValue)
        {
            if (conditionValue == -1 || grid.getCell(x, y) == conditionValue)
            {
                if (random.NextDouble() < chanceToLive)
                {
                    grid.setCell(x, y, livingValue);
                }
                else
                {
                    grid.setCell(x, y, deadValue);
                }
            }
        }

        public static void randomGridGeneration(GridInt grid, float chanceToLive, int livingValue, int deadValue, int conditionValue)
        {

            for (int i = 0; i < grid.height; i++)
            {
                for (int j = 0; j < grid.width; j++)
                {
                    if (conditionValue == -1 || grid.getCell(j, i) == conditionValue)
                    {
                        randomCellGeneration(grid, j, i, chanceToLive, livingValue, deadValue, conditionValue);
                    }

                }
            }
        }

        public static void nextCaveGeneration(GridInt grid, int livingValue, int deadValue)
        {
            GridInt neighborsGrid = GridInt.createNeighborsGrid(grid, livingValue);

            for (int i = 0; i < grid.height; ++i)
            {
                for (int j = 0; j < grid.width; ++j)
                {
                    int neighbors = neighborsGrid.getCell(j, i);

                    if (neighbors < 4 && grid.getCell(j, i) == livingValue)
                    {
                        grid.setCell(j, i, deadValue);
                    }
                    else if (neighbors > 4 && grid.getCell(j, i) == deadValue)
                    {
                        grid.setCell(j, i, livingValue);
                    }
                }
            }
        }

        public static void nextConwayGeneration(GridInt grid, ConwayRule rule, int livingValue, int deadValue)
        {
            GridInt neighborsGrid = GridInt.createNeighborsGrid(grid, livingValue);

            for (int i = 0; i < grid.height; ++i)
            {
                for (int j = 0; j < grid.width; ++j)
                {
                    int neighbors = neighborsGrid.getCell(j, i);
                    int cell = grid.getCell(j, i);

                    if (cell == livingValue)
                    {
                        if (neighbors < rule.min || neighbors > rule.max)
                        {
                            grid.setCell(j, i, deadValue);
                        }
                    }
                    else if (neighbors == rule.birth && cell == deadValue)
                    {
                        grid.setCell(j, i, livingValue);
                    }
                }
            }
        }

        public static int[] altitudeGeneration(int width, int height, float drop, int bias)
        {
            int[] altitude = new int[width];

            double x = random.NextDouble();
            //double a = random.NextDouble();

            for (int i = 0; i < width; i++)
            {
                /*
                if (i % 5 == 0)
                {
                    a = a + 0.2 * new int[] { -1, 1 }[random.Next(0, 2)];
                }
                */

                altitude[i] = (int)((Math.Sin(x) /* *a */ * height) ) + bias;
                x += drop;
            }

            return altitude;
        }
    }
}
