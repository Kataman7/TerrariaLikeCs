using System.Runtime.CompilerServices;
using TerrariaLikeCs;

namespace TerrariaLikeCs
{
    public interface Scene
    {
        public void draw();
        public void update();
    }
}

static class CurrentScene
{
    public static Scene scene = new BasicScene();

    public static void setScene(Scene newScene)
    {
        scene = newScene;
    }

}