using SplashKitSDK;
using System;

namespace _5._2C_Not_Complete
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
            Window window = new("Does He Scare You? - 103071494", 800, 600);
            Drawing drawing = new();

            ShapeKind kindToAdd = ShapeKind.Circle;

            do
            {
                SplashKit.ProcessEvents(); 
                SplashKit.ClearScreen();

                Point2D mouseLocation = SplashKit.MousePosition();

                //! Mouse Functionality
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

                //! Keystroke Functionality
                //? Relates keys pressed to shape kind
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

                //? Saves the data in a text file if Keydown S and Loads on Keydown O
                if (SplashKit.KeyReleased(KeyCode.SKey))
                {
                    drawing.Save(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\TestSave.txt");
                }

                if (SplashKit.KeyReleased(KeyCode.OKey))
                {
                    try
                    {
                        drawing.Load(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\TestSave.txt");
                    }
                    catch (Exception loadException)
                    {
                        Console.Error.WriteLine("Error loading file {0}", loadException.Message);
                    }
                    
                }

                drawing.Draw();
                SplashKit.RefreshScreen(60);
            } while (!window.CloseRequested);
        }
    }
}


