using SplashKitSDK;
using System.IO;

namespace _5._2C_Not_Complete
{
    public class MyRectangle : Shape
    {
        //! Fields
        private int _width, _height;

        //! Constructor(s)
        public MyRectangle()
        {

        }
            
        public MyRectangle(Color color, float x, float y, bool selected, int width, int height) : base(color, x, y, selected)
        {
            _width = width;
            _height = height;
        }

        //! Properties
        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }


        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }

        //! Method(s)
        public override bool IsAt(Point2D mouseLocation)
        {
            if (X < mouseLocation.X && mouseLocation.X < (X + Width) && Y < mouseLocation.Y && mouseLocation.Y < (Y + Height))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public override void DrawOutline()
        {
            SplashKit.DrawRectangle(Color.Black, (X - 2), (Y - 2), (Width + 4), (Height + 4));
        }

        public override void Draw()
        {
            SplashKit.FillRectangle(Color, X, Y, Width, Height);

            if (Selected)
            {
                DrawOutline();
            }
        }

        //! 5.2C Saving and Loading functionality
        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Rectangle");
            base.SaveTo(writer);
            writer.WriteLine(Width);
            writer.WriteLine(Height);
        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            Width = reader.ReadInteger();
            Height = reader.ReadInteger();
        }
    }
}
