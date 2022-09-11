using SplashKitSDK;
using System;

namespace _4._2P
{
    public class Program
    {
        private enum ShapeKind
        {
            Rectangle,
            Circle,
            Line
        }

        public static void Main()
        {
            Window window = new("4.2P: Thomas Horsley - 103071494", 800, 600);
            Drawing drawing = new();

            ShapeKind kindToAdd = ShapeKind.Circle;

            do
            {
                SplashKit.ProcessEvents(); 
                SplashKit.ClearScreen();

                Point2D mouseLocation = SplashKit.MousePosition();

                //? Draws a shape at mouse position and adds it to a shapes array
                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    if (kindToAdd == ShapeKind.Rectangle)
                    {
                        Shape rectangleShape = new MyRectangle(Color.Green, 0, 0, false, 100, 100)
                        {
                            X = (float)mouseLocation.X,
                            Y = (float)mouseLocation.Y
                        };

                        drawing.AddShape(rectangleShape);
                    }
                    if (kindToAdd == ShapeKind.Circle)
                    {
                        Shape circleShape = new MyCircle(Color.Red, 0, 0, false, 50)
                        {
                            X = (float)mouseLocation.X,
                            Y = (float)mouseLocation.Y
                        };

                        drawing.AddShape(circleShape);
                    }
                    if(kindToAdd == ShapeKind.Line)
                    {
                        Shape lineShape = new MyLine(Color.GreenYellow, 0, 0, false, 50)
                        {
                            X = (float)mouseLocation.X,
                            Y = (float)mouseLocation.Y,
                        };

                        drawing.AddShape(lineShape);
                    }
                }

                //? Relates keystrokes to shape kinds
                if (SplashKit.KeyReleased(KeyCode.RKey))
                {
                    kindToAdd = ShapeKind.Rectangle;
                }
                else if (SplashKit.KeyReleased(KeyCode.CKey))
                {
                    kindToAdd = ShapeKind.Circle;
                }  
                else if (SplashKit.KeyReleased(KeyCode.LKey))
                {
                    kindToAdd = ShapeKind.Line;
                } //TODO <--- can i use cases instead?

                                    
                //? Checks if shape is selected
                if (SplashKit.MouseClicked(MouseButton.RightButton))
                {
                    drawing.SelectShapesAt(mouseLocation);
                }


                //? Changes background color when user presses space
                if (SplashKit.KeyReleased(KeyCode.SpaceKey))
                {
                    drawing.Background = SplashKit.RandomRGBColor(255);
                }

                if (SplashKit.KeyReleased(KeyCode.DeleteKey) || SplashKit.KeyReleased(KeyCode.BackspaceKey))
                {
                    foreach(Shape genericShape in drawing.SelectedShapes)
                    {
                        drawing.RemoveShape(genericShape);
                    }
                }

                drawing.Draw();
                SplashKit.RefreshScreen(60);
            } while (!window.CloseRequested);
        }
    }
}


