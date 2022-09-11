using SplashKitSDK;
using System;

namespace _4._2P
{
    public class MyLine : Shape
    {
        //! Fields
        private float _length;

        //! Constructors
        public MyLine()
            : this(Color.BlueViolet, 0, 0, false, 150)
        {

        }

        public MyLine(Color color, float x, float y, bool selected, float length) : base(color, x, y, selected)
        {
            this._length = length;
        }

        //! Properties
        public float Length
        {
            get { return _length; }
            set { _length = value; }
        }


        //! Methods
        public override bool IsAt(Point2D mouseLocation)
        {
            Point2D initialPoint = new()
            {
                X = X,
                Y = Y
            };

            Point2D finalPoint = new()
            {
                X = X + Length,
                Y = Y
            };

            Line line = SplashKit.LineFrom(initialPoint, finalPoint);
            return SplashKit.PointOnLine(mouseLocation, line);
        }

        public override void DrawOutline()
        {
            SplashKit.DrawCircle(Color.GhostWhite, X, Y, 2);
            SplashKit.DrawCircle(Color.GhostWhite, X + Length, Y, 2);
        }

        public override void Draw()
        {
            SplashKit.DrawLine(Color, X, Y, (X + Length), Y);

            if (Selected)
            {
                DrawOutline();
            }
        }
    }
}