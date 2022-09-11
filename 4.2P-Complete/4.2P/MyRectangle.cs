using SplashKitSDK;

namespace _4._2P
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
    }
}
