using SplashKitSDK;

namespace ShapeDrawer
{
    public class Program
    {
        public static void Main()
        {
            Window window = new Window("Shape Drawer: Thomas Horsley - 103071494", 800, 600);
            Shape myShape = new Shape(Color.Green, 0, 0, 100, 100);

            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();

                Point2D pt = SplashKit.MousePosition();

                // Set x to be mouseX and y to be MouseY if mouse clicked is true
                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    myShape.X = SplashKit.MouseX();
                    myShape.Y = SplashKit.MouseY();
                }

                if (myShape.IsAt(pt) && SplashKit.KeyTyped(KeyCode.SpaceKey))
                {
                    myShape.Color = Color.RandomRGB(255);
                }

                myShape.IsAt(pt); //for debugging, remove after

                myShape.Draw();

                SplashKit.RefreshScreen();
            } while (!window.CloseRequested);
        }
    }
}

/* Use SplashKit.MouseX to return x location, same for mouseY
 * 
 * 
 * 
 */