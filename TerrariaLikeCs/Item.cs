using Raylib_CsLo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrariaLikeCs
{
    public class Item
    {
        public Texture texture;
        public int id;

        public Item(Texture texture, int id)
        {
            this.texture = texture;
            this.id = id;
        }

        public Item(Block block) : this(block.texture, block.id) { }

        public Item(Drop drop) : this(drop.stuff.texture, drop.stuff.id) { }

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Item other = (Item)obj;
            return id == other.id;
        }

        public override int GetHashCode()
        {
            return id.GetHashCode();
        }

    }
}
