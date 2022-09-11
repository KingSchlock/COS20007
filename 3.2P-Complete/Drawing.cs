using System.Collections.Generic;
using SplashKitSDK;

namespace ShapeDrawer
{
    class Drawing
    {
        private readonly List<Shape> _shapes;
        private Color _background;

        public Drawing(Color background) //! Constructor
        {
            _background = background;
            _shapes = new List<Shape>();
        }

        public Drawing() : this(Color.White) //This is used to refer to this specific object. This is also our default object as there's no parameters
        {

        }

        public Color Background
        {
            get { return _background; }
            set { _background = value; }
        }

        public int ShapeCount
        {
            get { return _shapes.Count; }
        }

        public List<Shape> SelectedShapes
        {
            get 
            {
                List<Shape> selectedShapes = new List<Shape>();

                foreach(Shape shape in _shapes)
                {
                    if (shape.Selected == true)
                    {
                        selectedShapes.Add(shape);
                    }
                }

                return selectedShapes; 
            }
        }

        public void AddShape(Shape shape)
        {
            _shapes.Add(shape);
        }

        public void Draw()
        {
            SplashKit.ClearScreen(Background);

            foreach(Shape shape in _shapes)
            {
                shape.Draw();
            }
        }

        //! Selects shapes the user clicks on
        public void SelectShapesAt(Point2D pt)
        {
            foreach(Shape shape in _shapes)
            {
                if(shape.Selected == false) //if shape isn't selected
                {
                    shape.Selected = shape.IsAt(pt); //we can select shape
                }
                else
                {
                    shape.Selected = !shape.IsAt(pt); //we can't select shape
                }
            }
        }

        public void RemoveShape(Shape shape)
        {
            _shapes.Remove(shape);
        }
    }
}
