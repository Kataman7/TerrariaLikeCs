using Raylib_CsLo;

namespace TerrariaLikeCs
{
    public class Inventory
    {
        public Dictionary<Item, int> items;
        public int width;
        public int height;

        public Inventory(int width, int height)
        {
            items = new Dictionary<Item, int>();
            this.width = width;
            this.height = height;
        }

        public bool addItem(Item item, int quantity)
        {
            if (items.ContainsKey(item))
            {
                items[item] += quantity;
                return true;
            }
            else
            {
                if (items.Count < width * height)
                {
                    items.Add(item, quantity);
                    return true;
                }
            }
            return false;
        }

        public void removeItem(Item item, int quantity)
        {
            if (items.ContainsKey(item))
            {
                items[item] -= quantity;
                if (items[item] <= 0)
                {
                    items.Remove(item);
                }
            }
        }

        public void draw()
        {
            items.Order();
            int x = 0;
            int y = 0;
            int step = 20;
            foreach (var item in items)
            {
                Raylib.DrawText("" + item.Value, x*step, y*step, 20, Raylib.BLACK);
                x+=1;
                if (x > width)
                {
                    x = 0;
                    y += 1;
                }
            }
        }
    }
}
