using SplashKitSDK;

namespace ShapeDrawer
{
    public class Shape
    {
        private Color _color;
        private float _x;
        private float _y;
        private int _width;
        private int _height;

        public Shape(Color color, float x, float y, int width, int height)
        {
            _color = color;
            _x = x;
            _y = y;
            _width = width;
            _height = height;
        }

        public Color Color
        {
            get { return _color; }
            set { _color = value; }
        }

        public float X
        {
            get { return _x; }
            set { _x = value; }
        }

        public float Y
        {
            get { return _y; }
            set { _y = value; }
        }

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

        public void Draw()
        {
            SplashKit.FillRectangle(_color, _x, _y, _width, _height);
        }

        public bool IsAt(Point2D pt)
        {
            /* if point.X is within x and  x + width and point.Y is withiny and y + height
             * pt will be within the bounds of our rectangle
             */

            if (_x < pt.X && pt.X < (_x + _width) && _y < pt.Y && pt.Y < (_y+ _height))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}