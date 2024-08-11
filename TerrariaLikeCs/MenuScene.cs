using Raylib_CsLo;

namespace TerrariaLikeCs
{
    public class MenuScene : Scene
    {
        private Button bouton;
        private Cursor cursor;
        private Camera camera;

        public MenuScene()
        {
            camera = new Camera(bouton, 1, 1, false);
            cursor = new Cursor(10, camera);
            bouton = new Button(100, 100, "play a game", cursor);
            bouton.setFontSize(30);
            bouton.setWidth(300);
            bouton.setHeight(50);
            bouton.setPadding(10);
            bouton.setAction(() => {
                CurrentScene.setScene(new MainScene());
            });
        }

        public void update()
        {
            bouton.update();  
            cursor.update();
        }

        public void draw()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Raylib.RAYWHITE);

            bouton.draw();
            cursor.draw();
            Raylib.EndMode2D();
            Raylib.EndDrawing();
        }

    }
}
