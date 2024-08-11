using Raylib_CsLo;
using Raylib_CsLo.InternalHelpers;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace TerrariaLikeCs
{
    public static class Blocks
    {
        public static Block STONE = new Block(1, Raylib.LoadTexture("resources/textures/stone.png"), States.SOLID);
        public static Block DIRT = new Block(2, Raylib.LoadTexture("resources/textures/dirt.png"), States.SOLID);
        public static Block DIRT_GRASS = new Block(3, Raylib.LoadTexture("resources/textures/dirt_grass.png"), States.SOLID);
        public static Block CURSOR = new Block(4, Raylib.LoadTexture("resources/textures/cursor.png"), States.VOID);

        public static Block[] list = new Block[10];

        static Blocks()
        {
            list[STONE.id] = STONE;
            list[DIRT.id] = DIRT;
            list[DIRT_GRASS.id] = DIRT_GRASS;
            list[CURSOR.id] = CURSOR;
        }

        public static void unloadTexture()
        {
            foreach (var block in list)
            {
                if (block != null)
                {
                    Raylib.UnloadTexture(block.texture);
                }

            }
        }

    }

    public enum States
    {
        VOID, SOLID, LIQUID, STAIRS
    }


    public class Block
    {
        public int id { get; }
        public Texture texture { get; }
        public States state { get; }


        public Block(int id, Texture texture, States state)
        {
            this.id = id;
            this.texture = texture;
            this.state = state;
        }

        public void draw(int x, int y, int size)
        {
            Rectangle destRec = new Rectangle(x * size, y * size, size, size);
            Rectangle sourceRec = new Rectangle(0, 0, texture.width, texture.height);
            Vector2 origin = new Vector2(0, 0);
            Raylib.DrawTexturePro(texture, sourceRec, destRec, origin, 0, Raylib.WHITE);
        }

        public void destroy(int x, int y, World world, Camera camera)
        {
            world.grid.setCell(x, y, 0);
            world.entities.Add(new Drop((int)x*world.grid.blockSize + world.grid.blockSize / 4, (int)y*world.grid.blockSize + world.grid.blockSize / 4, this, world));
        }
    }
}
