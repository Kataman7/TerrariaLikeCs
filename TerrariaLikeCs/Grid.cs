namespace TerrariaLikeCs
{
    public interface Grid<T>
    {
        public T getCell(int x, int y);
        public void setCell(int x, int y, T value);
        public void draw();
    }
}
