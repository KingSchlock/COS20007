using SplashKitSDK;

namespace _4._2P
{
    public abstract class Shape
    {
        //! Field Declerations
        private Color _color;
        private float _x, _y;
        private bool _selected;

        //! Constructors
        public Shape()
            : this(Color.Red, false)
        {

        }

        public Shape(Color color, bool selected)
        {
            this._color = color;
            this._selected = selected;
        }

        public Shape(Color color, float x, float y, bool selected)
            : this(color, selected)
        {
            this._x = x;
            this._y = x;
        }


        //! Properties
        public Color Color
        {
            get { return this._color; }
            set {this._color = value; }
        }

        public float X
        {
            get { return this._x; }
            set { this._x = value; }
        }

        public float Y
        {
            get { return this._y; }
            set { this._y = value; } 
        }

        public bool Selected
        {
            get { return this._selected; }
            set { this._selected = value; }
        }

        //! Methods
        //? Takes a point and determines if said point lies within our shape
        public abstract bool IsAt(Point2D mouseLocation);

        //? Draws the outline of a rectangle
        public abstract void DrawOutline();

        //? Draws a Rectangle based on parameters and outlines the rectangle if the shape is selected
        public abstract void Draw();
    }
}
