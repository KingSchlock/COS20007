using SplashKitSDK;
using System.IO;

namespace _5._2C_Not_Complete
{
    public class MyCircle : Shape
    {
        //! Fields
        private int _radius;

        //! Constructor(s)
        public MyCircle()
        {

        }

        public MyCircle(Color color, float x, float y, bool selected, int radius) : base(color, x, y, selected)
        {
            this._radius = radius;
        }

        //! Properties
        public int Radius
        {
            get { return _radius; }
            set { _radius = value; }
        }

        //! Method(s)
        public override bool IsAt(Point2D mouseLocation)
        {
            Point2D origin = new()
            {
                //Had to set the points or they kept changing with the mouse location, real prick to figure out
                X = X,
                Y = Y
            };

            Circle circle = SplashKit.CircleAt(origin, _radius);
            return SplashKit.PointInCircle(mouseLocation, circle);
        }

        public override void DrawOutline()
        {
            SplashKit.DrawCircle(Color.Black, X, Y, (Radius + 2));
        }

        public override void Draw()
        {
            SplashKit.FillCircle(Color, X, Y, Radius);
            if (Selected)
            {
                DrawOutline();
            }
        }

        //! 5.2C Saving and Loading functionality
        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Circle");
            base.SaveTo(writer);
            writer.WriteLine(Radius);
        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            Radius = reader.ReadInteger();
        }
    }
}